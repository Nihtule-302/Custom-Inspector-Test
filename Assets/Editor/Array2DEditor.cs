using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Array2D))]
    public class Array2DEditor : UnityEditor.Editor
    {
        SerializedProperty _rows, _columns;
        SerializedProperty _array;

        
        private void OnEnable()
        {
            _array = serializedObject.FindProperty("array");
            _rows = serializedObject.FindProperty("rows");
            _columns = serializedObject.FindProperty("columns");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUILayout.PropertyField(_rows);
            EditorGUILayout.PropertyField(_columns);
            
            GeneralTools.AddSpaceBetweenSections(3);
            
            DrawArray();
            
            serializedObject.ApplyModifiedProperties();
        }

        void DrawArray()
        {
            
            for (int row = 0; row < _rows.intValue; row++)
            {
                EditorGUILayout.BeginHorizontal();
                for (int column = 0; column < _columns.intValue; column++)
                {
                    var element = _array.GetArrayElementAtIndex(row * _columns.intValue + column);
                    EditorGUILayout.PropertyField(element, GUIContent.none);
                }
                EditorGUILayout.EndHorizontal();
            }
            
        }
    }
}