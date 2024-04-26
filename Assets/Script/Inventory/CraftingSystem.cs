using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingSystem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public DemoAddItem demoAddItem;
    public InventorySlot[] CraftSlots;
    void Update()
    {
        if (CraftSlots[0].GetComponentInChildren<InventoryItem>() != null && CraftSlots[0].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem1)
        {
            if (CraftSlots[1].GetComponentInChildren<InventoryItem>() != null && CraftSlots[1].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem1)
            {
                if (CraftSlots[2].GetComponentInChildren<InventoryItem>() != null && CraftSlots[2].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem1)
                {
                    if (CraftSlots[3].GetComponentInChildren<InventoryItem>() != null && CraftSlots[3].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem1)
                    {
                        InventorySlot slot = CraftSlots[0];
                        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot.gameObject);
                        InventorySlot slot1 = CraftSlots[1];
                        InventoryItem itemInSlot1 = slot1.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot1.gameObject);
                        InventorySlot slot2 = CraftSlots[2];
                        InventoryItem itemInSlot2 = slot2.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot2.gameObject);
                        InventorySlot slot3 = CraftSlots[3];
                        InventoryItem itemInSlot3 = slot3.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot3.gameObject);

                        int rand = Random.Range(0, demoAddItem.Class1itemsToPickup.Length);
                        inventoryManager.AddItem(demoAddItem.Class1itemsToPickup[rand]);
                    }
                }
            }
        }

        if (CraftSlots[0].GetComponentInChildren<InventoryItem>() != null && CraftSlots[0].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem2)
        {
            if (CraftSlots[1].GetComponentInChildren<InventoryItem>() != null && CraftSlots[1].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem2)
            {
                if (CraftSlots[2].GetComponentInChildren<InventoryItem>() != null && CraftSlots[2].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem2)
                {
                    if (CraftSlots[3].GetComponentInChildren<InventoryItem>() != null && CraftSlots[3].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem2)
                    {
                        InventorySlot slot = CraftSlots[0];
                        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot.gameObject);
                        InventorySlot slot1 = CraftSlots[1];
                        InventoryItem itemInSlot1 = slot1.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot1.gameObject);
                        InventorySlot slot2 = CraftSlots[2];
                        InventoryItem itemInSlot2 = slot2.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot2.gameObject);
                        InventorySlot slot3 = CraftSlots[3];
                        InventoryItem itemInSlot3 = slot3.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot3.gameObject);

                        int rand = Random.Range(0, demoAddItem.Class2itemsToPickup.Length);
                        inventoryManager.AddItem(demoAddItem.Class2itemsToPickup[rand]);
                    }
                }
            }
        }

        if (CraftSlots[0].GetComponentInChildren<InventoryItem>() != null && CraftSlots[0].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem3)
        {
            if (CraftSlots[1].GetComponentInChildren<InventoryItem>() != null && CraftSlots[1].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem3)
            {
                if (CraftSlots[2].GetComponentInChildren<InventoryItem>() != null && CraftSlots[2].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem3)
                {
                    if (CraftSlots[3].GetComponentInChildren<InventoryItem>() != null && CraftSlots[3].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem3)
                    {
                        InventorySlot slot = CraftSlots[0];
                        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot.gameObject);
                        InventorySlot slot1 = CraftSlots[1];
                        InventoryItem itemInSlot1 = slot1.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot1.gameObject);
                        InventorySlot slot2 = CraftSlots[2];
                        InventoryItem itemInSlot2 = slot2.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot2.gameObject);
                        InventorySlot slot3 = CraftSlots[3];
                        InventoryItem itemInSlot3 = slot3.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot3.gameObject);

                        int rand = Random.Range(0, demoAddItem.Class3itemsToPickup.Length);
                        inventoryManager.AddItem(demoAddItem.Class3itemsToPickup[rand]);
                    }
                }
            }
        }

        if (CraftSlots[0].GetComponentInChildren<InventoryItem>() != null && CraftSlots[0].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem4)
        {
            if (CraftSlots[1].GetComponentInChildren<InventoryItem>() != null && CraftSlots[1].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem4)
            {
                if (CraftSlots[2].GetComponentInChildren<InventoryItem>() != null && CraftSlots[2].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem4)
                {
                    if (CraftSlots[3].GetComponentInChildren<InventoryItem>() != null && CraftSlots[3].GetComponentInChildren<InventoryItem>().item.craftType == CraftType.CraftItem4)
                    {
                        InventorySlot slot = CraftSlots[0];
                        InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot.gameObject);
                        InventorySlot slot1 = CraftSlots[1];
                        InventoryItem itemInSlot1 = slot1.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot1.gameObject);
                        InventorySlot slot2 = CraftSlots[2];
                        InventoryItem itemInSlot2 = slot2.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot2.gameObject);
                        InventorySlot slot3 = CraftSlots[3];
                        InventoryItem itemInSlot3 = slot3.GetComponentInChildren<InventoryItem>();
                        Destroy(itemInSlot3.gameObject);

                        int rand = Random.Range(0, demoAddItem.Class4itemsToPickup.Length);
                        inventoryManager.AddItem(demoAddItem.Class4itemsToPickup[rand]);
                    }
                }
            }
        }
    }
}
