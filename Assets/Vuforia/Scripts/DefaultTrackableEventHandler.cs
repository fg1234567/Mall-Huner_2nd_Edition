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

        if (File.Exists(Application.persistentDataPath + "/gameData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gameData.dat", FileMode.Open);

            PlayerData gamedata = (PlayerData)bf.Deserialize(file);
            file.Close();
                        
            if (colliderComponents[0].name == "apple")
            {
                availabilty = gamedata.apple;
            }

            if (colliderComponents[0].name == "banana")
            {
                availabilty = gamedata.banana;
            }

            if (colliderComponents[0].name == "bottle")
            {
                availabilty = gamedata.bottle;
            }

            if (colliderComponents[0].name == "cup")
            {
                availabilty = gamedata.cup;
            }

            if (colliderComponents[0].name == "pear")
            {
                availabilty = gamedata.pear;
            }

            if (colliderComponents[0].name == "pumpkin")
            {
                availabilty = gamedata.pumpkin;
            }

            if (colliderComponents[0].name == "orange")
            {
                availabilty = gamedata.orange;
            }


            if (availabilty != null)
            {
                if (availabilty == "collected")
                {
                    // Enable rendering:
                    foreach (var component in rendererComponents)
                    {
                        component.enabled = true;
                        Color color = component.GetComponent<Renderer>().material.color;
                        color.a = 0.40f; //approximately 100/255
                        component.GetComponent<Renderer>().material.color = color;
                    }
                    Debug.Log("availability collected");
                }
                else
                {
                    foreach (var component in rendererComponents)
                    {
                        component.enabled = true;
                        Color color = component.GetComponent<Renderer>().material.color;
                        color.a = 1.00f; //approximately 100/255
                        component.GetComponent<Renderer>().material.color = color;
                    }
                    Debug.Log("availability available");

                }
            }
            else
            {
                foreach (var component in rendererComponents)
                {
                    component.enabled = true;
                }
                Debug.Log("availablity is null");
            }
        }
        else
        {
            foreach (var component in rendererComponents)
            {
                component.enabled = true;
            }
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

