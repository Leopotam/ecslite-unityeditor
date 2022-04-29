// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class DoubleInspector : EcsComponentInspectorTyped<double> {
        public override void OnGuiTyped (string label, ref double value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.DoubleField (label, value);
        }
    }
}