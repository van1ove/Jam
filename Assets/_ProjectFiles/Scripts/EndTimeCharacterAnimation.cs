using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTimeCharacterAnimation : MonoBehaviour
{
    private UserInput _userInput;
    private CharacterMovement _characterMovement;
    private Rigidbody2D _rigidbody2d;
    private CharacterContainer _characterContainer;
    void Start()
    {
        _userInput = GetComponent<UserInput>();
        _characterMovement = GetComponent<CharacterMovement>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _characterContainer = GetComponent<CharacterContainer>();
        GameManager.onTeleportPlayer += EndTime;
    }

    private void EndTime()
    {
        _rigidbody2d.transform.position = new Vector3(15f, -7f, 0); // Тут захардкодил координаты, чтобы не прокидывать трансформ и потенциально не поломать персонажа.(можно переделать).
        _userInput.enabled = false;
        _characterMovement.enabled = false;
        _rigidbody2d.velocity = Vector3.right * 4f;
        GameManager.onTeleportPlayer -= EndTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.gameObject.tag == "Exit")
        {
            GameManager.CurrentInventory = _characterContainer._inventory;
            GameManager.onNextLvl?.Invoke();
           // SceneManager.LoadScene("Dan");
            Debug.Log("exit");
        }
    }

}
