using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {
    
    public class BaseState : State {
        
        #region Fields
        
        protected MainController mainController;
        protected MainMenuScreenController mainMenuScreenController;
        protected TimerScreenController timerScreenController;
        protected BlogScreenController blogScreenController;
        protected LeaderboardScreenController leaderboardScreenController;
        protected FooterController footerController;
        protected App app;
        protected Player player;
        
        #endregion
        
        #region Public Behaviour
        
        public BaseState (object parent) {
            this.mainController = (MainController) parent;
            this.mainMenuScreenController = mainController.mainMenuScreenController;
            this.timerScreenController = mainController.timerScreenController;
            this.blogScreenController = mainController.blogScreenController;
            this.leaderboardScreenController = mainController.leaderboardScreenController;
            this.footerController = mainController.footerController;
            this.app = mainController.app;
            this.player = app.player;
        }
        
        #endregion
        
    }

}
