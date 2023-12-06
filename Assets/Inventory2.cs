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
