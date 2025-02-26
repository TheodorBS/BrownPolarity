using AGDDPlatformer;
using UnityEngine;

public class Spike : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || (other.CompareTag("Player2"))) // Check if the colliding object is the player
        {
            Debug.Log("collided");
            GameManager.instance.ResetLevel(); // Restart level on death
        }
    }
}
