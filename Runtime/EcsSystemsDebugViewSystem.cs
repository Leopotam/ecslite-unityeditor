// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Leopotam.EcsLite.UnityEditor {
    public sealed class EcsSystemsDebugSystem : IEcsPreInitSystem, IEcsPostDestroySystem {
        readonly string _systemsName;
        GameObject _go;

        public EcsSystemsDebugSystem (string systemsName = default) {
            _systemsName = systemsName;
        }

        public void PreInit (IEcsSystems systems) {
            var allSystems = systems.GetAllSystems ();
            var preInitList = new List<string> ();
            var initList = new List<string> ();
            var runList = new List<string> ();
            var postRunList = new List<string> ();
            var destroyList = new List<string> ();
            var postDestroyList = new List<string> ();
            foreach (var sys in allSystems) {
                var sysType = EditorExtensions.GetCleanGenericTypeName (sys.GetType ());
                if (sys is IEcsPreInitSystem) { preInitList.Add (sysType); }
                if (sys is IEcsInitSystem) { initList.Add (sysType); }
                if (sys is IEcsRunSystem) { runList.Add (sysType); }
                if (sys is IEcsPostRunSystem) { postRunList.Add (sysType); }
                if (sys is IEcsDestroySystem) { destroyList.Add (sysType); }
                if (sys is IEcsPostDestroySystem) { postDestroyList.Add (sysType); }
            }
            _go = new GameObject (_systemsName != null ? $"[ECS-SYSTEMS {_systemsName}]" : "[ECS-SYSTEMS]");
            Object.DontDestroyOnLoad (_go);
            _go.hideFlags = HideFlags.NotEditable;
            var view = _go.AddComponent<EcsSystemsDebugView> ();
            view.PreInitSystems = preInitList;
            view.InitSystems = initList;
            view.RunSystems = runList;
            view.PostRunSystems = postRunList;
            view.DestroySystems = destroyList;
            view.PostDestroySystems = postDestroyList;
        }

        public void PostDestroy (IEcsSystems systems) {
            if (Application.isPlaying) {
                Object.Destroy (_go);
            } else {
                Object.DestroyImmediate (_go);
            }
            _go = null;
        }
    }
}
