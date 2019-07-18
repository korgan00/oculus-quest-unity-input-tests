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
    public float maxDistance;
    
    public void Awake() {
        _handgrips = GetComponentsInChildren<Handgrip>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update() {
        List<Handgrip> activeGrips = _handgrips.Where(hg => hg.gripHand != null).OrderBy(a => a.bottomTopOrder).ToList();

        ApplyHandgrips(activeGrips);
    }

    private void ApplyHandgrips(List<Handgrip> activeGrips) {
        _rigidbody.isKinematic = activeGrips.Count > 0;
        const int TOP = 1;
        const int BOTTOM = 0;

        if (activeGrips.Count == 0) {
            return;

        } else if (activeGrips.Count == 1) {
            transform.rotation = activeGrips[0].gripHand.handlerRotation * (transform.rotation * Quaternion.Inverse(activeGrips[0].transform.rotation));
            transform.position = activeGrips[0].gripHand.transform.position + transform.position - activeGrips[0].transform.position;

        } else if (activeGrips.Count >= 2) {
            Vector3 posBottom = activeGrips[BOTTOM].gripHand.transform.position;
            Vector3 posTop = activeGrips[TOP].gripHand.transform.position;

            Vector3 desiredBottomPosition = posBottom + transform.position - activeGrips[BOTTOM].transform.position;
            Vector3 desiredTopPosition = posTop + transform.position - activeGrips[TOP].transform.position;
            bool shouldBreak = Vector3.SqrMagnitude(desiredBottomPosition - desiredTopPosition) > (maxDistance * maxDistance);

            if (shouldBreak) {
                activeGrips[TOP].gripHand.Release();
                return;
            }

            Vector3 v = (posBottom - posTop).normalized;
            Quaternion q = Quaternion.LookRotation(v);

            transform.rotation = q * Quaternion.AngleAxis(90, Vector3.left);
            transform.position = (desiredBottomPosition + desiredTopPosition) / 2;
        }

    }
}
