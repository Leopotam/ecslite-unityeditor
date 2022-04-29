// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Vector2IntInspector : EcsComponentInspectorTyped<Vector2Int> {
        public override void OnGuiTyped (string label, ref Vector2Int value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.Vector2IntField (label, value);
        }
    }
}