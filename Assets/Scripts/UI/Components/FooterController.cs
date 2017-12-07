using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FooterController : UIController {

    #region Fields / Properties

    [SerializeField] private Text versionText;
    [SerializeField] private Text authorText;
    [SerializeField] private Text companyText;

    #endregion

    #region Public Behaviour

    public void Show (AppInfo appInfo) {
        base.Show();
        versionText.text = appInfo.version.ToString();
        authorText.text = appInfo.author;
        companyText.text = appInfo.company;
    }

    #endregion

}