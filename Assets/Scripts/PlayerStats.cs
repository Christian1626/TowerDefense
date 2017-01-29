using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
    public static int Money;
    public static int Lives;
    public int startLives = 50;
    public int startMoney = 400;

    public static int Waves;
    

    void Start()
    {
        Lives = startLives;
        Money = startMoney;
        Waves = 0;
    }
}
