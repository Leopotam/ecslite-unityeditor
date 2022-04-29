// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class BoundsIntInspector : EcsComponentInspectorTyped<BoundsInt> {
        public override void OnGuiTyped (string label, ref BoundsInt value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.BoundsIntField (label, value);
        }
    }
}