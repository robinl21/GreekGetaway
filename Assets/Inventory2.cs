using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Inventory2 : MonoBehaviour
{

    public static Inventory2 inventory2;

    private void Awake()
    {
        inventory2 = this;
    }
    private const int SLOTS = 2;

    private int numItems = 0;

    public List<IInventoryItem> mItems2 = new List<IInventoryItem>();

    public event EventHandler<IInventoryEventArgs> ItemAdded2; 

    public event EventHandler<IInventoryEventArgs> ItemDropped2;

    public void Start() {
        mItems2.Add(null);
        mItems2.Add(null);
    }

    public bool HasItem(string name) {
        foreach(IInventoryItem item in mItems2) {
            if (item == null) {
                continue;
            }
            else {
                if (item.Name == name) {
                    return true;
                }
            }
        }
        return false;
    }

    public void DestroyItem(string name) {
        int counter = 0;
        foreach(IInventoryItem item in mItems2) {
            if (item == null) {
                // do nothing
            }
            else {
                if (item.Name == name) {
                    //destroy: don't drop
                    numItems -= 1; // set num of Items
                    mItems2[counter] = null; //set mItems at this index

                    item.onPickUp(); //sets it to inactive 
                    // (item now inactive, not in mitems - destroyed)

                    ItemDropped2(this, new IInventoryEventArgs(item, counter)); //remove from HUD at this index
                    
                    break; // finish

                }   
            }

            counter += 1;
        }

    }
    public void AddItem2(IInventoryItem item){
        if (numItems < SLOTS){
            Debug.Log("Entered AddItem");
            //Collider2D collider = (item as MonoBehaviour)?.GetComponent<Collider2D>();
            numItems += 1;

            int counter = 0;
            foreach(IInventoryItem mItem in mItems2) { //find slot to add at: put in first open
                if (mItem == null) { // can add here
                    mItems2[counter] = item; //put item in here
                    break;
                }
                counter += 1;
            }
            
        }

        item.onPickUp();

        if (ItemAdded2 != null) { 
            ItemAdded2(this, new IInventoryEventArgs(item, 0));
        }
    }



    public void DropItem2(IInventoryItem item, int index) {
        if (numItems > 0 && mItems2[index] != null) { // item here to remove
            numItems -= 1;
            mItems2[index] = null; //set mItems

            item.onDrop();

            if (ItemDropped2!= null) {
                ItemDropped2(this, new IInventoryEventArgs(item, index)); //removes from HUD at index location
            }
        }
        
    }




    

}
