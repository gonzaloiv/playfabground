using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using States;

public class MainController : MonoBehaviour {

    #region Fields / Properties

    public MainMenuScreenController mainMenuScreenController;
    public TimerScreenController timerScreenController;

    private readonly StateMachine stateMachine = new StateMachine();

    #endregion

    #region Mono Behaviour

    private void Awake () {
        stateMachine.Register(new InitState(this));
        stateMachine.Register(new MainMenuState(this));
        stateMachine.Register(new TimerState(this));
    }

    private void Start () {
        stateMachine.ChangeState<InitState>();
    }

    private void Update () {
        if (Input.GetKey(KeyCode.Escape))
            ToMainMenuState();
    }

    #endregion

    #region Public Behaviour

    public void ToMainMenuState () {
        stateMachine.ChangeState<MainMenuState>();
    }

    public void ToTimerState () {
        stateMachine.ChangeState<TimerState>();
    }

    #endregion

}
