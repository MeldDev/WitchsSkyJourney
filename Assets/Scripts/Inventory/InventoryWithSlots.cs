using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryWithSlots : IInventory
{

    public event Action<object, IInventoryItem, int> onInventoryItemAddadEvent;
    public event Action<object, Type, int> onInventoryItemRemovedEvent;


    public int capacity { get; set; }

    public bool isFull => _slots.All(slot => slot.isFull);

    private List<IInventorySlot> _slots;
    public InventoryWithSlots(int capacity)
    {
        this.capacity = capacity;
        _slots =  new List<IInventorySlot>(capacity);
        for (int i = 0; i < capacity; i++)
        {
            _slots.Add(new InventorySlot());
        }
    }

    public IInventoryItem GetItem(Type itemType)
    {
        return _slots.Find(slot => slot.itemType == itemType).item;
    }
    public IInventoryItem[] GetAllItems()
    {
        var allItems = new List<IInventoryItem>();
        foreach (var slot in _slots)
        {
            if (!slot.isEmpty)
                allItems.Add(slot.item);
        }

        return allItems.ToArray();
    }

    public IInventoryItem[] GetAllItems(Type itemType)
    {
        var allItemsOfType = new List<IInventoryItem>();
        var slotOfType = _slots.
            FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in slotOfType)
        {
            allItemsOfType.Add(slot.item);
        }

        return allItemsOfType.ToArray();
    }

    public IInventoryItem[] GetEquippedItems()
    {
        var requiredSlots = _slots.FindAll(slot => slot.item.isEquipped);
        var equippedItems = new List<IInventoryItem>();
        foreach (var slot in requiredSlots)
        {
            equippedItems.Add(slot.item);
        }

        return equippedItems.ToArray();
    }


    public int GetItemAmount(Type itemType)
    {
        var amount = 0;
        var allItemsSlot = _slots.
            FindAll(slot => !slot.isEmpty && slot.itemType == itemType);
        foreach (var slot in allItemsSlot)
        {
            amount += slot.amount;
        }

        return amount;
    }

    public bool TryToAdd(object sender, IInventoryItem item)
    {
        var slotWithSameItemsButNotEmpty = _slots.
            Find(slot => slot.isEmpty && slot.itemType == item.type && !slot.isEmpty);

        if (slotWithSameItemsButNotEmpty != null)
            return TroToAddToSlot(sender, slotWithSameItemsButNotEmpty, item);

        var emptySlot = _slots.Find(slot => slot.isEmpty);
        if(emptySlot != null)
            return TroToAddToSlot(sender, emptySlot, item);


        return false;
    }

    private bool TroToAddToSlot(object sender, IInventorySlot slot, IInventoryItem item)
    {
        var fits = slot.amount + item.amount <= item.maxItemsInInventorySlot;
        var amountToAdd = fits ? item.amount : item.maxItemsInInventorySlot - slot.amount;
        var amountLeft = item.amount - amountToAdd;
        var clonedItem = item.Clone();
        clonedItem.amount = amountToAdd;

        if (slot.isEmpty)
            slot.SetItem(clonedItem);
        else
            slot.item.amount += amountToAdd;

        onInventoryItemAddadEvent?.Invoke(sender, item, amountToAdd);

        if (amountLeft <= 0)
            return true;

        item.amount = amountLeft;
        return TryToAdd(sender, item);
    }
    public void Remove(object sender, Type itemType, int amount = 1)
    {
        var slotWithItems = GetAllSlots(itemType);
        if (slotWithItems == null)
            return;

        var amountToRemove = amount;
        var count = slotWithItems.Length;

        for (int i = count-1; i >= 0; i--)
        {
            var slot = slotWithItems[i];
            if (slot.amount >= amountToRemove)
            {
                slot.item.amount -= amountToRemove;

                if (slot.amount == 0)
                    slot.Clear();
                onInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
                break;
            }
            var amountRemoved = slot.amount;
            amountToRemove -= slot.amount;
            slot.Clear();
            onInventoryItemRemovedEvent?.Invoke(sender, itemType, amountToRemove);
        }

    }


    public bool HasItem(Type itemType, out IInventoryItem item)
    {
        item = GetItem(itemType);
        return item != null;
    }
    private IInventorySlot[] GetAllSlots(Type itemType)
    {
        return _slots.FindAll(slot => !slot.isEmpty && slot.itemType == itemType).ToArray();
    }

    private IInventorySlot[] GetAllSlots()
    {
        return _slots.ToArray();
    }




}
