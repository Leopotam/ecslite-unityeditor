// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class GradientInspector : EcsComponentInspectorTyped<Gradient> {
        public override void OnGuiTyped (string label, ref Gradient value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.GradientField (label, value);
        }
    }
}