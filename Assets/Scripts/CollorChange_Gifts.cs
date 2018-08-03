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

public class CollorChange_Gifts : MonoBehaviour {

    public ScoreData scoreData;
    public BinaryFormatter bf = new BinaryFormatter();
    public Button[] buttons;
    public GameObject areYouSureCanvas;
    public Text areYouSureText;

    public string currentButtonTag;

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {
            FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            
            scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
            scoreDataFile.Close();
            
            Debug.Log(scoreData.coinScore);
            Debug.Log(scoreData.currentCoinScore);

            foreach (Button defButton in buttons)
            {
                string buttonTagString = defButton.tag;
                int buttonTagInt;
                int.TryParse(buttonTagString, out buttonTagInt);

                if (scoreData.currentCoinScore < buttonTagInt)
                {
                    Image giftPanel = GameObject.FindGameObjectWithTag(defButton.tag).GetComponent<Image>();
                    giftPanel.color = Color.white;
                }
                else
                {
                    Image giftPanel = GameObject.FindGameObjectWithTag(defButton.tag).GetComponent<Image>();
                    giftPanel.color = Color.green;
                }
            }           

        }
    }

    public void anyButtonClick()
    {

        currentButtonTag = EventSystem.current.currentSelectedGameObject.tag;
        DontDestroyOnLoad(this.gameObject);
        Debug.Log(currentButtonTag);

        int tagInt;
        int.TryParse(currentButtonTag, out tagInt);

        if(scoreData.currentCoinScore - tagInt >= 0)
        {
            SceneManager.LoadScene(6);                     
        }
        else
        {
            Debug.Log("You do not have enough score to purchasew this gift");
        }
    }
    

    public void test()
    {
        FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);

        ScoreData scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
        scoreDataFile.Close();

        Debug.Log(scoreData.coinScore);
        Debug.Log(scoreData.currentCoinScore);
        Debug.Log(scoreData.bronzeCoinCount);
        Debug.Log(scoreData.silverCoinCount); 
        Debug.Log(scoreData.goldCoinCount);
    }

}
