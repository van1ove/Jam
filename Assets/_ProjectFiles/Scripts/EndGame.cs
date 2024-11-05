using System;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
    [SerializeField] CharacterContainer characterContainer;
    void Start()
    {
        Subscribe();
    }

    private void Subscribe()
    {
        GameManager.onTimeOver += EndTime;
        GameManager.onPlayerDied += PlayerDie;
        GameManager.onPlayerWin += PlayerWin;
    }

    private void UnSubscribe()
    {
        GameManager.onTimeOver -= EndTime;
        GameManager.onPlayerDied -= PlayerDie;
        GameManager.onPlayerWin -= PlayerWin;
    }

    private void EndTime()
    {
        UnSubscribe();
        LoseScreen.SetActive(true);
    }

    private void PlayerDie()
    {
        UnSubscribe();
        LoseScreen.SetActive(true);
    }
    private void PlayerWin()
    {
        UnSubscribe();
    }

    private void OnDestroy()
    {
        GameManager.onTimeOver = null;
        GameManager.onContinueGame = null;
        GameManager.onPause = null;
        GameManager.onPlayerWin = null;
        GameManager.onPlayerDied = null;
    }
}
