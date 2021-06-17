using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public float secondsBetweenShots;

    float secondsSinceLastShot;

    // Start is called before the first frame update
    void Start()
    {
        secondsSinceLastShot = secondsBetweenShots;
    }

    // Update is called once per frame
    void Update()
    {
        //WASD to move
        Vector3 inputVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Rigidbody ourRigidbody = GetComponent<Rigidbody>();
        ourRigidbody.velocity = inputVector * speed;

        Ray rayFromCameraToCursor = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        playerPlane.Raycast(rayFromCameraToCursor, out float distanceFromCamera);
        Vector3 cursorPosition = rayFromCameraToCursor.GetPoint(distanceFromCamera);

        //Face the new position
        Vector3 lookAtPosition = cursorPosition;
        transform.LookAt(lookAtPosition);

        //Firing
        secondsSinceLastShot += Time.deltaTime;


        if (Input.GetButton("Fire1") && secondsSinceLastShot >= secondsBetweenShots)
        {
            Instantiate(bulletPrefab, transform.position + transform.forward *1.5f, transform.rotation);
            secondsSinceLastShot = 0;
        }
    }
}
