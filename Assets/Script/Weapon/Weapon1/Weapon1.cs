using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Weapon1 : MonoBehaviour
{
    public MMFeedbacks Recoil1Shake;
    public MMFeedbacks Recoil2Shake;
    public Item item;
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float BulletForce;


    private void Update()
    {
        
        if(!Recoil1Shake)
            Recoil1Shake = GameObject.Find("Recoil1Shake").GetComponent<MMFeedbacks>();
        if(!Recoil2Shake)
            Recoil2Shake = GameObject.Find("Recoil2Shake").GetComponent<MMFeedbacks>();
        

        if (GamesManager.ParentWeapon1.name == transform.parent.gameObject.name)
        {
            if (transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Enemyradar>().enemyContact)
            {
                if (Time.time > GamesManager.nextfirerate1)
                {
                    if(Recoil1Shake)
                        Recoil1Shake.PlayFeedbacks();
                    fire(transform.parent.gameObject.transform.rotation);
                    GamesManager.nextfirerate1 = Time.time + item.Cooldown;
                }
            }
            //Debug.Log("nextFireTime: " + GamesManager.nextfirerate1 + " " + "Time: " + Time.time);
        }
        else if (GamesManager.ParentWeapon2.name == transform.parent.gameObject.name)
        {
            if (transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Enemyradar>().enemyContact)
            {
                if (Time.time > GamesManager.nextfirerate2)
                {
                    if (Recoil2Shake)
                        Recoil2Shake.PlayFeedbacks();
                    fire(transform.parent.gameObject.transform.rotation);
                    GamesManager.nextfirerate2 = Time.time + item.Cooldown;
                }
            }
            //Debug.Log("nextFireTime: " + GamesManager.nextfirerate2 + " " + "Time: " + Time.time);
        }
    }

    private void fire(Quaternion WeapTarget)
    {
        GameObject Bullets = Instantiate(BulletPrefab, FirePoint.position, Quaternion.Euler(BulletPrefab.transform.rotation.x + WeapTarget.x, BulletPrefab.transform.rotation.y + WeapTarget.y, BulletPrefab.transform.rotation.z + WeapTarget.z));
        if(Bullets.GetComponent<Bullet>() != null)
            Bullets.GetComponent<Bullet>().Damage = item.DamageInt;
        else if(Bullets.GetComponent<Bullet2>() != null)
            Bullets.GetComponent<Bullet2>().Damage = item.DamageInt;
        Rigidbody rb = Bullets.GetComponent<Rigidbody>();
        rb.AddForce(FirePoint.forward * BulletForce, ForceMode.Impulse);
    }
}
