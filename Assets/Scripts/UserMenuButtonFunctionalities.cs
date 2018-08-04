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

    private void Start()
    {
        FileStream file1 = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
        FileStream file2 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);


        BinaryFormatter bf = new BinaryFormatter();
        PlayerInfo data1 = (PlayerInfo)bf.Deserialize(file1);
        ScoreData data2 = (ScoreData)bf.Deserialize(file2);
        file1.Close();
        file2.Close();

        Debug.Log(data1.userEmail);
        Debug.Log(data2.bronzeCoinCount);

    }
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

    public void InstructionsButtonClick()
    {
        SceneManager.LoadScene(7);
    }


    public void ResetButtonClick()
    {
        if (File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            ScoreData data = new ScoreData();

            bf.Serialize(scoreDataFile, data);
            scoreDataFile.Close();

        }
    }
}
