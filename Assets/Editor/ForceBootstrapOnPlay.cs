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
            {
                // Abre o bootstrap
                EditorSceneManager.OpenScene("Assets/Scenes/Bootstrap.unity");

                // Depois abre a cena de login
                EditorSceneManager.OpenScene("Assets/Scenes/Login.unity", OpenSceneMode.Additive);
            }
        };
    }
}
