using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Scriptable object/Item")]
public class Item : ScriptableObject{

    [Header("Only UI")]
    public string Name;
    public Sprite image;
    public TileBase tile;
    public ItemType type;
    public ActionType actionType;
    public CraftType craftType;
    public Vector2Int range = new Vector2Int(5, 4);
    public bool stackable = true;

    [Header("Only gameplay")]
    public bool HaveDamage;
    public int DamageInt;
    public bool HaveDefence;
    public int DefenceeInt;
    public GameObject WeaponModel;
    public float Cooldown;
    public float Precision;
    public int Shootrange;
}

public enum ItemType {
    CraftingBlock,
    Tool
}

public enum ActionType
{
    Head,
    Neck,
    Weapon,
    Shirt,
    Pants,
    Shoes,
    Gadget,
    CraftTool
}

public enum CraftType
{
    None,
    CraftItem1,
    CraftItem2,
    CraftItem3,
    CraftItem4,
}



