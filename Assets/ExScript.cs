using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExScript : MonoBehaviour
{
    [SerializeField] Transform[] Points;

    [SerializeField] public static float moveSpeed = 3.55f;

    private int pointsIndex = 0;
    private float prevX = 0;
    private float prevY = 0;

    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite upSprite;
    public Sprite downSprite;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = Points[pointsIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(pointsIndex <= Points.Length - 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, Points[pointsIndex].transform.position, moveSpeed * Time.deltaTime);
            //change sprite direction
            if (prevY < transform.position[1])
            {
                transform.Find("NPC").gameObject.GetComponent<SpriteRenderer>().sprite = upSprite;
            }
            else if (prevY > transform.position[1])
            {
                transform.Find("NPC").gameObject.GetComponent<SpriteRenderer>().sprite = downSprite;
            }
            else if (prevX < transform.position[0])
            {
                transform.Find("NPC").gameObject.GetComponent<SpriteRenderer>().sprite = rightSprite;
            }
            else if (prevX > transform.position[0])
            {
                transform.Find("NPC").gameObject.GetComponent<SpriteRenderer>().sprite = leftSprite;
            }

            prevX = transform.position[0];
            prevY = transform.position[1];

            if (transform.position == Points[pointsIndex].transform.position)
            {
                pointsIndex += 1;
            }

            if(pointsIndex == Points.Length)
            {
                pointsIndex = 0;
            }
        }
    }
}
