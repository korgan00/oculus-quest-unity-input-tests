using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ControllerSensitiveButtonInput : ControllerButtonInput, IControllerSensitiveButtonInput {
    
    public float buttonPreassure { get; private set; }
    
    public ControllerSensitiveButtonInput(string inKey) : base(inKey) { }
    
    public override void CheckInput() {
        buttonPreassure = Input.GetAxis(_inputKey);
        base.CheckInput();
    }
}
