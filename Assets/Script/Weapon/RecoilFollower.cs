using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecoilFollower : MonoBehaviour
{
    public Transform Recoil;
    public bool FollowRotation;
    public bool FollowPosition;
    public Vector3 StartPos;
    private bool MoveRec;
    private void Start()
    {
        StartPos = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (FollowPosition)
        {
            Recoil.position = transform.position;
        }

        if (FollowRotation)
        {
            Recoil.rotation = transform.rotation;
        }

        if (MoveRec)
        {
            Debug.Log("ER");
            transform.localPosition = Vector3.Lerp(transform.localPosition, StartPos, 0.1f);
        }
    }

    public void PlayRec()
    {
        StartCoroutine(startRec());
    }

    IEnumerator startRec()
    {
        yield return new WaitForSeconds(0.2f);
        MoveRec = true;
        yield return new WaitForSeconds(0.2f);
        MoveRec = false;
    }
}
