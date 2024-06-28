using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float limitValue = 1;
    [SerializeField] private ParticleSystem coinParticle;
    
    private void Awake()
    {
        
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            MovePlayer();
        }
    }

    private void MovePlayer()
    {
        float halfScreen = Screen.width / 2;
        float xPos = (Input.mousePosition.x - halfScreen) / halfScreen;
        float finalXPosition = xPos * limitValue;
        playerTransform.localPosition = new Vector3(0, 0, finalXPosition);
    }
}
