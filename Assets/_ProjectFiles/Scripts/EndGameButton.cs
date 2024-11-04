using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private string sceneName1;
    [SerializeField] private string sceneName2;

    public void SwitchSceneButton1()
    {
        if (sceneName1 != null)
        {
            SceneManager.LoadScene(sceneName1);
        }
    }
    public void SwitchSceneButton2()
    {
        if (sceneName2 != null)
        {
            SceneManager.LoadScene(sceneName2);
        }
    }
}
