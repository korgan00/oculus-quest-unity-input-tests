using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IControllerStickInput : IControllerButtonInput {

    UnityEvent OnStickStateChange { get; }
    Vector2 stickState { get; }

    void SetKey(string inKey, string inHorizontalKey, string inVerticalKey);

}
