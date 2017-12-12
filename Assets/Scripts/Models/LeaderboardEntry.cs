using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class LeaderboardEntry {

    #region Fields / Properties

    public int position;
    public string playFabID;
    public string displayName;
    public int value; // This is mesured in seconds

    #endregion

    #region Public Behaviour

    public LeaderboardEntry(int position, string playFabID, string displayName, int value) {
        this.position = position;
        this.playFabID = playFabID;
        this.displayName = displayName;
        this.value = value;
    }

    #endregion

}