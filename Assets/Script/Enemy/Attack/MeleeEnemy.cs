using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{
    public AttackTrigger attackTrigger;
    private PlayerHealth Player;
    private float nextmeleeTime;
    [SerializeField] int MeleeDamage;
    [SerializeField] int Cooldown;

    private void Start()
    {
        Player = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        if (Time.time > nextmeleeTime && attackTrigger.takingdamage)
        {
            Player.TakeDamage(MeleeDamage);
            nextmeleeTime = Time.time + Cooldown;
        }
    }
}
