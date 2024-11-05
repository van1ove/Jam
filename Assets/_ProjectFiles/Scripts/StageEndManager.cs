using System;
using UnityEngine;

public class StageEndManager : MonoBehaviour
{
    [SerializeField] private GameObject cutscene;
    [SerializeField] private CharacterMovement characterMovement;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exit"))
        {
            characterMovement.Enabled = false;
            cutscene.SetActive(true);
        }
    }
}