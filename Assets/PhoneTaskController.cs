using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneTaskController : MonoBehaviour
{
    //keep track of flow chart of task
    // talk to dude -> jacket appears!
    public static PhoneTaskController phoneTask;
    // stages: initial stage => pizza stage => drink stage => phone stage => 

    public bool initialStage = true;
    public bool pizzaStage = false;
    public bool drinkStage = false;

    public bool phoneStage = false;

    public bool finishStage = false;

    public bool allDone = false;

    void Awake() {
        phoneTask = this;
    }

    // private void Update() {
    //     Debug.Log(Jacket.jacket.gameObject.activeSelf);
    // }
}