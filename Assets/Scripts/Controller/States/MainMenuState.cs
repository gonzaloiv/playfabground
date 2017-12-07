using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace States {

    public class MainMenuState : BaseState {

        #region Public Behaviour

        public MainMenuState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            mainMenuScreenController.Show();
        }

        public override void Exit () {
            base.Exit();
            mainMenuScreenController.Hide();
        }

        public void OnToTimerScreenButtonClickEvent (object sender, EventArgs e) {
            mainController.ToTimerState();
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            MainMenuScreenController.ToTimerScreenButtonClickEvent += OnToTimerScreenButtonClickEvent;
        }

        protected override void RemoveListeners () {
            MainMenuScreenController.ToTimerScreenButtonClickEvent -= OnToTimerScreenButtonClickEvent;
        }

        #endregion

    }

}