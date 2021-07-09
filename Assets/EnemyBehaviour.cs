using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (References.thePlayer != null)
        {
            Rigidbody enemyRigidbody = GetComponent<Rigidbody>();
            Vector3 vectorTotarget = References.thePlayer.transform.position - transform.position;
            enemyRigidbody.velocity = vectorTotarget.normalized * enemySpeed;
        }
    }

    private void OnCollisionEnter(Collision target)
    {
        GameObject theirGameObject = target.gameObject;

        if (theirGameObject.GetComponent<PlayerBehaviour>() != null)
        {
            HealthSystem theirHealthSystem = theirGameObject.GetComponent<HealthSystem>();
            if (theirHealthSystem != null)
                theirHealthSystem.TakeDamage(1);
        }


    }
}
