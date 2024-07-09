using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCreator : MonoBehaviour
{
    [SerializeField] private GameObject _buttonPrefab;
    [SerializeField] private Transform _buttonContainer;
    [SerializeField] private Sprite _lockIcon;

    private void Start()
    {
        StartCoroutine(CreateInventory());
    }

    IEnumerator CreateInventory()
    {
        yield return new WaitForEndOfFrame();

        foreach (Item item in ItemManager.Instance.Items)
        {
            GameObject instance = Instantiate(_buttonPrefab, _buttonContainer);
            instance.name = item.name;
            InventoryItem inventoryItem = instance.GetComponent<InventoryItem>();
            inventoryItem.Item = item;

            inventoryItem.Image.sprite = item.Icon;
        }
    }
}
