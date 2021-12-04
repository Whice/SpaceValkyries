using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsMoving : MonoBehaviour
{
    /// <summary>
    /// ������ ��������� �� �������� �� �.
    /// </summary>
    private Single localScaleX = 0;
    /// <summary>
    /// �������� �������� �����.
    /// </summary>
    private Single speed = 0.0025f;
    /// <summary>
    /// ���� � ������� � ������������.
    /// </summary>
    private Transform starsPlaneTransform = null;
    void Start()
    {
        this.starsPlaneTransform = this.gameObject.transform;
        this.localScaleX = this.starsPlaneTransform.localScale.x * 10;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.starsPlaneTransform.localPosition.x>this.localScaleX)
        {
            this.starsPlaneTransform.localPosition = new Vector3
            (
            -this.localScaleX,
            this.starsPlaneTransform.localPosition.y,
            this.starsPlaneTransform.localPosition.z
            );
        }
        this.starsPlaneTransform.localPosition = new Vector3
            (
            this.starsPlaneTransform.localPosition.x+this.speed,
            this.starsPlaneTransform.localPosition.y,
            this.starsPlaneTransform.localPosition.z
            );
    }
}
