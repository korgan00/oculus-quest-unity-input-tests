using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopChildren : MonoBehaviour {

    public float inmunityTime = 1.0f;
    public float breakThreshold = 3f;

    private void Update() {
        inmunityTime -= Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.relativeVelocity.sqrMagnitude > breakThreshold * breakThreshold) {
            Pop();
            DebugText.tmp.text += $"\nVelocity! {collision.relativeVelocity} :: F -> {collision.relativeVelocity.magnitude}    ";
        }
        DebugText.tmp.text += $"{collision.relativeVelocity.sqrMagnitude}...";
    }


    public void Pop() {
        if (inmunityTime > 0) {
            return;
        }

        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        transform.DetachChildren();
        Destroy(gameObject);
    }
}
