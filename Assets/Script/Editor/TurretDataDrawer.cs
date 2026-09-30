using System;
using System.Linq;
using UnityEditor;

[CustomEditor(typeof(TurretData))]
public class TurretDataDrawer : Editor
{
    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        DrawPropertiesExcluding(serializedObject, nameof(TurretData.shapeSearcher));
        SerializeShapeSearcher();
        serializedObject.ApplyModifiedProperties();
    }

    void SerializeShapeSearcher()
    {
        var property = serializedObject.FindProperty(nameof(TurretData.shapeSearcher));
        var types = TypeCache.GetTypesDerivedFrom<ShapeSearcher>().Where(t => !t.IsAbstract).ToArray();
        var names = types.Select(t => t.Name).ToArray();

        int index = Array.IndexOf(types, property.managedReferenceValue?.GetType());
        int newIndex = EditorGUILayout.Popup("Shape Searcher", index, names);

        if (newIndex != index)
            property.managedReferenceValue = Activator.CreateInstance(types[newIndex]);
    }
}
