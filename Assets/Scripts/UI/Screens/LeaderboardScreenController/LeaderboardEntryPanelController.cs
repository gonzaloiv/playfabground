using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardEntryPanelController : UIController {

    #region Fields / Properties

    [SerializeField] private Image avatarImage;
    [SerializeField] private Text indexText;
    [SerializeField] private Text displayNameText;
    [SerializeField] private Text statText;

    #endregion

    #region Private Behaviour

    public void Show (LeaderboardEntry leaderboardEntry) {
        base.Show();
        indexText.text = (leaderboardEntry.position + 1).ToString();
        displayNameText.text = string.IsNullOrEmpty(leaderboardEntry.displayName) ? leaderboardEntry.playFabID.Substring(0, 5) : leaderboardEntry.displayName;
        statText.text = leaderboardEntry.value.ToString();
        if (!string.IsNullOrEmpty(leaderboardEntry.avatarURL))
            StartCoroutine(SetLeaderboardEntryAvatarRoutine(leaderboardEntry.avatarURL));
    }

    private IEnumerator SetLeaderboardEntryAvatarRoutine (string avatarURL) {
        WWW www = new WWW(avatarURL);
        yield return www;
        Rect rect = new Rect(0, 0, avatarImage.rectTransform.rect.width, avatarImage.rectTransform.rect.height);
        avatarImage.sprite = Sprite.Create(www.texture, rect, new Vector2(0.5f, 0.5f), 100);
    }

    #endregion

}
