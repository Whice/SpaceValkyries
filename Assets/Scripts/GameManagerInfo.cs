using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Главный управляющий скрипт.
/// </summary>
public class GameManagerInfo : MonoBehaviour
{

    /// <summary>
    /// Границы полета игрока по горизонтали.
    /// </summary>
    public Single boundHorizontal = 46f;
    /// <summary>
    /// Границы полета игрока по вертикале.
    /// </summary>
    public Single boundVertical = 34f;
    /// <summary>
    /// Максимальное количество пуль в начале игры.
    /// </summary>
    private const Int32 maxCountBullet = 50;
    /// <summary>
    /// Неактивные пули.
    /// </summary>
    public List<BulletInfo> disableBullets = new List<BulletInfo>(maxCountBullet);
    /// <summary>
    /// Активные пули.
    /// </summary>
    public List<BulletInfo> enableBullets = new List<BulletInfo>(maxCountBullet);
    /// <summary>
    /// Заготовка пули.
    /// </summary>
    public GameObject bulletPrefab = null;
    /// <summary>
    /// Заготовка игрока.
    /// </summary>
    public GameObject playerPrefab = null;
    /// <summary>
    /// Инфо о местоположении игрока.
    /// </summary>
    [HideInInspector]
    public PlayerFlying playerInfo = null;
    /// <summary>
    /// Заготовка корабля игрока.
    /// </summary>
    public GameObject playerShipPrefab = null;
    /// <summary>
    /// Главная камера.
    /// </summary>
    public Camera mainCamera = null;
    /// <summary>
    /// Объект ировой карты.
    /// </summary>
    public GameObject gameMap = null;
    /// <summary>
    /// Информация об ировой карты.
    /// </summary>
    private GameMapInfo mapInfo = null;

    // Start is called before the first frame update
    void Start()
    {
        this.mapInfo = this.gameMap.GetComponent<GameMapInfo>();
        this.mapInfo.mainCamera = this.mainCamera;
        this.playerInfo = this.playerPrefab.GetComponent<PlayerFlying>();
        List<BulletInfo> disableBullets = this.disableBullets;
        for (Int32 i=0;i<maxCountBullet;i++)
        {
            BulletInfo info = Instantiate(this.bulletPrefab).GetComponent<BulletInfo>();
            info.gameManagerInfo = this;
            info.DisableBullet();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
