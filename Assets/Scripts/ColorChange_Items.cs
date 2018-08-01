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
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ColorChange_Items : MonoBehaviour
{

    public void Start()
    {
        
        if (File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);

            ScoreData scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
            scoreDataFile.Close();

            Text BronzeCoinCountText = GameObject.Find("BronzeCoinCountText").GetComponent<Text>();
            BronzeCoinCountText.text = "Bronze: " + scoreData.bronzeCoinCount;


            Text SilverCoinCountText = GameObject.Find("SilverCoinCountText").GetComponent<Text>();
            SilverCoinCountText.text = "Silver: " + scoreData.silverCoinCount;


            Text GoldCoinCountText = GameObject.Find("GoldCoinCountText").GetComponent<Text>();
            GoldCoinCountText.text = "Gold: " + scoreData.goldCoinCount;

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }
        


    }
}
