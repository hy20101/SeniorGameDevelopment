using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameDevTV.Inventories;
using UnityEngine.UI;

public class OnClickBuyItem : MonoBehaviour
{
    Inventory inventory;
    InventoryItem item;

    private Button button;

    public void Start()
    {
        button = GetComponent<Button>();
        inventory = GetComponent<Inventory>();
        item = InventoryItem.GetFromID("1efb8b7a-7732-426e-8749-d506b0b94b83");
    }

    public void OnClick()
    {
        inventory.AddItemToSlot(0, item, 1);
    }
}
