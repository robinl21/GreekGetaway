using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadTheGame ()
    {
        SceneManager.LoadScene("PlayerScene", LoadSceneMode.Single);
        SceneManager.LoadScene("bathroom", LoadSceneMode.Additive);
        SceneManager.LoadScene("BrotherFloor2Task", LoadSceneMode.Additive);
        SceneManager.LoadScene("ExesScene", LoadSceneMode.Additive);
        SceneManager.LoadScene("Floor2", LoadSceneMode.Additive);
        SceneManager.LoadScene("GetJacketTask", LoadSceneMode.Additive);
        SceneManager.LoadScene("GetPhoneTask", LoadSceneMode.Additive);
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Additive);
        
    }
}
