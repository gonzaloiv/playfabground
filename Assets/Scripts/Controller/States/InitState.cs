using UnityEngine;
using System.Collections;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            timerScreenController.Init();
            mainMenuScreenController.Init();
            mainController.ToMainMenuState();
        }

        #endregion

    }

}