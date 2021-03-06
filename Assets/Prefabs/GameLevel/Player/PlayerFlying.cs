using Assets.Scripts;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Инфо о перемещении игрока.
/// </summary>
public class PlayerFlying : MonoBehaviour
{
    /// <summary>
    /// Дистанция, которую надо пройти для победы.
    /// </summary>
    public Single victoryDistance = 999f;
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
    private Int32 healthPrivate = 3;
    /// <summary>
    /// Количество жизней.
    /// </summary>
    public Int32 health
    {
        get => this.healthPrivate;
        set
        {
            this.healthPrivate = value > 0 ? value : 0;
            this.textHealth.text = "Player health: " + this.healthPrivate.ToString();
            if(this.healthPrivate==0)
            {
                this.textGameOver.enabled = true;
            }
        }
    }
    /// <summary>
    /// Таймер выхода.
    /// </summary>
    private Single exitTimer = 5f;
    /// <summary>
    /// Основной холст уровня.
    /// </summary>
    public Canvas mainCanvas = null;
    /// <summary>
    /// Текст колчиества жизней игрока.
    /// </summary>
    public Text textHealth = null;
    /// <summary>
    /// Текст окончания игры, проигрыша на уровне.
    /// </summary>
    public Text textGameOver = null;
    /// <summary>
    /// Победы на уровне.
    /// </summary>
    public Text textVictory = null;
    private void Start()
    {
        this.playerTransform = this.gameObject.transform;
        this.playerSpaceShipTransform = this.playerSpaceShip.transform;
        this.gameManagerInfo = gameManager.GetComponent<GameManagerInfo>();
        this.victoryDistance = -(GameMapInfo.LENGTH_MAP + 20);
        this.mainCanvas = this.gameManagerInfo.mainCanvas;
        this.boundHorizontal = this.gameManagerInfo.boundHorizontal;
        this.health = 3;
        this.textGameOver.enabled = false;
        this.textVictory.enabled = false;
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

        if (this.playerSpaceShipTransform.position.x < this.victoryDistance)
        {
            if (!this.textGameOver.enabled)
            {
                this.textVictory.enabled = true;
                this.exitTimer -= Time.deltaTime;

                LevelKeeper levelKeeper = MainGameKeeper.GetKeeper(MainGameKeeper.numberActiveLevel);
                levelKeeper.levelNumber = MainGameKeeper.numberActiveLevel;
                levelKeeper.isLevelComplete = true;
                levelKeeper.SaveData();

                if (this.exitTimer < 0)
                {
                    SceneManager.LoadScene("MapLevelsScene");
                }
            }
        }

        if (this.textGameOver.enabled)
        {
            this.exitTimer -= Time.deltaTime;

            if (this.exitTimer < 0)
            {
                SceneManager.LoadScene("MapLevelsScene");
            }
        }
    }
}
