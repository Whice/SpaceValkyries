using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInfo : MonoBehaviour
{
    /// <summary>
    /// Заготовка главного эемента управления.
    /// </summary>
    [HideInInspector]
    public GameObject gameManager = null;
    /// <summary>
    /// Главный управляющий скрипт.
    /// </summary>
    [HideInInspector]
    public GameManagerInfo gameManagerInfo = null;
    /// <summary>
    /// Инфо о местоположении игрока.
    /// </summary>
    [HideInInspector]
    public PlayerFlying playerInfo = null;
    /// <summary>
    /// Скорость сближения.
    /// </summary>
    public Single convergenceSpeed = 0.002f;
    /// <summary>
    /// Заготовка корабля игрока.
    /// </summary>
    [HideInInspector]
    public GameObject playerSpaceShip = null;
    /// <summary>
    /// Информация о положении корабля игрока в пространстве.
    /// </summary>
    [HideInInspector]
    private Transform playerSpaceShipTransform = null;
    /// <summary>
    /// Главная камера.
    /// </summary>
    [HideInInspector]
    public Camera mainCamera = null;
    /// <summary>
    /// Перерыв между выстрелами игрока.
    /// </summary>
    private Single callDownShot = 4f;
    // Start is called before the first frame update
    void Start()
    {
        this.playerInfo = this.gameManagerInfo.playerInfo;
        this.playerSpaceShip = this.gameManagerInfo.playerShipPrefab;
        this.playerSpaceShipTransform = this.playerSpaceShip.transform;
    }
    /// <summary>
    /// В зоне видимости камеры.
    /// </summary>
    /// <returns></returns>
    private Boolean IsInFieldOfViewOfCamera()
    {
        Vector3 viewPosotion = this.mainCamera.WorldToViewportPoint(this.transform.position);
        if (viewPosotion.x > 1 || viewPosotion.x < 0 ||
           viewPosotion.y > 1 || viewPosotion.y < 0)
            return false;
        return true;
    }
    // Update is called once per frame
    void Update()
    {
        if (IsInFieldOfViewOfCamera())
        {
            if (this.playerSpaceShipTransform.position.z - this.transform.position.z < 0)
            {
                this.transform.position = new Vector3
                    (
                    this.transform.position.x,
                    this.transform.position.y,
                    this.transform.position.z - this.convergenceSpeed
                    );
            }
            else if (this.playerSpaceShipTransform.position.z - this.transform.position.z > 0)
            {
                this.transform.position = new Vector3
                    (
                    this.transform.position.x,
                    this.transform.position.y,
                    this.transform.position.z + this.convergenceSpeed
                    );
            }

            if (this.callDownShot > 1.3f)//выстрел раз в секунду
            {
                Int32 indexLastItem = this.gameManagerInfo.disableBullets.Count - 1;
                BulletInfo info = this.gameManagerInfo.disableBullets[indexLastItem];
                info.SetOwnerBullet(true);
                this.gameManagerInfo.disableBullets.RemoveAt(indexLastItem);
                this.gameManagerInfo.enableBullets.Add(info);
                info.transform.position = this.transform.position;
                this.callDownShot = 0;
            }
            this.callDownShot += Time.deltaTime;
        }
    }
}
