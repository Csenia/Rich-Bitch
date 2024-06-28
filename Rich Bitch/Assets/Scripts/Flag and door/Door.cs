using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private Animator _animatorDoor1;
    [SerializeField] private Animator _animatorDoor2;

    [SerializeField] private ParticleSystem _doorParticles1;
    [SerializeField] private AudioClip _doorSound;

    [SerializeField] private GameObject _nextLevel;

    private void Awake()
    {
        _animatorDoor1.enabled = false;
        _animatorDoor2.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animatorDoor1.enabled = true;
            _animatorDoor2.enabled = true;
            if (_doorParticles1 != null)
            {
                _doorParticles1.Play();
            }
            if (_doorSound != null)
            {
                AudioSource.PlayClipAtPoint(_doorSound, transform.position);
            }

            _nextLevel.SetActive(true);
        }
    }
}
