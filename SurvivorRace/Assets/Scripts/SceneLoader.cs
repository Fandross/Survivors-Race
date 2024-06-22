using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    string sceneName = "CenaPrincipal";
    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
