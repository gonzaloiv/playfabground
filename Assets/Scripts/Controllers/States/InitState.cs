using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            PlayerService.Login(Config.deviceId, OnLoginSuccess);
            mainMenuScreenController.Load();
            viewController.Init();
        }

        public void OnLoginSuccess () {
            PlayerService.GetPlayer(OnGetPlayerSuccess);
            DataService.GetAppData(OnGetAppInfoSuccess);
        }

        public void OnGetPlayerSuccess (Player player) {
            app.SetPlayer(player);
            app.player.data.IncreaseGamesCount();
            DataService.SetPlayerData(app.player.data);
            mainController.ToMainMenuState();
        }

        public void OnGetAppInfoSuccess (AppData appData) {
            app.SetInfo(appData);
            footerController.Show(app.data);
        }

        #endregion

    }

}