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

public class CollorChange_Gifts : MonoBehaviour {

    public ScoreData scoreData;
    public BinaryFormatter bf = new BinaryFormatter();
    public Button[] buttons;

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {
            FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            
            scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
            scoreDataFile.Close();
            
            Debug.Log(scoreData.coinScore);
            Debug.Log(scoreData.currentCoinScore);


            if (scoreData.currentCoinScore >= 10)
            {
                Image giftPanel = GameObject.Find("GiftButton_1").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 40)
            {
                Image giftPanel = GameObject.Find("GiftButton_2").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 90)
            {
                Image giftPanel = GameObject.Find("GiftButton_3").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 140)
            {
                Image giftPanel = GameObject.Find("GiftButton_4").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 200)
            {
                Image giftPanel = GameObject.Find("GiftButton_5").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 230)
            {
                Image giftPanel = GameObject.Find("GiftButton_6").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

            if (scoreData.currentCoinScore >= 340)
            {
                Image giftPanel = GameObject.Find("GiftButton_7").GetComponent<Image>();
                giftPanel.color = Color.green;
            }

        }
    }

    public void anyButtonClick()
    {
        string tagString = EventSystem.current.currentSelectedGameObject.tag;
        int tagInt;
        int.TryParse(tagString, out tagInt);

        if(scoreData.currentCoinScore > 0)
        {
            FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData.IncreaseTotalExpense(tagInt);
            bf.Serialize(scoreDataFile, scoreData);
            scoreDataFile.Close();

            FileStream scoreDataFile1 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            ScoreData scoreData1 = (ScoreData)bf.Deserialize(scoreDataFile1);
            scoreDataFile1.Close();

            foreach (Button defButton in buttons)
            {
                string buttonTagString = defButton.tag;
                int buttonTagInt;
                int.TryParse(buttonTagString, out buttonTagInt);

                if (scoreData1.currentCoinScore < buttonTagInt)
                {
                    Image giftPanel = GameObject.FindGameObjectWithTag(defButton.tag).GetComponent<Image>();
                    giftPanel.color = Color.white;
                }
            }            
        }
    }

    /*public void giftButton1Click()    //This gift has value of 10
    {

        if(scoreData.currentCoinScore > 0)
        {
            FileStream scoreDataFile2 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData.IncreaseTotalExpense(10);
            bf.Serialize(scoreDataFile2, scoreData);
            scoreDataFile2.Close();

            UpdateGifts();            
        }
    }*/

    /*public void giftButton2Click()    //This gift has value of 40
    {
        if (scoreData.currentCoinScore > 0)
        {
            FileStream scoreDataFile2 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData.IncreaseTotalExpense(40);
            bf.Serialize(scoreDataFile2, scoreData);
            scoreDataFile2.Close();

            UpdateGifts();
        }
    }*/

    /*public void giftButton3Click()    //This gift has value of 90
    {

        if (scoreData.currentCoinScore > 0)
        {
            FileStream scoreDataFile2 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData.IncreaseTotalExpense(90);
            bf.Serialize(scoreDataFile2, scoreData);
            scoreDataFile2.Close();

            UpdateGifts();

        }
    }*/

    /*public void giftButton4Click()    //This gift has value of 140
    {

        if (scoreData.currentCoinScore > 0)
        {
            FileStream scoreDataFile2 = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData.IncreaseTotalExpense(140);
            bf.Serialize(scoreDataFile2, scoreData);
            scoreDataFile2.Close();

            UpdateGifts();
        }
    }*/

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

    /*public void UpdateGifts()
    {

        FileStream scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
        ScoreData scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
        scoreDataFile.Close();

        if (scoreData.currentCoinScore < 10)
        {
            Image giftPanel = GameObject.Find("GiftButton_1").GetComponent<Image>();
            giftPanel.color = Color.white;
        }

        if (scoreData.currentCoinScore < 40)
        {
            Image giftPanel = GameObject.Find("GiftButton_2").GetComponent<Image>();
            giftPanel.color = Color.white;
        }

        if (scoreData.currentCoinScore < 90)
        {
            Image giftPanel = GameObject.Find("GiftButton_3").GetComponent<Image>();
            giftPanel.color = Color.white;
        }

        if (scoreData.currentCoinScore < 140)
        {
            Image giftPanel = GameObject.Find("GiftButton_4").GetComponent<Image>();
            giftPanel.color = Color.white;
        }
    }*/


}
