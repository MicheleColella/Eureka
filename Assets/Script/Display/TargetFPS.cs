using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetFPS : MonoBehaviour
{

    public int targetFrameRate;
    public bool usetarget;

    [Range(0, 1)]
    public float Timescale;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        if(usetarget)
        {
            Application.targetFrameRate = targetFrameRate;
        }
        else
        {
            Application.targetFrameRate = Screen.currentResolution.refreshRate;
        }
    }

    private void FixedUpdate()
    {
        Time.timeScale = Timescale;
    }
}
