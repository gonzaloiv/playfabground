using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScreenController : BaseScreenController  {

    #region Fields / Properties

    [SerializeField] private Text leaderboardEntryDisplayNameText;
    [SerializeField] private Text leaderboardEntryStatValueText;
    private List<LeaderboardEntry> leaderboardEntries;

    #endregion

    #region Public Behaviour

    public void Show (List<LeaderboardEntry> leaderboardEntries) {
        base.Show();
        this.leaderboardEntries = leaderboardEntries;
        ShowLeaderboardEntry(leaderboardEntries[0]);
    }

    #endregion

    #region Private Behaviour

    private void ShowLeaderboardEntry(LeaderboardEntry leaderboardEntry) {
        leaderboardEntryDisplayNameText.text = string.IsNullOrEmpty(leaderboardEntry.displayName) ? leaderboardEntry.playFabID.Substring(0, 5) : leaderboardEntry.displayName;
        leaderboardEntryStatValueText.text = leaderboardEntry.statValue.ToString();
    }

    #endregion

}