using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class PlayerData {

    #region Fields / Properties

    public enum FieldName { // C# 6's nameof(MyField) is not around...
        GamesCount
    }

    public int gamesCount;

    #endregion

    #region Public Behaviour

    public PlayerData (int gamesCount = 0) {
        this.gamesCount = gamesCount;
    }

    public void IncreaseGamesCount (int amount = 1) {
        this.gamesCount += amount;
    }

    #endregion

}
