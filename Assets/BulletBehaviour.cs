using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody bulletRigidbody = GetComponent<Rigidbody>();
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision target)
    {
        GameObject theirGameObject = target.gameObject;

        if (theirGameObject.GetComponent<EnemyBehaviour>() != null)
        {
            Destroy(theirGameObject);
        }

        Destroy(gameObject);
    }
}
