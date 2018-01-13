using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Timers;

public class WaitingScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Text waitingTimeText;
    [SerializeField] private Button batteryButton;

    #endregion

    #region Events

    public delegate void BatteryReloadTaskCompletedEventHandler ();
    public static event BatteryReloadTaskCompletedEventHandler BatteryReloadTaskCompletedEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        batteryButton.onClick.AddListener(() => TaskSystem.RunOne(new BatteryReloadTask(TaskSystem.Instance, SetWaitingTimeText, InvokeBatteryReloadTaskCompletedEvent)));
    }

    public void SetWaitingTimeText (int count) {
        this.waitingTimeText.text = count.ToString();
    }

    public void InvokeBatteryReloadTaskCompletedEvent () {
        BatteryReloadTaskCompletedEvent.Invoke();
    }

    #endregion

}
