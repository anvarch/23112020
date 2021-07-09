using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;
    public float secondsUntilDestroyed;
    public float damage;
    Vector3 currentScale;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
        currentScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        secondsUntilDestroyed -= Time.deltaTime;

        transform.localScale = Mathf.Min(1, secondsUntilDestroyed)* currentScale;

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
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem!= null)
                theirHealthSystem.TakeDamage(damage);
            Destroy(gameObject);
        }

        
    }
}
