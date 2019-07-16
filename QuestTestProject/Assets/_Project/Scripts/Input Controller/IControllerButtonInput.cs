using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IControllerButtonInput {

    UnityEvent OnPress { get; }
    UnityEvent OnRelease { get; }
    UnityEvent OnPressed { get; }
    
    void CheckInput();
    void SetKey(string key);
}
