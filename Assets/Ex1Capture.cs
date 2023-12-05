using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ex1Capture : MonoBehaviour
{
    private List<Collider2D> playersInZone = new List<Collider2D>();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            playersInZone.Add(other);
            p1move.p1movement.moveSpeed = 0;
            ExScript.moveSpeed = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (playersInZone.Contains(other))
        {
            playersInZone.Remove(other);
            p1move.p1movement.moveSpeed = 10f;
            ExScript.moveSpeed = 2.5f;
        }
    }
}
