using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ex2Capture : MonoBehaviour
{
    private List<Collider2D> playersInZone = new List<Collider2D>();
    public static bool ex1captured = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player2"))
        {
            playersInZone.Add(other);
            p2move.p2movement.moveSpeed = 0;
            ExScript2.moveSpeed = 0;
            Ex1Capture.ex2captured = true;

            if (ex1captured)
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
            p2move.p2movement.moveSpeed = 10f;
            ExScript2.moveSpeed = 2.5f;
            Ex1Capture.ex2captured = false;
        }
    }
}
