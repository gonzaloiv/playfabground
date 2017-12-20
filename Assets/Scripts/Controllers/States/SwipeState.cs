using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class SwipeState : BaseState {

        #region Public Behaviour

        public SwipeState (object parent) : base(parent) { }

        public override void Enter () {
            swipeScreenController.Show();
        }

        public override void Exit () {
            swipeScreenController.Hide();
        }

        #endregion

    }

}