using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour {
    public int moneyLimit = 100;

    // Items is private because of specialized adding
    public List<BaseItem> Items { get; private set; }

    // Money is private because its limit may be ceilinged
    private int money;

    // Initialize items list and set it to what it previously was
    void Start()
    {
        Items = new List<BaseItem>();
    }

    // Add items to the list only if they should be allowed to be added
    public void AddItem(BaseItem itemToAdd)
    {
        List<BaseItem> alreadyOwned = Items.Where(x => x.ItemType == itemToAdd.ItemType).ToList();
        if (alreadyOwned.Count == 0)
        {
            Items.Add(itemToAdd);
        }
        else
        {
            if (ItemCanBeAdded(itemToAdd, alreadyOwned))
            {
                Items.Add(itemToAdd);
            }

            return;

        }
    }

    public bool RemoveItem(BaseItem itemToRemove)
    {
        return Items.Remove(itemToRemove);
    }

    public bool HasItem(BaseItem item)
    {
        return Items.Contains(item);
    }

    // Add money up to the current money limit
    public void AddMoney(int moneyReceived)
    {
        money += moneyReceived;
        
        if (money > moneyLimit)
        {
            money = moneyLimit;
        }
    }

    // Take money but don't go below zero
    public int TakeMoney(int moneyTaken)
    {
        if (moneyTaken >= money)
        {
            money = 0;
            return money;
        }

        money -= moneyTaken;
        return moneyTaken;
    }

    // Determines whether the item is allowed to be added to the pack
    private bool ItemCanBeAdded(BaseItem itemToAdd, List<BaseItem> alreadyOwned)
    {
        if (itemToAdd.IsUnique)
        {
            return false;
        }

        if (itemToAdd.MaxStack == alreadyOwned.Count)
        {
            return false;
        }

        return true;
    }
}
