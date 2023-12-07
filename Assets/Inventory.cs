using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public class Inventory : MonoBehaviour
{
    public static Inventory inventory;

    private void Awake() 
    {
        inventory = this;
    }
    
    private const int SLOTS = 2;

    private int numItems = 0;

    // [item, item]

    //keep track of numItems and mItems
    public List<IInventoryItem> mItems = new List<IInventoryItem>(); //null if no item in that slot

    public event EventHandler<IInventoryEventArgs> ItemAdded; //function from HUD added to inventory
    public event EventHandler<IInventoryEventArgs> ItemDropped; 

    public void Start() {
        // initialize two empty
        mItems.Add(null);
        mItems.Add(null);
    }

    public bool HasItem(string name) {
        foreach(IInventoryItem item in mItems) {
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

    public void DestroyItem(string name) { // finds first, drops by index
        int counter = 0;
        foreach(IInventoryItem item in mItems) {
            if (item == null) {
                // do nothing
            }
            else {
                if (item.Name == name) {
                    //destroy: don't drop
                    numItems -= 1; // set num of Items
                    mItems[counter] = null; //set mItems at this index

                    item.onPickUp(); //sets it to inactive 
                    // (item now inactive, not in mitems - destroyed)

                    ItemDropped(this, new IInventoryEventArgs(item, counter)); //remove from HUD at this index
                    
                    break;// finish

                }   
            }

            counter += 1;
        }

    }
    public void DropItem(IInventoryItem item, int index) { //drops by index
        if (numItems > 0 && mItems[index] != null) { // item here to remove
            numItems -= 1; // set numItems
            Debug.Log(numItems);
            Debug.Log(mItems);
            mItems[index] = null; //set mItems

            item.onDrop(); // sets active again

            if (ItemDropped != null) {
                ItemDropped(this, new IInventoryEventArgs(item, index)); //removes from HUD at index location
            }
        }
        
    }
    public void AddItem(IInventoryItem item){ //first available slot
        if (numItems < SLOTS){ //ADD!
            Debug.Log("Entered AddItem");
            //Collider2D collider = (item as MonoBehaviour)?.GetComponent<Collider2D>();
            numItems += 1;

            int counter = 0;
            foreach(IInventoryItem mItem in mItems) { //find slot to add at: put in first open
                if (mItem == null) { // can add here
                    mItems[counter] = item; //put item in here
                    break;
                }
                counter += 1;
            }

            item.onPickUp(); //pick up header item (function): sets inactive
            
            if (ItemAdded != null){ //HUD aligns with mItems
                Debug.Log("Entered ItemAdded!=null");
                ItemAdded(this, new IInventoryEventArgs(item, 0)); // adds to HUD
            }
            
        }
    }




}
