using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateJacket : MonoBehaviour
{
    public static ActivateJacket jacketActivator;

    public bool isActive;

    public GameObject NPC;

    public GameObject Trigger;

    void Awake() {
        jacketActivator = this;
    }

    // Update is called once per frame
    void Update()
    {
        isActive = JacketTaskController.jacketTask.activateJacket;
        Debug.Log("ISACTIVE" + isActive);
        this.NPC.SetActive(isActive);
        this.Trigger.SetActive(isActive);

    }
}
