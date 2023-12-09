using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitTrigger : MonoBehaviour
{



    // Update is called once per frame
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON Active")]
    [SerializeField] private TextAsset inkJSON; 


    private List<Collider2D> playersInZone = new List<Collider2D>();

    private void Awake()
    {   
        visualCue.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ENDING IN");
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
            Debug.Log("ENDING DETECTED");
            visualCue.SetActive(true);

            if (playersInZone.Count == 2 && PhoneTaskController.phoneTask.allDone && JacketTaskController.jacketTask.allDone) {
                SceneManager.LoadScene("GameWin", LoadSceneMode.Single); // win!
            }

            foreach (var player in playersInZone)
            {   
                if (player.CompareTag("Player1")) {
                    if (InputManager.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying1) {


                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, true, null);

                        // get pizza


                    }
                }

                if (player.CompareTag("Player2")) {
                    if (InputManager1.GetInstance().GetInteractPressed() && !DialogueManager.GetInstance().dialogueIsPlaying2) {
                        Debug.Log("RUN PLAYER2");
                        DialogueManager.GetInstance().EnterDialogueMode(inkJSON, false, null); // player 2


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
