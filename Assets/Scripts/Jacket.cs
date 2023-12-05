using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jacket : MonoBehaviour, IInventoryItem
{
    // Start is called before the first frame update
    public string Name {
        get{
            return "Jacket";
        }
    }

    // Update is called once per frame
    public Sprite _Image = null;
    public Sprite Image {
        get {
            return _Image; 
        }
    }

    public void onPickUp(){
        gameObject.SetActive(false);
    }
}
