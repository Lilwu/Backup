using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private const int SLOTS = 20;

    private List<IInventoryItem> mItem = new List<IInventoryItem>();

    public event EventHandler<InventoryEventArgs> ItemAdded;

    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public event EventHandler<InventoryEventArgs> ItemUsed;

    public void AddItem(IInventoryItem item)
    {
        if(mItem.Count < SLOTS)
        {
            Collider other = (item as MonoBehaviour).GetComponent<Collider>();
            if(other.enabled)
            {
                other.enabled = false;
                mItem.Add(item); 
                item.OnPickup();
             
                if(ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    internal void UseItem(IInventoryItem item)
    {
        if (ItemUsed != null)
        {
            ItemUsed(this, new InventoryEventArgs(item));
        }
    }

    //Drop機制
    public void RemoveItem(IInventoryItem item)
    {
        if(mItem.Contains(item))
        {
            mItem.Remove(item);
            item.OnDrop();

            Collider other = (item as MonoBehaviour).GetComponent<Collider>();
            if(other != null)
            {
                other.enabled = true;
            }

            if(ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}
