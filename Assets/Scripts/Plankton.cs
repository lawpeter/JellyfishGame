using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plankton : MonoBehaviour
{
    private float waterSpeed = 0.1f;
    private float waterPower = 0.1f;

    private float cameraHeight;
    private float cameraWidth;
    private float xRange;
    private float zRange;
    private float maxSpeed = 3.0f;

    private Rigidbody enemyRb;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Camera camera = Camera.main;
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Jellyfish");
        cameraWidth = camera.orthographicSize * 2.0f;
        cameraHeight = cameraWidth / camera.aspect;
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(RandomMovement());
        xRange = cameraWidth;
        zRange = cameraHeight;
        enemyRb.velocity = Vector3.ClampMagnitude(enemyRb.velocity, maxSpeed);
    }

    IEnumerator RandomMovement()
    {
        while(true)
        {
            yield return new WaitForSeconds(waterSpeed);
            StayInBounds();
            enemyRb.AddForce(GenerateRandomPower(), 0, GenerateRandomPower(), ForceMode.Impulse);
        }
    }
    
    float GenerateRandomPower()
    {
        return Random.Range(-waterPower, waterPower);
    }
    void StayInBounds()
    {
        if (enemyRb.transform.position.x > player.transform.position.x + xRange)
        {
            //transform.position = new Vector3(player.transform.position.x + xRange, 0, transform.position.z);
            enemyRb.velocity = Vector3.zero;
        }

        if (enemyRb.transform.position.x < player.transform.position.x - xRange)
        {
            //transform.position = new Vector3(player.transform.position.x - xRange, 0, transform.position.z);
            enemyRb.velocity = Vector3.zero;
        }

        if (enemyRb.transform.position.z > player.transform.position.z + zRange)
        {
            //transform.position = new Vector3(player.transform.position.x, 0, transform.position.z + zRange);
            enemyRb.velocity = Vector3.zero;
        }

        if (enemyRb.transform.position.z < player.transform.position.z - zRange)
        {
            //transform.position = new Vector3(player.transform.position.x, 0, transform.position.z - zRange);
            enemyRb.velocity = Vector3.zero;
        }
    }
}
