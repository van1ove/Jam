using UnityEngine;

public class UserInput : MonoBehaviour
{
    private Vector2 _axes;
    public Vector2 Axes => _axes;
    
    private void Update()
    {
        _axes.x = Input.GetAxis("Horizontal");
        _axes.y = Input.GetAxis("Vertical");
    } 
}