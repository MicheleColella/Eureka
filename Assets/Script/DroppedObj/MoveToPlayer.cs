using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToPlayer : MonoBehaviour
{
    public Transform Target;
    public float MinModifier;
    public float MaxModifier;
    public bool Touch;
    public float TimeDelayFollow;

    Vector3 _velocity = Vector3.zero;
    public bool _isFollowing = false;
    void Start()
    {
        Target = GameObject.Find("Player").GetComponent<Transform>();
        StartCoroutine(DelayFollow());
    }

    public void StartFollowing()
    {
        _isFollowing = true;
    }

    void FixedUpdate()
    {
        if (_isFollowing)
        {
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Touch = true;
            Destroy(gameObject, 0.01f);
        }
    }

    IEnumerator DelayFollow()
    {
        yield return new WaitForSeconds(TimeDelayFollow);
        _isFollowing = true;
    }
}
