using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Timers;

public class TimerScreenController : ScreenController {

    #region Fields / Properties

    private const int SECOND = 1000;

    [SerializeField] private Text timerText;
    [SerializeField] private Button timerButton;

    private readonly Timer timer = new Timer(SECOND); // It could be also achieved with the class StopWatch
    private int seconds;
    private Player player;

    #endregion

    #region Events

    public delegate void TimerStopEventHandler (int time);
    public static event TimerStopEventHandler TimerStopEvent = delegate { };

    #endregion

    #region Mono Behaviour

    private void Update () {
        timerText.text = (seconds / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
    }

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        timer.Elapsed += delegate { seconds++; };
        timerButton.onClick.AddListener(OnTimerButtonClickEvent);
    }

    public void Show (Player player) {
        base.Show();
        this.player = player;
    }

    public override void Hide () {
        base.Hide();
        seconds = 0;
        timer.Enabled = false;
    }

    public void OnTimerButtonClickEvent () {
        timer.Enabled = !timer.Enabled;
        if (!timer.Enabled)
            TimerStopEvent.Invoke(seconds);
    }

    #endregion

}
