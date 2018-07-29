using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;
using UnityEngine.UI;



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
        SceneManager.LoadScene(4);
    }

    public void ResetButtonClick()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
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
