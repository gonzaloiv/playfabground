using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuScreenController : ScreenController {

    #region Fields / Properties

    [SerializeField] private Button timerButton;
    [SerializeField] private Button blogButton;

    #endregion

    #region Event

    public static event EventHandler TimerButtonClickEvent;
    public static event EventHandler BlogButtonClickEvent;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        timerButton.onClick.AddListener(InvokeTimerButtonClickEvent);
        blogButton.onClick.AddListener(InvokeBlogButtonClickEvent);
    }

    public void InvokeTimerButtonClickEvent() {
        TimerButtonClickEvent.Invoke(timerButton, null);
    }

    public void InvokeBlogButtonClickEvent () {
        BlogButtonClickEvent.Invoke(blogButton, null);
    }

    #endregion

}
