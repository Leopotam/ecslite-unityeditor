// ----------------------------------------------------------------------------
// The Proprietary or MIT-Red License
// Copyright (c) 2012-2022 Leopotam <leopotam@yandex.ru>
// ----------------------------------------------------------------------------

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Leopotam.EcsLite.UnityEditor {
    [CustomEditor (typeof (EcsSystemsDebugView))]
    sealed class EcsSystemsDebugViewInspector : Editor {
        static bool _preInitOpened = true;
        static bool _initOpened = true;
        static bool _runOpened = true;
        static bool _postRunOpened = true;
        static bool _destroyOpened = true;
        static bool _postDestroyOpened = true;

        public override void OnInspectorGUI () {
            var view = (EcsSystemsDebugView) target;
            var savedState = GUI.enabled;
            GUI.enabled = true;
            RenderLabeledList ("PreInit systems", view.PreInitSystems, ref _preInitOpened);
            RenderLabeledList ("Init systems", view.InitSystems, ref _initOpened);
            RenderLabeledList ("Run systems", view.RunSystems, ref _runOpened);
            RenderLabeledList ("PostRun systems", view.PostRunSystems, ref _postRunOpened);
            RenderLabeledList ("Destroy systems", view.DestroySystems, ref _destroyOpened);
            RenderLabeledList ("PostDestroy systems", view.PostDestroySystems, ref _postDestroyOpened);
            GUI.enabled = savedState;
        }

        void RenderLabeledList (string label, List<string> list, ref bool opened) {
            if (list.Count > 0) {
                opened = EditorGUILayout.BeginFoldoutHeaderGroup (opened, label);
                if (opened) {
                    EditorGUI.indentLevel++;
                    foreach (var item in list) {
                        EditorGUILayout.LabelField (item);
                    }
                    EditorGUI.indentLevel--;
                }
                EditorGUILayout.EndFoldoutHeaderGroup ();
                EditorGUILayout.Space ();
            }
        }
    }
}
