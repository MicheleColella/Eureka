using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManage : MonoBehaviour
{

    public void ReturnHome()
    {
        Loader.Load(Loader.Scene.StartMenu);
    }
}
