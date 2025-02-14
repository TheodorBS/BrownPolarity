using System.Collections;
using UnityEngine;

public class Portal_Script : MonoBehaviour
{
    public Transform newPortalPos;
    public Vector2 offset = new Vector2(0.5f, 0);
    private static bool isTeleporting = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!isTeleporting && other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            StartCoroutine(Teleport(other));
        }
    }

    private IEnumerator Teleport(Collider2D player)
    {
        isTeleporting = true;
        player.transform.position = (Vector2)newPortalPos.position + offset;
        yield return new WaitForSeconds(0.5f);
        isTeleporting = false;
    }
}
