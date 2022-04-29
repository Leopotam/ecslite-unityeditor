// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class IntInspector : EcsComponentInspectorTyped<int> {
        public override void OnGuiTyped (string label, ref int value, EcsEntityDebugView entityView) {
            value = EditorGUILayout.IntField (label, value);
        }
    }
}