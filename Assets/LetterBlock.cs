using UnityEngine;
using UnityEngine.EventSystems;

public class LetterBlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform _rect;
    private Vector2 _initialPosition;
    private Vector2 _letterContainerPos;
    [SerializeField] private string _Letter = "A";
    [Header("Debug Variables - Don't alterate")]
    [SerializeField] private bool _isTouchingCorrectBlock = false;
    [SerializeField] private bool _isInCorrectPlace = false;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = transform.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (_isInCorrectPlace)
            return;

        _rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_isInCorrectPlace)
            return;

        if (_isTouchingCorrectBlock)
        {
            _rect.localPosition = _letterContainerPos;
            _isInCorrectPlace = true;
        }
        else
            _rect.anchoredPosition = _initialPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_Letter))
        {
            _isTouchingCorrectBlock = true;
            _letterContainerPos = other.transform.localPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_Letter))
            _isTouchingCorrectBlock = false;
    }

}
