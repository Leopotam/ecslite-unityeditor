// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class RectInspector : EcsComponentInspectorTyped<Rect> {
        public override void OnGuiTyped (string label, ref Rect value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.RectField (label, value);
        }
    }
}