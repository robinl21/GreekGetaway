using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogueTriggerBathroomGuardian : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Initiate")]
    [SerializeField] private TextAsset inkJSONInitiate; // "I really really need to pee but this line ISN'T MOVING!"

    [Header("Guardian")]
    [SerializeField] private GameObject guardian; 

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

    public void DeactivateGuardian() {
        this.guardian.SetActive(false);
    }

    private void Update()
    {   
        inBathroomTaskController inBTask = inBathroomTaskController.inBTask;

 
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {
                        
                        Action callBackAction = null;
                        // needs to pee
                        curInkJSON = inkJSONInitiate; // "I need to pee"




                        Debug.Log("RUN PLAYER1");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, true, callBackAction);


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        
                        Action callBackAction = null;
                        // needs to pee
                        curInkJSON = inkJSONInitiate; // "I need to pee"




                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, false, callBackAction);


                    }
                }

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

        else
        {
            visualCue.SetActive(false);
        }
    }
}

