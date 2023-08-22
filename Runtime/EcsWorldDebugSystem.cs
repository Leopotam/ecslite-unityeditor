// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Leopotam.EcsLite.UnityEditor {
    public sealed class EcsWorldDebugSystem : IEcsPreInitSystem, IEcsRunSystem, IEcsWorldEventListener {
        readonly string _worldName;
        readonly GameObject _rootGo;
        readonly Transform _entitiesRoot;
        readonly bool _bakeComponentsInName;
        readonly string _entityNameFormat;
        EcsWorld _world;
        EcsEntityDebugView[] _entities;
        Dictionary<int, byte> _dirtyEntities;
        Type[] _typesCache;

        public EcsWorldDebugSystem (string worldName = null, bool bakeComponentsInName = true, string entityNameFormat = "X8") {
            _bakeComponentsInName = bakeComponentsInName;
            _worldName = worldName;
            _entityNameFormat = entityNameFormat;
            _rootGo = new GameObject (_worldName != null ? $"[ECS-WORLD {_worldName}]" : "[ECS-WORLD]");
            Object.DontDestroyOnLoad (_rootGo);
            _rootGo.hideFlags = HideFlags.NotEditable;
            _entitiesRoot = new GameObject ("Entities").transform;
            _entitiesRoot.gameObject.hideFlags = HideFlags.NotEditable;
            _entitiesRoot.SetParent (_rootGo.transform, false);
        }

        public void PreInit (IEcsSystems systems) {
            _world = systems.GetWorld (_worldName);
            if (_world == null) { throw new Exception ("Cant find required world."); }
            _entities = new EcsEntityDebugView [_world.GetWorldSize ()];
            _dirtyEntities = new Dictionary<int, byte> (_entities.Length);
            _world.AddEventListener (this);
            var entities = Array.Empty<int> ();
            var entitiesCount = _world.GetAllEntities (ref entities);
            for (var i = 0; i < entitiesCount; i++) {
                OnEntityCreated (entities[i]);
            }
        }

        public void Run (IEcsSystems systems) {
            foreach (var pair in _dirtyEntities) {
                var entity = pair.Key;
                var entityName = entity.ToString (_entityNameFormat);
                if (_world.GetEntityGen (entity) > 0) {
                    var count = _world.GetComponentTypes (entity, ref _typesCache);
                    for (var i = 0; i < count; i++) {
                        entityName = $"{entityName}:{EditorExtensions.GetCleanGenericTypeName (_typesCache[i])}";
                    }
                }
                _entities[entity].name = entityName;
            }
            _dirtyEntities.Clear ();
        }

        public void OnEntityCreated (int entity) {
            if (!_entities[entity]) {
                var go = new GameObject ();
                go.transform.SetParent (_entitiesRoot, false);
                var entityObserver = go.AddComponent<EcsEntityDebugView> ();
                entityObserver.Entity = entity;
                entityObserver.World = _world;
                entityObserver.DebugSystem = this;
                _entities[entity] = entityObserver;
                if (_bakeComponentsInName) {
                    _dirtyEntities[entity] = 1;
                } else {
                    go.name = entity.ToString (_entityNameFormat);
                }
            }
            _entities[entity].gameObject.SetActive (true);
        }

        public void OnEntityDestroyed (int entity) {
            if (_entities[entity]) {
                _entities[entity].gameObject.SetActive (false);
            }
        }

        public void OnEntityChanged (int entity, short poolId, bool added) {
            if (_bakeComponentsInName) {
                _dirtyEntities[entity] = 1;
            }
        }

        public void OnFilterCreated (EcsFilter filter) { }

        public void OnWorldResized (int newSize) {
            Array.Resize (ref _entities, newSize);
        }

        public void OnWorldDestroyed (EcsWorld world) {
            _world.RemoveEventListener (this);
            Object.Destroy (_rootGo);
        }

        public EcsEntityDebugView GetEntityView (int entity) {
            return entity >= 0 && entity < _entities.Length ? _entities[entity] : null;
        }

        public GameObject GetGameObject () {
            return _rootGo;
        }
    }
}
