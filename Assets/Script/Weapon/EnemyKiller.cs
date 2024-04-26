using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKiller : MonoBehaviour
{
    public int Damage;
    public float checkRadius;
    public LayerMask checkLayers;

    [SerializeField] float DestroyTime;
    public bool haveDestroy;

    private void Start()
    {
        if (haveDestroy)
        {
            Destroy(gameObject, DestroyTime);
        }
    }

    private void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        foreach (Collider item in colliders)
        {
            if (item.tag == "Enemy")
            {
                EnemyHealth enemyhealth = item.gameObject.GetComponent<EnemyHealth>();
                enemyhealth.TakeDamage(Damage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
