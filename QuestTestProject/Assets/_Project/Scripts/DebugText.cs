using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour {

    public static TMPro.TextMeshProUGUI tmp;
    public bool clearPerFrame = true;

    private void Awake() {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
        tmp.text = "";
    }

    public void Update() {
        if (clearPerFrame) tmp.text = "";
    }

}
