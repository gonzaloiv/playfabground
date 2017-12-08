using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using States;

public class MainController : MonoBehaviour {

    #region Fields / Properties

    public MainMenuScreenController mainMenuScreenController;
    public TimerScreenController timerScreenController;
    public BlogScreenController blogScreenController;
    public LeaderboardScreenController leaderboardScreenController;
    public FooterController footerController;
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
        stateMachine.ChangeState<InitState>();
    }

    private void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            ToPreviousState();
    }

    #endregion

    #region Public Behaviour

    public void ToPreviousState() {
        stateMachine.Return();
    }

    public void ToMainMenuState () {
        stateMachine.ChangeState<MainMenuState>();
    }

    public void ToTimerState () {
        stateMachine.ChangeState<TimerState>();
    }

    public void ToBlogState () {
        stateMachine.ChangeState<BlogState>();
    }

    public void ToLeaderboardState () {
        stateMachine.ChangeState<LeaderboardState>();
    }

    #endregion

}
