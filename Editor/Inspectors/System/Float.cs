// ----------------------------------------------------------------------------
// The MIT-Red License
// Copyright (c) 2012-2024 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class FloatInspector : EcsComponentInspectorTyped<float> {
        public override bool OnGuiTyped (string label, ref float value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.FloatField (label, value);
            if (System.Math.Abs (newValue - value) < float.Epsilon) { return false; }
            value = newValue;
            return true;
        }
    }
}
