using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class BaseState : State {

        #region Fields

        protected MainController mainController;
        protected ViewController viewController;
        protected LoginScreenController loginScreenController;
        protected MainMenuScreenController mainMenuScreenController;
        protected TimerScreenController timerScreenController;
        protected BlogScreenController blogScreenController;
        protected LeaderboardScreenController leaderboardScreenController;
        protected JoystickScreenController joystickScreenController;
        protected FooterController footerController;
        protected PopUpController popUpController;
        protected App app;

        #endregion

        #region Public Behaviour

        public BaseState (object parent) {
            this.mainController = (MainController) parent;
            this.viewController = mainController.viewController;
            this.loginScreenController = mainController.viewController.loginScreenController;
            this.mainMenuScreenController = mainController.viewController.mainMenuScreenController;
            this.timerScreenController = mainController.viewController.timerScreenController;
            this.blogScreenController = mainController.viewController.blogScreenController;
            this.leaderboardScreenController = mainController.viewController.leaderboardScreenController;
            this.joystickScreenController = mainController.viewController.joystickScreenController;
            this.footerController = mainController.viewController.footerController;
            this.popUpController = mainController.viewController.popUpController;
            this.app = mainController.app;
        }

        #endregion

    }

}
