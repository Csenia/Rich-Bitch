using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BotleCollector : MonoBehaviour
{
    public static BotleCollector Instance { get; private set; }


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

   
}
