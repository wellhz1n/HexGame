using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveClass
{
    public int BestScore = 0;
    public int Money = 0;

    public SaveClass(Global g)
    {
        BestScore = g.BestScore;
        Money = g.Money;
    }
}
