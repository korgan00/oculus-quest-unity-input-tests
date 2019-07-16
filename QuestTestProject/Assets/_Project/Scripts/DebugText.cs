using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugText : MonoBehaviour {

    public static TMPro.TextMeshProUGUI tmp;

    private void Awake() {
        tmp = GetComponent<TMPro.TextMeshProUGUI>();
    }

    public void Update() {
        //tmp.text = "";
    }

}
