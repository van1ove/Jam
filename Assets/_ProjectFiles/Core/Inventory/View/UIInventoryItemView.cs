using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItemView : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private float returnDuration;
    [SerializeField] private Color disabledColor;
    [SerializeField] private Color enabledColor;
    [SerializeField] private AnimationCurve scalePerDistance;
    
    private bool _dragEnabled;
    private bool _isBeingDragged;
    private Vector2 _dragDelta;
    private PointerEventData _eventData;
    private Image _itemImage;
    
    public void Update()
    {
        ScaleToDistance();
        if (_eventData == null) return;
        
        transform.position = _eventData.position - _dragDelta;
    }

    public void Initialize(Image itemImage, Sprite itemSprite)
    {
        _itemImage = itemImage;
    }
    
    private void ScaleToDistance()
    {
        float currentDistance = transform.localPosition.magnitude;
        transform.localScale = Vector3.one * scalePerDistance.Evaluate(currentDistance);
    }

    public void Enable()
    {
        _itemImage.color = enabledColor;
        _dragEnabled = true;
    }

    public void Disable()
    {
        _itemImage.color = disabledColor;
        _dragEnabled = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_dragEnabled) return;
        _eventData = eventData;
        
        _dragDelta = eventData.position - (Vector2)transform.position;
        _isBeingDragged = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_eventData == null) return;

        _eventData = null;
        PlaceItem();
        _isBeingDragged = false;
    }

    private void PlaceItem()
    {
        transform.DOLocalMove(Vector3.zero, returnDuration);
    }
}