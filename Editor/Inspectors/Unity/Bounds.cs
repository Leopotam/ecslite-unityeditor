// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class BoundsInspector : EcsComponentInspectorTyped<Bounds> {
        public override void OnGuiTyped (string label, ref Bounds value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.BoundsField (label, value);
        }
    }
}