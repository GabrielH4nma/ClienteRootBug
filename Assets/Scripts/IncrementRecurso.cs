using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrementRecurso : MonoBehaviour
{
    public int _coins; //agua

    public int _minerals = 10; 
    public int _sol =10;


    private float timer = 0f;
    public float delayAmount;

    [SerializeField] private int _coinsMultiplier;
    [SerializeField] public TMP_Text _coinsText;

    [SerializeField] public TMP_Text _mineralsText;
    [SerializeField] public TMP_Text _solText;


    [SerializeField] private GameObject _clickFX;
    [SerializeField] private RectTransform _buttonPosition;
    public GameObject botao;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            _coins = PlayerPrefs.GetInt("coins");
            _coinsText.text = _coins.ToString();
        }
        
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/



    public void IncrementCoins()
    {
        Vector3 particlePosition = botao.transform.position;
        particlePosition.z += 1;
        GameObject particleInstance = Instantiate(_clickFX, particlePosition, Quaternion.identity);
        _coins += _coinsMultiplier;
        PlayerPrefs.SetInt("coins", _coins);
        _coinsText.text = _coins.ToString();
        
    }
}
