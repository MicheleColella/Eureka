using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GamesManager gamesManager;

    [Header("Health")]
    [SerializeField] float maxHealth, delaydeath;
    public float health;
    public bool death;
    [SerializeField] bool Havedrop;

    [Header("Drop Items")]
    [SerializeField] GameObject DropItemsClass1;
    [SerializeField] GameObject DropItemsClass2;
    [SerializeField] GameObject DropItemsClass3;
    [SerializeField] GameObject DropItemsClass4;
    [SerializeField] int ItemClass;
    [SerializeField] bool RandomClass;
    [Range(1, 4)]
    [SerializeField] int MaxItemClass;
    [SerializeField] int ProbablyItemClass;
    [SerializeField] bool UseTimerToClass;
    [SerializeField] int CoinAmount;

    [Header("VFX")]
    public GameObject HitVFX;

    private void Start()
    {
        gamesManager = GameObject.Find("GameManager").GetComponent<GamesManager>();
        health = maxHealth;
        death = false;
    }

    private void Update()
    {
        if (UseTimerToClass)
        {
            MaxItemClass = GamesManager.ActualClass;
        }
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        var HitParticle = Instantiate(HitVFX, transform.position, transform.rotation);
        Destroy(HitParticle, 2.0f);

        if (health <= 0)
        {
            death = true;
            StartCoroutine(Delaydeath(delaydeath));
        }
    }

    private void DropItem()
    {
        if (RandomClass)
        {
            ItemClass = Random.Range(1, MaxItemClass+1);
        }

        int prob = Random.Range(1, ProbablyItemClass);
        if(prob == 1)
        {
            if ((ItemClass == 1) && ItemClass <= MaxItemClass)
            {
                Debug.Log(ItemClass);
                Instantiate(DropItemsClass1, transform.position, Quaternion.identity);
            }
            else if ((ItemClass == 2) && ItemClass <= MaxItemClass)
            {
                Debug.Log(ItemClass);
                Instantiate(DropItemsClass2, transform.position, Quaternion.identity);
            }
            else if ((ItemClass == 3) && ItemClass <= MaxItemClass)
            {
                Debug.Log(ItemClass);
                Instantiate(DropItemsClass3, transform.position, Quaternion.identity);
            }
            else if ((ItemClass == 4) && ItemClass <= MaxItemClass)
            {
                Debug.Log(ItemClass);
                Instantiate(DropItemsClass4, transform.position, Quaternion.identity);
            }
        }
    }

    IEnumerator Delaydeath(float delaydeath)
    {
        yield return new WaitForSeconds(delaydeath);
        if (Havedrop)
        {
            gamesManager.AddCoin(CoinAmount);
            DropItem();
        }
        EnemySpawn.EnemyKillCount += 1;
        Destroy(gameObject);
    }
}
