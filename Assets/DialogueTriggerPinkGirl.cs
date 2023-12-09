using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DialogeTriggerPinkGirl : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Initiate")]
    [SerializeField] private TextAsset inkJSONInitiate; // Oops. I threw up and missed the toilet. Can you get me some paper towels?

    [Header("Ink JSON PaperTowel")]
    [SerializeField] private TextAsset inkJSONPaper; //Alright that'll do it. All that throwing up made me thirsty. Can you get me a drink?

    [Header("Ink JSON FinishDrink")]
    [SerializeField] private TextAsset inkJSONFinishDrink; // Here's my number. (ran upon completing previous. only ran once)

    [Header("Ink JSON Finish")]
    [SerializeField] private TextAsset inkJSONFinish; // Hit me up sometime

    public GameObject vomit;

    public GameObject number;

    private TextAsset curInkJSON;

    private List<Collider2D> playersInZone = new List<Collider2D>();

    public bool initialStage = true;

    public bool paperTowelStage = false;

    public bool drinkStage = false;

    public bool finishStage = false;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    public void Start() {
        this.initialStage = true;
        this.paperTowelStage = false;
        this.drinkStage = false;
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
                            this.initialStage = false;
                            this.paperTowelStage = true;
                            curInkJSON = inkJSONInitiate; // get me a paper towel?
                        }

                        else if (this.paperTowelStage) {
                            Debug.Log("HAS PAPER TOWEL?");
                            if (Inventory.inventory.HasItem("PaperTowel")) {
                                
                                this.paperTowelStage = false;
                                this.drinkStage = true;
                                curInkJSON = inkJSONPaper; // can you get me a drink?

                                //give jacket back + change sprite
                                // inactivate vomit
                                vomit.SetActive(false);
                                Inventory.inventory.DestroyItem("PaperTowel");
                            }
                            else {
                                Debug.Log("NO TOWEL");
                                curInkJSON = inkJSONInitiate; // get me a paper towel
                            }
                        }


                        else if (this.drinkStage) {
                            if (Inventory.inventory.HasItem("Drink")) {
                                this.drinkStage = false;
                                this.finishStage = true;
                                curInkJSON = inkJSONFinishDrink; // Here's my number

                                // activate number
                                // use up drink
                                number.SetActive(true);
                                Inventory.inventory.DestroyItem("Drink");
                            }
                            else {
                                curInkJSON = inkJSONPaper; // get me a paper towel
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
                            this.paperTowelStage = true;
                            curInkJSON = inkJSONInitiate; // get me a paper towel?
                        }

                        else if (this.paperTowelStage) {
                            if (Inventory2.inventory2.HasItem("PaperTowel")) {
                                this.paperTowelStage = false;
                                this.drinkStage = true;
                                curInkJSON = inkJSONPaper; // can you get me a drink?

                                //give jacket back + change sprite
                                // inactivate vomit
                                vomit.SetActive(false);
                                Inventory2.inventory2.DestroyItem("PaperTowel");
                            }
                            else {
                                curInkJSON = inkJSONInitiate; // get me a paper towel
                            }
                        }


                        else if (this.drinkStage) {
                            if (Inventory2.inventory2.HasItem("Drink")) {
                                this.drinkStage = false;
                                this.finishStage = true;
                                curInkJSON = inkJSONFinishDrink; // Here's my number

                                // activate number
                                // use up drink
                                number.SetActive(true);
                                Inventory2.inventory2.DestroyItem("Drink");
                            }
                            else {
                                curInkJSON = inkJSONPaper; // get me a paper towel
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
