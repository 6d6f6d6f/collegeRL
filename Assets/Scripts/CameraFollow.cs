﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 40.0f;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.Camera>().orthographicSize = ((Screen.height / 2) / cameraDistance);
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null) {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
