using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plankton : MonoBehaviour
{
    private float waterSpeed = 2.0f;
    private float waterPower = 0.1f;

    private float cameraHeight;
    private float cameraWidth;
    private float xRange;
    private float zRange;
    private float maxSpeed = 3.0f;

    private bool isGameActive;
    private GameObject button;

    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Jellyfish");
        cameraHeight = camera.orthographicSize * 2.0f;
        cameraWidth = cameraHeight * camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomMovement());
        xRange = cameraWidth / 2;
        zRange = cameraHeight / 2;
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
    }

    IEnumerator RandomMovement()
    {
        while(StayInBounds() && ActiveGame())
        {
            enemyRb.AddForce(GenerateRandomPower(), 0, GenerateRandomPower(), ForceMode.Impulse);
            yield return new WaitForSeconds(waterSpeed);
        }
        enemyRb.velocity = Vector3.zero;
    }
    
    float GenerateRandomPower()
    {
        return Random.Range(-waterPower, waterPower);
    }
    bool StayInBounds()
    {
        if (enemyRb.transform.position.x > player.transform.position.x + xRange + (transform.localScale.x / 2))
        {
            return false;
        }

        if (enemyRb.transform.position.x < player.transform.position.x - xRange - (transform.localScale.x / 2))
        {
            return false;
        }

        if (enemyRb.transform.position.z > player.transform.position.z + zRange + (transform.localScale.z / 2))
        {
            return false;
        }

        if (enemyRb.transform.position.z < player.transform.position.z - zRange - (transform.localScale.z / 2))
        {
            return false;
        }
        return true;
    }

    bool ActiveGame()
    {
        if (GameObject.Find("SizeButton"))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
