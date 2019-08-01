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
    private ControllerButtonInput _mainButtonYB;
    public IControllerButtonInput mainButtonYB => _mainButtonYB;

    [SerializeField]
    private ControllerButtonInput _mainButtonXA;
    public IControllerButtonInput mainButtonXA => _mainButtonXA;

    [SerializeField]
    private ControllerStickInput _stick;
    public IControllerStickInput stick => _stick;

    public OneHandControllerInput(string indexTriggerKey, string grabTriggerKey, 
                                  string mainButton1Key, string mainButton2Key, 
                                  string stickKey, string stickHKey, string stickVKey) {

        _indexTrigger = _indexTrigger ?? new ControllerSensitiveButtonInput(indexTriggerKey);
        _grabTrigger = _grabTrigger ?? new ControllerSensitiveButtonInput(grabTriggerKey);
        _mainButtonYB = _mainButtonYB ?? new ControllerButtonInput(mainButton1Key);
        _mainButtonXA = _mainButtonXA ?? new ControllerButtonInput(mainButton2Key);
        _stick = _stick ?? new ControllerStickInput(stickKey, stickHKey, stickVKey);
        SetKeys(indexTriggerKey, grabTriggerKey, mainButton1Key, mainButton2Key, stickKey, stickHKey, stickVKey);
    }

    public void SetKeys(string indexTriggerKey, string grabTriggerKey, 
                        string mainButton1Key, string mainButton2Key, 
                        string stickKey, string stickHKey, string stickVKey) {

        _indexTrigger.SetKey(indexTriggerKey);
        _grabTrigger.SetKey(grabTriggerKey);
        _mainButtonYB.SetKey(mainButton1Key);
        _mainButtonXA.SetKey(mainButton2Key);
        _stick.SetKey(stickKey, stickHKey, stickVKey);
    }

    public void CheckInput() {
        _indexTrigger.CheckInput();
        _grabTrigger.CheckInput();
        _mainButtonYB.CheckInput();
        _mainButtonXA.CheckInput();
        _stick.CheckInput();
    }

}
