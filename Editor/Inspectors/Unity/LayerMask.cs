// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class LayerMaskInspector : EcsComponentInspectorTyped<LayerMask> {
        static string[] _layerNames;

        static string[] GetLayerNames () {
            if (_layerNames == null) {
                var size = 0;
                var names = new string[32];
                for (var i = 0; i < names.Length; i++) {
                    names[i] = LayerMask.LayerToName (i);
                    if (names[i].Length > 0) { size = i + 1; }
                }
                if (size != names.Length) { System.Array.Resize (ref names, size); }
                _layerNames = names;
            }
            return _layerNames;
        }

        public override bool OnGuiTyped (string label, ref LayerMask value, EcsEntityDebugView entityView) {
            var newValue = EditorGUILayout.MaskField (label, value, GetLayerNames ());
            if (newValue == value) { return false; }
            value = newValue;
            return true;
        }
    }
}
