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

	bool availability;

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

    public FileStream scoreDataFile;
    public ScoreData scoreData;
    //public BinaryFormatter bf = new BinaryFormatter();

    public void Awake () {

        itemCanvas.alpha = 0f;
        giftCanvas.alpha = 0f;
    }

    public void Start()
    {
        if(File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {
            Debug.Log("score Data file exists");
            

            BinaryFormatter bf = new BinaryFormatter();

            scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
            scoreDataFile.Close();



            Text BronzeCount = GameObject.Find("BronzeCountText").GetComponent<Text>();
            BronzeCount.text = "Bronze: " + scoreData.bronzeCoinCount;

            Text SilverCount = GameObject.Find("SilverCountText").GetComponent<Text>();
            SilverCount.text = "Silver: " + scoreData.silverCoinCount;

            Text GoldCount = GameObject.Find("GoldCountText").GetComponent<Text>();
            GoldCount.text = "Gold: " + scoreData.goldCoinCount;


            // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!


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

					print(touchedObj.name);
                
					fadeOutAnim = (Animator)touchedObj.GetComponent(typeof(Animator));
					if(fadeOutAnim){

                        BinaryFormatter bf = new BinaryFormatter();
                       
                        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                        scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
                        scoreData = (ScoreData)bf.Deserialize(scoreDataFile);

                        Debug.Log("Touched bronzeCoinCount: " + scoreData.bronzeCoinCount);
                        Debug.Log("Touched silverCoinCount: " + scoreData.silverCoinCount);
                        Debug.Log("Touched goldCoinCount: " + scoreData.goldCoinCount);

                        scoreDataFile.Close();

                        if(scoreData.Contains(touchedObj.name, touchedObj.tag))
                        {
                            print("Item already collected!");
                            //fadeOutAnim.enabled = false;
                            //scoreDataFile.Close();
                        } else{
                            
                            scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
                            print("Item available now");
                            scoreData.CollectCoin(touchedObj.name, touchedObj.tag);
                            bf.Serialize(scoreDataFile, scoreData);
                            fadeOutAnim.enabled = true;
                            scoreDataFile.Close();
                        }

                        Debug.Log("Touched 2 bronzeCoinCount: " + scoreData.bronzeCoinCount);
                        Debug.Log("Touched 2 silverCoinCount: " + scoreData.silverCoinCount);
                        Debug.Log("Touched 2 goldCoinCount: " + scoreData.goldCoinCount);

                        scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
                        scoreData = (ScoreData)bf.Deserialize(scoreDataFile);

                        Debug.Log("Touched 3 bronzeCoinCount: " + scoreData.bronzeCoinCount);
                        Debug.Log("Touched 3 silverCoinCount: " + scoreData.silverCoinCount);
                        Debug.Log("Touched 3 goldCoinCount: " + scoreData.goldCoinCount);

                        scoreDataFile.Close();



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

        /*
        for (int i = 0; i < numbOfCollectedItems; i++)
        {
            Image image = GameObject.Find("giftPanel" + i).GetComponent<Image>();
            image.color = UnityEngine.Color.green;
        }
        */

    }


}

