using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using States;

public class MainController : MonoBehaviour {

    #region Fields / Properties

    public App app;
    public ViewController viewController;
    private readonly StateMachine stateMachine = new StateMachine();

    #endregion

    #region Mono Behaviour

    private void Awake () {
        app = new App();
        Config.Init(Resources.Load("Config") as ConfigData);
        stateMachine.Register(new InitState(this));
        stateMachine.Register(new LoginState(this));
        stateMachine.Register(new MainMenuState(this));
        stateMachine.Register(new TimerState(this));
        stateMachine.Register(new BlogState(this));
        stateMachine.Register(new LeaderboardState(this));
        stateMachine.Register(new JoystickState(this));
        stateMachine.Register(new CloudState(this));
        stateMachine.Register(new SwipeState(this));
        stateMachine.Register(new WaitingState(this));
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

    public void ToLoginState () {
        stateMachine.NextState<LoginState>();
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

    public void ToJoystickState () {
        stateMachine.NextState<JoystickState>();
    }

    public void ToCloudState () {
        stateMachine.NextState<CloudState>();
    }

    public void ToSwipeState () {
        stateMachine.NextState<SwipeState>();
    }

    public void ToWaitingState () {
        stateMachine.NextState<WaitingState>();
    }

    #endregion

}
