using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public float totalTime = 90.0f;
    public TextMeshProUGUI timerVisual;

    // Start is called before the first frame update
    void Start()
    {
        timerVisual = GameObject.Find("Timer").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        totalTime -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(totalTime / 60);  
        float seconds = Mathf.FloorToInt(totalTime % 60);
        timerVisual.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (totalTime <= 60.0f)
        {
            timerVisual.color = Color.red;
        }
    }
}
