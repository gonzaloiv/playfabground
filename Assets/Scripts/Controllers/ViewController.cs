using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewController : MonoBehaviour {

    #region Fields / Properties

    public LoginScreenController loginScreenController;
    public MainMenuScreenController mainMenuScreenController;
    public TimerScreenController timerScreenController;
    public BlogScreenController blogScreenController;
    public LeaderboardScreenController leaderboardScreenController;
    public JoystickScreenController joystickScreenController;
    public CloudScreenController cloudScreenController;
    public SwipeScreenController swipeScreenController;
    public WaitingScreenController waitingScreenController;
    public ToggleScreenController toggleScreenController;
    public PopUpController popUpController;
    public FooterController footerController;

    #endregion

    #region Public Behaviour

    public void Init () {
        loginScreenController.Init();
        timerScreenController.Init();
        mainMenuScreenController.Init();
        blogScreenController.Init();
        leaderboardScreenController.Init();
        joystickScreenController.Init();
        cloudScreenController.Init();
        swipeScreenController.Init();
        waitingScreenController.Init();
        toggleScreenController.Init();
        footerController.Init();
        popUpController.Init();
    }

    #endregion

}
