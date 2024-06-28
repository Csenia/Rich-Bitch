using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip _collectSound;
    [SerializeField] private ParticleSystem _coinParticles;

    [SerializeField] private float _changeSpeed = 1.0f;
    [SerializeField] private float _minScale = 0.1f;
    

    private Vector3 _originalScale;
    private bool _isShrinking = true;

    private void Start()
    {
        _originalScale = transform.localScale;
        StartCoroutine(ScaleCoin());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector.Instance.CollectCoin();

            if (_collectSound != null)
            {
                AudioSource.PlayClipAtPoint(_collectSound, transform.position);
            }
            if (_coinParticles != null)
            {
                _coinParticles.Play();
            }
            print("—бор монет");
            Destroy(gameObject);
        }
    }

    private IEnumerator ScaleCoin()
    {
        while (true)
        {
            if (_isShrinking)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _minScale, _changeSpeed * Time.deltaTime);
                if (transform.localScale.x - 0.1f <= _minScale )
                {
                    _isShrinking = false;
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * _originalScale.x, _changeSpeed * Time.deltaTime);
                if (transform.localScale.x +0.1f >= _originalScale.x)
                {
                    _isShrinking = true;
                }
            }
            yield return null;
        }
    }
}
