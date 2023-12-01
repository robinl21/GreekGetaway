using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogeTriggerJacket : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Active")]
    [SerializeField] private TextAsset inkJSONActive; 

    [Header("Ink JSON Finish")]
    [SerializeField] private TextAsset inkJSONFinish; 

    private TextAsset curInkJSON;

    private List<Collider2D> playersInZone = new List<Collider2D>();

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            playersInZone.Add(other);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playersInZone.Contains(other))
        {
            playersInZone.Remove(other);
        }
    }

    private void Update()
    {
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {   
                //finished jacket task
                if (JacketTaskController.jacketTask.jacketDone) {
                    curInkJSON = inkJSONFinish;
                    //
                }
                else {
                    curInkJSON = inkJSONActive;
                }

                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {
                        Debug.Log("RUN PLAYER1");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, true);

                        // jacketDone true: dialogues now "finished" dialogues
                        JacketTaskController.jacketTask.jacketDone = true;
                        // TODO: JACKET DISAPPEAR
                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, false); // player 2

                        // jacketDone true: dialogues now "finished" dialogues
                        JacketTaskController.jacketTask.jacketDone = true;
                        // TODO: JACKET DISAPPEAR
                    }
                }
                
                // if (InputManager.GetInstance().GetInteractPressed() && player.CompareTag("Player1"))
                // {
                //     Debug.Log("Player 1 triggered");
                // }

                // if (InputManager1.GetInstance().GetInteractPressed() && player.CompareTag("Player2"))
                // {
                //     Debug.Log("Player 2 triggered");
                // }
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
