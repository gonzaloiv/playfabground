using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            loginScreenController.Load();
            viewController.Init();
            mainController.ToLoginState();
        }

        #endregion

    }

}