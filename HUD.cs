using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public Inventory Inventory;
    private bool bagEnabled;

    private void Awake()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;

        //Drop機制
        Inventory.ItemRemoved += Inventory_ItemRemoved;
    }


    void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform ItemGrid = transform.Find("InventoryPanl1").Find("ItemGrid");
        foreach(Transform slot in ItemGrid)
        {
            // Border ... Image
            Transform imageTransform = slot.GetChild(0).GetChild(0);

            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            //We found the empty slot
            if(!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;

                //TODO: Store a reference to the item |Done
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void Inventory_ItemRemoved(object sender, InventoryEventArgs e)
    {
        Transform ItemGrid = transform.Find("InventoryPanl1").Find("ItemGrid");
        foreach (Transform slot in ItemGrid)
        {
            Transform imageTransform = slot.GetChild(0).GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            ItemDragHandler itemDragHandler = imageTransform.GetComponent<ItemDragHandler>();

            //We found the item in the UI
            if(itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;

                //會出現Bug
                //itemDragHandler.Item = null;
                break;
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            bagEnabled = !bagEnabled;
        }

        if( bagEnabled == true)
        {
            GetComponent<Canvas>().enabled = true;
        }
        else
        {
            GetComponent<Canvas>().enabled = false;
        }
    }
}
