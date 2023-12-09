using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ex1Capture : MonoBehaviour
{
    private List<Collider2D> playersInZone = new List<Collider2D>();
    public static bool ex2captured = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            playersInZone.Add(other);
            p1move.p1movement.moveSpeed = 0;
            ExScript.moveSpeed = 0;
            Ex2Capture.ex1captured = true;

            if (ex2captured)
            {
                SceneManager.LoadScene("ExesGameOver", LoadSceneMode.Single);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playersInZone.Contains(other))
        {
            playersInZone.Remove(other);
            p1move.p1movement.moveSpeed = 10f;
            ExScript.moveSpeed = 2.5f;
            Ex2Capture.ex1captured = false;
        }
    }
}
