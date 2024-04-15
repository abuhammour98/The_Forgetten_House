using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timeScore : MonoBehaviour
{

    public TextMeshProUGUI timeText, coinsText, Victory;
    public int coins, totalCoins;
    private AudioSource audio;
    public AudioClip winSound;
    private float time;
    private bool played;
    
    // Start is called before the first frame update
    void Start()
    {
        played = false;
        time = 0f;
        coins = 0;
        totalCoins = GameObject.FindGameObjectsWithTag("Collectables").Length;
        timeText.text = "0.00s";
        coinsText.text = "0/0";
        audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        string seconds = (time % 60).ToString("0#.00");
        string minutes = Mathf.FloorToInt(time / 60).ToString("0#");
        timeText.text = minutes + ";" + seconds;
        if (totalCoins ==0)
        {
            coinsText.text = "Coins Collected: ";
        }
        else
        {
            coinsText.text = "Coins Collected: " + coins.ToString() + '/' + totalCoins.ToString();
        }

        if (coins == totalCoins && played == false)
        {
            Victory.gameObject.SetActive(true);
            gameObject.transform.Find("Particle System").gameObject.SetActive(true);
            audio.clip = winSound;
            audio.Play(0);
            played = true;
        }
    }
}
