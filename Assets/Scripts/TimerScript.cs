using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float totalTime = 90.0f;
    private float originalTime;
    public TextMeshProUGUI timerVisual;

    // Start is called before the first frame update
    void Start()
    {
        timerVisual = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
        originalTime = totalTime;
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
        timerVisual.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (totalTime <= originalTime / 2)
        {
            timerVisual.color = Color.red;
        }
    }
}
