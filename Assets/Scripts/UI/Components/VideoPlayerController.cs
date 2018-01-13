using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoPlayerController : UIController {

    #region Fields / Properties

    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private UIController videoPanelController;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        videoPlayer.prepareCompleted += OnPrepareCompleted;
        videoPlayer.loopPointReached += OnLoopPointReached;
    }

    public override void Show () {
        base.Show();
        videoPanelController.Hide();
    }

    public override void Hide () {
        base.Hide();
        videoPanelController.Hide();
    }

    public void Play () {
        videoPanelController.Hide();
        videoPlayer.Prepare();
    }

    public void Stop () {
        videoPanelController.Hide();
        videoPlayer.Stop();
    }

    public void OnPrepareCompleted (VideoPlayer videoPlayer) {
        videoPanelController.Show();
        videoPlayer.Play();
    }

    public void OnLoopPointReached (VideoPlayer videoPlayer) {
        Stop();
    }

    #endregion

}
