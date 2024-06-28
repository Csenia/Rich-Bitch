using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    public static CoinCollector Instance { get; private set; }

    private const float Count = 0.1f;
    [HideInInspector] public int CoinCount = 0;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectCoin()
    {
        CoinCount++;
        _slider.value += Count;
        UpdateCoinText();
    }

    public void UpdateCoinText()
    {
        if (_coinText != null)
        {
            _coinText.text = " " + CoinCount;
        }
    }
}
