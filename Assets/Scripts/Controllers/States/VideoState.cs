using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class VideoState : BaseState {

        #region Public Behaviour

        public VideoState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            videoScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            videoScreenController.Hide();
        }

        #endregion

    }

}