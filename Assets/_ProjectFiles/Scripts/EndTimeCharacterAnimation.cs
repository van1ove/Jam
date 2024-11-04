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
        _characterContainer = GetComponent<CharacterContainer>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
        GameManager.onTeleportPlayer += EndTime;
    }

    private void EndTime()
    {
        _rigidbody2d.transform.position = new Vector3(14f, -7f, 0);
        _characterMovement.Enabled = false;
        _rigidbody2d.velocity = Vector3.right;
        GameManager.onTeleportPlayer -= EndTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Exit")
        {
            Destroy(_characterMovement.transform.parent.gameObject);
            GameManager.CurrentInventory = _characterContainer._inventory;
            SceneManager.LoadScene("Dan");
            
        }
    }
}