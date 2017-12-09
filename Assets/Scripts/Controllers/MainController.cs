using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using States;

public class MainController : MonoBehaviour {

    #region Fields / Properties

    public ViewController viewController;
    public App app;
    private readonly StateMachine stateMachine = new StateMachine();

    #endregion

    #region Mono Behaviour

    private void Awake () {
        app = new App();
        Config.Init(Resources.Load("Config") as ConfigData);
        stateMachine.Register(new InitState(this));
        stateMachine.Register(new MainMenuState(this));
        stateMachine.Register(new TimerState(this));
        stateMachine.Register(new BlogState(this));
        stateMachine.Register(new LeaderboardState(this));
    }

    private void Start () {
        stateMachine.NextState<InitState>();
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToPreviousState();
    }

    #endregion

    #region Public Behaviour

    public void ToPreviousState () {
        stateMachine.PreviousState();
    }

    public void ToMainMenuState () {
        stateMachine.NextState<MainMenuState>();
    }

    public void ToTimerState () {
        stateMachine.NextState<TimerState>();
    }

    public void ToBlogState () {
        stateMachine.NextState<BlogState>();
    }

    public void ToLeaderboardState () {
        stateMachine.NextState<LeaderboardState>();
    }

    #endregion

}
