using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChosenWeapon : MonoBehaviour
{
    public int IDChosenWeapon;

    public GameObject[] Markers;
    public GameObject[] Locker;
    public bool[] UnlockedWeapon;


    private void Start()
    {
        for (int i = 0; i < Markers.Length; i++)
        {
            Markers[i].SetActive(false);
        }
    }

    void Update()
    {
        if (!Markers[IDChosenWeapon].activeSelf)
        {
            for(int i = 0; i<Markers.Length; i++)
            {
                Markers[i].SetActive(false);
            }
            Markers[IDChosenWeapon].SetActive(true);
        }

        for (int i = 0; i < Markers.Length; i++)
        {
            Locker[i].SetActive(!UnlockedWeapon[i]);
        }
            
    }

    public void IDChosenWep(int IDWeap)
    {
        IDChosenWeapon = IDWeap;
    }
}
