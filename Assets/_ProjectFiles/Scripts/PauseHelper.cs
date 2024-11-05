using UnityEngine;

public class PauseHelper : MonoBehaviour
{
    [SerializeField] private GameObject pauseCanvas;
    [SerializeField] private string pauseButton = "Escape";
    private bool isPaused;
    
    private void Start()
    {
        pauseCanvas.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetButtonDown(pauseButton) == true)
        {
            Debug.Log("button is down");
            isPaused = !isPaused;
            
            pauseCanvas.SetActive(isPaused);
            Debug.Log(isPaused);
            
            if (isPaused)
            {
                GameManager.onPause?.Invoke();
            }
            else
            {
                 GameManager.onContinueGame?.Invoke();
            }
        }
    }
}
