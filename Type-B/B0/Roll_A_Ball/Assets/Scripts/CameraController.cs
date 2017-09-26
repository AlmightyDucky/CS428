using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;

    private Vector3 offset;
    
    // Use this for initialization
	void Start()
    {
        offset = transform.position - ((player.transform.position + player2.transform.position) / 2);
	}

    // Update is called once per frame
    void Update()
    {
        transform.position = ((player.transform.position + player2.transform.position) / 2) + offset;
    }
}
