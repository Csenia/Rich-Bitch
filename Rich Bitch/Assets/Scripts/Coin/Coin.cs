using System.Collections;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private ParticleSystem coinParticles;

    [SerializeField] private float changeSpeed = 1.0f;
    [SerializeField] private float minScale = 0.1f;
    

    private Vector3 originalScale;
    private bool isShrinking = true;

    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(ScaleCoin());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CoinCollector.Instance.CollectCoin();

            if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }
            if (coinParticles != null)
            {
                coinParticles.Play();
            }
            print("—бор монет");
            Destroy(gameObject);
        }
    }

    private IEnumerator ScaleCoin()
    {
        while (true)
        {
            if (isShrinking)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * minScale, changeSpeed * Time.deltaTime);
                if (transform.localScale.x - 0.1f <= minScale )
                {
                    isShrinking = false;
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * originalScale.x, changeSpeed * Time.deltaTime);
                if (transform.localScale.x +0.1f >= originalScale.x)
                {
                    isShrinking = true;
                }
            }
            yield return null;
        }
    }
}
