using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private LeaderboardEntryPanelController globalLeaderboardEntryPanelController;
    [SerializeField] private LeaderboardEntryPanelController playerLeaderboardEntryPanelController;


    #endregion

    #region Public Behaviour

    public void ShowGlobalLeaderboard (List<LeaderboardEntry> leaderboardEntries) {
        base.Show();
        globalLeaderboardEntryPanelController.Show(leaderboardEntries[0]);
    }

    public void HideGlobalLeaderboard () {
        globalLeaderboardEntryPanelController.Hide();
    }

    public void ShowPlayerLeaderboard (List<LeaderboardEntry> leaderboardEntries) {
        base.Show();
        playerLeaderboardEntryPanelController.Show(leaderboardEntries[0]);
    }

    public void HidePlayerLeaderboard () {
        playerLeaderboardEntryPanelController.Hide();
    }

    #endregion

}