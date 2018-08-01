using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class ScoreData
{
    public List<string> bronzeCoinList;
    public List<string> silverCoinList;
    public List<string> goldCoinList;
    public int bronzeCoinCount;
    public int silverCoinCount;
    public int goldCoinCount;
    public int coinScore;

    public ScoreData()
    {
        bronzeCoinList = new List<string>();
        silverCoinList = new List<string>();
        goldCoinList = new List<string>();
        bronzeCoinCount = 0;
        silverCoinCount = 0;
        goldCoinCount = 0;
        coinScore = 0;
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

        //calculating coin score
        coinScore = (bronzeCoinCount * 10) + (silverCoinCount * 30) + (goldCoinCount * 50);


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