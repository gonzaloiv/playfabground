using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Facebook.Unity;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            mainMenuScreenController.Load();
            viewController.Init();
            if (Config.launchMode == LaunchMode.Production) {
                FB.Init(() => PlayerService.LoginWithFacebook().Then(() => OnLoginSuccess()));
            } else {
                PlayerService.LoginWithCustomID(Config.deviceId).Then(() => OnLoginSuccess());
            }
        }

        public void OnLoginSuccess () {
           PlayerService.GetPlayer().Then((player) => {
                app.SetPlayer(player);
                app.player.data.IncreaseGamesCount();
                DataService.SetPlayerData(app.player.data);
                mainController.ToMainMenuState();
            }).Catch((error) => Debug.Log(error.Message)); // This would lead to another log screen or similar
            DataService.GetAppData().Then((appData) => {
                app.SetInfo(appData);
                footerController.Show(app.data);
            });
        }

        #endregion

    }

}