using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogueTriggerBrotherFloor2 : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Initiate")]
    [SerializeField] private TextAsset inkJSONInitiate; 

    [Header("Ink JSON Brother")]
    [SerializeField] private TextAsset inkJSONBrother;


    [Header("Ink JSON Finish")]
    [SerializeField] private TextAsset inkJSONFinish; 

    [Header("Guardian")]
    [SerializeField] private GameObject guardian; 

    private TextAsset curInkJSON;
    private List<Collider2D> playersInZone = new List<Collider2D>();

    private string questName;

    private void Awake()
    {
        questName = "Get to the second floor";
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
        BF2TaskController BF2Task = BF2TaskController.BF2Task;

 
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {
                        
                        Action callBackAction = null;
                        if (BF2Task.initialStage) {

                            // create button/quest if not already made: add to all 3!
                            if (!QuestScript.questScript.QuestSet.Contains(questName)) {
                                QuestScript.questScript.allQuests.Add(questName);
                                QuestScript.questScript.allStatus.Add("There's a brother stopping you! Find... Jeff?");
                                QuestScript.questScript.QuestSet.Add(questName);
                            }

                            // move to find a brother stage:
                            BF2Task.initialStage = false;
                            BF2Task.brotherStage = true;
                            curInkJSON = inkJSONInitiate; // "Sorry, do you know a brother?"
                        }

                        else if (BF2Task.brotherStage) {
                            if (p1move.p1movement.metJeff) {
                                // move to next stage:
                                BF2Task.initialStage = false;
                                BF2Task.finishStage = true;
                                curInkJSON = inkJSONFinish; // "Hey, I saw you talking to Jeff! Come up!"
                                callBackAction = DeactivateGuardian;

                                // finished! update status

                                QuestScript.questScript.UpdateStatus(questName, "Finished!");
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONBrother; // "Find a brother and I'll let you up. I think Jeff's on this floor."
                            }
                        }


                        // after this point: person deactivated!


                        Debug.Log("RUN PLAYER1");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, true, callBackAction);


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        
                        Action callBackAction = null;
                        if (BF2Task.initialStage) {

                            // create button/quest if not already made: add to all 3
                            if (!QuestScript.questScript.QuestSet.Contains(questName)) {
                                QuestScript.questScript.allQuests.Add(questName);
                                QuestScript.questScript.allStatus.Add("There's a brother stopping you! Find... Jeff?"); 
                                QuestScript.questScript.QuestSet.Add(questName); 
                            }

                            // move to find a brother stage:
                            BF2Task.initialStage = false;
                            BF2Task.brotherStage = true;
                            curInkJSON = inkJSONBrother; // "Sorry, do you know a brother?"


                        }

                        else if (BF2Task.brotherStage) {
                            if (p2move.p2movement.metJeff) {
                                // move to next stage:
                                BF2Task.initialStage = false;
                                BF2Task.finishStage = true;
                                curInkJSON = inkJSONFinish; // "Hey, I saw you talking to Jeff! Come up!"
                                callBackAction = DeactivateGuardian;

                                QuestScript.questScript.UpdateStatus(questName, "Finished!");
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONBrother; // "Sorry, do you know a brother?"
                            }
                        }


                        // after this point: person deactivated!

                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, false, callBackAction);

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

