using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerPaperTowel : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Active")]
    [SerializeField] private TextAsset inkJSON; 

    [Header("Parent Object")]
    [SerializeField] private GameObject paperTowel; // header object

    private Inventory inventory1;
    private Inventory2 inventory2;

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

    // after speaking, add header item
    public void PickUpPaperTowelP1() {
        IInventoryItem item = paperTowel.GetComponent<IInventoryItem>();
        inventory1 = Inventory.inventory;
        inventory1.AddItem(item);
    }

    public void PickUpPaperTowelP2() {
        IInventoryItem item = paperTowel.GetComponent<IInventoryItem>();
        inventory2 = Inventory2.inventory2;
        inventory2.AddItem2(item);
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


                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true, PickUpPaperTowelP1);

                        // get pizza


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false, PickUpPaperTowelP2); // player 2


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
