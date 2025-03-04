using UnityEngine;
using UnityEngine.EventSystems;

public class LetterBlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform _rect;
    private Vector2 _initialPosition;
    private GameObject _letterContainer;
    [SerializeField] private string _Letter = "A";
    [Header("Debug Variables - Don't alterate")]
    [SerializeField] private bool _isTouchingCorrectBlock = false;
    [SerializeField] private bool _isInCorrectPlace = false;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = _rect.localPosition;
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
            gameObject.transform.SetParent(_letterContainer.transform);
            _rect.position = _letterContainer.GetComponent<RectTransform>().position;
            _isInCorrectPlace = true;

            _letterContainer.tag = "Untagged"; // para evitar que mais de uma letra seja posta no mesmo letterContainer
        }
        else
            _rect.localPosition = _initialPosition;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_Letter))
        {
            _isTouchingCorrectBlock = true;
            _letterContainer = other.gameObject;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag(_Letter))
        {
            _isTouchingCorrectBlock = true;
            _letterContainer = other.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_Letter))
            _isTouchingCorrectBlock = false;
    }

}
