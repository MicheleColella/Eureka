using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class PumpWeapon1 : MonoBehaviour
{
    public MMFeedbacks Recoil1Shake;
    public MMFeedbacks Recoil2Shake;
    public Item item;
    public GameObject BulletPrefab;
    public Transform FirePoint;
    public float BulletForce;
    [SerializeField] int NumBullets;
    [SerializeField] float AngleVertical;
    [SerializeField] float AngleOrizzontal;

    private float nextFireTime;

    private void Start()
    {
        nextFireTime = 0;
    }

    private void Update()
    {
        if (!Recoil1Shake)
            Recoil1Shake = GameObject.Find("Recoil1Shake").GetComponent<MMFeedbacks>();
        if (!Recoil2Shake)
            Recoil2Shake = GameObject.Find("Recoil2Shake").GetComponent<MMFeedbacks>();

        if (GamesManager.ParentWeapon1.name == transform.parent.gameObject.name)
        {
            if (transform.parent.gameObject.transform.GetChild(0).gameObject.GetComponent<Enemyradar>().enemyContact)
            {
                if (Time.time > GamesManager.nextfirerate1)
                {
                    if (Recoil1Shake)
                        Recoil1Shake.PlayFeedbacks();
                    fire();
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
                    fire();
                    GamesManager.nextfirerate2 = Time.time + item.Cooldown;
                }
            }
            //Debug.Log("nextFireTime: " + GamesManager.nextfirerate2 + " " + "Time: " + Time.time);
        }
    }

    private void fire()
    {
        for(int i = 0; i < NumBullets; i++)
        {
            float rand_v = Random.Range(-AngleVertical, AngleVertical);
            float rand_o = Random.Range(-AngleOrizzontal, AngleOrizzontal);
            GameObject Bullets = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
            if (Bullets.GetComponent<Bullet>() != null)
                Bullets.GetComponent<Bullet>().Damage = item.DamageInt;
            else if (Bullets.GetComponent<Bullet2>() != null)
                Bullets.GetComponent<Bullet2>().Damage = item.DamageInt;
            Rigidbody rb = Bullets.GetComponent<Rigidbody>();
            //Bullets.transform.rotation = Quaternion.Euler(FirePoint.rotation.x + rand_v, FirePoint.rotation.y + rand_o, FirePoint.rotation.z);
            Vector3 dir = FirePoint.forward + new Vector3(0, rand_o, rand_v);
            rb.AddForce(dir * (BulletForce * 100));
        }
    }
}
