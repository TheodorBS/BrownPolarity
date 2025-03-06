using UnityEngine;
using System.Collections;

public class Lever : MonoBehaviour
{
    [SerializeField] private Door linkedDoor; // Assign this in the inspector
    public bool isActivated = false;
    private Transform leverTransform;
    private bool isOnCooldown = false;
    [SerializeField] private float cooldownTime = 1f; // Adjust cooldown duration

    private void Start()
    {
        leverTransform = transform;
        leverTransform.rotation = Quaternion.Euler(0, 0, 45); // Start at 45 degrees
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isOnCooldown && (other.CompareTag("Player1") || other.CompareTag("Player2")))
        {
            StartCoroutine(ToggleLeverWithCooldown());
        }
    }

    private IEnumerator ToggleLeverWithCooldown()
    {
        isOnCooldown = true;
        ToggleLever();
        yield return new WaitForSeconds(cooldownTime);
        isOnCooldown = false;
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
