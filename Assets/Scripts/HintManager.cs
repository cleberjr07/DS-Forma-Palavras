using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [Header("Variaveis de controle")]
    [SerializeField] private float[] _tempoParaDicas = new float[3];

    [Header("Debug variables Don't Change")]
    [SerializeField] private int _currentHintIndex = 0;
    [SerializeField] private bool _hintTimerRunning = false;
    [SerializeField] private float _hintTimer = 0f;

    public List<LetterBlock> LetterBlocks = new List<LetterBlock>();
    public List<LetterContainer> LetterContainers = new List<LetterContainer>();

    public static HintManager instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);   
        }


        // isso é só pra debug, deletar depois
        GetLetterBlocksAndContainers();
    }

    void Update()
    {
        if (_hintTimerRunning && _currentHintIndex < 3) // se for 3 é pq significa que todas as dicas ja foram tocadas
        {
            _hintTimer -= Time.deltaTime;

            if (_hintTimer <= 0) // caso o tempo de uma dica tenha chegado
            {
                switch(_currentHintIndex) // depois trocar para que de fato tenha as 3 dicas
                {
                    case 0:
                        Hint1();
                    break;
                    case 1:
                        Hint1();
                    break;
                    case 2:
                        Hint1();
                    break;
                }

                _currentHintIndex++;
                if (_currentHintIndex >= _tempoParaDicas.Length) // faz com que caso passe da última dica, começe denovo
                    _currentHintIndex = 0;

                _hintTimer = _tempoParaDicas[_currentHintIndex];
            }
        }
    }

    public void GetLetterBlocksAndContainers()
    {
        foreach(Transform child in GameObject.FindWithTag("LetterBlockMaster").transform)
        {
            if (child.CompareTag("LetterBlock"))
                LetterBlocks.Add(child.GetComponent<LetterBlock>());
        }

        foreach(Transform child in GameObject.FindWithTag("LetterContainerMaster").transform)
        {
            if (child.CompareTag("LetterContainer"))
                LetterContainers.Add(child.GetComponent<LetterContainer>());
        }
    }

    public void ResetHintTimer()
    {
        _hintTimer = _tempoParaDicas[_currentHintIndex];
    }

    public void ResetHintIndex()
    {
        _currentHintIndex = 0;
    }

    public void Hint1()
    {
        for (int i = 1; i <= 5; i++)
        {   
            foreach(LetterContainer lc in LetterContainers.Where(lc => lc.WordIndex == i))
            {
                if (lc.Matched == false)
                {
                    Debug.Log("A proxima letra não colocada é " + lc.Letter + " E ela fica na wordIndex " + lc.WordIndex);
                    return;
                }
            }
        }


        Debug.LogWarning("Nenhuma letra foi encontrada na FirstHint");
        // fazer com que na verdade a letra correspondente brilhe
    }
}
