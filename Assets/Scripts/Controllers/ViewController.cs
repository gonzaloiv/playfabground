﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    #region Fields / Properties

    public MainMenuScreenController mainMenuScreenController;
    public TimerScreenController timerScreenController;
    public BlogScreenController blogScreenController;
    public LeaderboardScreenController leaderboardScreenController;
    public JoystickScreenController joystickScreenController;
    public PopUpController popUpController;
    public FooterController footerController;

    #endregion

    #region Public Behaviour

    public void Init () {
        timerScreenController.Init();
        mainMenuScreenController.Init();
        blogScreenController.Init();
        leaderboardScreenController.Init();
        joystickScreenController.Init();
        footerController.Init();
        popUpController.Init();
    }

    #endregion

}
