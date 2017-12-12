using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class JoystickState : BaseState {

        #region Public Behaviour

        public JoystickState (object parent) : base(parent) { }

        public override void Enter () {
            joystickScreenController.Show();
        }

        public override void Exit () {
            joystickScreenController.Hide();
        }

        #endregion

    }

}