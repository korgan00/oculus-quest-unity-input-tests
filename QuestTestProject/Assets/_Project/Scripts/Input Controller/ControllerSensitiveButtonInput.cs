using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ControllerSensitiveButtonInput : ControllerButtonInput, IControllerSensitiveButtonInput {

    [SerializeField]
    [Range(0f, 1f)]
    private float _buttonThreshold = 0.9f;

    public float buttonPreassure { get; private set; }
    
    public ControllerSensitiveButtonInput(string inKey) : base(inKey) { }
    
    public override void CheckInput() {

        float oldButtonPreassure = buttonPreassure;
        buttonPreassure = Input.GetAxis(_inputKey);
        
        if (buttonPreassure > _buttonThreshold) _onPressed?.Invoke();
        if (oldButtonPreassure <= _buttonThreshold && buttonPreassure > _buttonThreshold) _onPress?.Invoke();
        if (oldButtonPreassure > _buttonThreshold && buttonPreassure <= _buttonThreshold) _onRelease?.Invoke();
    }
    
}
