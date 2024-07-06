using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Data/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public string Id;
    public bool CanConjure;
    public Sprite Icon;
    public bool IsLocked;
    public int Quantity;
    public int PerSecond;
}
