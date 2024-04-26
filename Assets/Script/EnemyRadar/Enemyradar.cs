using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemyradar : MonoBehaviour
{
    /*
    public float checkRadius;
    public LayerMask checkLayers;
    public Transform closestEnemy;
    public bool enemyContact;

    private void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    private void Update()
    {
        checkRadius = gameObject.GetComponent<SphereCollider>().radius;
        getCloser();

        if(closestEnemy == null)
        {
            enemyContact = false;
        }
    }

    public void getCloser()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));
        int cont = 0;

        foreach (Collider item in colliders)
        {
            if (cont == 0)
            {
                //Debug.Log(item.name);
                closestEnemy = item.transform;
                enemyContact = true;
            }
            cont += 1;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
    */

    public float checkRadius;
    public LayerMask checkLayers;
    public Transform closestEnemy;
    public bool enemyContact;
    public string enemyTag;

    private void Start()
    {
        closestEnemy = null;
        enemyContact = false;
    }

    private void Update()
    {
        bool sphereCheck = Physics.CheckSphere(transform.position, checkRadius, checkLayers);

        checkRadius = gameObject.GetComponent<SphereCollider>().radius;
        getCloser();
        if (closestEnemy == null && !sphereCheck)
        {
            enemyContact = false;
        }
        else if(closestEnemy != null && !sphereCheck)
        {
            closestEnemy = null;
            enemyContact = false;
        }
    }

    public void getCloser()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, checkRadius, checkLayers);
        Array.Sort(colliders, new DistanceComparer(transform));
        int cont = 0;
        foreach (Collider item in colliders)
        {
            if (item.tag == enemyTag)
            {
                if (cont == 0)
                {
                    closestEnemy = item.transform;
                    enemyContact = true;
                }
                cont += 1;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, checkRadius);
    }
}
