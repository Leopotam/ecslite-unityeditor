// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class QuaternionInspector : EcsComponentInspectorTyped<Quaternion> {
        public override void OnGuiTyped (string label, ref Quaternion value, EcsEntityDebugView entityView) {
            var eulerAngles = value.eulerAngles;
            value = Quaternion.Euler(EditorGUILayout.Vector3Field (label, eulerAngles));
        }
    }
}