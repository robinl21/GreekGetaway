using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inBathroomTaskController : MonoBehaviour
{
    public static inBathroomTaskController inBTask;

    public bool initialStage = true;

    public bool DJStage = false;

    public bool allDone =false;

    void Awake() {
        inBTask = this;
    }
}
