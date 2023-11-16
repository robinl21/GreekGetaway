using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class p1 : MonoBehaviour
{
    public static p1 player1; // global static var: only one player1 at all times
    public int drunk = 0; 
    
    void Start() {
    // Start is called before the first frame update
    }
    void Awake()
    {
        player1 = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
