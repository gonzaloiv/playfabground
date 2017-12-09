using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Currency {

    #region Fields / Properties

    public CurrencyCode code;
    public int amount;

    #endregion

    #region Public Behaviour

    public Currency (CurrencyCode code, int amount) {
        this.code = code;
        this.amount = amount;
    }

    public void SetAmount(int amount) {
        this.amount = amount;
    }

    public void DecreaseAmount (int amount = 1) {
        this.amount -= amount;
    }

    #endregion

}