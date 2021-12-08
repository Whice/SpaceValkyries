using Assets.Scripts;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public Camera mainCamera = null;
    private Vector3 axisOfPlanet = new Vector3(0, 45f, 15f);
    // Start is called before the first frame update
    void Start()
    {
        MainGameKeeper.LoadLevels();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(this.axisOfPlanet*Time.deltaTime);
    }

    private Boolean isMouseButonNotDown = true;
    private void OnMouseDown()
    {
        if(this.isMouseButonNotDown)
        {
            RaycastHit hit;
            Ray MyRay;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                MyRay = this.mainCamera.ScreenPointToRay(Input.mousePosition);
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
                SceneManager.LoadSceneAsync("GameLevelScene");
            }
        }
    }
    private void OnMouseUp()
    {
        this.isMouseButonNotDown = true;
    }
}
