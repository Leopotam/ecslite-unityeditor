// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class LayerMaskInspector : EcsComponentInspectorTyped<LayerMask> {
        public override bool OnGuiTyped (string label, ref LayerMask value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.LayerField (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}