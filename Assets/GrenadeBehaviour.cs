using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeBehaviour : MonoBehaviour
{
    public float grenadeSpeed;
    public float secondsUntilDestroyed;
    public GameObject deathEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody grenadeRigidbody = GetComponent<Rigidbody>();
        grenadeRigidbody.velocity = (transform.forward*0+transform.up) * grenadeSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDestroyed -= Time.deltaTime;

        if (secondsUntilDestroyed < 0)
        {
            if (deathEffectPrefab != null)
            {
                Instantiate(deathEffectPrefab, transform.position + Vector3.down * 0.5f, transform.rotation);
            }
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        if (deathEffectPrefab != null)
        {
            Instantiate(deathEffectPrefab, transform.position + Vector3.down * 0.5f, transform.rotation);
        }
        Destroy(gameObject);
    }
}
