using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class LeaderboardState : BaseState {

        #region Public Behaviour

        public LeaderboardState (object parent) : base(parent) { }

        public override void Enter () {
            StatisticService.GetLeaderboard(StatisticType.HourTime.ToString())
                .Then(result => leaderboardScreenController.ShowGlobalLeaderboard(result))
                .Catch(error => mainController.ToMainMenuState());
            StatisticService.GetPlayerLeaderboard(StatisticType.HourTime.ToString())
                .Then(result => leaderboardScreenController.ShowPlayerLeaderboard(result))
                .Catch(error => mainController.ToMainMenuState());
            leaderboardScreenController.Load();
        }

        public override void Exit () {
            leaderboardScreenController.Hide();
        }

        #endregion

    }

}