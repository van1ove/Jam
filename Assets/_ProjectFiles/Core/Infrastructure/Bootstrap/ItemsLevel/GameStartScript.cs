using System.Collections;
using UnityEngine;

public class GameStartScript : MonoBehaviour
{
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private ShowLevelCameraScript showLevelScript;
    [SerializeField] private GlobalLightManager globalLightManager;
    [SerializeField] private Timer timer;
    [SerializeField] private UIInventory inventory;
    [SerializeField] private float startDelayTime;
    [SerializeField] private float transitionTime;

    public void StartGame()
    {
        showLevelScript.OnShowFinished += OnShowFinished;

        inventory.Interactable(true);
        characterMovement.Enabled = false;
        StartCoroutine(StartDelay());
    }

    public void EndGame()
    {
        characterMovement.Enabled = false;
    }

    private IEnumerator StartDelay()
    {
        yield return new WaitForSeconds(startDelayTime);
        OnStartDelayEnd();
    }

    public void OnStartDelayEnd()
    {
        globalLightManager.StartFade(transitionTime);
        showLevelScript.Show(transitionTime);
    }
    
    private void OnShowFinished()
    {
        characterMovement.Enabled = true;
        timer.gameObject.SetActive(true);
    }
}
