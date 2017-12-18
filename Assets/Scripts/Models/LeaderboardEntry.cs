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
    public int value; // This is measured in seconds
    public string avatarURL;
    public string city;

    #endregion

    #region Public Behaviour

    public LeaderboardEntry (int position, string playFabID, string displayName, int value, string avatarURL = null) {
        this.position = position;
        this.playFabID = playFabID;
        this.displayName = displayName;
        this.value = value;
    }

    public void SetAvatarURL (string avatarURL) {
        this.avatarURL = avatarURL;
    }

    public void SetCity (string city) {
        this.city = city;
    }

    #endregion

}