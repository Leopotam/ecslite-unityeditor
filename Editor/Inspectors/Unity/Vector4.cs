// ----------------------------------------------------------------------------
// The MIT-Red License
// Copyright (c) 2012-2024 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Vector4Inspector : EcsComponentInspectorTyped<Vector4> {
        public override bool OnGuiTyped (string label, ref Vector4 value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.Vector4Field (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}
