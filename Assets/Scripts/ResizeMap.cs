using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResizeMap : MonoBehaviour {

    float lastClickTime = -1.50f;
    float allowedTimeInterval = 1.50f;

    public RawImage map;
    public RawImage marker1;
    public RawImage marker2;
    bool isMapLarge = false;
    
    public void Update()
    {
        /*if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(marker1.rectTransform.position);
            Debug.Log(Input.mousePosition);
            if(Time.time - lastClickTime < allowedTimeInterval)
            {
                Debug.Log("duble click");

                if (!isMapLarge)
                {
                    map.rectTransform.sizeDelta = new Vector2(2151.10f, 2977.20f);
                    //marker1.rectTransform.position = new Vector3(-402.00f, 297.00f, 0); 
                    Debug.Log(marker1.rectTransform.position);


                    isMapLarge = true;
                }
                else
                {
                    map.rectTransform.sizeDelta = new Vector2(717.70f, 992.40f);
                    //marker1.rectTransform.position = new Vector3(-134.00f, 297.00f, 0);
                    Debug.Log(marker1.rectTransform.position);

                    isMapLarge = false;
                }
            }
            else
            {
                Debug.Log("single click");
            }
            lastClickTime = Time.time;
        }*/
    }

}
