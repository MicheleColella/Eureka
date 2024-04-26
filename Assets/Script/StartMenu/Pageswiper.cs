using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pageswiper : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;
    public float percentThreshold = 0.2f;
    public float easing = 0.5f;
    public float distance;
    public float Height;
    public float min;
    public float max;

    public void OnDrag(PointerEventData data)
    {
        //Debug.Log(data.pressPosition - data.position);
        float difference = data.pressPosition.x - data.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);
    }

    public void OnEndDrag(PointerEventData data)
    {
        float percentage = (data.pressPosition.x - data.position.x) / Screen.width;
        if(Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLoaction = panelLocation;
            if(percentage > 0)
            {
                newLoaction += new Vector3(-distance, 0, 0);
                newLoaction.y = Height + (Screen.height / 2);
            }
            else if(percentage < 0)
            {
                newLoaction += new Vector3(distance, 0, 0);
                newLoaction.y = Height + (Screen.height / 2);
            }

            StartCoroutine(SmoothMove(transform.position, newLoaction, easing));
            panelLocation = newLoaction;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }

        //Debug.Log(panelLocation.x);
        if (panelLocation.x > min && panelLocation.x < max)
        {
            //Debug.Log("normal");
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
        else if (transform.position.x <= min)
        {
            //Debug.Log("Min");
            panelLocation.x = min;
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
        else
        {
            //Debug.Log("Max");
            panelLocation.x = max;
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));
        }
    }

    IEnumerator SmoothMove(Vector3 startpos, Vector3 endpos, float seconds)
    {
        float t = 0f;
        while(t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startpos, endpos, Mathf.SmoothStep(0f, 1f, t));
            transform.position = new Vector3(transform.position.x, Height, transform.position.z);
            yield return null;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, Height, transform.position.z);
    }
}
