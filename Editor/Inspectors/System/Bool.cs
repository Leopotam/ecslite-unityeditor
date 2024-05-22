// ----------------------------------------------------------------------------
// The MIT-Red License
// Copyright (c) 2012-2024 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class BoolInspector : EcsComponentInspectorTyped<bool> {
        public override bool OnGuiTyped (string label, ref bool value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.Toggle (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}
