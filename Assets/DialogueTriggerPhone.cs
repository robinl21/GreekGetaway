using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogeTriggerPhone : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Active")]
    [SerializeField] private TextAsset inkJSON; 

    [Header("Parent Object")]
    [SerializeField] private GameObject phone;


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

    public void DestroyPhone() {
        phone.SetActive(false);
    }

    private void Update() // upon pickup, set allDone to True for phone task!
    {   
        
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {   
                Action destroyCallback = DestroyPhone;
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {


                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true, destroyCallback);

                        PhoneTaskController.phoneTask.allDone = true; // just sets to complete

                        QuestScript.questScript.UpdateStatus("Find Your Phone!", "Finished!"); // update quest


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false, destroyCallback); // player 2

                    
                        PhoneTaskController.phoneTask.allDone = true; // just sets to complete
                        QuestScript.questScript.UpdateStatus("Find Your Phone!", "Finished!"); //update quest

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