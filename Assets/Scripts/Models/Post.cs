using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Post {

    #region Fields / Properties

    public string id;
    public DateTime timestamp;
    public string title;
    public string body;

    #endregion

    #region Public Behaviour

    public Post (string id, DateTime timestamp, string title, string body) {
        this.id = id;
        this.timestamp = timestamp;
        this.title = title;
        this.body = body;
    }

    #endregion

}