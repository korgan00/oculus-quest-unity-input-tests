using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pointer : MonoBehaviour {

    [SerializeField]
    private float _maxDistance = 30;
    public float maxDistance => _maxDistance;
    [SerializeField]
    private LayerMask _mask = ~0;

    public RaycastHit raycastInfo;


    void Update() {
        Ray r = new Ray(transform.position, transform.forward);

        Physics.Raycast(r, out raycastInfo, _maxDistance, _mask);
    }

    [ContextMenu("Fire")]
    public void Fire() {
        if (raycastInfo.collider == null) return;
        raycastInfo.collider.GetComponent<CanBePointed>()?.GetFire();
    }

}
