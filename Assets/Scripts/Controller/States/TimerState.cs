using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class TimerState : BaseState {

        #region Public Behaviour

        public TimerState (object parent) : base(parent) { }

        public override void Enter () {
            timerScreenController.Show();
        }

        public override void Exit () {
            timerScreenController.Hide();
        }

        #endregion

    }

}