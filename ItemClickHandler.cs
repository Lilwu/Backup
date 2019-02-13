using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClickHandler : MonoBehaviour
{
    public Inventory _inventory;

    float time = 0;

    public void OnItemClicked()
    {
        ItemDragHandler dragHandler =
            gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

        IInventoryItem item = dragHandler.Item;

        Debug.Log(item.Name);

        _inventory.UseItem(item);

        item.OnUse();
    }


    //滑鼠雙擊左鍵卸除武器&裝備
    private void Start()
    {
        time = Time.deltaTime;
    }

    public void OnItemRemoved()
    {
        if(Time.time - time <= 0.3f)
        {
            ItemDragHandler dragHandler =
            gameObject.transform.Find("ItemImage").GetComponent<ItemDragHandler>();

            IInventoryItem item = dragHandler.Item;
            Debug.Log("卸除" + item.Name);

            _inventory.UnUsedItem(item);

        }

        time = Time.time;
    }
}
