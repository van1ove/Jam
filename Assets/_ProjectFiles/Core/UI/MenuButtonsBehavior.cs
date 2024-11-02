using UnityEngine;
using UnityEngine.SceneManagement;

namespace _ProjectFiles.Core.UI
{
    public class MenuButtonsBehavior : MonoBehaviour
    {
        public void LoadGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        public void QuitGame() => Application.Quit();
    }
}
