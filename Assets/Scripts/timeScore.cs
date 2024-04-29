using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeScore : MonoBehaviour
{
    public TextMeshProUGUI timeText, coinsText, Victory;
    public int coins;
    private int totalCoins;
    private AudioSource audio;
    public AudioClip winSound;
    private float time;
    private bool played;
    private bool timerActive; // New variable to control the timer

    // Start is called before the first frame update
    void Start()
    {
        played = false;
        time = 0f;
        coins = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Coin").Length;
        timeText.text = "0.00s";
        coinsText.text = "0/" + totalCoins;
        Victory.gameObject.SetActive(false);
        audio = GetComponent<AudioSource>();
        timerActive = true; // Start the timer by default
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            time += Time.deltaTime;
            string seconds = (time % 60).ToString("0#.00");
            string minutes = Mathf.FloorToInt(time / 60).ToString("0#");
            timeText.text = minutes + ":" + seconds; // Changed ';' to ':' for standard time format
        }

        if (totalCoins == 0)
        {
            coinsText.text = "Coins Collected: ";
        }
        else
        {
            coinsText.text = "Coins Collected: " + coins.ToString() + '/' + totalCoins.ToString();
        }

        if (coins == totalCoins && !played)
        {
            Victory.gameObject.SetActive(true);
            gameObject.transform.Find("Particle System").gameObject.SetActive(true);
            audio.clip = winSound;
            audio.Play(0);
            played = true;
            timerActive = false; // Stop the timer
        }
    }
}
