using System.Collections;
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
    [SerializeField] private Button cloudButton;
    [SerializeField] private Button swipeButton;
    [SerializeField] private Button waitingButton;
    [SerializeField] private Button toggleButton;
    [SerializeField] private Button videoButton;

    #endregion

    #region Event

    public static event EventHandler TimerButtonClickEvent = delegate { };
    public static event EventHandler BlogButtonClickEvent = delegate { };
    public static event EventHandler LeaderboardButtonClickEvent = delegate { };
    public static event EventHandler JoystickButtonClickEvent = delegate { };
    public static event EventHandler CloudButtonClickEvent = delegate { };
    public static event EventHandler SwipeButtonClickEvent = delegate { };
    public static event EventHandler WaitingButtonClickEvent = delegate { };
    public static event EventHandler ToggleButtonClickEvent = delegate { };
    public static event EventHandler VideoButtonClickEvent = delegate { };

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        timerButton.onClick.AddListener(InvokeTimerButtonClickEvent);
        blogButton.onClick.AddListener(InvokeBlogButtonClickEvent);
        leaderboardButton.onClick.AddListener(InvokeLeaderboardButtonClickEvent);
        joystickButton.onClick.AddListener(InvokeJoystickButtonClickEvent);
        cloudButton.onClick.AddListener(InvokeCloudButtonClickEvent);
        swipeButton.onClick.AddListener(InvokeSwipeButtonClickEvent);
        waitingButton.onClick.AddListener(InvokeWaitingButtonEvent);
        toggleButton.onClick.AddListener(InvokeToggleButtonClickEvent);
        videoButton.onClick.AddListener(InvokeVideoButtonClickEvent);
    }

    public void Show (Player player) {
        base.Show();
        playerNameText.text = Config.deviceId.Substring(0, 5); // Should be the PlayFab display name loaded from the method GetPlayerCombinedInfo()
        bestTimeText.text = player.GetStatistic(StatisticType.HourTime).bestValue.ToString();
        rupeesText.text = player.GetCurrency(CurrencyCode.RP).amount.ToString();
    }

    public void InvokeTimerButtonClickEvent () {
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

    public void InvokeCloudButtonClickEvent () {
        CloudButtonClickEvent.Invoke(cloudButton, null);
    }

    public void InvokeSwipeButtonClickEvent () {
        SwipeButtonClickEvent.Invoke(swipeButton, null);
    }

    public void InvokeWaitingButtonEvent () {
        WaitingButtonClickEvent.Invoke(waitingButton, null);
    }

    public void InvokeToggleButtonClickEvent () {
        ToggleButtonClickEvent.Invoke(toggleButton, null);
    }

    public void InvokeVideoButtonClickEvent () {
        VideoButtonClickEvent.Invoke(videoButton, null);
    }

    #endregion

}
