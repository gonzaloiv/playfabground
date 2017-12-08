using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            PlayerSystem.Login(Config.DeviceId, OnLoginSuccess);
            InitUI();
        }

        public void OnLoginSuccess () {
            DataSystem.GetAppInfo(OnGetAppInfoSuccess);
            StatisticsSystem.GetStatistic(StatisticType.Time, OnGetStatisticSuccess);
            VirtualCurrencySystem.GetVirtualCurrency(VirtualCurrencyCode.RP, player.SetRupees);
            PlayerSystem.GetPlayerInfo(OnGetPlayerInfoSuccess);
        }

        public void OnGetAppInfoSuccess (AppInfo appInfo) {
            app.SetInfo(appInfo);
            footerController.Show(app.info);
        }

        public void OnGetStatisticSuccess (int time) {
            player.SetBestTime(time);
            player.SetLastTime(time);
        }

        public void OnGetPlayerInfoSuccess (PlayerInfo info) {
            if (info != null)
                player.SetPlayerInfo(info);
            player.info.IncreaseGamesCount();
            PlayerSystem.SetPlayerInfo(player.info);
            mainController.ToMainMenuState();
        }

        #endregion

        #region Private Behaviour

        private void InitUI () {
            timerScreenController.Init();
            mainMenuScreenController.Init();
            blogScreenController.Init();
            leaderboardScreenController.Init();
            footerController.Init();
        }

        #endregion

    }

}