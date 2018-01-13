using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BatteryReloadTask : Task {

    #region Fields / Properties

    protected new Action<int> OnTick;

    #endregion

    #region Public Behaviour

    public BatteryReloadTask (MonoBehaviour parent, Action<int> OnTick = null, Action OnComplete = null) : base(parent) {
        this.OnTick = OnTick;
        this.OnComplete = OnComplete;
    }

    public override void Run () {
        base.Run();
        parent.StartCoroutine(BatteryReloadRoutine());
    }

    #endregion

    #region Private Behaviour

    private IEnumerator BatteryReloadRoutine () {
        int count = 10;
        while (count >= 0) {
            yield return new WaitForSeconds(1);
            if (OnTick != null)
                OnTick(count);
            count--;
        }
        Dispose();
    }

    #endregion

}
