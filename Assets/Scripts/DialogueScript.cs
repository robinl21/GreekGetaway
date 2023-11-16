using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueScript : MonoBehaviour
{
    // Start is called before the first frame update
    public static DialogueScript dialogueFuncs;


    public GameObject leftDialoguePanel;
    public GameObject rightDialoguePanel;

    public GameObject leftText;
    public GameObject rightText;

    void Awake()
    {
        dialogueFuncs = this;
    }

    public void leftDialogueActivate(string dialogue) {
        StartCoroutine(DelayFunc(1f, true));
    }

    IEnumerator DelayFunc(float duration, bool isLeft) {
        leftDialoguePanel.SetActive(false);
        yield return new WaitForSeconds(duration);
        leftDialoguePanel.SetActive(true);
    }
}
