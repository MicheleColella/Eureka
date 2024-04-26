using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public DemoAddItem demoAddItem;
    public int maxStackedItems;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;

    public InventorySlot[] CraftSlots;
    public InventorySlot[] EquipSlots;
    public InventorySlot[] TrashSlots;

    public bool HeadEquip;
    public bool NeckEquip;
    public bool Weapon1Equip;
    public bool Weapon2Equip;
    public bool ShirtEquip;
    public bool PantsEquip;
    public bool ShoesEquip;
    public bool GadgetEquip;
    public GameObject[] Hand1;
    public GameObject[] Hand2;

    public Vector3 Weapon1Offset;
    public Vector3 Weapon2Offset;

    private void Update()
    {
        if (Weapon1Equip)
        {
            for(int i = 0; i < Hand1.Length; i++)
            {
                Hand1[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Hand1.Length; i++)
            {
                Hand1[i].SetActive(true);
            }
        }

        if (Weapon2Equip)
        {
            for (int i = 0; i < Hand2.Length; i++)
            {
                Hand2[i].SetActive(false);
            }
        }
        else
        {
            for (int i = 0; i < Hand2.Length; i++)
            {
                Hand2[i].SetActive(true);
            }
        }

        if (TrashSlots[0].GetComponentInChildren<InventoryItem>() != null)
        {
            Destroy(TrashSlots[0].GetComponentInChildren<InventoryItem>().gameObject);
        }
    }


    public bool AddItem(Item item)
    {
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if (itemInSlot != null && 
                itemInSlot.item == item && 
                itemInSlot.count < maxStackedItems &&
                itemInSlot.item.stackable == true){
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
            if(itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }

    void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }


}
