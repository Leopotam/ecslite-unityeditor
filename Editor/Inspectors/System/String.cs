// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class StringInspector : EcsComponentInspectorTyped<string> {
        public override bool IsNullAllowed () {
            return true;
        }

        public override void OnGuiTyped (string label, ref string value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.TextField (label, value);
        }
    }
}