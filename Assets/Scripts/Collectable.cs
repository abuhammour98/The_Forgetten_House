using UnityEngine;

public class Collectible : MonoBehaviour
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
        if (other.gameObject.CompareTag("Player"))
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null && collectSound != null)
            {
                
                audioSource.PlayOneShot(collectSound);

               
            }

           
            gameObject.SetActive(false);
        }
    }
}
