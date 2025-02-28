using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Portal_Script : MonoBehaviour
{
    public Transform newPortalPos;
    public Vector2 offset = new Vector2(0.5f, 0);
    private static HashSet<string> teleportingPlayers = new HashSet<string>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        string playerName = other.gameObject.name;
        if (!teleportingPlayers.Contains(playerName))
            {
                StartCoroutine(Teleport(other.gameObject, playerName));
            }
    }

    private IEnumerator Teleport(GameObject player, string playerName)
    {
        teleportingPlayers.Add(playerName); 
        player.transform.position = (Vector2)newPortalPos.position + offset;
        yield return new WaitForSeconds(1f);
        teleportingPlayers.Remove(playerName);
    }
}
