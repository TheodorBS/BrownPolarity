using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator animator; // Optional: For animations
    [SerializeField] private Collider2D doorCollider; // To disable collision
    [SerializeField] private SpriteRenderer doorRenderer; // To control opacity

    [SerializeField] private float fadeOpacity = 0.2f; // Opacity when "open"

    private void Start()
    {
        if (doorRenderer == null)
            doorRenderer = GetComponent<SpriteRenderer>(); // Get renderer if not assigned
    }

    public void SetDoorState(bool isOpen)
    {
        if (animator != null)
        {
            animator.SetBool("IsOpen", isOpen); // Play animation if available
        }

        if (doorCollider != null)
        {
            doorCollider.enabled = !isOpen; // Disable collider when open
        }

        if (doorRenderer != null)
        {
            Color newColor = doorRenderer.color;
            newColor.a = isOpen ? fadeOpacity : 1f; // Reduce opacity when open
            doorRenderer.color = newColor;
        }

        Debug.Log("Door " + (isOpen ? "Fading Out" : "Fully Visible"));
    }

    public void ResetDoor()
    {
        SetDoorState(false); // Close the door (fully visible & collider enabled)
    }

}
