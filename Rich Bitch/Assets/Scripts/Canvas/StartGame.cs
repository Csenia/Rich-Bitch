using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    [SerializeField] private PathFollower _pathFollower;
    [SerializeField] private GameObject _startGame;

    private void Awake()
    {
        _pathFollower.enabled = false;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0))
        {
            _pathFollower.enabled = true;
            _startGame.SetActive(false);
        }
    }
}
