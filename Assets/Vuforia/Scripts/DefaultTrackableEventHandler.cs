/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// 
/// Changes made to this file could be overwritten when upgrading the Vuforia version. 
/// When implementing custom event handler behavior, consider inheriting from this class instead.
/// </summary>
public class DefaultTrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PROTECTED_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;

    #endregion // PROTECTED_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    string availabilty;

    public BinaryFormatter bf = new BinaryFormatter();
    public FileStream scoreDataFile;
    public ScoreData scoreData;
    
    protected virtual void Start()
    {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    protected virtual void OnDestroy()
    {
        if (mTrackableBehaviour)
            mTrackableBehaviour.UnregisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        }
        else if (previousStatus == TrackableBehaviour.Status.TRACKED &&
                 newStatus == TrackableBehaviour.Status.NO_POSE)
        {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        }
        else
        {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    #endregion // PUBLIC_METHODS

    #region PROTECTED_METHODS

    protected virtual void OnTrackingFound()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        if (File.Exists(Application.persistentDataPath + "/scoreData.dat"))
        {

            print("TEST123");

            scoreDataFile = File.Open(Application.persistentDataPath + "/scoreData.dat", FileMode.Open);
            
            print("TEST456");
            
            scoreData = (ScoreData)bf.Deserialize(scoreDataFile);
            
            print("TEST789");
            
            scoreDataFile.Close();


            print("TAG and Name");
            
            print(colliderComponents[0].tag);
            print(colliderComponents[0].name);
            

            if(scoreData.Contains(colliderComponents[0].name, colliderComponents[0].tag))
            {
                print("Vuforia Item already collected!");
                foreach (var component in rendererComponents)
                {
                    component.enabled = true;
                    Color color = component.GetComponent<Renderer>().material.color;
                    color.a = 0.40f; //approximately 100/255
                    component.GetComponent<Renderer>().material.color = color;
                }

            } else{

                print("Vuforia Item available!");
                
                foreach (var component in rendererComponents)
                {
                    component.enabled = true;
                    Color color = component.GetComponent<Renderer>().material.color;
                    color.a = 1.00f; //approximately 100/255
                    component.GetComponent<Renderer>().material.color = color;
                }
            }   
     
        }
        else
        {

            Debug.Log("File does not exist");
        }
               
                        
        // Enable colliders:
        foreach (var component in colliderComponents)
            component.enabled = true;

        // Enable canvas':
        foreach (var component in canvasComponents)
            component.enabled = true;
    }


    protected virtual void OnTrackingLost()
    {
        var rendererComponents = GetComponentsInChildren<Renderer>(true);
        var colliderComponents = GetComponentsInChildren<Collider>(true);
        var canvasComponents = GetComponentsInChildren<Canvas>(true);

        // Disable rendering:
        foreach (var component in rendererComponents)
            component.enabled = false;

        // Disable colliders:
        foreach (var component in colliderComponents)
            component.enabled = false;

        // Disable canvas':
        foreach (var component in canvasComponents)
            component.enabled = false;
    }

    #endregion // PROTECTED_METHODS
}

