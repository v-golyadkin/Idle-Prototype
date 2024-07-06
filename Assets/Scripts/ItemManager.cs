using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance;

    public Item[] Items;

    private void Awake()
    {
        Instance = this;

        Items = Utils.GetAllInstances<Item>();
        foreach (Item item in Items) 
        {
            Debug.Log(item.Name);
        }
    }
}
