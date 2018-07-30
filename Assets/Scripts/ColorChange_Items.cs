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

public class ColorChange_Items : MonoBehaviour
{

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (data.apple == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("apple+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.banana == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("banana+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.bottle == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("bottle+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.cup == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("cup+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.pear == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("pear+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.pumpkin == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("pumpkin+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            if (data.orange == "collected")
            {
                UnityEngine.UI.Button button_1 = GameObject.Find("orange+").GetComponent<UnityEngine.UI.Button>();
                button_1.image.color = UnityEngine.Color.green;
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }


    }
}
