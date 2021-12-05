using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour
{
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
    }
}
