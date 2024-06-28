using System.Collections;
using UnityEngine;

public class Botle : MonoBehaviour
{
    [SerializeField] private AudioClip _botleSound;
    [SerializeField] private ParticleSystem _botleParticles;

    [SerializeField] private float _changeSpeed = 1.0f;
    [SerializeField] private float _minScale = 0.1f;


    private Vector3 _originalScale;
    private bool _isShrinking = true;

    private void Start()
    {
        _originalScale = transform.localScale;
        StartCoroutine(ScaleBotle());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            BotleCollector.Instance.CollectBotle();

            if (_botleSound != null)
            {
                AudioSource.PlayClipAtPoint(_botleSound, transform.position);
            }
            if (_botleParticles != null)
            {
                _botleParticles.Play();
            }
            print("—бор бутылки");
            Destroy(gameObject);
        }
    }

    private IEnumerator ScaleBotle()
    {
        while (true)
        {
            if (_isShrinking)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _minScale, _changeSpeed * Time.deltaTime);
                if (transform.localScale.x - 0.1f <= _minScale)
                {
                    _isShrinking = false;
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _originalScale.x, _changeSpeed * Time.deltaTime);
                if (transform.localScale.x + 0.1f >= _originalScale.x)
                {
                    _isShrinking = true;
                }
            }
            yield return null;
        }
    }
}
