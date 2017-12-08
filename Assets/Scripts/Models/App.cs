using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class App {

    #region Fields / Properties

    public AppInfo info;
    public List<Post> posts;
    public List<LeaderboardEntry> leaderboardEntries; // This could located inside LeaderboardState...
    public Player player = new Player();

    #endregion

    #region Public Behaviour

    public void SetInfo (AppInfo info) {
        this.info = info;
    }

    public void SetPosts (List<Post> posts) {
        this.posts = posts;
    }

    public void SetLeaderboardEntries (List<LeaderboardEntry> leaderboardEntries) {
        this.leaderboardEntries = leaderboardEntries;
    }

    #endregion

}