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

    public void Show (AppData appData) {
        base.Show();
        versionText.text = appData.version.ToString();
        authorText.text = appData.author;
        companyText.text = appData.company;
    }

    #endregion

}