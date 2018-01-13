using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class ToggleState : BaseState {

        #region Public Behaviour

        public ToggleState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            toggleScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            toggleScreenController.Hide();
        }

        #endregion

    }

}