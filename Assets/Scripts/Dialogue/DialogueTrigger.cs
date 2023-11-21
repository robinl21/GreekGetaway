using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON; 

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
                if (player.CompareTag("Player1")){
                    if (InputManager.GetInstance().GetInteractPressed()){
                        p1move movescript= player.GetComponent<p1move>();
                        movescript.canMove = false;
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true);
                    }
                    }

                else {
                    if (InputManager1.GetInstance().GetInteractPressed()){
                        p2move movescript = player.GetComponent<p2move>();
                        movescript.canMove = false;
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false);
                    }
                }
                
               
                
            }
        }
        else
        {
            visualCue.SetActive(false);
        }
    }
}
