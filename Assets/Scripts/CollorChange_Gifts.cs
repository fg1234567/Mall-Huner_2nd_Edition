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

public class CollorChange_Gifts : MonoBehaviour {

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
                        
            for(int i = 1; i < data.numbOfCollectedItems + 1; i++)
            {
                Button button = GameObject.Find("GiftButton_" + i).GetComponent<Button>();
                button.image.color = UnityEngine.Color.green;
            }                     

        }
        
    }
}
