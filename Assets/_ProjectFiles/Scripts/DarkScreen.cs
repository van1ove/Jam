using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DarkScreen : MonoBehaviour
{
    [SerializeField] private Image _darkScreen;
    private Color _darkColor;
    private void Start()
    {
        GameManager.onNextLvl += Blackout;
    }

    private void Blackout()
    {
        GameManager.onNextLvl -= Blackout;
        //StartCoroutine(BlackoutCorutine());
    }

    IEnumerator BlackoutCorutine()
    {
        GameManager.onNextLvl -= Blackout;
        _darkColor = _darkScreen.color; 
        while (_darkScreen.color.a < 1)
        {
            _darkColor.a += 0.0005f * Time.deltaTime;
            _darkScreen.color = _darkColor;
        } 
        yield return null;
    }
}
