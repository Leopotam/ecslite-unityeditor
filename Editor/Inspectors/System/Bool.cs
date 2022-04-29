// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class BoolInspector : EcsComponentInspectorTyped<bool> {
        public override void OnGuiTyped (string label, ref bool value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.Toggle (label, value);
        }
    }
}