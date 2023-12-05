using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BF2TaskController : MonoBehaviour
{
    public static BF2TaskController BF2Task;

    public bool initialStage = true;

    public bool brotherStage = false;

    public bool finishStage = false;

    public bool allDone =false;

    void Awake() {
        BF2Task = this;
    }
}
