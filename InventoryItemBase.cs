using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InventoryItemBase : MonoBehaviour, IInventoryItem
{
    public GameObject inventory;

    public virtual string Name
    {
        get
        {
            return "_base_item";
        }
    }

    public Sprite _Image;      public Sprite Image     {         get         {             return _Image;         }     }


    public virtual void OnPickup()
    {
        gameObject.SetActive(false);
    }       public virtual void OnDrop()     {
        //TODO: move a logic like this to a base class or helper method
        RaycastHit hit = new RaycastHit();         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);         if (Physics.Raycast(ray, out hit, 1000))         {             gameObject.SetActive(true);             gameObject.transform.position = hit.point; //將物品移到丟棄物品的點上 TODO:各場景需有一個回收GameObject;         }
    }

    public virtual void OnUse()
    {

    }

    public virtual void UnUsed()
    {

    }
}
