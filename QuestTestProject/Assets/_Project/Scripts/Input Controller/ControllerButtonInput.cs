using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ControllerButtonInput : IControllerButtonInput {

    protected string _inputKey;
    
    [SerializeField]
    protected UnityEvent _onPress = new UnityEvent();
    public UnityEvent OnPress => _onPress;

    [SerializeField]
    protected UnityEvent _onRelease = new UnityEvent();
    public UnityEvent OnRelease => _onRelease;

    [SerializeField]
    protected UnityEvent _onPressed = new UnityEvent();
    public UnityEvent OnPressed => _onPressed;


    public ControllerButtonInput(string inKey) {
        _inputKey = inKey;
    }

    public virtual void CheckInput() {
        if (Input.GetButton(_inputKey)) _onPressed.Invoke();
        if (Input.GetButtonDown(_inputKey)) _onPress.Invoke();
        if (Input.GetButtonUp(_inputKey)) _onRelease.Invoke();
    }
}
