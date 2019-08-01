using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOneHandControllerInput {

    IControllerSensitiveButtonInput indexTrigger { get; }
    IControllerSensitiveButtonInput grabTrigger { get; }

    IControllerButtonInput mainButtonYB { get; }
    IControllerButtonInput mainButtonXA { get; }

    IControllerStickInput stick { get; }

    void CheckInput();

    void SetKeys(string indexTriggerKey, string grabTriggerKey,
                string mainButton1Key, string mainButton2Key,
                string stickKey, string stickHKey, string stickVKey);
}
