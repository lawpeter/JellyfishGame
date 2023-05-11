using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public AudioClip boop;

    private float verticalInput;
    private float horizontalInput;
    private bool isGameActive;

    private Rigidbody playerRb;

    public float speed = 1.0f;

    private GameManager gameManager;

    private GameObject[] planktons;
    private GameObject Jellyfish;
    private Vector3 scale;

    public Button speedButton;
    public Button sizeButton;

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
        Jellyfish = GameObject.Find("Jellyfish");
        scale = new Vector3(1.5f, 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");

        if (ActiveGame())
        {
            transform.Translate(Vector3.forward * Time.deltaTime * verticalInput * speed, Space.World);
            transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed, Space.World);
        }
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

    public void IncreaseSize()
    {
        Jellyfish.transform.localScale = Vector3.Scale(Jellyfish.transform.localScale, scale);
        sizeButton.gameObject.SetActive(false);
        speedButton.gameObject.SetActive(false);
    }

    public void IncreaseSpeed() 
    {
        speed *= 2.0f;
        speedButton.gameObject.SetActive(false);
        sizeButton.gameObject.SetActive(false);
    }

    public bool ActiveGame()
    {
        if (sizeButton.gameObject.activeSelf)
        {
            return false;
        } else
        {
            return true;
        }
    }
}
