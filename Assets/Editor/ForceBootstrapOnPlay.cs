using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class ForceBootstrapOnPlay
{
    static ForceBootstrapOnPlay()
    {
        EditorApplication.playModeStateChanged += state =>
        {
            if (state == PlayModeStateChange.ExitingEditMode)
                EditorSceneManager.OpenScene("Assets/Scenes/Bootstrap.unity");
        };
    }
}
