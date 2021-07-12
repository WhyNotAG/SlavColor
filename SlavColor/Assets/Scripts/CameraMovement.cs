using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Vector3 offset;
    [SerializeField] public GameObject player;

    private void Start()
    {
        player = GameObject.FindObjectOfType<PlayerMovement>().gameObject;
    }

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y,
            offset.z);
    }
}
