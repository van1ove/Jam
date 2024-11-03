using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;
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

}
