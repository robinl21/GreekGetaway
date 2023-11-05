using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{

    public Vector3 newPosition;

    // door is set as trigger: other is the object that runs into it
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(newPosition);
        if (other.tag == "Player1") {
            UIScripts.UI.leftBlackScreen.SetActive(true);
            other.transform.position = newPosition;
            p1move.p1movement.moveSpeed = 0; // dont let them move
            // p1move.p1movement.rb.velocity = Vector3.zero;
            StartCoroutine(DelayInActive(0.8f, UIScripts.UI.leftBlackScreen, p1move.p1movement, p2move.p2movement, true));
        }

        else if (other.tag == "Player2") {
            UIScripts.UI.rightBlackScreen.SetActive(true);
            other.transform.position = newPosition;
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

    // Update is called once per frame

}
