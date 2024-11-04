using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHelper : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private string pauseButton = "Escape";
    private void Start()
    {
        GameManager.onContinueGame += continueGame;
        pauseCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown(pauseButton) == true)
        {
            if(pauseCanvas.activeInHierarchy == false)
            {
                pauseCanvas.SetActive(true);
            }
            else
            {
                pauseCanvas.SetActive(false);
            }
            GameManager.onPause?.Invoke();
        }
    }
    private void continueGame()
    {
        pauseCanvas.SetActive(false);
        GameManager.onPause?.Invoke();
    }
}
