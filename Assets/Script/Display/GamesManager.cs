using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class GamesManager : MonoBehaviour
{
    [Header("Timer")]
    public TextMeshProUGUI timerText;
    public float startTime;
    public float timerDuration;
    public static int Actualminutes;
    public static float elapsedTime;

    public static float nextfirerate1;
    public static float nextfirerate2;
    public static GameObject ParentWeapon1;
    public static GameObject ParentWeapon2;
    [Header("Timer Armi")]
    public GameObject ActualParentWeapon1;
    public GameObject ActualParentWeapon2;

    public static int ActualClass;
    [Header("Drop Craft")]
    public int TimerSwitchFromClass1;
    public int TimerSwitchFromClass2;
    public int TimerSwitchFromClass3;
    public int TimerSwitchFromClass4;

    [Header("Partita")]
    [SerializeField] private AnimatorController _animatorController;
    public PlayerHealth playerHealth;
    public GameObject TryMenu;
    public int Try;
    public int MaxAttempt;
    public GameObject Enemykiller;

    [Header("Monete")]
    public PlayFabManager playFabManager;
    public TextMeshProUGUI CoinText;
    public int StartCoin;
    public static int ActualCoin;

    int cont;

    private void Start()
    {
        ActualCoin = StartCoin;
        Try = 0;
        ParentWeapon1 = ActualParentWeapon1;
        ParentWeapon2 = ActualParentWeapon2;
        startTime = startTime / 2;
        timerDuration = timerDuration * 60;
    }

    private void Update()
    {
        elapsedTime = Time.time + startTime;
        if (elapsedTime <= timerDuration + 1)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(startTime + elapsedTime);
            Actualminutes = timeSpan.Minutes;
            string timeString = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            timerText.text = timeString;
        }

        if(startTime <= Actualminutes && Actualminutes < TimerSwitchFromClass1)
        {
            ActualClass = 1;
        }
        else if(TimerSwitchFromClass1 <= Actualminutes && Actualminutes < TimerSwitchFromClass2)
        {
            ActualClass = 2;
        }
        else if(TimerSwitchFromClass2 <= Actualminutes && Actualminutes < TimerSwitchFromClass3)
        {
            ActualClass = 3;
        }
        else if(TimerSwitchFromClass3 <= Actualminutes && Actualminutes <= TimerSwitchFromClass4)
        {
            ActualClass = 4;
        }

        if(Try <= MaxAttempt)
        {
            if (playerHealth.Death && playerHealth.Health <= 0)
            {
                if(cont == 0)
                {
                    cont += 1;
                    playFabManager.SendLeaderboard(EnemySpawn.EnemyKillCount);
                }
                Enemykiller.SetActive(true);
                TryMenu.SetActive(true);
            }
            else
            {
                cont = 0;
                Enemykiller.SetActive(false);
                TryMenu.SetActive(false);
            }
        }
        else
        {
            //Cambia Scena
        }

        //Debug.Log(playerHealth.Death);

        CoinText.text = ": " + ActualCoin.ToString();
    }

    public void Restart()
    {
        Try += 1;
        playerHealth.Health = playerHealth.MaxHealth;
        playerHealth.Death = false;
        _animatorController.RePlayIdle();
    }

    public void Exit()
    {
        
    }

    public void AddCoin(int CoinAmount)
    {
        ActualCoin += CoinAmount;
    }
}
