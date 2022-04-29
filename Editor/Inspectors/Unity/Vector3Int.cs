// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Vector3IntInspector : EcsComponentInspectorTyped<Vector3Int> {
        public override void OnGuiTyped (string label, ref Vector3Int value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.Vector3IntField (label, value);
        }
    }
}