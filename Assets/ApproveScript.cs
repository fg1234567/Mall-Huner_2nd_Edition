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
    public BinaryFormatter bf = new BinaryFormatter();

    public string currentButtonTag;


    public void Start()
    {
        FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);

        scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
        scoreDataFile.Close();

        currentButtonTag = FindObjectOfType<CollorChange_Gifts>().currentButtonTag;

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

        SceneManager.LoadScene(4);

    }

    public void noButtonClick()
    {
        Debug.Log("no clicked");
        SceneManager.LoadScene(4);
    }
    
}
