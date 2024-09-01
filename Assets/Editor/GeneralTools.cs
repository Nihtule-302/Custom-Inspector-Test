using UnityEditor;

namespace Editor
{
    public abstract class GeneralTools
    {
        public static void AddSpaceBetweenSections(int spaceCount = 1)
        {
            for (int i = 0; i < spaceCount; i++)
            {
                EditorGUILayout.Space();
            }
        }
    }
}