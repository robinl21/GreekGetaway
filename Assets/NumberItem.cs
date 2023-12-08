using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberItem : MonoBehaviour, IInventoryItem
{
    public string Name {
        get {
            return "Number";
        }
    }

    public Sprite _Image = null;

    public Sprite Image {
        get {
            return _Image;
        }
    }

    public void onPickUp() {
        gameObject.SetActive(false);
    }

    public void onDrop() {
        gameObject.SetActive(true);
    }
}
