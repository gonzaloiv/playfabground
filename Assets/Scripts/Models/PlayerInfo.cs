using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerInfo {

    #region Fields / Properties

    public enum FieldName {
        PreviousRupees,
        GamesCount
    }

    public int previousRupees;
    public int gamesCount;

    #endregion

    #region Public Behaviour

    public PlayerInfo () {
        this.previousRupees = 0;
        this.gamesCount = 0;
    }

    public PlayerInfo (int previousRupees, int gamesCount) {
        this.previousRupees = previousRupees;
        this.gamesCount = gamesCount;
    }

    public void SetPreviousRupees(int previousRupees) {
        this.previousRupees = previousRupees;
    }

    public void IncreaseGamesCount (int amount = 1) {
        this.gamesCount += amount;
    }

    #endregion

}
