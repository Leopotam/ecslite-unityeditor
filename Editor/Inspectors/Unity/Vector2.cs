// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Vector2Inspector : EcsComponentInspectorTyped<Vector2> {
        public override void OnGuiTyped (string label, ref Vector2 value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.Vector2Field (label, value);
        }
    }
}