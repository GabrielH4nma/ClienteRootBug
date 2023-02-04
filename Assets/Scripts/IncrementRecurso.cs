using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncrementRecurso : MonoBehaviour
{
    private int _coins;
    [SerializeField] private int _coinsMultiplier;
    [SerializeField] private TMP_Text _coinsText;
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
        Instantiate(_clickFX, botao.transform.position, Quaternion.identity);
        _coins += _coinsMultiplier;
        PlayerPrefs.SetInt("coins", _coins);
        _coinsText.text = _coins.ToString();
        
    }
}
