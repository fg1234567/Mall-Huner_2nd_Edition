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
    public FileStream file;
    

    public void Start()
    {
        if(!File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    

    public void loginButtonClick()
    {
        BinaryFormatter bf = new BinaryFormatter();
        PlayerInfo data = new PlayerInfo();

        if (userNameInput.text != null && userEmailInput.text != null)
        {
            data.userEmail = userEmailInput.text;
            data.userName = userNameInput.text;

            bf.Serialize(file, data);
            file.Close();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("Either one is null");
        }        
    }
}


[Serializable]
class PlayerInfo
{
    public string userName;
    public string userEmail;
}