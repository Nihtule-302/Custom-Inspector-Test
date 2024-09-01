using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ObjectSpawner : EditorWindow
{
    #region Variables
    private GameObject _prefab;

    private bool _showColorList = false;
    private List<Color> _colors = new List<Color> { Color.white };
    private Color _newColor = Color.white;

    private int _objectCount = 1;
    private float _spawnRadius = 1.0f;
    #endregion

    [MenuItem("Tools/Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow<ObjectSpawner>("Object Spawner");
    }

    private void OnGUI()
    {
        GUILayout.Label("Object Spawner", EditorStyles.boldLabel);

        DrawPrefabSelection();
        DrawSpawnSettings();
        
        AddSpaceBetweenSections(2);
        
        DrawColorSection();

        AddSpaceBetweenSections(4);

        if (GUILayout.Button("Instantiate Objects", GUILayout.Height(25f)))
        {
            InstantiateObjects();
        }
    }

    private void DrawPrefabSelection()
    {
        _prefab = EditorGUILayout.ObjectField("Prefab", _prefab, typeof(GameObject), false) as GameObject;
    }

    private void DrawSpawnSettings()
    {
        _objectCount = Mathf.Max(1, EditorGUILayout.IntField("Number of Objects", _objectCount)); // Ensures a minimum of 1 object
        _spawnRadius = EditorGUILayout.Slider("Spawn Radius", _spawnRadius, 0.0f, 10.0f);
    }

    private void DrawColorSection()
    {
        GUILayout.Label("Color Settings", EditorStyles.boldLabel);
        DrawColorList();
        AddSpaceBetweenSections();
        DrawAddNewColor();
    }

    private void DrawColorList()
    {
        _showColorList = EditorGUILayout.BeginFoldoutHeaderGroup(_showColorList, "Color List");
        if (_showColorList)
        {
            for (int i = 0; i < _colors.Count; i++)
            {
                EditorGUILayout.BeginHorizontal();

                GUILayout.Label($"Color {i + 1}");
                _colors[i] = EditorGUILayout.ColorField(_colors[i]);

                if (GUILayout.Button("Remove", GUILayout.Width(80)))
                {
                    _colors.RemoveAt(i);
                }

                EditorGUILayout.EndHorizontal();
            }
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
    }

    private void DrawAddNewColor()
    {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("New Color");
        _newColor = EditorGUILayout.ColorField(_newColor);

        if (GUILayout.Button("Add Color", GUILayout.Width(80)))
        {
            if (!_colors.Contains(_newColor)) // Prevents duplicate colors
            {
                _colors.Add(_newColor);
            }
            else
            {
                Debug.LogWarning("This color is already in the list!");
            }
            _newColor = Color.white;
        }
        EditorGUILayout.EndHorizontal();
    }


    private void InstantiateObjects()
    {
        if (_prefab == null)
        {
            Debug.LogError("Prefab is not assigned.");
            return;
        }

        for (int i = 0; i < _objectCount; i++)
        {
            Vector3 objectPosition = Random.onUnitSphere * _spawnRadius;
            var gameObject = Instantiate(_prefab, objectPosition, Quaternion.identity);
            
            gameObject.GetComponentInChildren<MeshRenderer>().material.color = _colors[Random.Range(0, _colors.Count)];
        }
    }

    private static void AddSpaceBetweenSections(int spaceCount = 1)
    {
        for (int i = 0; i < spaceCount; i++)
        {
            EditorGUILayout.Space();
        }
    }
}
