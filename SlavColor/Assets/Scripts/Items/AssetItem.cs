using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Item ")]
public class AssetItem : ScriptableObject,  IItem
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _uiIcon;
    [SerializeField] private ItemType _type;

    public string Name => _name;
    public Sprite UIIcon => _uiIcon;

    public ItemType Type
    {
        get => _type;
        set => _type = value;
    }

    public enum ItemType
    {
        Weapon,
        QuestItem,
        Clothes,
        UsableItem
    }
}
