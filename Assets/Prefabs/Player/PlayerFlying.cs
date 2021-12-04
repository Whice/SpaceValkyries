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
    /// Информация о положении корабля игрока в пространстве.
    /// </summary>
    private Transform playerSpaceShipTransform = null;
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
        this.playerSpaceShipTransform = GameObject.Find("PlayerSpaceShip").transform;
    }
    private void Update()
    {
        Single horizontalShift = Input.GetAxis("Horizontal");
        this.playerTransform.position = new Vector3
            (
            this.playerTransform.position.x - this.playerSpeed,
            this.playerTransform.position.y,
            this.playerTransform.position.z 
            );

        Single newZCoordinateShip = this.playerSpaceShipTransform.position.z + horizontalShift*0.9f;
            if (newZCoordinateShip > this.boundHorizontal)
            {
                newZCoordinateShip = this.boundHorizontal;
            }
            else if (newZCoordinateShip < -this.boundHorizontal)
            {
                newZCoordinateShip = -this.boundHorizontal;
            }
            this.playerSpaceShipTransform.position = new Vector3
                (
                this.playerSpaceShipTransform.position.x,
                this.playerSpaceShipTransform.position.y,
                newZCoordinateShip
                );
    }
}
