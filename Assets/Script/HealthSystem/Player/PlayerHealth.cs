using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public bool Death;
    public bool Dieing;
    public float DelayDeath;
    public float armorDamageReduction;
    [SerializeField] private AnimatorController _animatorController;
    void Start()
    {
        Health = MaxHealth;
        Death = false;
    }

    private void Update()
    {
        if (Health <= 0)
        {
            //Debug.Log("DelayDeath");
            StartCoroutine(DeathDelay());
        }
        if(Health > 0)
        {
            Death = false;
            Dieing = false;
        }
    }

    public void TakeDamage(int damage)
    {
        if (!Death)
        {
            if (Health > 0)
            {
                if (InventorySlot.armorDefence != 0)
                {
                    armorDamageReduction = (1f - ((0.052f * (float)InventorySlot.armorDefence) / (0.9f + 0.048f * Mathf.Abs((float)InventorySlot.armorDefence))));
                }
                else
                {
                    armorDamageReduction = 1;
                }
                float finalDamage = damage * armorDamageReduction;
                Debug.Log(finalDamage);
                Health -= (int)finalDamage;
            }
            else
            {
                Health = 0;
            }
        }
    }

    public void TakeHealth(int recover)
    {
        if (!Death)
        {
            if (Health < MaxHealth)
            {
                Health += recover;
            }
            else
            {
                Health = MaxHealth;
            }
        }
    }

    IEnumerator DeathDelay()
    {
        Dieing = true;
        _animatorController.PlayDeath();
        yield return new WaitForSeconds(DelayDeath);
        Death = true;
        //Debug.Log("Death");
    }
}
