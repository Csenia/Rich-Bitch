using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] private Animator _animatorFlag1;
    [SerializeField] private Animator _animatorFlag2;

    [SerializeField] private ParticleSystem _flagParticles1;
    [SerializeField] private ParticleSystem _flagParticles2;

    [SerializeField] private AudioClip _flagSound;

    private void Awake()
    {
        _animatorFlag1.enabled = false;
        _animatorFlag2.enabled = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _animatorFlag1.enabled = true;
            _animatorFlag2.enabled = true;
            if (_flagParticles1 != null)
            {
                _flagParticles1.Play();
            }
            if (_flagParticles2 != null)
            {
                _flagParticles2.Play();
            }
            if (_flagSound != null)
            {
                AudioSource.PlayClipAtPoint(_flagSound, transform.position);
            }
        }
    }
}
