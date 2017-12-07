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

        public void OnTimerButtonClickEvent (object sender, EventArgs e) {
            mainController.ToTimerState();
        }

        public void OnBlogButtonClickEvent (object sender, EventArgs e) {
            mainController.ToBlogState();
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            MainMenuScreenController.TimerButtonClickEvent += OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent += OnBlogButtonClickEvent;
        }

        protected override void RemoveListeners () {
            MainMenuScreenController.TimerButtonClickEvent -= OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent -= OnBlogButtonClickEvent;
        }

        #endregion

    }

}