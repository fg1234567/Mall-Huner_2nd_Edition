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

public class ApproveScript : MonoBehaviour
{

    public ScoreData scoreData;
    public GiftData giftData;
    public BinaryFormatter bf = new BinaryFormatter();
    public Text areYouSureText;

    public string currentButtonTag;
    public string currentButtonName;
    

    public void Start()
    {
        FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
        scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
        scoreDataFile.Close();

        FileStream giftDataFile = File.Open(Application.persistentDataPath + "/giftData.dat", FileMode.Open);
        giftData = (GiftData)bf.Deserialize(giftDataFile);
        giftDataFile.Close();

        currentButtonTag = FindObjectOfType<CollorChange_Gifts>().currentButtonTag;
        areYouSureText.text = "Are you sure to purchase " + FindObjectOfType<CollorChange_Gifts>().currentButtonName + "?";

    }

    public void yesButtonClick()
    {
        Debug.Log("yes clicked");

        int tagInt;
        int.TryParse(currentButtonTag, out tagInt);
    
        FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
        scoreData.IncreaseTotalExpense(tagInt);
        bf.Serialize(scoreDataFile, scoreData);
        scoreDataFile.Close();

        FileStream giftDataFile = File.Open(Application.persistentDataPath + "/giftData.dat", FileMode.Open);
        giftData.AddGift(currentButtonName);
        bf.Serialize(giftDataFile, giftData);
        giftDataFile.Close();

        SceneManager.LoadScene(4);

    }

    public void noButtonClick()
    {
        Debug.Log("no clicked");
        SceneManager.LoadScene(4);
    }
    
}
