using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[Serializable]
public class GiftData
{
    public List<string> giftList;
    public int giftCount;


    public GiftData()
    {
        giftList = new List<string>();
        giftCount = 0;
    }

    public void AddGift(string giftName)
    {
        Debug.Log("gift registered!");
        giftList.Add(giftName);
        giftCount++;    
    }

}