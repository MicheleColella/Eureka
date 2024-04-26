using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddObjCraft : MonoBehaviour
{
    public GameObject ObjAdder;
    public DemoAddItem demoAdd;
    public MoveToPlayer moveToPlayer;
    public Item[] ClassCraftitemsToPickup;
    int Cont;
    [Range(1, 4)]
    public int ClassItemToAdd;
    public bool addRandomObj;
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;
    public bool useRandomBox;

    private void Awake()
    {
        ObjAdder = GameObject.Find("ObjAdder");
        demoAdd = ObjAdder.GetComponent<DemoAddItem>();
    }

    private void Start()
    {
        if (addRandomObj)
        {
            ClassItemToAdd = Random.Range(1, 4);
        }
        switch (ClassItemToAdd)
        {
            case 1:
                if(useRandomBox)
                    Box1.SetActive(true);
                ClassCraftitemsToPickup = demoAdd.Class1CraftitemsToPickup;
                break;

            case 2:
                if (useRandomBox)
                    Box1.SetActive(true);
                ClassCraftitemsToPickup = demoAdd.Class2CraftitemsToPickup;
                break;
            
            case 3:
                if (useRandomBox)
                    Box1.SetActive(true);
                ClassCraftitemsToPickup = demoAdd.Class3CraftitemsToPickup;
                break;
            
            case 4:
                if (useRandomBox)
                    Box1.SetActive(true);
                ClassCraftitemsToPickup = demoAdd.Class4CraftitemsToPickup;
                break;
        }
    }

    private void Update()
    {
        if (moveToPlayer.Touch && Cont == 0)
        {
            AddCraftObj();
            Cont += 1;
        }
    }

    public void AddCraftObj()
    {
        int rand = Random.Range(0, ClassCraftitemsToPickup.Length);
        demoAdd.PickupClassCraftItem(rand, ClassItemToAdd);
    }
}
