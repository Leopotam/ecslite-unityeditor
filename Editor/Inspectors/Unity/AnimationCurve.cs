// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class AnimationCurveInspector : EcsComponentInspectorTyped<AnimationCurve> {
        public override void OnGuiTyped (string label, ref AnimationCurve value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.CurveField (label, value);
        }
    }
}