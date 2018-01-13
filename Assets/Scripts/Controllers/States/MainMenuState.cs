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
            mainMenuScreenController.Show(app.player);
            if (PrizeTableSystem.CanApply(app.player))
                PrizeTableSystem.Apply(app.player, OnPrizeTableSystemApply);
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

        public void OnLeaderboardButtonClickEvent (object sender, EventArgs e) {
            mainController.ToLeaderboardState();
        }

        public void OnJoystickButtonClickEvent (object sender, EventArgs e) {
            mainController.ToJoystickState();
        }

        public void OnCloudButtonClickEvent (object sender, EventArgs e) {
            mainController.ToCloudState();
        }

        public void OnSwipeButtonClickEvent (object sender, EventArgs e) {
            mainController.ToSwipeState();
        }

        public void OnWaitingButtonClickEvent (object sender, EventArgs e) {
            mainController.ToWaitingState();
        }

        public void OnToggleButtonClickEvent (object sender, EventArgs e) {
            mainController.ToToggleState();
        }

        public void OnVideoButtonClickEvent (object sender, EventArgs e) {
            mainController.ToVideoState();
        }

        public void OnPrizeTableSystemApply (Item prize) {
            popUpController.Show("You've got a prize\n" + prize.name);
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            MainMenuScreenController.TimerButtonClickEvent += OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent += OnBlogButtonClickEvent;
            MainMenuScreenController.LeaderboardButtonClickEvent += OnLeaderboardButtonClickEvent;
            MainMenuScreenController.JoystickButtonClickEvent += OnJoystickButtonClickEvent;
            MainMenuScreenController.CloudButtonClickEvent += OnCloudButtonClickEvent;
            MainMenuScreenController.SwipeButtonClickEvent += OnSwipeButtonClickEvent;
            MainMenuScreenController.WaitingButtonClickEvent += OnWaitingButtonClickEvent;
            MainMenuScreenController.ToggleButtonClickEvent += OnToggleButtonClickEvent;
            MainMenuScreenController.VideoButtonClickEvent += OnVideoButtonClickEvent;
        }

        protected override void RemoveListeners () {
            MainMenuScreenController.TimerButtonClickEvent -= OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent -= OnBlogButtonClickEvent;
            MainMenuScreenController.LeaderboardButtonClickEvent -= OnLeaderboardButtonClickEvent;
            MainMenuScreenController.JoystickButtonClickEvent -= OnJoystickButtonClickEvent;
            MainMenuScreenController.SwipeButtonClickEvent -= OnSwipeButtonClickEvent;
            MainMenuScreenController.WaitingButtonClickEvent -= OnWaitingButtonClickEvent;
            MainMenuScreenController.ToggleButtonClickEvent -= OnToggleButtonClickEvent;
            MainMenuScreenController.VideoButtonClickEvent -= OnVideoButtonClickEvent;
        }

        #endregion

    }

}