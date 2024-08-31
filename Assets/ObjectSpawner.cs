using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class ObjectSpawner : EditorWindow
{
    #region Variables
    
    [SerializeField] private GameObject prefab;
    [SerializeField] private int objectCount;
    [SerializeField] private int objectName;
    
    [Range(0,10f)]
    [SerializeField] private float spawnRadius;
    
    #endregion
}

#if UNITY_EDITOR
[CustomEditor(typeof(ObjectSpawner))]
class ObjectSpawnerEditor : EditorWindow
{
    
}
#endif
