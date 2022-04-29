// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Color32Inspector : EcsComponentInspectorTyped<Color32> {
        public override void OnGuiTyped (string label, ref Color32 value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.ColorField (label, value);
        }
    }
}