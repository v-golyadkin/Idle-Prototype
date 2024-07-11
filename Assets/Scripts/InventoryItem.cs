using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public Button ConjureButton;
    public Image Image;
    public TextMeshProUGUI QuantityText;
    [HideInInspector] public Item Item;

    private void Start()
    {
        EventManager.Instance.InventoryUpdateEvent.AddListener(ProcessInventoryUpdate);
    }

    private void OnEnable()
    {
        StartCoroutine(SetQuantity());
    }

    IEnumerator SetQuantity()
    {
        yield return new WaitForEndOfFrame();
        QuantityText.text = Item.Quantity.ToString();
    }

    private void ProcessInventoryUpdate(Item updateItemType, int count)
    {
        if(Item == updateItemType)
        {
            QuantityText.text = count.ToString();
        }
    }

    private void OnDestroy()
    {
        EventManager.Instance.InventoryUpdateEvent.RemoveListener(ProcessInventoryUpdate);
    }
}
