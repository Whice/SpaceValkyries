using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour
{
    /// <summary>
    /// Объект игрока.
    /// </summary>
    public GameObject playerObject = null;
    /// <summary>
    /// Информация об игроке.
    /// </summary>
    private PlayerFlying playerInfo = null;
    private void Start()
    {
        this.playerInfo = this.playerObject.GetComponent<PlayerFlying>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.name.Contains("Bullet"))
        {
            BulletInfo info = other.gameObject.GetComponent<BulletInfo>();
            info.DisableBullet();
        }
        else
        {
            other.gameObject.transform.parent.transform.position = new Vector3(0, 0, -99);
        }
            this.playerInfo.health--;
    }
}
