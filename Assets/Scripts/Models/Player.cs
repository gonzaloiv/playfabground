using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Player {

    #region Fields / Properties

    public PlayerInfo info = new PlayerInfo();
    public int rupees;
    public int bestTime;
    public int lastTime;

    #endregion

    #region Public Behaviour

    public void SetPlayerInfo (PlayerInfo info) {
        this.info = info;
    }

    public void SetRupees(int amount) {
        this.rupees = amount;
    }

    public void DecreaseRupees(int amount = 1) {
        this.rupees -= amount;
    }

    public void SetLastTime(int time) {
        this.lastTime = time;
    }

    public bool IsBestTime(int time) {
        return time > bestTime;
    }

    public void SetBestTime(int time) {
        this.bestTime = time;
    }

    #endregion

}
