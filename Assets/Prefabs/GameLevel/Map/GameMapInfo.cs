using Assets.Prefabs.GameLevel.Map;
using Assets.Scripts.Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Информация об игровой карте.
/// Создает и хранит объекты для игровой карты.
/// </summary>
public class GameMapInfo : MonoBehaviour
{
    /// <summary>
    /// Максимальное количество препятсвий к концу уровня для игрока.
    /// </summary>
    public const Int32 MAX_COUNT_OBJECTS = 100;
    /// <summary>
    /// Место занимаетмое одним объектом в длине карты.
    /// </summary>
    public const Single LENGTH_ONE_OBJECT = 15f;
    /// <summary>
    /// Длинна всей карты.
    /// </summary>
    public const Single LENGTH_MAP = MAX_COUNT_OBJECTS * LENGTH_ONE_OBJECT;
    /// <summary>
    /// Список врагов на карте.
    /// </summary>
    public List<GameObject> enemies = new List<GameObject>();
    /// <summary>
    /// Список врагов на карте.
    /// </summary>
    public List<GameObject> asteroids=new List<GameObject>();
    /// <summary>
    /// Заготовка главного элемента управления.
    /// </summary>
    public GameObject gameManager = null;
    /// <summary>
    /// Главный управляющий скрипт.
    /// </summary>
    public GameManagerInfo gameManagerInfo = null;
    /// <summary>
    /// Главная камера.
    /// </summary>
    public Camera mainCamera = null;
    

    /// <summary>
    /// Заготовка врага.
    /// </summary>
    public GameObject enemyPrefab = null;
    /// <summary>
    /// Заготовка метеорита.
    /// </summary>
    public GameObject asteroidPrefab = null;
    /// <summary>
    /// Корабль игрока.
    /// </summary>
    public GameObject playerSpaceShip = null;

    private MapStartController mapStartController = null;
    private MapStartView mapStartView = null;

    void Start()
    {
        this.mapStartController = new MapStartController(this);
        this.mapStartView = new MapStartView(this);

        this.gameManagerInfo = this.gameManager.GetComponent<GameManagerInfo>();

        //Создание данных для карты и определние их отрисовки
        List<ISpaceObject> spaceObjects = this.mapStartController.CreateMapObjects();
        this.mapStartView.SetViewForAllObjects(spaceObjects, ref this.enemies, ref this.asteroids);
    }
}
