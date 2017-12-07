using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuScreenController : ScreenController {

    #region Fields / Properties

    [SerializeField] private Button toTimerScreenButton;

    #endregion

    #region Event

    public static event EventHandler ToTimerScreenButtonClickEvent;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        toTimerScreenButton.onClick.AddListener(InvokeToTimerScreenButtonClickEvent);
    }

    public void InvokeToTimerScreenButtonClickEvent() {
        ToTimerScreenButtonClickEvent.Invoke(toTimerScreenButton, null);
    }

    #endregion

}
