using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Информация о пуле.
/// </summary>
public class BulletInfo : MonoBehaviour
{
    /// <summary>
    /// Матерьял пули.
    /// </summary>
    private Material materialOfBullet = null;
    /// <summary>
    /// Свет пули.
    /// </summary>
    private Light ligthOfBullet = null;

    /// <summary>
    /// Эта пуля активна.
    /// </summary>
    private bool isEnable = false;
    /// <summary>
    /// Эта пуля была выпущена врагом.
    /// </summary>
    public bool isEnemyBullet = false;
    /// <summary>
    /// Скорость, с которой летит пуля.
    /// </summary>
    public Single bulletSpeed = -0.3f;
    /// <summary>
    /// Скорость, которая расчитывается изходя из владельца пули.
    /// Просчет происходит с ее участием.
    /// </summary>
    private Single bulletSpeedPrivate = -0.3f;
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
    /// Установить владельца пули. Метод влияет в какую строрну будет лететь пуля.
    /// </summary>
    /// <param name="isEnemy">Владелец враг?</param>
    public void SetOwnerBullet(bool isEnemy)
    {
        if(isEnemy)
        {
            this.bulletSpeedPrivate = -this.bulletSpeed;
            this.isEnemyBullet = true;
            this.materialOfBullet.color = Color.red;
            this.ligthOfBullet.color = Color.red;
        }
        else
        {
            this.bulletSpeedPrivate = this.bulletSpeed;
            this.isEnemyBullet = false;
            this.materialOfBullet.color = Color.blue;
            this.ligthOfBullet.color = Color.blue;
        }

        this.isEnable = true;
    }
    /// <summary>
    /// Сделать эту пулю неактивной.
    /// </summary>
    public void DisableBullet()
    {
        this.gameManagerInfo.disableBullets.Add(this);
        this.isEnable = false;
        this.transform.position = new Vector3(0, 0, -99);
    }
    void Start()
    {
        this.playerInfo = gameManagerInfo.playerInfo;
        this.materialOfBullet = this.gameObject.GetComponent<Renderer>().material;
        this.ligthOfBullet= this.transform.GetChild(0).gameObject.GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isEnable)
        {
            this.transform.localPosition = new Vector3
                (
                this.transform.localPosition.x + this.bulletSpeedPrivate,
                this.transform.localPosition.y,
                this.transform.localPosition.z
                );
            if (Math.Abs(this.transform.position.x - this.playerInfo.transform.position.x)
                 > this.gameManagerInfo.boundVertical)
            {
                this.gameManagerInfo.enableBullets.Remove(this);
                DisableBullet();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!this.isEnemyBullet)
        {
            String name = other.gameObject.name;
            if (name.Contains("Enemy"))
            {
                this.playerInfo.score += 10;
                other.gameObject.transform.parent.transform.position = new Vector3(0, 0, -99);
            }
            else
            {
                this.playerInfo.score += 2;
                other.gameObject.transform.position = new Vector3(0, 0, -99);
            }
            DisableBullet();
        }
    }
}
