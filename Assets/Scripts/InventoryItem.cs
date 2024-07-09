using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{
    public Button ClojureButton;
    public Image Image;
    public TextMeshProUGUI QuantityText;
    [HideInInspector] public Item Item;
}
