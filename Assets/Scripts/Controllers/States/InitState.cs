using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class InitState : BaseState {

        #region Public Behaviour

        public InitState (object parent) : base(parent) { }

        public override void Enter () {
            UserSystem.Login(Config.DeviceId, OnLoginSuccess);
            InitUI();
        }

        public void OnLoginSuccess () {
            DataSystem.GetAppInfo(OnGetAppInfoSuccess);
        }

        public void OnGetAppInfoSuccess (AppInfo appInfo) {
            app.SetInfo(appInfo);
            StatisticsSystem.GetStatistic(StatisticType.Time, OnGetStatisticSuccess);
            VirtualCurrencySystem.GetVirtualCurrency(VirtualCurrencyCode.RP, player.SetRupees);
            footerController.Show(app.info);
            mainController.ToMainMenuState();
        }

        public void OnGetStatisticSuccess (int time) {
            player.SetBestTime(time);
            player.SetLastTime(time);
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