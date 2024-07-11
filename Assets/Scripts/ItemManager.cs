using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Item[] Items;

    public Item CurrentItem;

    private float _timer;

    private void Awake()
    {
        Instance = this;

        Items = Utils.GetAllInstances<Item>();
        Items = Items.OrderBy(p => p.Id).ToArray();
        foreach (Item item in Items) 
        {
            Debug.Log(item.Name);
        }
    }

    private void Start()
    {
        string currentItemName = PlayerPrefs.GetString("lastCraft", "copper");
        CurrentItem = GetItem(currentItemName);
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= 1f)
        {
            IncrementCurrentItem();
            _timer -= 1f;
        }
    }

    private Item GetItem(string itemName)
    {
        foreach (Item item in Items)
        {
            if(item.Name.ToLower() == itemName.ToLower())
            {
                return item;
            }
        }
        Debug.LogError("Unable to get item of string" + itemName);
        return null;
    }

    public void IncrementCurrentItem()
    {
        CurrentItem.Quantity += CurrentItem.PerSecond;
        EventManager.Instance.InventoryUpdated(CurrentItem, CurrentItem.Quantity);
    }

    public void SetCurrentItem(Item item)
    {
        CurrentItem = item;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString("lastCraft", CurrentItem.Name.ToLower());
    }
}
