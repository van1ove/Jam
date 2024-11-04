using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTimeCharacterAnimation : MonoBehaviour
{
    private UserInput _userInput;
    private CharacterMovement _characterMovement;
    private Rigidbody2D _rigidbody2d;
    void Start()
    {
        _userInput = GetComponent<UserInput>();
        _characterMovement = GetComponent<CharacterMovement>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        GameManager.onTeleportPlayer += EndTime;
    }

    private void EndTime()
    {
        _rigidbody2d.transform.position = new Vector3(14f, -7f, 0); // Тут захардкодил координаты, чтобы не прокидывать трансформ и потенциально не поломать персонажа.(можно переделать).
        _userInput.enabled = false;
        _characterMovement.enabled = false;
        _rigidbody2d.velocity = Vector3.right;
        GameManager.onTeleportPlayer -= EndTime;
    }
}
