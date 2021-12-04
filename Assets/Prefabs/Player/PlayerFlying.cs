using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFlying : MonoBehaviour
{
    private Transform playerTransform = null;
    private Single playerSpeed = 0.01f;
    private void Start()
    {
        this.playerTransform = this.gameObject.transform;
    }
    private void Update()
    {
        this.playerTransform.position = new Vector3
            (
            this.playerTransform.position.x-this.playerSpeed,
            this.playerTransform.position.y,
            this.playerTransform.position.z
            );
    }
}
