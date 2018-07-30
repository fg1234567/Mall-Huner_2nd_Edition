//====================================================================
// Initialized :27.7.2018  12.30
// Last edited :29.7.2018  13.30 
//====================================================================

using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UserMenuButtonFunctionalities : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }

    public void CameraButtonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ItemsButtonClick()
    {
        SceneManager.LoadScene(3);
    }


    public void GiftsButtonClick()
    {
        SceneManager.LoadScene(4);
    }

    
    public void MapButtonClick()
    {
        SceneManager.LoadScene(5);
    }

    public void ResetButtonClick()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
            PlayerData data = new PlayerData();

            data.apple = "available";
            data.banana = "available";
            data.bottle = "available";
            data.cup = "available";
            data.pear = "available";
            data.pumpkin = "available";
            data.orange = "available";
            data.numbOfCollectedItems = 0;
            
            bf.Serialize(file, data);
            file.Close();

        }
    }
}
