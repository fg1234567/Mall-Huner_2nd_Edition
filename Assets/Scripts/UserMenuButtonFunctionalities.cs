using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;


public class UserMenuButtonFunctionalities : MonoBehaviour {


    public void CameraButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ItemsButtonClick()
    {
        SceneManager.LoadScene(2);
    }


    public void GiftsButtonClick()
    {
        SceneManager.LoadScene(3);
    }

    
    public void MapButtonClick()
    {
        Debug.Log("map button clicked");
    }

    public void ResetButtonClick()
    {
        Debug.Log("reset button clicked");
    }
}
