using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject target;
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody enemyRigidbody = GetComponent<Rigidbody>();
        Vector3 vectorTotarget = target.transform.position - transform.position;
        enemyRigidbody.velocity = vectorTotarget.normalized * enemySpeed;
    }
}
