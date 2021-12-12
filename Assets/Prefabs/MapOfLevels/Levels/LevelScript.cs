using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Управляющий скрипт уровня.
/// </summary>
public class LevelScript : MonoBehaviour
{
    /// <summary>
    /// Номер уровня.
    /// </summary>
    public Int16 levelNumber = 0;
    /// <summary>
    /// Главная камера.
    /// </summary>
    public Camera mainCamera = null;
    /// <summary>
    /// Ось вокруг которой вращаются планеты-уровни.
    /// </summary>
    private Vector3 axisOfPlanet = new Vector3(0, 45f, 15f);

    void Start()
    {
        MainGameKeeper.LoadLevels();
    }

    void Update()
    {
        //Вращение планет-уровней
        this.transform.Rotate(this.axisOfPlanet*Time.deltaTime);
    }

    /// <summary>
    /// Кнопка мыши не была нажата.
    /// </summary>
    private Boolean isMouseButonNotDown = true;
    private void OnMouseDown()
    {
        if(this.isMouseButonNotDown)
        {
            RaycastHit hit;
            Ray MyRay;

            if (Input.GetKeyDown(KeyCode.Mouse0))//Нажатие левой кнопкой мыши
            {
                MyRay = this.mainCamera.ScreenPointToRay(Input.mousePosition);
                //проверка попадания в планету-уровень
                if (Physics.Raycast(MyRay, out hit, 100))
                {
                    GameObject level = hit.collider.gameObject;
                    MainGameKeeper.numberActiveLevel = Convert.ToInt16(level.name.Remove(0, 5));
                    if (level==null)
                    {           
                        Debug.Log("No object!");
                        return;
                    }
                }
                this.isMouseButonNotDown = false;
                //при попадании загрузить уровень, если он открыт.
                if (MainGameKeeper.IsLevelOpen(this.levelNumber) ||
                    this.levelNumber==1)
                {
                    SceneManager.LoadSceneAsync("GameLevelScene");
                }
            }
        }
    }
    private void OnMouseUp()
    {
        this.isMouseButonNotDown = true;
    }
}
