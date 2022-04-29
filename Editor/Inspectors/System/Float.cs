// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class FloatInspector : EcsComponentInspectorTyped<float> {
        public override void OnGuiTyped (string label, ref float value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.FloatField (label, value);
        }
    }
}