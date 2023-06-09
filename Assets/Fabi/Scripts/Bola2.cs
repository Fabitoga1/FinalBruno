using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola2 : MonoBehaviour
{

    public GameObject ball;
    public float force;

    Transform cameraTransform;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();

        }
        
    }

   void Shoot()
    {
        GameObject b = Instantiate(ball, cameraTransform.position, Quaternion.identity);
        Vector3 direction = cameraTransform.forward * force;
        b.GetComponent<Rigidbody>().AddForce(direction, ForceMode.Impulse);
        Destroy(b, 5.0f);
    }
}
