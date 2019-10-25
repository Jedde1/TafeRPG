﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    public int itemId = 0;
    public ItemTypes item;
    public int amount;

    public void Oncollection()
    {
        if (item == ItemTypes.Money)//Are we Moneeey?
        {
            LinearInventory.money += amount;
        }
        else if (item == ItemTypes.Craftable || item == ItemTypes.Food || item == ItemTypes.Potion || item == ItemTypes.Ingredient)
        {
            int found = 0;
            int addIndex = 0;
            for (int i = 0; i < LinearInventory.inv.Count; i++)
            {
                if (itemId == LinearInventory.inv[i].ID)
                {
                    found = 1;
                    addIndex = i;
                    break;
                }
            }
            if (found == 1)
            {
                LinearInventory.inv[addIndex].Amount += amount;

            }
            else
            {
                LinearInventory.inv.Add(ItemData.CreateItem(itemId));
                if (amount > 1)
                {
                    for (int i = 0; i < LinearInventory.inv.Count; i++)
                    {
                        if (itemId == LinearInventory.inv[i].ID)
                        {
                            LinearInventory.inv[i].Amount = amount;
                        }
                    }
                }
            }
        }
        else
        {
            LinearInventory.inv.Add(ItemData.CreateItem(itemId));
        }
        Destroy(gameObject);
    }
}
