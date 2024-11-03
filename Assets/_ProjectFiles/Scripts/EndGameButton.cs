using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButton : MonoBehaviour
{
    [SerializeField] private string sceneName;

    public void SwitchSceneButton()
    {
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
