// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class LongInspector : EcsComponentInspectorTyped<long> {
        public override void OnGuiTyped (string label, ref long value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.LongField (label, value);
        }
    }
}