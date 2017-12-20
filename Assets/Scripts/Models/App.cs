using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

[Serializable]
public class App {

    #region Fields / Properties

    public AppData data;
    public List<Post> posts;
    public Player player = new Player();

    #endregion

    #region Public Behaviour

    public void SetInfo (AppData data) {
        this.data = data;
    }

    public void SetPosts (List<Post> posts) {
        this.posts = posts;
    }

    public void SetPlayer(Player player) {
        this.player = player;
    }

    #endregion

}