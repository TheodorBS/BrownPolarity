using UnityEngine;

public class Lever : MonoBehaviour
{
    [SerializeField] private Door linkedDoor; // Assign this in the inspector
    private bool isActivated = false;
    private Transform leverTransform;

    private void Start()
    {
        leverTransform = transform;
        leverTransform.rotation = Quaternion.Euler(0, 0, 45); // Start at 45 degrees
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || (other.CompareTag("Player2"))) // Check if the player interacts
        {
            ToggleLever();
        }
    }

    private void ToggleLever()
    {
        isActivated = !isActivated; // Toggle state

        if (linkedDoor != null)
        {
            linkedDoor.SetDoorState(isActivated);
        }

        RotateLever();

        Debug.Log("Lever Toggled: " + isActivated);
    }

    private void RotateLever()
    {
        float targetAngle = isActivated ? -45f : 45f; // Move 90 degrees in total
        leverTransform.rotation = Quaternion.Euler(0, 0, targetAngle);
    }

    public void ResetLever()
    {
        isActivated = false; // Set it back to default (unpressed)
        RotateLever(); // Move lever back to its starting position
    }

}
