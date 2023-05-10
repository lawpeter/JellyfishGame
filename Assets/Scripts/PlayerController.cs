using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip boop;

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
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
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
            playerAudio.Play(0);
        }

    }

    void DetermineRotation()
    {
        planktons = GameObject.FindGameObjectsWithTag("Plankton");
        distance = 10000;
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
