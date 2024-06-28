using System.Collections;
using UnityEngine;

public class Botle : MonoBehaviour
{
    [SerializeField] private AudioClip botleSound;
    [SerializeField] private ParticleSystem botleParticles;

    [SerializeField] private float changeSpeed = 1.0f;
    [SerializeField] private float minScale = 0.1f;


    private Vector3 originalScale;
    private bool isShrinking = true;

    private void Start()
    {
        originalScale = transform.localScale;
        StartCoroutine(ScaleBotle());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            if (botleSound != null)
            {
                AudioSource.PlayClipAtPoint(botleSound, transform.position);
            }
            if (botleParticles != null)
            {
                botleParticles.Play();
            }
            print("—бор бутылки");
            Destroy(gameObject);
        }
    }

    private IEnumerator ScaleBotle()
    {
        while (true)
        {
            if (isShrinking)
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * minScale, changeSpeed * Time.deltaTime);
                if (transform.localScale.x - 0.1f <= minScale)
                {
                    isShrinking = false;
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(transform.localScale, Vector3.one * originalScale.x, changeSpeed * Time.deltaTime);
                if (transform.localScale.x + 0.1f >= originalScale.x)
                {
                    isShrinking = true;
                }
            }
            yield return null;
        }
    }
}
