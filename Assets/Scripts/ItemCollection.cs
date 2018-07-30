//====================================================================
// Initialized :18.7.2018  12.30
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


public class ItemCollection : MonoBehaviour {

    public static ItemCollection cameraScene;

	string availability;

    Animator fadeOutAnim;

    public Animator endGameAnim;
    public Animator itemNumberAnim;
    public Text itemNumber_Text;

    public CanvasGroup itemCanvas;
    public CanvasGroup giftCanvas;

    bool isItemHolderOpen = false;
    bool isGiftHolderOpen = false;

    UnityEngine.UI.Image defPanel;

    public GameObject endGameAnimationHolder;
        
    string apple = "available";
    string banana = "available";
    string bottle = "available";
    string cup = "available";
    string pear = "available";
    string pumpkin  = "available";
    string orange = "available";
    int numbOfCollectedItems = 0;

    public void Awake () {

        itemCanvas.alpha = 0f;
        giftCanvas.alpha = 0f;
    }

    public void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            Debug.Log("file exist");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();

            apple = data.apple;
            banana = data.banana;
            bottle = data.bottle;
            cup = data.cup;
            pear = data.pear;
            pumpkin = data.pumpkin;
            orange = data.orange;
            numbOfCollectedItems = data.numbOfCollectedItems;


            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

            if (apple == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("apple+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (banana == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("banana+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (bottle == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("bottle+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (cup == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("cup+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (pear == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("pear+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (pumpkin == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("pumpkin+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            if (orange == "collected")
            {
                UnityEngine.UI.Image defPanel = GameObject.Find("orange+").GetComponent<UnityEngine.UI.Image>();
                defPanel.color = UnityEngine.Color.green;
            }
            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

        }
    }

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
                                    numbOfCollectedItems += 1;


                                    // gets and sets the color of the panel named after the clicked object
                                    UnityEngine.UI.Image defPanel = GameObject.Find(touchedObj.name + "+").GetComponent<UnityEngine.UI.Image>();
                                    defPanel.color = UnityEngine.Color.green;
                            
                                    //Updates the text on the screen with the number of the collected items
                                    /*if(numOfItems == 1)
                                    {
                                        itemNumber_Text.text = "You have collected" + " " + numOfItems.ToString() + " " + "item";
                                    }
                                    else if(numOfItems > 1)
                                    {
                                        itemNumber_Text.text = "You have collected" + " " + numOfItems.ToString() + " " + "items";
                                    }*/

                                    //When all objects are collected end game animation is collected
                                    if (numbOfCollectedItems == 6)
                                    {
                                        //itemNumber_Text.text = "You have collected all items";
                                        //itemNumberAnim.enabled = true;
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
            
            if(File.Exists(Application.persistentDataPath + "/gameData.dat"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file_1 = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);
                PlayerData playerdata = new PlayerData();
                playerdata.apple = apple;
                playerdata.banana = banana;
                playerdata.bottle = bottle;
                playerdata.cup = cup;
                playerdata.pear = pear;
                playerdata.pumpkin = pumpkin;
                playerdata.orange = orange;
                playerdata.numbOfCollectedItems = numbOfCollectedItems;

                bf.Serialize(file_1, playerdata);
                file_1.Close();
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file_1 = File.Create(Application.persistentDataPath + "/gameData.dat");
                PlayerData playerdata = new PlayerData();
                playerdata.apple = apple;
                playerdata.banana = banana;
                playerdata.bottle = bottle;
                playerdata.cup = cup;
                playerdata.pear = pear;
                playerdata.pumpkin = pumpkin;
                playerdata.orange = orange;
                playerdata.numbOfCollectedItems = numbOfCollectedItems;

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

        for (int i = 0; i < numbOfCollectedItems; i++)
        {
            Image image = GameObject.Find("giftPanel" + i).GetComponent<Image>();
            image.color = UnityEngine.Color.green;
        }

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
    public int numbOfCollectedItems;
}