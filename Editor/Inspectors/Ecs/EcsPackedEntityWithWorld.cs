// ----------------------------------------------------------------------------
// The MIT-Red License
// Copyright (c) 2012-2024 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor.Inspectors {
    sealed class EcsPackedEntityWithWorldInspector : EcsComponentInspectorTyped<EcsPackedEntityWithWorld> {
        public override bool OnGuiTyped (string label, ref EcsPackedEntityWithWorld value, EcsEntityDebugView entityView) {
            EditorGUILayout.BeginHorizontal ();
            EditorGUILayout.PrefixLabel (label);
            if (value.Unpack (out var unpackedWorld, out var unpackedEntity)) {
                if (unpackedWorld == entityView.World) {
                    if (GUILayout.Button ("Ping entity")) {
                        EditorGUIUtility.PingObject (entityView.DebugSystem.GetEntityView (unpackedEntity));
                    }
                } else {
                    EditorGUILayout.SelectableLabel ("<External entity>", GUILayout.MaxHeight (EditorGUIUtility.singleLineHeight));
                }
            } else {
                if (value.EqualsTo (default)) {
                    EditorGUILayout.SelectableLabel ("<Empty entity>", GUILayout.MaxHeight (EditorGUIUtility.singleLineHeight));
                } else {
                    EditorGUILayout.SelectableLabel ("<Invalid entity>", GUILayout.MaxHeight (EditorGUIUtility.singleLineHeight));
                }
            }
            EditorGUILayout.EndHorizontal ();
            return false;
        }
    }
}
