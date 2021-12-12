using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    /// Инфо о местоположении игрока.
    /// </summary>
    [HideInInspector]
    public PlayerFlying playerInfo = null;
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
    public GameMapInfo mapInfo = null;
    /// <summary>
    /// Основной холст уровня.
    /// </summary>
    public Canvas mainCanvas = null;
    /// <summary>
    /// Текст счета игрока на уровне.
    /// </summary>
    public Text textScore = null;
    void Start()
    {
        AddPrefabToKeeper();
        this.mapInfo = this.gameMap.GetComponent<GameMapInfo>();
        this.mapInfo.mainCamera = this.mainCamera;
        this.playerInfo = this.playerPrefab.GetComponent<PlayerFlying>();
        this.textScore = this.mainCanvas.transform.GetChild(0).GetComponent<Text>();
        this.textScore.text = "Player score: 0";
        List<BulletInfo> disableBullets = this.disableBullets;
        for (Int32 i=0;i<maxCountBullet;i++)
        {
            BulletInfo info = Instantiate(this.bulletPrefab).GetComponent<BulletInfo>();
            info.gameManagerInfo = this;
            info.playerInfo = this.playerInfo;
            info.textScore = this.textScore;
            info.DisableBullet();
        }

        LevelKeeper keeper = MainGameKeeper.GetKeeper(MainGameKeeper.numberActiveLevel);
        if(keeper==null)
        {
            keeper = new LevelKeeper(MainGameKeeper.numberActiveLevel);
            keeper.SetDataForLevel(this);
            keeper.SaveData();
        }
        else
        {
            GameManagerInfo info = new GameManagerInfo();
            keeper.GetDataForLevel(info);
            this.mapInfo.enemys = info.mapInfo.enemys;
            this.mapInfo.asteroids = info.mapInfo.asteroids;
        }
    }

    #region Игровые заготовки и их загрузка  в хранителя (репозиторий)

    /// <summary>
    /// Заготовка пули.
    /// </summary>
    public GameObject bulletPrefab = null;
    /// <summary>
    /// Заготовка игрока.
    /// </summary>
    public GameObject playerPrefab = null;
    /// <summary>
    /// Заготовка корабля игрока.
    /// </summary>
    public GameObject playerShipPrefab = null;
    /// <summary>
    /// Заготовка врага.
    /// </summary>
    public GameObject enemyPrefab = null;
    /// <summary>
    /// Заготовка врага.
    /// </summary>
    public GameObject asteroidPrefab = null;
    /// <summary>
    /// Заготовка игровой карты.
    /// </summary>
    public GameObject gameMapPrefab = null;
    /// <summary>
    /// Заготовка звезд.
    /// </summary>
    public GameObject starsPrefab = null;
    /// <summary>
    /// Заготовка уровня.
    /// </summary>
    public GameObject levelPrefab = null;
    /// <summary>
    /// Заготовка всех уровней.
    /// </summary>
    public GameObject levelsPrefab = null;

    /// <summary>
    /// Добавить все заготовки в словарь главного хранителя, чтобы они были доступны отовсюду.
    /// </summary>
    public void AddPrefabToKeeper()
    {
        MainGameKeeper.AddPrefab(this.asteroidPrefab.name, this.asteroidPrefab);
        MainGameKeeper.AddPrefab(this.bulletPrefab.name, this.bulletPrefab);
        MainGameKeeper.AddPrefab(this.playerPrefab.name, this.playerPrefab);
        MainGameKeeper.AddPrefab(this.playerShipPrefab.name, this.playerShipPrefab);
        MainGameKeeper.AddPrefab(this.enemyPrefab.name, this.enemyPrefab);
        MainGameKeeper.AddPrefab(this.gameMapPrefab.name, this.gameMapPrefab);
        MainGameKeeper.AddPrefab(this.starsPrefab.name, this.starsPrefab);
        MainGameKeeper.AddPrefab(this.levelPrefab.name, this.levelPrefab);
        MainGameKeeper.AddPrefab(this.levelsPrefab.name, this.levelsPrefab);
    }
    

    #endregion
}
