using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class AppInfo {

    #region Fields / Properties

    public string version;
    public string author;
    public string company;

    #endregion

    #region Public Behaviour 

    public AppInfo (string version, string author, string company) {
        this.version = version;
        this.author = author;
        this.company = company;
    }

    #endregion

}
