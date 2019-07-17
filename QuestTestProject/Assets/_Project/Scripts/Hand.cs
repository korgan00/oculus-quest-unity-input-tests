using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Handgrip currentGrip { get; private set; }
    private Handgrip availableGrip { get; set; }

    public Quaternion upRotation => transform.rotation;
    public Quaternion forwardRotation => transform.rotation * Quaternion.Euler(90, 0, 0);
    public Quaternion handlerRotation => transform.rotation * Quaternion.Euler(45, 0, 0);


    private void OnTriggerStay(Collider other) {
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

    private void Update() {
        DebugText.tmp.text += $"HAND! {name}:: available: {(availableGrip ? availableGrip.name : "null")} ||  current: {(currentGrip ? currentGrip.name : "null")}\n";
    }

    [ContextMenu("Pick")]
    public void Pick() {
        GetComponentInChildren<MeshRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
        if (availableGrip && !availableGrip.gripHand) {
            currentGrip = availableGrip;
            currentGrip.gripHand = this;
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
