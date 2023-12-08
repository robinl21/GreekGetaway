using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogeTriggerJacket : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Initiate")]
    [SerializeField] private TextAsset inkJSONInitiate; 

    [Header("Ink JSON Finish")]
    [SerializeField] private TextAsset inkJSONFinish; 

    private TextAsset curInkJSON;

    private List<Collider2D> playersInZone = new List<Collider2D>();

    public bool initialStage = true; // I'll give you jacket back if you give me her number

    public bool numberStage = false; // Sweet. Here's your jacket. 

    public bool finishStage = false; // Your jacket was ugly anyways

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    public void Start() {
        this.initialStage = true;
        this.numberStage = false;
        this.finishStage = false;
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


                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {
                        
                        Action callBackAction = null;

                        if (this.initialStage) {
                            Debug.Log("HERE");
                            this.initialStage = false;
                            this.numberStage = true;
                            curInkJSON = inkJSONInitiate;
                        }

                        else if (this.numberStage) {
                            if (Inventory.inventory.HasItem("Number")) {
                                this.numberStage = false;
                                this.finishStage = true;
                                curInkJSON = inkJSONFinish;

                                //give jacket back + change sprite
                                JacketTaskController.jacketTask.jacketDone = true;
                                Inventory.inventory.DestroyItem("Number");
                            }
                            else {
                                curInkJSON = inkJSONInitiate;
                            }
                        }

                        else if (this.finishStage) {
                            curInkJSON = inkJSONFinish;
                        }

                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, true, callBackAction);

                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        
                        Action callBackAction = null;

                        if (this.initialStage) {
                            this.initialStage = false;
                            this.numberStage = true;
                            curInkJSON = inkJSONInitiate;
                        }

                        else if (this.numberStage) {
                            if (Inventory2.inventory2.HasItem("Number")) {
                                this.numberStage = false;
                                this.finishStage = true;
                                curInkJSON = inkJSONFinish;
                                //give jacket back
                                JacketTaskController.jacketTask.jacketDone = true;
                                Inventory2.inventory2.DestroyItem("Number");
                            }
                            else {
                                curInkJSON = inkJSONInitiate;
                            }
                        }

                        else if (this.finishStage) {
                            curInkJSON = inkJSONFinish;
                        }
                        
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
