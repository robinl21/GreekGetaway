using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCollider : MonoBehaviour
{

    // door is set as trigger: other is the object that runs into it
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player1") {
            UIScripts.UI.leftBlackScreen.SetActive(true);
            other.transform.position = new Vector3(-37f, 0f, 0f);
            StartCoroutine(DelayInActive(0.8f, UIScripts.UI.leftBlackScreen));
        }

        else if (other.tag == "Player2") {
            UIScripts.UI.rightBlackScreen.SetActive(true);
            other.transform.position = new Vector3(-37f, 0f, 0f);
            StartCoroutine(DelayInActive(0.8f, UIScripts.UI.rightBlackScreen));
        }
    }



    IEnumerator DelayInActive(float duration, GameObject screen) {
        yield return new WaitForSeconds(duration);
        screen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
