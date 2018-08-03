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

public class LoginFunctionality : MonoBehaviour {

    public InputField userNameInput;
    public InputField userEmailInput;
    public FileStream playerInfoFile, scoreDataFile;
    

    public void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            playerInfoFile = File.Create(Application.persistentDataPath + "/playerInfo.dat");
            scoreDataFile = File.Create(Application.persistentDataPath + "/scoreData.dat");
                        
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    

    public void loginButtonClick()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerInfo playerData = new PlayerInfo();
        ScoreData scoreData = new ScoreData();

        if (userNameInput.text != null && userEmailInput.text != null)
        {

            playerData.userEmail = userEmailInput.text;
            playerData.userName = userNameInput.text;



            bf.Serialize(playerInfoFile, playerData);
            bf.Serialize(scoreDataFile, scoreData);

            playerInfoFile.Close();
            scoreDataFile.Close();
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Either one is null");
        }        
    }
}




