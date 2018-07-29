using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeColor_PositionIcons : MonoBehaviour {

    public void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            Debug.Log("file exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (data.apple == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(0)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            if (data.banana == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(1)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            if (data.bottle == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(2)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            if (data.cup == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(3)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            if (data.pear == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(4)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            if (data.pumpkin == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(5)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;                
            }
            if (data.orange == "collected")
            {
                RawImage defPanel = GameObject.Find("RawImage(6)").GetComponent<RawImage>();
                Color color = defPanel.color;
                color.r = 0.16f; //Approximately 40/255
                color.b = 0.00f;
                defPanel.color = color;
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        }
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
