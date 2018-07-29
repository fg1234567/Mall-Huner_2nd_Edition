using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class CollorChange_Gifts : MonoBehaviour {

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
                        
            for(int i = 1; i < data.numbOfCollectedItems + 1; i++)
            {
                Button button = GameObject.Find("GiftButton_" + i).GetComponent<Button>();
                button.image.color = UnityEngine.Color.green;
            }

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            /*if (data.numbOfCollectedItems == 1)
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.numbOfCollectedItems == 2)
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
                Button button_2 = GameObject.Find("GiftButton_2").GetComponent<Button>();
                button_2.image.color = UnityEngine.Color.green;
            }
            if (data.numbOfCollectedItems == 3)
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
                Button button_2 = GameObject.Find("GiftButton_2").GetComponent<Button>();
                button_2.image.color = UnityEngine.Color.green;
                Button button_3 = GameObject.Find("GiftButton_3").GetComponent<Button>();
                button_3.image.color = UnityEngine.Color.green;
            }
            if (data.numbOfCollectedItems == 4)
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
                Button button_2 = GameObject.Find("GiftButton_2").GetComponent<Button>();
                button_2.image.color = UnityEngine.Color.green;
                Button button_3 = GameObject.Find("GiftButton_3").GetComponent<Button>();
                button_3.image.color = UnityEngine.Color.green;
                Button button_4 = GameObject.Find("GiftButton_4").GetComponent<Button>();
                button_4.image.color = UnityEngine.Color.green;
            }
            if (data.numbOfCollectedItems == 5)
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
                Button button_2 = GameObject.Find("GiftButton_2").GetComponent<Button>();
                button_2.image.color = UnityEngine.Color.green;
                Button button_3 = GameObject.Find("GiftButton_3").GetComponent<Button>();
                button_3.image.color = UnityEngine.Color.green;
                Button button_4 = GameObject.Find("GiftButton_4").GetComponent<Button>();
                button_4.image.color = UnityEngine.Color.green;
                Button button_5 = GameObject.Find("GiftButton_5").GetComponent<Button>();
                button_5.image.color = UnityEngine.Color.green;
            }
            if (data.numbOfCollectedItems == 6 || data.numbOfCollectedItems > 6) // *** second condition is for testing purposes
            {
                Button button_1 = GameObject.Find("GiftButton_1").GetComponent<Button>();
                button_1.image.color = UnityEngine.Color.green;
                Button button_2 = GameObject.Find("GiftButton_2").GetComponent<Button>();
                button_2.image.color = UnityEngine.Color.green;
                Button button_3 = GameObject.Find("GiftButton_3").GetComponent<Button>();
                button_3.image.color = UnityEngine.Color.green;
                Button button_4 = GameObject.Find("GiftButton_4").GetComponent<Button>();
                button_4.image.color = UnityEngine.Color.green;
                Button button_5 = GameObject.Find("GiftButton_5").GetComponent<Button>();
                button_5.image.color = UnityEngine.Color.green;
                Button button_6 = GameObject.Find("GiftButton_6").GetComponent<Button>();
                button_6.image.color = UnityEngine.Color.green;
            }*/

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }
        
    }
}
