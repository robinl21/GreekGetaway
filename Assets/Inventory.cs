using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 2;
    private List<IInventoryItem> mItems = new List<IInventoryItem>();

    public event EventHandler<IInventoryEventArgs> ItemAdded; 

    public void AddItem(IInventoryItem item){
        if (mItems.Count < SLOTS){
            Collider2D collider = (item as MonoBehaviour)?.GetComponent<Collider2D>();
            Debug.Log("ISACTIVE");
            if (collider != null && collider.enabled){
                collider.enabled = false; 
                mItems.Add(item);
                item.onPickUp();
                
                if (ItemAdded != null){
                    ItemAdded(this, new IInventoryEventArgs(item));
                }
            }
        }
    }

}
