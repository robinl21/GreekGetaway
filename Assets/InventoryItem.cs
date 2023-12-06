using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; 

public interface IInventoryItem {
    string Name { get; }
    Sprite Image { get; }
    void onPickUp();
    void onDrop();
}


public class IInventoryEventArgs : EventArgs
{
    public IInventoryEventArgs(IInventoryItem item, int i)
    {
        Item = item;
        Index = i;
    }

    public IInventoryItem Item;
    public int Index;
}
