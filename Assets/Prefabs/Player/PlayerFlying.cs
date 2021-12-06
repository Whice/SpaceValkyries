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
    /// Счет игрока.
    /// </summary>
    public Int32 score = 0;
    /// <summary>
    /// Информация о положении игрока в пространстве.
    /// </summary>
    private Transform playerTransform = null;
    /// <summary>
    /// Заготовка корабля игрока.
    /// </summary>
    public GameObject playerSpaceShip = null;
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
    /// <summary>
    /// Заготовка главного эемента управления.
    /// </summary>
    public GameObject gameManager = null;
    /// <summary>
    /// Главный управляющий скрипт.
    /// </summary>
    private GameManagerInfo gameManagerInfo = null;
    /// <summary>
    /// Перерыв между выстрелами игрока.
    /// </summary>
    private Single callDownShot = 4f;
    /// <summary>
    /// Количество жизней.
    /// </summary>
    private Int32 health = 3;
    /// <summary>
    /// Основной холст уровня.
    /// </summary>
    public Canvas mainCanvas = null;
    private void Start()
    {
        this.playerTransform = this.gameObject.transform;
        this.playerSpaceShipTransform = this.playerSpaceShip.transform;
        this.gameManagerInfo = gameManager.GetComponent<GameManagerInfo>();
        this.mainCanvas = this.gameManagerInfo.mainCanvas;
        this.boundHorizontal = this.gameManagerInfo.boundHorizontal;
    }
    private void Update()
    {
        //Полет вперед
        this.playerTransform.position = new Vector3
            (
            this.playerTransform.position.x - this.playerSpeed,
            this.playerTransform.position.y,
            this.playerTransform.position.z 
            );

        //Движение вбок
        Single horizontalShift = Input.GetAxis("Horizontal");
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

        //Выстрел

        if(Input.GetButton("Fire1"))
        {
            if (this.callDownShot > 0.3)
            {
                Int32 indexLastItem = this.gameManagerInfo.disableBullets.Count - 1;
                BulletInfo info = this.gameManagerInfo.disableBullets[indexLastItem];
                info.SetOwnerBullet(false);
                this.gameManagerInfo.disableBullets.RemoveAt(indexLastItem);
                this.gameManagerInfo.enableBullets.Add(info);
                info.transform.position = new Vector3
                    (
                    this.playerSpaceShipTransform.position.x-4,
                    this.playerSpaceShipTransform.position.y,
                    this.playerSpaceShipTransform.position.z
                    );
                this.callDownShot = 0; 
            }
        }
        this.callDownShot += Time.deltaTime;
    }
}
