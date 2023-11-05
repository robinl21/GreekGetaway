using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dude : MonoBehaviour


{
    // When hit dude
    // talk to dude => get jacket
    public static Dude dude;

    private bool first = true;

    void Awake() {
        dude = this;
    }

    void Start() {
        this.gameObject.SetActive(true);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        //jacket not found yet
        if (JacketTaskController.jacketTask.allDone == false) {

            if (first & (other.tag == "Player1" | other.tag == "Player2")) { //first time talking to: activate NEXT STAGE: JACKET
                Jacket.jacket.gameObject.SetActive(true);
                this.first = false;
            }
            // dialogue: always said if not finished
            if (other.tag == "Player1") {
                Debug.Log("Hey player 1: Your jacket isn't here. There's someone on the other floor who took it I think");
            }


            else if (other.tag == "Player2") {
                if (other.tag == "Player2") {
                    Debug.Log("Hey player 2: Your jacket isn't here. There's someone on the other floor who took it I think");
                }   
            }

        }

        // jacket task all done
        else {
            // dialogue
            if (other.tag == "Player1") {
                Debug.Log("Hey you've found your jacket! Cute");
            }


            else if (other.tag == "Player2") {
                if (other.tag == "Player2") {
                    Debug.Log("Hey you've found your jacket! Cute");
                }   
            }
        }
    }


    private void OnTriggerExit2D(Collider2D other) {

    }

    // private void Update() {
    //     Debug.Log(gameObject.activeSelf);
    // }
}
