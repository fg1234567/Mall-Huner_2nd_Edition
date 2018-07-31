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


[Serializable]
class PlayerInfo
{
    public string userName;
    public string userEmail;
}


[Serializable]
public class ScoreData
{
    public List<string> bronzeCoinList;
    public List<string> silverCoinList;
    public List<string> goldCoinList;
    public int bronzeCoinCount;
    public int silverCoinCount;
    public int goldCoinCount;

    public ScoreData()
    {
        bronzeCoinList = new List<string>();
        silverCoinList = new List<string>();
        goldCoinList = new List<string>();
        bronzeCoinCount = 0;
        silverCoinCount = 0;
        goldCoinCount = 0;
    }

    public void CollectCoin(string coinName, string coinTag)
    {
        Debug.Log("Coin Collection Info: " + coinName + " : " + coinTag );


        if(coinTag == "bronzeCoin"){
            
            Debug.Log("bronzeCoinCollect!");
            bronzeCoinList.Add(coinName);
            bronzeCoinCount++;
        } else if(coinTag == "silverCoin"){
            
            Debug.Log("silverCoinCollect!");
            silverCoinList.Add(coinName);
            silverCoinCount++;

        } else if(coinTag == "goldCoin"){
            
            Debug.Log("goldCoinCollect!");
            goldCoinList.Add(coinName);
            goldCoinCount++;
        }

        Debug.Log("bronzeCoinCount: " + bronzeCoinCount);
        Debug.Log("silverCoinCount: " + silverCoinCount);
        Debug.Log("goldCoinCount: " + goldCoinCount);


    }

    public bool Contains(string coinName, string coinTag)
    {

        Debug.Log("Contains Info: " + coinName + " : " + coinTag );

        if(coinTag == "bronzeCoin"){
            
            if(bronzeCoinList.Contains(coinName))
                return true;
            else
                return false;

        } else if(coinTag == "silverCoin"){
            
            if(silverCoinList.Contains(coinName))
                return true;
            else
                return false;

        } else if(coinTag == "goldCoin"){
            
            if(goldCoinList.Contains(coinName))
                return true;
            else
                return false;
        } else {
            Debug.Log("coin tag not found ");
            return false;
        }


    }

}