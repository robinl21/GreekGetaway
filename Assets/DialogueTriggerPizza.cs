using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class DialogeTriggerPizza : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Active")]
    [SerializeField] private TextAsset inkJSON; 

    [Header("Parent Object")]
    [SerializeField] private GameObject pizza;


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

    public void DestroyPizza() {
        pizza.SetActive(false);
    }

    private void Update()
    {   
        
        if (playersInZone.Count > 0)
        {
            visualCue.SetActive(true);
            foreach (var player in playersInZone)
            {   
                Action destroyCallback = DestroyPizza;
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {


                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true, destroyCallback);

                        // get pizza
                        p1move.p1movement.hasPizza = true;


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false, destroyCallback); // player 2

                        
                        // get pizza
                        p2move.p2movement.hasPizza = true;

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
