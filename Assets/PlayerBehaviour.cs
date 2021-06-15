using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;

    Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.velocity = direction * speed;

        Vector3 lookAtPosition = transform.position + direction;

        transform.LookAt(lookAtPosition);
        
        if (Input.GetButton("Fire1"))
        {
            Instantiate(bulletPrefab, transform.position + transform.forward *1.5f, transform.rotation);
        }
    }
}
