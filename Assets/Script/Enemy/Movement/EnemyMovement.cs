using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator Anim;
    public GameObject player;
    public float Height_offset;
    public float MaxHeight;
    public float MinHeight;
    public float speed;
    private float actualspeed;

    private void Start()
    {
        Anim.SetFloat("Speed", speed);
        actualspeed = speed;
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (!player.GetComponent<PlayerHealth>().Death)
        {
            if (transform.position.y > MaxHeight)
            {
                transform.position = new Vector3(transform.position.x, MaxHeight, transform.position.z);
            }
            if (transform.position.y < MinHeight)
            {
                transform.position = new Vector3(transform.position.x, MinHeight, transform.position.z);
            }
            Vector3 playerpos = player.transform.position;
            playerpos = new Vector3(playerpos.x, transform.position.y, playerpos.z);
            transform.LookAt(playerpos);
            transform.position = Vector3.MoveTowards(transform.position, playerpos + new Vector3(0, Height_offset, 0), actualspeed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision Obj)
    {
        if(Obj.gameObject.name == "Player")
        {
            actualspeed = 0f;
        }
    }

    private void OnCollisionExit(Collision Obj)
    {
        if (Obj.gameObject.name == "Player")
        {
            actualspeed = speed;
        }
    }
}
