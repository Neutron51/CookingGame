using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangerController : MonoBehaviour
{
    public static void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public static void Restart()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
