using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class ControllerStickInput : ControllerButtonInput, IControllerStickInput {
    
    protected string _inputHKey;
    protected string _inputVKey;

    public Vector2 stickState { get; private set; }
    
    [SerializeField]
    protected UnityEvent _onStickStateChange;
    public UnityEvent OnStickStateChange => _onStickStateChange;

    public ControllerStickInput(string inKey, string inHorizontalKey, string inVerticalKey) : base(inKey) {
        SetKey(inKey, inHorizontalKey, inVerticalKey);
    }

    public override void CheckInput() {
        if (stickState.x != Input.GetAxis(_inputHKey) || stickState.y != Input.GetAxis(_inputVKey)) {
            stickState = new Vector2(Input.GetAxis(_inputHKey), Input.GetAxis(_inputVKey));
            _onStickStateChange?.Invoke();
        }

        base.CheckInput();
    }

    public void SetKey(string inKey, string inHorizontalKey, string inVerticalKey) {
        SetKey(inKey);
        _inputHKey = inHorizontalKey;
        _inputVKey = inVerticalKey;
    }
}
