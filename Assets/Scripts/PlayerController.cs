using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Speed of player movement
    public float jumpSpeed = 7.0f; // Speed of the jump
    private Transform playerTransform;
    private Rigidbody playerRB;
    private bool isGrounded; // Check if the player is grounded
    private AudioSource audio;
    private AudioClip ping;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize player's Transform and Rigidbody components
        playerTransform = transform;
        playerRB = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    // OnCollisionStay is called once per frame for every Collider/Rigidbody
    // that is touching the trigger.
    private void OnCollisionStay(Collision c)
    {
        if ( c.collider.tag == "Ground")
        {
            isGrounded = true;
            Debug.Log(c.GetContact(0));
        }
    }
        

    // OnCollisionExit is called when this Collider/Rigidbody has
    // stopped touching another rigidbody/Collider.
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            Debug.Log("Touch");
            GetComponent<timeScore> ().coins += 1;
            audio.clip = ping;
            audio.Play(0);
            GameObject.Destroy(other.gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Handle player movement
        playerTransform.Translate(Input.GetAxis("Vertical") * speed * Time.deltaTime * Vector3.forward);
        playerTransform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right);

        // Handle player rotation
        playerTransform.Rotate(new Vector3(0, Input.GetAxis("Mouse X"), 0));

        // Handle player jumping
        if (isGrounded && Input.GetAxis("Jump") > 0)
        {
            playerRB.velocity = Vector3.up * jumpSpeed;
            isGrounded = false; // Prevent multiple jumps
        }

        Debug.Log(isGrounded);
    }
}
