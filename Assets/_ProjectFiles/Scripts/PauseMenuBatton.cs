using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBatton : MonoBehaviour
{
    public void ExitToMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }
    public void EscapeButton()
    {
        GameManager.onContinueGame?.Invoke();
    }
}
