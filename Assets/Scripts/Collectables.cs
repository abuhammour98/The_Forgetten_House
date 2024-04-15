using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Collectables : MonoBehaviour
{
    public AudioClip collectSound;

    private void Awake()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.playOnAwake = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coin")  // Make sure this tag matches exactly
        {
            Debug.Log("Touch");
            GetComponent<timeScore>().coins += 1;  // Assuming TimeScore is a component attached to this or another GameObject

            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && collectSound != null)
            {
                audioSource.clip = collectSound;
                audioSource.Play();
            }

            GameObject.Destroy(other.gameObject);
        }
    }
}
