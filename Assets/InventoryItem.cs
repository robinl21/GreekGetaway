using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public interface IInventoryItem {
    string Name { get; }
    Sprite Image { get; }
    void onPickUp();
}


public class IInventoryEventArgs : EventArgs
{
    public IInventoryEventArgs(IInventoryItem item)
    {
        Item = item;
    }

    public IInventoryItem Item;
}
