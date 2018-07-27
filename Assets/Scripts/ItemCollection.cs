//====================================================================
// Initialized :13.7.2018  12.30
// Last edited :24.7.2018  13.05 
//====================================================================

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class ItemCollection : MonoBehaviour {

    public static ItemCollection cameraScene;

	string availability;

    Animator fadeOutAnim;

    public Animator endGameAnim;
    public Animator itemNumberAnim;
    public Text itemNumber_Text;
    int numOfItems = 0;

    public CanvasGroup itemCanvas;
    public CanvasGroup giftCanvas;

    bool isItemHolderOpen = false;
    bool isGiftHolderOpen = false;

    UnityEngine.UI.Image defPanel;

    public GameObject endGameAnimationHolder;


    public string apple = "available";
    public string banana = "available";
    public string bottle = "available";
    public string cup = "available";
    public string pear = "available";
    public string pumpkin = "available";
    public string orange = "available";

    public void Awake () {

        itemCanvas.alpha = 0f;
        giftCanvas.alpha = 0f;
    }

    public void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            apple = data.apple;
            banana = data.banana;
            bottle = data.bottle;
            cup = data.cup;
            pear = data.pear;
            pumpkin = data.pumpkin;
            orange = data.orange;

            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
           
            if (apple == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("apple+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("apple");
            }
            if (banana == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("banana+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("banana");
            }
            if (bottle == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("bottle+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("bottle");
            }
            if (cup == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("cup+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("cup");
            }
            if (pear == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("pear+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("pear");
            }
            Debug.Log(pumpkin);
            if (pumpkin == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("pumpkin+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("pumpkin");
            }
            if (orange == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("orange+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
                itemsList.Add("orange");
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }
    }

    List<string> itemsList = new List<string>();

    private void Update () {

       
        //Checks whether the mouse left button is pressed
        if (Input.GetMouseButtonDown(0)){

            if (EventSystem.current.currentSelectedGameObject.name == "UselessButton")
            {
                itemCanvas.alpha = 0f;
                isItemHolderOpen = false;
                giftCanvas.alpha = 0f;
                isGiftHolderOpen = false;
            }

            print("Mouse clicked!");

			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Checks whether the mouse click hits a mesh collider
			if(Physics.Raycast(ray, out hit, 100.0f)){
				if(hit.transform != null ){

					GameObject touchedObj = hit.transform.gameObject;

					PrintName(touchedObj);
                
					fadeOutAnim = (Animator)touchedObj.GetComponent(typeof(Animator));
					if(fadeOutAnim){
                       
                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        
                        if(touchedObj.name == "apple")
                        {
                            availability = apple;
                            apple = "collected";
                        }
                        
                        else if (touchedObj.name == "bottle")
                        {
                            availability = bottle;
                            bottle = "collected";
                        }

                        else if (touchedObj.name == "cup")
                        {
                            availability = cup;
                            cup = "collected";
                        }

                        else if (touchedObj.name == "orange")
                        {
                            availability = orange;
                            orange = "collected";
                        }

                        else if (touchedObj.name == "pumpkin")
                        {
                            availability = pumpkin;
                            pumpkin = "collected";
                        }

                        else if (touchedObj.name == "banana")
                        {
                            availability = banana;
                            banana = "collected";
                        }
                        
                        else if (touchedObj.name == "pear")
                        {
                            availability = pear;
                            pear = "collected";
                        }

                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


                        print("Availibility: " + availability);

                                //Checks wether the object is collected and activates the animation of the touched object
                                if(availability == "available"){
                                    fadeOutAnim.enabled = true;


                                    //numOfItem is incremented each time an object is collected
                                    numOfItems += 1;

                                    // gets and sets the color of the panel named after the clicked object
                                    UnityEngine.UI.Image defPanel = GameObject.Find(touchedObj.name + "+").GetComponent<UnityEngine.UI.Image>();
                                    defPanel.color = UnityEngine.Color.green;
                                    itemsList.Add(touchedObj.name);
                            
                                    //Updates the text on the screen with the number of the collected items
                                    if(numOfItems == 1)
                                    {
                                        itemNumber_Text.text = "You have collected" + " " + numOfItems.ToString() + " " + "item";
                                    }
                                    else if(numOfItems > 1)
                                    {
                                        itemNumber_Text.text = "You have collected" + " " + numOfItems.ToString() + " " + "items";
                                    }

                                    //When all objects are collected end game animation is collected
                                    if (numOfItems == 6)
                                    {
                                        itemNumber_Text.text = "You have collected all items";
                                        itemNumberAnim.enabled = true;
                                        endGameAnimationHolder.SetActive(true);
                                        endGameAnim.enabled = true;
                                    }

                                }else{
                                    print("Item already collected!");
                                    fadeOutAnim.enabled = false;
                                }                             

                    }
                    else
                    {
						print("No animator defined for this object!");

					}
				}
			}
		}

        if (Input.GetKey(KeyCode.Escape))
        {
            
            if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file_1 = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
                PlayerData playerdata = new PlayerData();
                playerdata.apple = apple;
                playerdata.banana = banana;
                playerdata.bottle = bottle;
                playerdata.cup = cup;
                playerdata.pear = pear;
                playerdata.pumpkin = pumpkin;
                playerdata.orange = orange;

                bf.Serialize(file_1, playerdata);
                file_1.Close();
            }
            else //Only in the first play
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file_1 = File.Create(Application.persistentDataPath + "/playerInfo.dat");
                PlayerData playerdata = new PlayerData();
                playerdata.apple = apple;
                playerdata.banana = banana;
                playerdata.bottle = bottle;
                playerdata.cup = cup;
                playerdata.pear = pear;
                playerdata.pumpkin = pumpkin;
                playerdata.orange = orange;

                bf.Serialize(file_1, playerdata);
                file_1.Close();
            }
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            Debug.Log(Application.persistentDataPath);
        }
    }
           

    public void itemsHolderIsClicked()
    {

        if ( !isItemHolderOpen )
        {
            itemCanvas.alpha = 1f;
            isItemHolderOpen = true;
            giftCanvas.alpha = 0f;
            isGiftHolderOpen = false;
        }

        else if (isItemHolderOpen)
        {
            itemCanvas.alpha = 0f;
            isItemHolderOpen = false;
            giftCanvas.alpha = 0f;
            isGiftHolderOpen = false;
        }     
    }


    public void giftHolderIsClicked()
    {

        if (!isGiftHolderOpen)
        {
            giftCanvas.alpha = 1f;
            isGiftHolderOpen = true;        
            itemCanvas.alpha = 0f;
            isItemHolderOpen = false;
        }

        else if (isGiftHolderOpen)
        {
            giftCanvas.alpha = 0f;
            isGiftHolderOpen = false;
            itemCanvas.alpha = 0f;
            isItemHolderOpen = false;
        }

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        if (itemsList.Count == 1)
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
        }
        if (itemsList.Count == 2)
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel2 = GameObject.Find("giftPanel1").GetComponent<UnityEngine.UI.Image>();
            panel2.color = UnityEngine.Color.green;
        }
        if (itemsList.Count == 3)
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel2 = GameObject.Find("giftPanel1").GetComponent<UnityEngine.UI.Image>();
            panel2.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel3 = GameObject.Find("giftPanel2").GetComponent<UnityEngine.UI.Image>();
            panel3.color = UnityEngine.Color.green;
        }
        if (itemsList.Count == 4)
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel2 = GameObject.Find("giftPanel1").GetComponent<UnityEngine.UI.Image>();
            panel2.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel3 = GameObject.Find("giftPanel2").GetComponent<UnityEngine.UI.Image>();
            panel3.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel4 = GameObject.Find("giftPanel3").GetComponent<UnityEngine.UI.Image>();
            panel4.color = UnityEngine.Color.green;
        }
        if (itemsList.Count == 5)
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel2 = GameObject.Find("giftPanel1").GetComponent<UnityEngine.UI.Image>();
            panel2.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel3 = GameObject.Find("giftPanel2").GetComponent<UnityEngine.UI.Image>();
            panel3.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel4 = GameObject.Find("giftPanel3").GetComponent<UnityEngine.UI.Image>();
            panel4.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel5 = GameObject.Find("giftPanel4").GetComponent<UnityEngine.UI.Image>();
            panel5.color = UnityEngine.Color.green;
        }
        if (itemsList.Count == 6 || itemsList.Count > 6) // *** second condition is for testing purposes
        {
            UnityEngine.UI.Image panel1 = GameObject.Find("giftPanel0").GetComponent<UnityEngine.UI.Image>();
            panel1.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel2 = GameObject.Find("giftPanel1").GetComponent<UnityEngine.UI.Image>();
            panel2.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel3 = GameObject.Find("giftPanel2").GetComponent<UnityEngine.UI.Image>();
            panel3.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel4 = GameObject.Find("giftPanel3").GetComponent<UnityEngine.UI.Image>();
            panel4.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel5 = GameObject.Find("giftPanel4").GetComponent<UnityEngine.UI.Image>();
            panel5.color = UnityEngine.Color.green;
            UnityEngine.UI.Image panel6 = GameObject.Find("giftPanel5").GetComponent<UnityEngine.UI.Image>();
            panel6.color = UnityEngine.Color.green;
        }

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    }

    private void PrintName(GameObject go){
    	print(go.name);
    }
}

[Serializable]
class PlayerData
{
    public string apple;
    public string banana;
    public string bottle;
    public string cup;
    public string pear;
    public string pumpkin;
    public string orange;
}
