using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectMask2D))]
[RequireComponent(typeof(RectTransform))]
public class TextCarouselBehaviour : UIController {

    #region Fields / Properties

    [SerializeField] private Text carouselText;
    [SerializeField] private float textSpeed;
    private RectTransform rectTransform;

    #endregion

    #region Mono Behaviour

    private void FixedUpdate () {
        if (!string.IsNullOrEmpty(carouselText.text)) {
            if (carouselText.rectTransform.anchoredPosition.x < -carouselText.rectTransform.sizeDelta.x)
                carouselText.rectTransform.anchoredPosition = new Vector3(rectTransform.sizeDelta.x, 0, 0);
            carouselText.rectTransform.anchoredPosition -= new Vector2(textSpeed, 0);
        }
    }

    #endregion

    #region Public Behaviour

    public override void Init () {
        base.Init();
        rectTransform = GetComponent<RectTransform>();
    }

    public void Show (string text) {
        base.Show();
        carouselText.text = text;
    }

    public override void Hide () {
        base.Hide();
        carouselText.text = string.Empty;
    }

    #endregion

}
