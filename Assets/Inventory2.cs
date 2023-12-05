using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Inventory2 : MonoBehaviour
{
    private const int SLOTS = 2;
    private List<IInventoryItem> mItems2 = new List<IInventoryItem>();

    public event EventHandler<IInventoryEventArgs> ItemAdded2; 

    public void AddItem2(IInventoryItem item){
        if (mItems2.Count < SLOTS){
            Collider2D collider = (item as MonoBehaviour)?.GetComponent<Collider2D>();
            Debug.Log("ISACTIVE");
            if (collider != null && collider.enabled){
                collider.enabled = false; 
                mItems2.Add(item);
                item.onPickUp();
                
                if (ItemAdded2 != null){
                    ItemAdded2(this, new IInventoryEventArgs(item));
                }
            }
        }
    }

}
