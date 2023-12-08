using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD2 : MonoBehaviour
{
    public Inventory2 Inventory2; 
    // Start is called before the first frame update
    void Start()
    {
        Inventory2.ItemAdded2 += InventoryScript_ItemAdded2;
        Inventory2.ItemDropped2 += InventoryScript_ItemDropped2;
    }

    // Update is called once per frame
    private void InventoryScript_ItemAdded2(object sender, IInventoryEventArgs e){
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

    private void InventoryScript_ItemDropped2(object sender, IInventoryEventArgs e) {
        Transform inventoryPanel = transform.Find("Inventory");
        int counter = 0;
        Transform slot = null;
        foreach(Transform slt in inventoryPanel) {
            if (counter == e.Index) {
                slot = slt;
                break;
            }
            counter += 1;
        }
        Debug.Log("index" + e);
        Debug.Log("Slot: Drop" + slot.name);
        Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
        Debug.Log("Image: Drop" + image.name);
        if (image.enabled) { // if something there, take out
            image.enabled = false;
            image.sprite = null;
        }
    }
}
