using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Image leaderboardEntryAvatarImage;
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

    private void ShowLeaderboardEntry (LeaderboardEntry leaderboardEntry) {
        leaderboardEntryDisplayNameText.text = string.IsNullOrEmpty(leaderboardEntry.displayName) ? leaderboardEntry.playFabID.Substring(0, 5) : leaderboardEntry.displayName;
        leaderboardEntryStatValueText.text = leaderboardEntry.value.ToString();
        StartCoroutine(SetLeaderboardEntryAvatarRoutine(leaderboardEntry.avatarURL));
    }

    private IEnumerator SetLeaderboardEntryAvatarRoutine (string avatarURL) {
        WWW www = new WWW(avatarURL);
        yield return www;
        Rect rect = new Rect(0, 0, leaderboardEntryAvatarImage.rectTransform.rect.width, leaderboardEntryAvatarImage.rectTransform.rect.height);
        leaderboardEntryAvatarImage.sprite = Sprite.Create(www.texture, rect, new Vector2(0.5f, 0.5f), 100);
    }

    #endregion

}