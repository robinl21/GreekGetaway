using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDoorCollider : MonoBehaviour
{
    public bool[] playerCompleted;

    void Start ()
    {
    }
    void Update ()
    {
        // If both players have crossed the door, enter a new scene
        if (playerCompleted[0] && playerCompleted[1])
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player1") {
            playerCompleted[0] = true;
            UIScripts.UI.leftBlackScreen.SetActive(true);
            p1move.p1movement.moveSpeed = 0; // dont let them move
            // p1move.p1movement.rb.velocity = Vector3.zero;
            StartCoroutine(DelayInActive(0.8f, UIScripts.UI.leftBlackScreen, p1move.p1movement, p2move.p2movement, true));
        }

        else if (other.tag == "Player2") {
            playerCompleted[1] = true;
            UIScripts.UI.rightBlackScreen.SetActive(true);
            p2move.p2movement.moveSpeed = 0; // dont let them move
            StartCoroutine(DelayInActive(0.8f, UIScripts.UI.rightBlackScreen, p1move.p1movement, p2move.p2movement, false));
        }
    }



    IEnumerator DelayInActive(float duration, GameObject screen, p1move p1, p2move p2, bool isP1) { 
        // weird workaround C# strong typing
        yield return new WaitForSeconds(duration);
        screen.SetActive(false);
        if (isP1) { //let p1 move again
            p1move.p1movement.moveSpeed = 10f;
        }
        else { // let p2 move again
            p2move.p2movement.moveSpeed = 10f;
        }
    }

}
