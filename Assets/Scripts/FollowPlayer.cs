using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jellyfish");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
    }
}