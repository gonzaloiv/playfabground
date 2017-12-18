using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LoginScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private Button facebookButton;
    [SerializeField] private Button guestButton;

    #endregion

    #region Events

    public static event EventHandler FacebookButtonClickEvent;
    public static event EventHandler GuestButtonClickEvent;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        facebookButton.onClick.AddListener(InvokeFacebookButtonClickEvent);
        guestButton.onClick.AddListener(InvokeGuestButtonClickEvent);
    }

    public void InvokeFacebookButtonClickEvent () {
        FacebookButtonClickEvent.Invoke(facebookButton, null);
    }

    public void InvokeGuestButtonClickEvent () {
        GuestButtonClickEvent.Invoke(guestButton, null);
    }

    #endregion

}
