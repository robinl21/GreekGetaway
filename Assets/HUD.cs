using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory; 
    // Start is called before the first frame update
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    // Update is called once per frame
    private void InventoryScript_ItemAdded(object sender, IInventoryEventArgs e){
        Transform inventoryPanel = transform.Find("Inventory");
        Debug.Log("Is now ewqew1");
        foreach(Transform slot in inventoryPanel){
            // Border ... Image
            Debug.Log("Slot: " + slot.name);
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
            Debug.Log("Slot: " + slot.GetChild(0).GetChild(0).name);
            if (!image.enabled){
                Debug.Log("Sprite Name: " + e.Item.Name);
                image.enabled = true; 
                Debug.Log("Sprite Name: " + e.Item.Image);
                image.sprite = e.Item.Image; 

                break;
            }
        }
    }
}
