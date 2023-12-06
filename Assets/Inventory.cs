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

    public void AddItem(IInventoryItem item){
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

    public void DropItem(IInventoryItem item, int index) { //drops 
        if (numItems > 0 && mItems[index] != null) { // item here to remove
            numItems -= 1;
            Debug.Log(numItems);
            Debug.Log(mItems);
            mItems[index] = null; //set mItems

            item.onDrop(); // sets active again

            if (ItemDropped != null) {
                ItemDropped(this, new IInventoryEventArgs(item, index)); //removes from HUD at index location
            }
        }
        
    }

}
