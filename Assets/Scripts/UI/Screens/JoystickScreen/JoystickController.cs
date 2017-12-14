using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class JoystickController : UIController, IBeginDragHandler, IDragHandler, IEndDragHandler {

    #region Fields / Properties

    public float XOffSet { get { return (dragObject.rect.max.x / 3); } }
    public float YOffSet { get { return (dragObject.rect.max.y / 3); } }
    public float MaxXDistance { get { return dragArea.rect.max.x + XOffSet - dragObject.rect.max.x; } }
    public float MaxYDistance { get { return dragArea.rect.max.y + YOffSet - dragObject.rect.max.y; } }

    public RectTransform dragArea;
    public RectTransform dragObject;
    public float xAxis;
    public float yAxis;

    private Vector2 originalLocalPointerPosition;
    private Vector3 originalPanelLocalPosition;

    #endregion

    #region Mono Behaviour

    public void OnBeginDrag (PointerEventData data) {
        originalPanelLocalPosition = dragObject.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(dragArea, data.position, data.pressEventCamera, out originalLocalPointerPosition);
    }

    public void OnDrag (PointerEventData data) {
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(dragArea, data.position, data.pressEventCamera, out localPointerPosition)) {
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            dragObject.localPosition = originalPanelLocalPosition + offsetToOriginal;
        }
        ClampToArea();
        UpdateAxis(originalPanelLocalPosition - dragObject.localPosition);
    }

    public void OnEndDrag(PointerEventData data) {
        // dragObject.localPosition = originalPanelLocalPosition;
        UpdateAxis(Vector2.zero);
        dragObject.DOLocalMove(originalPanelLocalPosition, 0.3f).SetEase(Ease.OutBack);
    }

    #endregion

    #region Private Behaviour

    private void ClampToArea () {
        Vector3 pos = dragObject.localPosition;

        // This would be a solution for a squared area:

        // Vector3 minPosition = dragArea.rect.min - dragObject.rect.min;
        // Vector3 maxPosition = dragArea.rect.max - dragObject.rect.max;
        // pos.x = Mathf.Clamp(dragObject.localPosition.x, minPosition.x, maxPosition.x);
        // pos.y = Mathf.Clamp(dragObject.localPosition.y, minPosition.y, maxPosition.y);

        pos = Vector3.ClampMagnitude(dragObject.localPosition, MaxXDistance);

        dragObject.localPosition = pos;
    }

    private void UpdateAxis(Vector2 drag) {
        xAxis = -drag.x / MaxXDistance;
        yAxis = -drag.y / MaxYDistance;
    }

    #endregion

}


