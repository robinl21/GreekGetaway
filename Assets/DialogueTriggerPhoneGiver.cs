using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogueTriggerPhoneGiver : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Initiate")]
    [SerializeField] private TextAsset inkJSONInitiate; 

    [Header("Ink JSON Pizza")]
    [SerializeField] private TextAsset inkJSONPizza; 

    [Header("Ink JSON Drink")]
    [SerializeField] private TextAsset inkJSONDrink;  

    [Header("Ink JSON Finish")]
    [SerializeField] private TextAsset inkJSONFinish; 


    [Header("Phone Object")]
    [SerializeField] private GameObject phone;

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

    public void SetActivePhone() {
        Debug.Log("PHONE ACTIVATE");
        this.phone.SetActive(true);
    }

    private void Update()
    {   
        PhoneTaskController phoneTask = PhoneTaskController.phoneTask;

 
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {
                        
                        Action callBackAction = null;
                        if (phoneTask.initialStage) {
                            // move to next stage: get pizza
                            phoneTask.initialStage = false;
                            phoneTask.pizzaStage = true;
                            curInkJSON = inkJSONInitiate; // "get me a pizza"
                        }

                        else if (phoneTask.pizzaStage) {
                            if (Inventory.inventory.HasItem("Pizza")) {
                                // move to next stage:
                                phoneTask.pizzaStage = false;
                                phoneTask.drinkStage = true;
                                curInkJSON = inkJSONPizza; // "thanks for pizza. now get drink"

                                // need to destroy item
                                Inventory.inventory.DestroyItem("Pizza");
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONInitiate; // "get me a pizza"
                            }
                        }


                        else if (phoneTask.drinkStage) {
                            if (Inventory.inventory.HasItem("Drink")) {
                                // move to next stage:
                                phoneTask.drinkStage = false;
                                phoneTask.phoneStage = true;
                                curInkJSON = inkJSONDrink; // "drink was good. your phone is here": set phone to active! 
                                Debug.Log("ACTIVATE");

                                //destroy drink item
                                Inventory.inventory.DestroyItem("Drink");
                                callBackAction = SetActivePhone;
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONPizza; // "thanks for pizza: now get drink"
                            }
                        }


                        else if (phoneTask.phoneStage) {

                            if (phoneTask.allDone) { // someone got phone: set to allDone (not in inventory)
                                phoneTask.phoneStage = false;
                                phoneTask.finishStage = true;
                                curInkJSON = inkJSONFinish; // done!

                            }
                            else {
                                curInkJSON = inkJSONDrink; // "drink was good. your phone is here"
                            }
                        }


                        else if (phoneTask.finishStage) {
                            curInkJSON = inkJSONFinish;
                        }

                        Debug.Log("RUN PLAYER1");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, true, callBackAction);


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Action callbackAction = null;
                        if (phoneTask.initialStage) {
                            // move to next stage: get pizza
                            phoneTask.initialStage = false;
                            phoneTask.pizzaStage = true;
                            curInkJSON = inkJSONInitiate; // "get me a pizza"
                        }

                        else if (phoneTask.pizzaStage) {
                            if (Inventory2.inventory2.HasItem("Pizza")) {
                                // move to next stage:
                                phoneTask.pizzaStage = false;
                                phoneTask.drinkStage = true;
                                curInkJSON = inkJSONPizza; // "thanks for pizza. now get drink"

                                // need to destroy item pizza
                                Inventory2.inventory2.DestroyItem("Pizza");
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONInitiate; // "get me a pizza"
                            }
                        }


                        else if (phoneTask.drinkStage) {
                            if (Inventory2.inventory2.HasItem("Drink")) {
                                // move to next stage:
                                phoneTask.drinkStage = false;
                                phoneTask.phoneStage = true;
                                curInkJSON = inkJSONDrink; // "drink was good. your phone is here"
                                Debug.Log("ACTIVATE");

                                //destroy drink
                                Inventory2.inventory2.DestroyItem("Drink");

                                callbackAction = SetActivePhone; //activate phone!
                            }
                            else {
                                // stay in current stage:
                                curInkJSON = inkJSONPizza; // "thanks for pizza: now get drink"
                            }
                        }


                        else if (phoneTask.phoneStage) {

                            if (phoneTask.allDone) { // set by getting phone, phone found
                                phoneTask.phoneStage = false;
                                phoneTask.finishStage = true;
                                curInkJSON = inkJSONFinish; //FINISHED! mark as finished

                            }
                            else {
                                curInkJSON = inkJSONDrink; // "drink was good. your phone is here"
                            }
                        }


                        else if (phoneTask.finishStage) {
                            curInkJSON = inkJSONFinish;
                        }

                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(curInkJSON, false, callbackAction);


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
            }
        
        else
        {
            visualCue.SetActive(false);
        }
    }
}
