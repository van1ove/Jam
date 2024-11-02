using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private float returnDuration;
    [SerializeField] private Color disabledColor;
    [SerializeField] private Color enabledColor;
    [SerializeField] private AnimationCurve scalePerDistance;
    [SerializeField] private float scaleGrowSpeed;
    private LevelItemInfo _levelItemInfo;

    private bool _dragEnabled;
    private bool _isBeingDragged;
    private Vector2 _dragDelta;
    private PointerEventData _eventData;
    
    public void Update()
    {
        if (_eventData == null) return;
        
        transform.position = _eventData.position - _dragDelta;
        ScaleToDistance();
    }

    private void ScaleToDistance()
    {
        float currentDistance = transform.localScale.magnitude / scaleGrowSpeed;
        transform.localScale = Vector3.one * scalePerDistance.Evaluate(currentDistance);
    }
    
    public void Initialize(LevelItemInfo levelItemInfo)
    {
        itemImage.sprite = levelItemInfo.ItemIcon;
        _levelItemInfo = levelItemInfo;
    }

    public void Enable()
    {
        itemImage.color = enabledColor;
        _dragEnabled = true;
    }

    public void Disable()
    {
        itemImage.color = disabledColor;
        _dragEnabled = false;
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
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