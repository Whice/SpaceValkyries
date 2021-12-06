using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    private Vector3 axisOfPlanet = new Vector3(0, 45f, 15f);
    // Start is called before the first frame update
    void Start()
    {
        
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
            this.isMouseButonNotDown = false;
            SceneManager.LoadSceneAsync("GameLevelScene");
        }
    }
    private void OnMouseUp()
    {
        this.isMouseButonNotDown = true;
    }
}
