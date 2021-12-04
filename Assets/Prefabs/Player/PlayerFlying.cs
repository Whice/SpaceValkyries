using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Инфо о перемещении игрока.
/// </summary>
public class PlayerFlying : MonoBehaviour
{
    /// <summary>
    /// Информация о положении игрока в пространстве.
    /// </summary>
    private Transform playerTransform = null;
    /// <summary>
    /// Скорость игрока.
    /// </summary>
    public Single playerSpeed = 0.01f;
    /// <summary>
    /// Границы полета игрока по горизонтали.
    /// </summary>
    public Single boundHorizontal = 46f;
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
