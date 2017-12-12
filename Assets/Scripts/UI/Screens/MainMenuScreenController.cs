﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MainMenuScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Text playerNameText;
    [SerializeField] private Text bestTimeText;
    [SerializeField] private Text rupeesText;
    [SerializeField] private Button timerButton;
    [SerializeField] private Button blogButton;
    [SerializeField] private Button leaderboardButton;
    [SerializeField] private Button joystickButton;

    #endregion

    #region Event

    public static event EventHandler TimerButtonClickEvent;
    public static event EventHandler BlogButtonClickEvent;
    public static event EventHandler LeaderboardButtonClickEvent;
    public static event EventHandler JoystickButtonClickEvent;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        timerButton.onClick.AddListener(InvokeTimerButtonClickEvent);
        blogButton.onClick.AddListener(InvokeBlogButtonClickEvent);
        leaderboardButton.onClick.AddListener(InvokeLeaderboardButtonClickEvent);
        joystickButton.onClick.AddListener(InvokeJoystickButtonClickEvent);
    }

    public void Show(Player player){
        base.Show();
        playerNameText.text = Config.deviceId.Substring(0, 5); // Should be the PlayFab display name loaded from the method GetPlayerCombinedInfo()
        bestTimeText.text = player.GetStatistic(StatisticType.HourTime).bestValue.ToString();
        rupeesText.text = player.GetCurrency(CurrencyCode.RP).amount.ToString();
    }

    public void InvokeTimerButtonClickEvent() {
        TimerButtonClickEvent.Invoke(timerButton, null);
    }

    public void InvokeBlogButtonClickEvent () {
        BlogButtonClickEvent.Invoke(blogButton, null);
    }

    public void InvokeLeaderboardButtonClickEvent () {
        LeaderboardButtonClickEvent.Invoke(leaderboardButton, null);
    }

    public void InvokeJoystickButtonClickEvent () {
        JoystickButtonClickEvent.Invoke(joystickButton, null);
    }

    #endregion

}
