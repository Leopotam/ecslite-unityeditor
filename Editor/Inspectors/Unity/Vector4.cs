// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class Vector4Inspector : EcsComponentInspectorTyped<Vector4> {
        public override void OnGuiTyped (string label, ref Vector4 value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.Vector4Field (label, value);
        }
    }
}