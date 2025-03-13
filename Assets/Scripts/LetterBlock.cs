using UnityEngine;
using UnityEngine.EventSystems;

public class LetterBlock : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform _rect;
    private Vector2 _initialPosition;
    private GameObject _letterContainer;

    [Header("Variaveis de Configuração")]
    public string Letter = "A";
    public bool Matched = false;


    [Header("Debug Variables - Don't alterate")]
    [SerializeField] private bool _isTouchingCorrectBlock = false;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _initialPosition = _rect.localPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (Matched)
            return;

        _rect.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (Matched)
            return;

        if (!_isTouchingCorrectBlock)
        {
            _rect.localPosition = _initialPosition;
            return;
        }

        gameObject.transform.SetParent(_letterContainer.transform); // prende a letra no container
        _rect.position = _letterContainer.GetComponent<RectTransform>().position; // prende a letra no seu container
        Matched = true;

        _letterContainer.tag = "Untagged"; // para evitar que mais de uma letra seja posta no mesmo letterContainer
        _letterContainer.GetComponent<LetterContainer>().Matched = true; // coloca o container como completo


        HintManager.instance.ResetHintTimer(); // reseta o timer pra dicas, já que o jogador conseguiu acertar uma das letras
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        LetterCheck(other.gameObject, true);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        LetterCheck(other.gameObject, true);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        LetterCheck(other.gameObject, false);
    }

    private void LetterCheck(GameObject other, bool entering)
    {
        if (!other.CompareTag("LetterContainer"))
            return;

        LetterContainer lt = other.GetComponent<LetterContainer>();
        if (lt == null || lt.Letter != Letter)
            return;

        _letterContainer = entering ? other : null;
        _isTouchingCorrectBlock = entering;
    }

}
