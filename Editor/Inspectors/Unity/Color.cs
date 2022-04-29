// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class ColorInspector : EcsComponentInspectorTyped<Color> {
        public override void OnGuiTyped (string label, ref Color value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.ColorField (label, value);
        }
    }
}