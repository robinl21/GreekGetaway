using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jacket : MonoBehaviour
{
    // Start is called before the first frame update

    public static Jacket jacket;

    private bool first = true;

    void Awake() {
        jacket = this;
    }

    void Start() {
        this.gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other) {

        //jacket not found yet
        if (JacketTaskController.jacketTask.allDone == false) {

            if (first & (other.tag == "Player1" | other.tag == "Player2")) { //first time talking to: activate NEXT STAGE: JACKET
                this.first = false;
                Debug.Log("You beat this dirty THIEF up for taking your jacket. Spam the T Key.");
                StartCoroutine(DelayInActive(0.8f, this.gameObject));
                JacketTaskController.jacketTask.allDone = true;


            }

        // jacket task all done
        else {
            // dialogue
            if (other.tag == "Player1") {
                Debug.Log("Sorry for taking your jacket :(");
            }


            else if (other.tag == "Player2") {
                if (other.tag == "Player2") {
                    Debug.Log("Sorry for taking your jacket :(");
                }   
            }
            }
        }
    }

    IEnumerator DelayInActive(float duration, GameObject jacket) {
        yield return new WaitForSeconds(duration);
        jacket.SetActive(false);
    }

    private void OnTriggerExit2D(Collider2D other) {

    }
}
