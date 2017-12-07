using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class App {

    #region Fields / Properties

    public AppInfo info;
    public List<Post> posts;

    #endregion

    #region Public Behaviour

    public void SetInfo (AppInfo info) {
        this.info = info;
    }

    public void SetPosts (List<Post> posts) {
        this.posts = posts;
    }

    #endregion

}