using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float verticalInput;
    private float horizontalInput;

    private Rigidbody playerRb;

    public float speed = 1.0f;
    

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plankton"))
        {
            Destroy(other.gameObject);
        }
    }
}
