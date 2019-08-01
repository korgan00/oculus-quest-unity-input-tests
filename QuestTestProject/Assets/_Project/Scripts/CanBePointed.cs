using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CanBePointed : MonoBehaviour {

    public UnityEvent OnFire;

    
    public void GetFire() {
        OnFire.Invoke();
    }
}
