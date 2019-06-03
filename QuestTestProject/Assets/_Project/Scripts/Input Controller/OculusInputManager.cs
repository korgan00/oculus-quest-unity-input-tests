using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class OculusInputManager : MonoBehaviour {

    public static OculusInputManager _instance;
    public static OculusInputManager instance {
        get {
            if (_instance == null) {
                // if exists on scene, is associated
                _instance = FindObjectOfType<OculusInputManager>();

                if (_instance == null) {
                    // if not exists, this tries to add it to the EventSystem GameObject
                    EventSystem instanceHolder = FindObjectOfType<EventSystem>();
                    if (instanceHolder != null) {
                        _instance = instanceHolder.gameObject.AddComponent<OculusInputManager>();
                    } else {
                        // Creates a dedicated GameObject in other case.
                        _instance = new GameObject("OculusInputManager").AddComponent<OculusInputManager>();
                    }
                }
            }
            return _instance;
        }
    }

    [SerializeField]
    private OneHandControllerInput _leftHand;
    public IOneHandControllerInput leftHandController => _leftHand;
    public static IOneHandControllerInput leftHand => _instance?.leftHandController;

    [SerializeField]
    private OneHandControllerInput _rightHand;
    public IOneHandControllerInput rightHandController => _rightHand;
    public static IOneHandControllerInput rightHand => _instance?.rightHandController;
    
    private void Awake() {
        _rightHand = new OneHandControllerInput("Oculus_CrossPlatform_SecondaryIndexTrigger",
                                                "Oculus_CrossPlatform_SecondaryHandTrigger",
                                                "Oculus_CrossPlatform_Button1",
                                                "Oculus_CrossPlatform_Button2",
                                                "Oculus_CrossPlatform_SecondaryThumbstick",
                                                "Oculus_CrossPlatform_SecondaryThumbstickHorizontal",
                                                "Oculus_CrossPlatform_SecondaryThumbstickVertical");

        _leftHand = new OneHandControllerInput( "Oculus_CrossPlatform_PrimaryIndexTrigger",
                                                "Oculus_CrossPlatform_PrimaryHandTrigger",
                                                "Oculus_CrossPlatform_Button3",
                                                "Oculus_CrossPlatform_Button4",
                                                "Oculus_CrossPlatform_PrimaryThumbstick",
                                                "Oculus_CrossPlatform_PrimaryThumbstickHorizontal",
                                                "Oculus_CrossPlatform_PrimaryThumbstickVertical");

        _instance = this;

        /*
        txt += $"Oculus_CrossPlatform_Button1 {Input.GetAxis("Oculus_CrossPlatform_Button1")}\n";
        txt += $"Oculus_CrossPlatform_Button2 {Input.GetAxis("Oculus_CrossPlatform_Button2")}\n";
        txt += $"Oculus_CrossPlatform_SecondaryIndexTrigger {Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger")}\n";
        txt += $"Oculus_CrossPlatform_SecondaryHandTrigger {Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger")}\n";
        txt += $"Oculus_CrossPlatform_SecondaryThumbstickHorizontal {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal")}\n";
        txt += $"Oculus_CrossPlatform_SecondaryThumbstickVertical {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical")}\n";
        txt += $"Oculus_CrossPlatform_SecondaryThumbstick {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstick")}\n";
        
        txt += $"Oculus_CrossPlatform_Button3 {Input.GetAxis("Oculus_CrossPlatform_Button3")}\n";
        txt += $"Oculus_CrossPlatform_Button4 {Input.GetAxis("Oculus_CrossPlatform_Button4")}\n";
        txt += $"Oculus_CrossPlatform_PrimaryIndexTrigger {Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger")}\n";
        txt += $"Oculus_CrossPlatform_PrimaryHandTrigger {Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger")}\n";
        txt += $"Oculus_CrossPlatform_PrimaryThumbstickHorizontal {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")}\n";
        txt += $"Oculus_CrossPlatform_PrimaryThumbstickVertical {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical")}\n";
        txt += $"Oculus_CrossPlatform_PrimaryThumbstick {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstick")}\n";
        */
    }


    void Update() {
        _leftHand.CheckInput();
        _rightHand.CheckInput();
    }
}
