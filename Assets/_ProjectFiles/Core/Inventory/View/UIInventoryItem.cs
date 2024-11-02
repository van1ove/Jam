using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIInventoryItem : MonoBehaviour, IPointerDownHandler, IPointerMoveHandler, IPointerUpHandler
{
    [SerializeField] private Image itemImage;
    [SerializeField] private float returnDuration;
    private LevelItemInfo _levelItemInfo;
    
    private bool _isBeingDragged = false;
    private Vector2 _dragDelta;
    private Vector2 _origin;
    
    public void Initialize(LevelItemInfo levelItemInfo)
    {
        itemImage.sprite = levelItemInfo.ItemIcon;
        _levelItemInfo = levelItemInfo;
        _origin = transform.position;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _dragDelta = eventData.position - (Vector2)transform.position;
        
        _isBeingDragged = true;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        if (!_isBeingDragged) return;
        
        transform.position = eventData.position - _dragDelta;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlaceItem();
        _isBeingDragged = false;
    }

    private void PlaceItem()
    {
        transform.DOLocalMove(Vector3.zero, returnDuration);
    }
}