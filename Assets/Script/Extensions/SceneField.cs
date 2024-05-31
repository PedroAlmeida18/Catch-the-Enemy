#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[System.Serializable]

public class SceneField 
{
    #if UNITY_EDITOR
    public SceneAsset _sceneAsset;
    #endif
    public string _sceneName;

    public string SceneName
    {
        get { return _sceneName; }
    }

    //make it work with existing Unity methods (LoadLevel/LoadScene)
    public static implicit operator string(SceneField sceneField)
    {
        return sceneField.SceneName;
    }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(SceneField))]
public class SceneFieldPropertyDrawer : PropertyDrawer
{
    private const string AssetPropertyName = "_sceneAsset";
    private const string NamePropertyName = "_sceneName";

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, GUIContent.none, property);

        SerializedProperty sceneAsset = property.FindPropertyRelative(AssetPropertyName);
        SerializedProperty sceneName = property.FindPropertyRelative(NamePropertyName);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        if (sceneAsset != null)
        {
            sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

            if (sceneAsset.objectReferenceValue != null)
                sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset).name;
        }

        EditorGUI.EndProperty();
    }
}
#endif
