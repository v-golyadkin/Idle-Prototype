using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;

    public UnityEvent<Item, int> InventoryUpdateEvent;

    private void Awake()
    {
        Instance = this;
    }

    public void InventoryUpdated(Item item, int count)
    {
        InventoryUpdateEvent.Invoke(item, count);
    }
}
