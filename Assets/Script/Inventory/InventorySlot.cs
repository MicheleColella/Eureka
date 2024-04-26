using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public ActionType SlotActionType;
    public ItemType SlotItemType;
    public bool UseControl;
    private InventoryManager InventoryManager;
    public static int armorDefence;
    public static int weapondamage;

    public TextMeshProUGUI DamageText;
    public TextMeshProUGUI ArmorText;

    int tmp_head_defence;
    int tmp_Neck_defence;
    int tmp_weapon1_damage;
    int tmp_weapon2_damage;
    int tmp_Shirt_defence;
    int tmp_Pants_defence;
    int tmp_Shoes_defence;

    public static string weapon1_tmp_name;
    public static string weapon2_tmp_name;

    private GameObject Player;
    private Transform Playerpos;
    
    private GameObject Targetweapos;
    private Transform Targetpos;
    private GameObject Target2weapos;
    private Transform Target2pos;

    public GameObject[] taggedObjects;
    public GameObject[] taggedObjects2;

    public GameObject weapon1;
    public GameObject weapon2;

    private void Start()
    {
        InventoryManager = GameObject.Find("Inventory Manager").GetComponent<InventoryManager>();
        Player = GameObject.Find("Player");
        Playerpos = Player.GetComponent<Transform>();

        Targetweapos = GameObject.Find("weaponTarget");
        Targetpos = Targetweapos.GetComponent<Transform>();

        Target2weapos = GameObject.Find("weapon2Target");
        Target2pos = Target2weapos.GetComponent<Transform>();

        armorDefence = 0;
        weapondamage = 0;
        tmp_head_defence = 0;
        tmp_Neck_defence = 0;
        tmp_weapon1_damage = 0;
        tmp_weapon2_damage = 0;
        tmp_Shirt_defence = 0;
        tmp_Pants_defence = 0;
        tmp_Shoes_defence = 0;
    }

    private void Update()
    {
        //Debug.Log(armorDefence);
        //Debug.Log(weapondamage);
        //Debug.Log(Playerpos.position);

        if(DamageText != null)
        {
            DamageText.text = ": " + weapondamage;
        }
        if(ArmorText != null)
        {
            ArmorText.text = ": " + armorDefence;
        }

        if (InventoryManager.EquipSlots[0].transform.childCount != 0 && InventoryManager.HeadEquip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[0].GetComponentInChildren<InventoryItem>();
            InventoryManager.HeadEquip = true;
            tmp_head_defence = itemInSlot.item.DefenceeInt;
            armorDefence += tmp_head_defence;
            //Debug.Log(itemInSlot.item.Name);
        }
        else if (InventoryManager.EquipSlots[0].transform.childCount == 0 && InventoryManager.HeadEquip == true)
        {
            InventoryManager.HeadEquip = false;
            armorDefence -= tmp_head_defence;
            tmp_head_defence = 0;
            //Debug.Log(itemInSlot.item.Name);
        }   

        if (InventoryManager.EquipSlots[1].transform.childCount != 0 && InventoryManager.NeckEquip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[1].GetComponentInChildren<InventoryItem>();
            InventoryManager.NeckEquip = true;
            tmp_Neck_defence = itemInSlot.item.DefenceeInt;
            armorDefence += tmp_Neck_defence;
        }
        else if (InventoryManager.EquipSlots[1].transform.childCount == 0 && InventoryManager.NeckEquip == true)
        {
            InventoryManager.NeckEquip = false;
            armorDefence -= tmp_Neck_defence;
            tmp_Neck_defence = 0;
        } 

        if (InventoryManager.EquipSlots[2].transform.childCount != 0 && InventoryManager.Weapon1Equip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[2].GetComponentInChildren<InventoryItem>();
            weapon1_tmp_name = itemInSlot.item.Name;
            weapon1 = Instantiate(itemInSlot.item.WeaponModel, Targetpos.position, Targetpos.rotation);
            weapon1.transform.parent = Targetweapos.transform;
            InventoryManager.Weapon1Equip = true;
            tmp_weapon1_damage = itemInSlot.item.DamageInt;
            weapondamage += tmp_weapon1_damage;
        }
        else if(InventoryManager.EquipSlots[2].transform.childCount == 0 && InventoryManager.Weapon1Equip == true)
        {
            Destroy(weapon1);
            weapon1_tmp_name = null;
            InventoryManager.Weapon1Equip = false;
            weapondamage -= tmp_weapon1_damage;
            tmp_weapon1_damage = 0;
        }

        if (InventoryManager.EquipSlots[3].transform.childCount != 0 && InventoryManager.Weapon2Equip == false)
        {
            InventoryItem itemInSlot2 = InventoryManager.EquipSlots[3].GetComponentInChildren<InventoryItem>();
            weapon2_tmp_name = itemInSlot2.item.Name;
            weapon2 = Instantiate(itemInSlot2.item.WeaponModel, Target2pos.position, Target2pos.rotation);
            weapon2.transform.parent = Target2weapos.transform;
            InventoryManager.Weapon2Equip = true;
            tmp_weapon2_damage = itemInSlot2.item.DamageInt;
            weapondamage += tmp_weapon2_damage;
        }
        else if (InventoryManager.EquipSlots[3].transform.childCount == 0 && InventoryManager.Weapon2Equip == true)
        {
            Destroy(weapon2);
            weapon2_tmp_name = null;
            InventoryManager.Weapon2Equip = false;
            weapondamage -= tmp_weapon2_damage;
            tmp_weapon2_damage = 0;
        }

        if (InventoryManager.EquipSlots[4].transform.childCount != 0 && InventoryManager.ShirtEquip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[4].GetComponentInChildren<InventoryItem>();
            InventoryManager.ShirtEquip = true;
            tmp_Shirt_defence = itemInSlot.item.DefenceeInt;
            armorDefence += tmp_Shirt_defence;
        }
        else if(InventoryManager.EquipSlots[4].transform.childCount == 0 && InventoryManager.ShirtEquip == true)
        {
            InventoryManager.ShirtEquip = false;
            armorDefence -= tmp_Shirt_defence;
            tmp_Shirt_defence = 0;
        }

        if (InventoryManager.EquipSlots[5].transform.childCount != 0 && InventoryManager.PantsEquip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[5].GetComponentInChildren<InventoryItem>();
            InventoryManager.PantsEquip = true;
            tmp_Pants_defence = itemInSlot.item.DefenceeInt;
            armorDefence += tmp_Pants_defence;
        }
        else if(InventoryManager.EquipSlots[5].transform.childCount == 0 && InventoryManager.PantsEquip == true)
        {
            InventoryManager.PantsEquip = false;
            armorDefence -= tmp_Pants_defence;
            tmp_Pants_defence = 0;
        }

        if (InventoryManager.EquipSlots[6].transform.childCount != 0 && InventoryManager.ShoesEquip == false)
        {
            InventoryItem itemInSlot = InventoryManager.EquipSlots[6].GetComponentInChildren<InventoryItem>();
            InventoryManager.ShoesEquip = true;
            tmp_Shoes_defence = itemInSlot.item.DefenceeInt;
            armorDefence += tmp_Shoes_defence;
        }
        else if (InventoryManager.EquipSlots[6].transform.childCount == 0 && InventoryManager.ShoesEquip == true)
        {
            InventoryManager.ShoesEquip = false;
            armorDefence -= tmp_Shoes_defence;
            tmp_Shoes_defence = 0;
        }

        if (InventoryManager.EquipSlots[7].transform.childCount != 0)
        {
            InventoryManager.GadgetEquip = true;
        }
        else
        {
            InventoryManager.GadgetEquip = false;
        }
            
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem inventoryItem1 = dropped.GetComponent<InventoryItem>();

            if (UseControl)
            {
                if (SlotActionType.ToString() == inventoryItem1.item.actionType.ToString()  && SlotItemType.ToString() == inventoryItem1.item.type.ToString())
                {
                    inventoryItem1.parentAfterDrag = transform;
                    //Debug.Log(inventoryItem1.item.actionType);
                }
            }
            else
            {
                inventoryItem1.parentAfterDrag = transform;
            }
        }
    }
}
