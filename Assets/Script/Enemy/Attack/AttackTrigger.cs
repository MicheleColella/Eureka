using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public bool takingdamage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && takingdamage == false)
        {
            takingdamage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player" && takingdamage == true)
        {
            takingdamage = false;
        }
    }
}
