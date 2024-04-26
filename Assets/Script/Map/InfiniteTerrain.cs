using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteTerrain : MonoBehaviour
{
    public GameObject[] Object;
    public List<Vector3> Offset;
    public float snap;
    public Transform trPlayer;
    public Renderer renderTerrain;
    public float speed;
    //float tempScroll;

    private void Start()
    {
        for(int i = 0; i < Object.Length; i++)
        {
            Offset.Add(new Vector3(Object[i].transform.position.x, 0, Object[i].transform.position.z));
        }
    }

    private void Update()
    {
        renderTerrain.material.mainTextureOffset = new Vector2(trPlayer.position.x, trPlayer.position.z) * speed;
        transform.position = new Vector3(trPlayer.position.x, transform.position.y, trPlayer.position.z);

        for(int i = 0; i < Object.Length; i++)
        {
            Vector3 pos = new Vector3(Mathf.Round(trPlayer.position.x / snap) * snap, Object[i].transform.position.y, Mathf.Round(trPlayer.position.z / snap) * snap);
            Object[i].transform.position = pos + Offset[i];
        }
    }
}
