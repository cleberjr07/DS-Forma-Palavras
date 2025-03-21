using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    [Header("Variaveis de Configuração")]
    public string Letter = "A";
    public int WordIndex = 0;
    public int LetterIndex = 0;
    public bool Matched = false;

    #region Debug and Editor Stuff
    [SerializeField] TextMeshProUGUI _letterText;
    void OnValidate()
    {
        if (_letterText == null)
            _letterText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        _letterText.text = Letter;

        gameObject.name = Letter;
    }
    #endregion
}
