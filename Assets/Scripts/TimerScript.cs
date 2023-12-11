using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float totalTime = 120.0f;
    private float originalTime;
    public TextMeshProUGUI timerVisual;

    private AudioSource audioSource;
    public AudioClip[] music;
    private bool[] hasMusicBeenPlayed = {false, false, false};
    // Start is called before the first frame update
    void Start()
    {
        timerVisual = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        originalTime = totalTime;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = music[0];
        audioSource.Play();
        hasMusicBeenPlayed[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (totalTime > 0.0f)
        {
            totalTime -= Time.deltaTime;
        }
        else
        {
            SceneManager.LoadScene("GameOver", LoadSceneMode.Single);
        }
        float minutes = Mathf.FloorToInt(totalTime / 60);  
        float seconds = Mathf.FloorToInt(totalTime % 60);
        if (totalTime <= originalTime - 45) {
            timerVisual.text = string.Format("DRUNK\n{0:00}:{1:00}", minutes, seconds);
            // activate the drunk timer and the music
            if (!hasMusicBeenPlayed[1])
            {
                audioSource.Stop();
                audioSource.clip = music[1];
                audioSource.Play();
                hasMusicBeenPlayed[1] = true;
            }
            if (totalTime < 13 && !hasMusicBeenPlayed[2])
            {
                audioSource.Stop();
                audioSource.clip = music[2];
                audioSource.Play();
                hasMusicBeenPlayed[2] = true;
            }
        }
        else timerVisual.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (totalTime <= originalTime / 2) timerVisual.color = Color.red;
    }
}
