using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemiesToSpawn;
    [SerializeField] float MaxDistance;
    [SerializeField] float MinDistance;
    [SerializeField] int MaxEnemy;
    [SerializeField] float TimeSpawn;
    private Transform Playerpos;
    private bool Canspawn;
    public List<GameObject> ActiveEnemy;
    public TextMeshProUGUI EnemyTextKillCount;
    public static int EnemyKillCount;

    void Start()
    {
        Canspawn = true;
        Playerpos = GameObject.Find("Player").GetComponent<Transform>();
        //InvokeRepeating("SpawnNow", 1, TimeSpawn);
        StartCoroutine(EnemySpawner());
    }

    private void Update()
    {
        EnemyTextKillCount.text = EnemyKillCount.ToString();
        if (Canspawn && ActiveEnemy.Count < MaxEnemy)
        {
            StartCoroutine(EnemySpawner());
        }

        for (var i = ActiveEnemy.Count - 1; i > -1; i--)
        {
            if (ActiveEnemy[i] == null)
                ActiveEnemy.RemoveAt(i);
        }
    }

    Vector3 getRandomPos()
    {
        float x = Random.Range(-MaxDistance, MaxDistance);
        if(x < MinDistance && x >= 0)
        {
            x = MinDistance;
        }
        else if(x > -MinDistance && x <= 0)
        {
            x = -MinDistance;
        }
        float y = 0f;
        float z = Random.Range(-MaxDistance, MaxDistance);
        if (z < MinDistance && z >= 0)
        {
            z = MinDistance;
        }
        else if (z > -MinDistance && z <= 0)
        {
            z = -MinDistance;
        }

        Vector3 newPos = Playerpos.position + new Vector3(x, y, z);
        return newPos;
    }

    IEnumerator EnemySpawner()
    {
        Canspawn = false;
        yield return new WaitForSeconds(TimeSpawn);
        SpawnNow();
        Canspawn = true;
    }

    void SpawnNow()
    {
        var enemy = Instantiate(enemiesToSpawn[Random.Range(0, enemiesToSpawn.Length)], getRandomPos(), Quaternion.identity);
        ActiveEnemy.Add(enemy);
    }
}
