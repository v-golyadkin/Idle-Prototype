using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

            //inventoryItem.ConjureButton.gameObject.SetActive(item.CanConjure);

            if(item.CanConjure)
            {
                SetButtonOnClickFunction(inventoryItem.ConjureButton, item);
            }

            if (item.IsLocked)
            {
                inventoryItem.Image.sprite = _lockIcon;
                inventoryItem.NameText.text = "Close";
            }
            else
            {
                inventoryItem.Image.sprite = item.Icon;
                inventoryItem.NameText.text = item.Name;
            }
            
        }
    }

    private void SetButtonOnClickFunction(Button button, Item item)
    {
        button.onClick.AddListener(delegate { SetConjure(item); });
    }

    private void SetConjure(Item item)
    {
        ItemManager.Instance.SetCurrentItem(item);
    }
}
