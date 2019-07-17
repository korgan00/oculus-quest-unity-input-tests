using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Handgrip : MonoBehaviour {

    public Hand gripHand;

    private void Update() {
        DebugText.tmp.text += $"GRIP! {name}: {(gripHand ? gripHand.name : "null")}\n";
    }
}
