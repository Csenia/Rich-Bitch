using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BotleCollector : MonoBehaviour
{
    public static BotleCollector Instance { get; private set; }

    private const float Count = 0.1f;
    [SerializeField] private CoinCollector _coin;
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

    public void CollectBotle()
    {
        _coin.CoinCount--;
        _slider.value -= Count;
        _coin.UpdateCoinText();
    }

}
