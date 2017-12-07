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
        protected FooterController footerController;
        protected App app { get { return mainController.app; } }
        
        #endregion
        
        #region Public Behaviour
        
        public BaseState (object parent) {
            this.mainController = (MainController) parent;
            this.mainMenuScreenController = mainController.mainMenuScreenController;
            this.timerScreenController = mainController.timerScreenController;
            this.blogScreenController = mainController.blogScreenController;
            this.footerController = mainController.footerController;
        }
        
        #endregion
        
    }

}
