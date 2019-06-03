using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugButtons : MonoBehaviour
{

    private TMPro.TextMeshProUGUI tmp;

    public bool showLeftButtons = false;
    public bool showRightButtons = false;

    private void Start() {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
    }


    public void Update() {
        string txt = "";

        txt += $"Oculus_GearVR_DpadX {Input.GetAxis("Oculus_GearVR_DpadX")}\n";
        txt += $"Oculus_GearVR_DpadY {Input.GetAxis("Oculus_GearVR_DpadY")}\n";
        txt += $"\n";
        if (showLeftButtons) {
            txt += $"Oculus_GearVR_LThumbstickX {Input.GetAxis("Oculus_GearVR_LThumbstickX")}\n";
            txt += $"Oculus_GearVR_LThumbstickY {Input.GetAxis("Oculus_GearVR_LThumbstickY")}\n";
            txt += $"Oculus_GearVR_LIndexTrigger {Input.GetAxis("Oculus_GearVR_LIndexTrigger")}\n";
        }
        if (showRightButtons) {
            txt += $"Oculus_GearVR_RThumbstickX {Input.GetAxis("Oculus_GearVR_RThumbstickX")}\n";
            txt += $"Oculus_GearVR_RThumbstickX {Input.GetAxis("Oculus_GearVR_RThumbstickY")}\n";
            txt += $"Oculus_GearVR_RIndexTrigger {Input.GetAxis("Oculus_GearVR_RIndexTrigger")}\n";
        }

        txt += $"==============================\n";

        if (showLeftButtons) {
            txt += $"Oculus_CrossPlatform_Button3 {Input.GetAxis("Oculus_CrossPlatform_Button3")}\n";
            txt += $"Oculus_CrossPlatform_Button4 {Input.GetAxis("Oculus_CrossPlatform_Button4")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_PrimaryIndexTrigger {Input.GetAxis("Oculus_CrossPlatform_PrimaryIndexTrigger")}\n";
            txt += $"Oculus_CrossPlatform_PrimaryHandTrigger {Input.GetAxis("Oculus_CrossPlatform_PrimaryHandTrigger")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_PrimaryThumbstickHorizontal {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickHorizontal")}\n";
            txt += $"Oculus_CrossPlatform_PrimaryThumbstickVertical {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstickVertical")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_PrimaryThumbstick {Input.GetAxis("Oculus_CrossPlatform_PrimaryThumbstick")}\n";
            txt += $" -- BUTTON {Input.GetButton("Oculus_CrossPlatform_PrimaryThumbstick")}\n";
            txt += $" -- BUTTON UP {Input.GetButtonUp("Oculus_CrossPlatform_PrimaryThumbstick")}\n";
            txt += $" -- BUTTON DOWN {Input.GetButtonDown("Oculus_CrossPlatform_PrimaryThumbstick")}\n";
        }

        if (showRightButtons) {
            txt += $"Oculus_CrossPlatform_Button1 {Input.GetAxis("Oculus_CrossPlatform_Button1")}\n";
            txt += $"Oculus_CrossPlatform_Button2 {Input.GetAxis("Oculus_CrossPlatform_Button2")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_SecondaryIndexTrigger {Input.GetAxis("Oculus_CrossPlatform_SecondaryIndexTrigger")}\n";
            txt += $"Oculus_CrossPlatform_SecondaryHandTrigger {Input.GetAxis("Oculus_CrossPlatform_SecondaryHandTrigger")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_SecondaryThumbstickHorizontal {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickHorizontal")}\n";
            txt += $"Oculus_CrossPlatform_SecondaryThumbstickVertical {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstickVertical")}\n";
            txt += $"\n";
            txt += $"Oculus_CrossPlatform_SecondaryThumbstick {Input.GetAxis("Oculus_CrossPlatform_SecondaryThumbstick")}\n";
            txt += $" -- BUTTON {Input.GetButton("Oculus_CrossPlatform_SecondaryThumbstick")}\n";
            txt += $" -- BUTTON UP {Input.GetButtonUp("Oculus_CrossPlatform_SecondaryThumbstick")}\n";
            txt += $" -- BUTTON DOWN {Input.GetButtonDown("Oculus_CrossPlatform_SecondaryThumbstick")}\n";
        }



        tmp.text = txt;
    }
}
