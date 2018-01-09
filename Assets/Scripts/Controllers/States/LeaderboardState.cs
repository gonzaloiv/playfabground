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
                .Catch(error => leaderboardScreenController.HideGlobalLeaderboard());
            StatisticService.GetPlayerLeaderboard(StatisticType.HourTime.ToString(), 1)
                .Then(result => leaderboardScreenController.ShowPlayerLeaderboard(result))
                .Catch(error => leaderboardScreenController.HidePlayerLeaderboard());
            leaderboardScreenController.Load();
        }

        public override void Exit () {
            leaderboardScreenController.Hide();
        }

        #endregion

    }

}