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
            if (app.player.inventory.HasPrizes)
                RewardPlayer();
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

        public void OnJoystickButtonClickEvent(object sender, EventArgs e) {
            mainController.ToJoystickState();
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            MainMenuScreenController.TimerButtonClickEvent += OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent += OnBlogButtonClickEvent;
            MainMenuScreenController.LeaderboardButtonClickEvent += OnLeaderboardButtonClickEvent;
            MainMenuScreenController.JoystickButtonClickEvent += OnJoystickButtonClickEvent;
        }

        protected override void RemoveListeners () {
            MainMenuScreenController.TimerButtonClickEvent -= OnTimerButtonClickEvent;
            MainMenuScreenController.BlogButtonClickEvent -= OnBlogButtonClickEvent;
            MainMenuScreenController.LeaderboardButtonClickEvent -= OnLeaderboardButtonClickEvent;
            MainMenuScreenController.JoystickButtonClickEvent -= OnJoystickButtonClickEvent;
        }

        #endregion

        #region Private Behaviour

        private void RewardPlayer () { // This could be a State by itself
            Item prize = app.player.inventory.Prizes[0];
            popUpController.Show("You've got a prize\n" + prize.name);
            ItemService.ConsumeItem(prize, 1, delegate {
                ItemService.GetInventory(app.player.SetInventory);
                CurrencyService.GetCurrency(CurrencyCode.RP, app.player.SetCurrency);
            });
        }

        #endregion

    }

}