using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Handgrip currentGrip { get; private set; }
    private Handgrip availableGrip { get; set; }


    private void OnTriggerEnter(Collider other) {
        Handgrip triggeredHandGrip = other.GetComponentInParent<Handgrip>();
        if (triggeredHandGrip) {
            availableGrip = triggeredHandGrip;
            Debug.Log(availableGrip.name);
        }
    }

    private void OnTriggerExit(Collider other) {
        Handgrip triggeredOutHandGrip = other.GetComponentInParent<Handgrip>();
        if (triggeredOutHandGrip) {
            availableGrip = null;
            Debug.Log($"NOT : {availableGrip?.name}");
        }
    }

    [ContextMenu("Pick")]
    public void Pick() {
        GetComponentInChildren<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
        if (availableGrip && !availableGrip.gripHand) {
            currentGrip = availableGrip;
            availableGrip.gripHand = this;
        }
    }

    [ContextMenu("Release")]
    public void Release() {
        GetComponentInChildren<MeshRenderer>().material.color = Color.black;
        if (currentGrip) {
            if (currentGrip.gripHand == this) {
                currentGrip.gripHand = null;
            }
            currentGrip = null;
        }
    }

}
