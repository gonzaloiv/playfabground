using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using Facebook.Unity;

namespace States {

    public class LoginState : BaseState {

        #region Public Behaviour

        public LoginState (object parent) : base(parent) { }

        public override void Enter () {
            base.Enter();
            loginScreenController.Show();
        }

        public void OnFacebookButtonClickEvent (object sender, EventArgs e) {
            FB.Init(() => PlayerService.LoginWithFacebook().Then(() => OnLoginSuccess()));
            loginScreenController.Hide();
            mainMenuScreenController.Load();
        }

        public void OnGuestButtonClickEvent (object sender, EventArgs e) {
            PlayerService.LoginWithCustomID(Config.deviceId).Then(() => OnLoginSuccess());
            loginScreenController.Hide();
            mainMenuScreenController.Load();
        }

        public void OnLoginSuccess () {
            PlayerService.GetPlayer().Then((player) => {
                app.SetPlayer(player);
                app.player.data.IncreaseGamesCount();
                DataService.SetPlayerData(app.player.data);
                mainController.ToMainMenuState();
            }).Catch(error => Debug.Log(error.Message)); // Maybe there should be an error screen here.
            DataService.GetAppData().Then((appData) => {
                app.SetInfo(appData);
                footerController.Show(app.data);
            });
            if (FB.IsLoggedIn)
                PlayerService.GetFacebookPictureURL().Then(result => PlayerService.UpdatePlayerAvatarURL(result));
        }

        #endregion

        #region Protected Behaviour

        protected override void AddListeners () {
            LoginScreenController.FacebookButtonClickEvent += OnFacebookButtonClickEvent;
            LoginScreenController.GuestButtonClickEvent += OnGuestButtonClickEvent;
        }

        protected override void RemoveListeners () {
            LoginScreenController.FacebookButtonClickEvent -= OnFacebookButtonClickEvent;
            LoginScreenController.GuestButtonClickEvent -= OnGuestButtonClickEvent;
        }

        #endregion

    }

}