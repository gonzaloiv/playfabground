using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace States {

    public class LeaderboardState : BaseState {

        #region Public Behaviour

        public LeaderboardState (object parent) : base(parent) { }

        public override void Enter () {
            StatisticsSystem.GetLeaderboard(StatisticType.Time.ToString().ToLower(), OnGetLeaderboardSuccess);
            if (app.leaderboardEntries == null) { // First time shows loader, rest of times, shows the already loaded entries
                leaderboardScreenController.Load();
            } else {
                leaderboardScreenController.Show(app.leaderboardEntries);
            }
        }

        public override void Exit () {
            leaderboardScreenController.Hide();
        }

        public void OnGetLeaderboardSuccess (List<LeaderboardEntry> leaderboardEntries) {
            if (leaderboardEntries == null) { // TODO: Should show a pop-up saying that the leaderboard is still empty
                mainController.ToMainMenuState();
            } else {
                app.leaderboardEntries = leaderboardEntries;
                leaderboardScreenController.Show(app.leaderboardEntries);
            }
        }


        #endregion

    }

}