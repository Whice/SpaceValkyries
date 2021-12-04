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
    private const Int32 MAX_COUNT_OBJECTS = 100;
    /// <summary>
    /// Место занимаетмое одним объектом в длине карты.
    /// </summary>
    private const Single LENGTH_ONE_OBJECT = 5f;
    /// <summary>
    /// Длинна всей карты.
    /// </summary>
    private const Single LENGTH_MAP = MAX_COUNT_OBJECTS * LENGTH_ONE_OBJECT;
    /// <summary>
    /// Список врагов на карте.
    /// </summary>
    private List<GameObject> enemys = new List<GameObject>();
    /// <summary>
    /// Список врагов на карте.
    /// </summary>
    private List<GameObject> asteroids=new List<GameObject>();
    /// <summary>
    /// Поворот всех объектов вниз "лицом".
    /// </summary>
    private Quaternion rotate = Quaternion.AngleAxis(90, new Vector3( 0, 1, 0));
    /// <summary>
    /// Создать вектор положения со случайным смепшение на карте по одной оси (z).
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector3 CreateReandomYVector3(Single x, Single y)
    {
        return new Vector3(x, y, UnityEngine.Random.Range(-this.playerFlying.boundHorizontal, this.playerFlying.boundHorizontal+1)); 
    }

    /// <summary>
    /// Создать все объекты для карты.
    /// </summary>
    private void CreateMapObjects()
    {
        Int32 countOfEnemy = 1;
        const Single lengthMap = LENGTH_MAP;
        const Single lengthObject = LENGTH_ONE_OBJECT;
        Single y = this.playerSpaceShip.transform.localPosition.y;
        Single startX = this.playerSpaceShip.transform.position.x+20;
        Transform parentTransform = this.gameObject.transform;
        GameObject newObject = null;

        for (Single x = startX; x < lengthMap; x += lengthObject, countOfEnemy++)
        {
            if (countOfEnemy % 5 == 0)
            {
                newObject = Instantiate(this.enemyPrefab, CreateReandomYVector3(-x, y), this.rotate);
                this.enemys.Add(newObject);
            }
            else
            {
                newObject = Instantiate(this.asteroidPrefab, CreateReandomYVector3(-x, y), this.rotate);
                this.asteroids.Add(newObject); ;
            }
            newObject.transform.parent = parentTransform;
        }
    }

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
    /// <summary>
    /// Инфо о полете игрока.
    /// </summary>
    private PlayerFlying playerFlying = null;

    void Start()
    {
        this.playerFlying = GameObject.Find("Player").GetComponent<PlayerFlying>();
        CreateMapObjects();
    }
}
