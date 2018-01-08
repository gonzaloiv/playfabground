using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class WaitingState : BaseState {

        #region Public Behaviour

        public WaitingState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            waitingScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            waitingScreenController.Hide();
        }

        public void OnBatteryReloadTaskCompletedEvent() {
            mainController.ToMainMenuState();
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            WaitingScreenController.BatteryReloadTaskCompletedEvent += OnBatteryReloadTaskCompletedEvent;
        }

        protected override void RemoveListeners () {
            WaitingScreenController.BatteryReloadTaskCompletedEvent -= OnBatteryReloadTaskCompletedEvent;
        }

        #endregion

    }

}