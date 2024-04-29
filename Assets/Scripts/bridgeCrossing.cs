using UnityEngine;

public class bridgeCrossing : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Make sure the player has a tag "Player"
        {
            Debug.Log("Player is crossing the bridge!");
            // Add more actions here like playing sounds
        }
    }
}
