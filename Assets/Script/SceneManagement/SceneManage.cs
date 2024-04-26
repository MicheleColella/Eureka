using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    public void StartGame()
    {
        Loader.Load(Loader.Scene.GameplayScene);
    }
}
