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

        DebugText.tmp.text += $"PICKABLE! Handgrips: {activeGrips.Count}\n";
        if (activeGrips.Count == 0) {
            return;
        } else if (activeGrips.Count == 1) {
            transform.rotation = activeGrips[0].gripHand.handlerRotation * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            transform.position = activeGrips[0].gripHand.transform.position + transform.position - activeGrips[0].transform.position;
        } else if (activeGrips.Count >= 2) {
            Vector3 pos1 = activeGrips[1].gripHand.transform.position;
            Vector3 pos2 = activeGrips[0].gripHand.transform.position;
            DebugText.tmp.text += $"{pos1} :: {pos2}\n";

            Vector3 xyz = Vector3.Cross(pos1, pos2);
            float w = Vector3.Distance(pos1, pos2) * Vector3.Dot(pos1, pos2);
            Quaternion q = new Quaternion(xyz.x, xyz.y, xyz.z, w);
            q.Normalize();
            DebugText.tmp.text += $"Quaternion calculado\n";

            transform.rotation = q * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            DebugText.tmp.text += $"Quaternion aplicado\n";
            transform.position = pos1 + transform.position - activeGrips[1].transform.position;
            DebugText.tmp.text += $"transform.position: {transform.position}\n";

            //transform.rotation = activeGrips[0].gripHand.transform.rotation * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            //transform.position = activeGrips[0].gripHand.transform.position + transform.position - activeGrips[0].transform.position;
        }

    }
}
