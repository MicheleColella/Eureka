using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoAddItem : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public Item[] itemsToPickup;
    public Item[] CraftitemsToPickup;
    public Item[] Class1itemsToPickup;
    public Item[] Class2itemsToPickup;
    public Item[] Class3itemsToPickup;
    public Item[] Class4itemsToPickup;
    public Item[] Class1CraftitemsToPickup;
    public Item[] Class2CraftitemsToPickup;
    public Item[] Class3CraftitemsToPickup;
    public Item[] Class4CraftitemsToPickup;
    bool result;

    public void PickupItem(int id)
    {
        bool result = inventoryManager.AddItem(itemsToPickup[id]);
        if(result == true)
        {
            //Debug.Log("Oggetto Aggiunto");
        }
        else
        {
            //Debug.Log("Oggetto Non Aggiunto");
        }
    }

    public void PickupCraftItem(int id)
    {
        bool result = inventoryManager.AddItem(CraftitemsToPickup[id]);
        if (result == true)
        {
            Debug.Log("Oggetto Aggiunto");
        }
        else
        {
            Debug.Log("Oggetto Non Aggiunto");
        }
    }

    public void PickupClassCraftItem(int id, int Class)
    {
        switch (Class) {
            case 1:
                result = inventoryManager.AddItem(Class1CraftitemsToPickup[id]);
                break;
            case 2:
                result = inventoryManager.AddItem(Class2CraftitemsToPickup[id]);
                break;
            case 3:
                result = inventoryManager.AddItem(Class3CraftitemsToPickup[id]);
                break;
            case 4:
                result = inventoryManager.AddItem(Class4CraftitemsToPickup[id]);
                break;

        }

        if (result == true)
        {
            Debug.Log("Oggetto Aggiunto");
        }
        else
        {
            Debug.Log("Oggetto Non Aggiunto");
        }
    }
}
