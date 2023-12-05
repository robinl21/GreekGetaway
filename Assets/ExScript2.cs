using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExScript2 : MonoBehaviour
{
    [SerializeField] Transform[] Points;

    [SerializeField] public static float moveSpeed = 2.5f;

    private int pointsIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            if (pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
