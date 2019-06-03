using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOneHandControllerInput {

    IControllerSensitiveButtonInput indexTrigger { get; }
    IControllerSensitiveButtonInput grabTrigger { get; }

    IControllerButtonInput mainButton1 { get; }
    IControllerButtonInput mainButton2 { get; }

    IControllerStickInput stick { get; }

    void CheckInput();
}
