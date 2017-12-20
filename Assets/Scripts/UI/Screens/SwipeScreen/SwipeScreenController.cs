using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwipeScreenController : BaseScreenController {

    #region Fields / Properties

    [SerializeField] private SwipePanelController swipePanelController;
    [SerializeField] private Text swipeText;

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        swipePanelController.Init();
    }

    public override void Show () {
        base.Show();
        swipePanelController.Show();
        SwipePanelController.SwipeEvent += OnSwipeEvent;
        swipeText.text = string.Empty;
    }

    public override void Hide () {
        base.Hide();
        swipePanelController.Hide();
        SwipePanelController.SwipeEvent -= OnSwipeEvent;
    }

    public void OnSwipeEvent (Direction direction) {
        swipeText.text = direction.ToString().ToLower();
    }

    #endregion

}