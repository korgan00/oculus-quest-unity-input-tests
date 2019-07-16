using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Pickable : MonoBehaviour {

    private Handgrip[] _handgrips;
    private Rigidbody _rigidbody;
    
    public void Awake() {
        _handgrips = GetComponentsInChildren<Handgrip>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        List<Handgrip> activeGrips = _handgrips.Where(hg => hg.gripHand != null).ToList();

        ApplyHandgrips(activeGrips);
    }

    private void ApplyHandgrips(List<Handgrip> activeGrips) {
        _rigidbody.isKinematic = activeGrips.Count > 0;

        if (activeGrips.Count == 0) {
            return;
        } else if (activeGrips.Count == 1) {
            transform.rotation = activeGrips[0].gripHand.transform.rotation * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            transform.position = activeGrips[0].gripHand.transform.position + transform.position - activeGrips[0].transform.position;
        } else if (activeGrips.Count > 2) {
            //transform.rotation = activeGrips[0].gripHand.transform.rotation * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            //transform.position = activeGrips[0].gripHand.transform.position + transform.position - activeGrips[0].transform.position;
        }

    }
}
