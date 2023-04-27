using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float verticalInput;
    private float horizontalInput;

    private Rigidbody playerRb;

    public float speed = 1.0f;

    private GameManager gameManager;

    private GameObject[] planktons;

    private float distance;
    private float tempDistance;
    private GameObject closestPlankton;
    private Transform closestPlanktonTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed, Space.World);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed, Space.World);

        DetermineRotation();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Plankton"))
        {
            Destroy(other.gameObject);
            gameManager.UpdateScore();
        }

    }

    void DetermineRotation()
    {
        planktons = GameObject.FindGameObjectsWithTag("Plankton");
        distance = Vector3.Distance(planktons[0].transform.position, playerRb.position);
        closestPlankton = planktons[0];
        closestPlanktonTransform = closestPlankton.transform;
        for (int i = 0; i < planktons.Length; i++)
        {
            tempDistance = Vector3.Distance(planktons[i].transform.position, playerRb.position);
            if (tempDistance < distance)
            {
                distance = tempDistance;
                closestPlankton = planktons[i];
                closestPlanktonTransform = closestPlankton.transform;
            }
        }
        transform.LookAt(closestPlanktonTransform);
    }
}
