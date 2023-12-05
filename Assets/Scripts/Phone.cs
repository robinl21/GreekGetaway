using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour, IInventoryItem
{
    public string Name {
        get{
            return "Phone";
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
