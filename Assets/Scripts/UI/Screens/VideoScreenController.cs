using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VideoScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private VideoPlayerController videoPlayerController;
    [SerializeField] private ToggleGroupController videoToggleGroupController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        videoPlayerController.Init();
        videoToggleGroupController.Init();
    }

    public override void Show () {
        base.Show();
        videoPlayerController.Show();
        videoToggleGroupController.Show();
    }

    public override void Hide () {
        base.Hide();
        videoPlayerController.Hide();
        videoToggleGroupController.Hide();
    }

    public void OnToggleButtonClickEvent (int index) {
        switch (index) {
            case 0:
                videoPlayerController.Play();
                break;
            case 1:
                videoPlayerController.Stop();
                break;
        }
    }

    #endregion

    #region Protected Behaviour

    protected override void AddListeners () {
        ToggleGroupController.ToggleButtonClickEvent += OnToggleButtonClickEvent;
    }

    protected override void RemoveListeners () {
        ToggleGroupController.ToggleButtonClickEvent -= OnToggleButtonClickEvent;
    }

    #endregion

}
