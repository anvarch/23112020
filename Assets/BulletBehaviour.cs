using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;
    public float secondsUntilDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDestroyed -= Time.deltaTime;

        transform.localScale *= Mathf.Min(1, secondsUntilDestroyed);

        if (secondsUntilDestroyed < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        GameObject theirGameObject = target.gameObject;

        if (theirGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            Destroy(theirGameObject);
            Destroy(gameObject);
        }

        
    }
}
