// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class LayerMaskInspector : EcsComponentInspectorTyped<LayerMask> {
        public override void OnGuiTyped (string label, ref LayerMask value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.LayerField (label, value);
        }
    }
}