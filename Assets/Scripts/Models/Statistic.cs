using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Statistic {

    #region Fields / Properties

    public StatisticType type;
    public int bestValue = 0;
    public int lastValue = 0;

    #endregion

    #region Public Behaviour

    public Statistic (StatisticType type, int value = 0) {
        this.type = type;
        this.bestValue = value;
    }

    public void SetLastValue (int value) {
        this.lastValue = value;
    }

    public bool IsBestValue (int value) {
        return value > bestValue && bestValue > 0;
    }

    public void SetBestValue (int value) {
        this.bestValue = value;
    }

    #endregion

}