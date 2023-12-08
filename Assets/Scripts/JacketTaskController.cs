using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JacketTaskController : MonoBehaviour
{
    //keep track of flow chart of task
    // talk to dude -> jacket appears!
    public static JacketTaskController jacketTask;

    public bool jacketDone = false; // sets to finish dialogues + checks whether to activate  -> DialogueTriggerDude.cs, DialogueTriggerJacket.cs

    void Awake() {
        jacketTask = this;
    }

    // private void Update() {
    //     Debug.Log(Jacket.jacket.gameObject.activeSelf);
    // }
}
