using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    #region Fields / Properties

    public int bestTime;
    public int lastTime;

    #endregion

    #region Public Behaviour

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
