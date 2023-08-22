// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class LongInspector : EcsComponentInspectorTyped<long> {
        public override bool OnGuiTyped (string label, ref long value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.LongField (label, value);
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}
