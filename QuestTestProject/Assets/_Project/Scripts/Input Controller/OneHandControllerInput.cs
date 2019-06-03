using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class OneHandControllerInput : IOneHandControllerInput {
    
    [SerializeField]
    private ControllerSensitiveButtonInput _indexTrigger;
    public IControllerSensitiveButtonInput indexTrigger => _indexTrigger;

    [SerializeField]
    private ControllerSensitiveButtonInput _grabTrigger;
    public IControllerSensitiveButtonInput grabTrigger => grabTrigger;

    [SerializeField]
    private ControllerButtonInput _mainButton1;
    public IControllerButtonInput mainButton1 => _mainButton1;

    [SerializeField]
    private ControllerButtonInput _mainButton2;
    public IControllerButtonInput mainButton2 => _mainButton2;

    [SerializeField]
    private ControllerStickInput _stick;
    public IControllerStickInput stick => _stick;

    public OneHandControllerInput(string indexTriggerKey, string grabTriggerKey, 
                                  string mainButton1Key, string mainButton2Key, 
                                  string stickKey, string stickHKey, string stickVKey) {

        _indexTrigger = new ControllerSensitiveButtonInput(indexTriggerKey);
        _grabTrigger = new ControllerSensitiveButtonInput(indexTriggerKey);
        _mainButton1 = new ControllerButtonInput(mainButton1Key);
        _mainButton2 = new ControllerButtonInput(mainButton2Key);
        _stick = new ControllerStickInput(stickKey, stickHKey, stickVKey);

    }
    
    public void CheckInput() {
        _indexTrigger.CheckInput();
        _grabTrigger.CheckInput();
        _mainButton1.CheckInput();
        _mainButton2.CheckInput();
        _stick.CheckInput();
    }
}
