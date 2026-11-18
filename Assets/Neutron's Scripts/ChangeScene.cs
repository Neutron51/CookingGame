using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public void Play()
    {
        SceneChangerController.LoadScene(1);
    }

    public void Restart()
    {
        SceneChangerController.Restart();
    }

    public void SceneLoad(int sceneIndex)
    {
        SceneChangerController.LoadScene(sceneIndex);
    }

    public void Credit()
    {
        SceneChangerController.LoadScene(2);
    }

    public void BackSpace()
    {
        SceneChangerController.LoadScene(0);
    }
}
