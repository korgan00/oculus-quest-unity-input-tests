using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(Pointer))]
public class LineRendererPointer : MonoBehaviour {

    private Pointer _pointer;
    private LineRenderer _lineRenderer;

    private void Start() {
        _pointer = GetComponent<Pointer>();
        _lineRenderer = GetComponent<LineRenderer>();
    }

    void Update() {
        Vector3 v = _pointer.raycastInfo.collider != null ? _pointer.raycastInfo.point : transform.forward * _pointer.maxDistance + transform.position;
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPositions(new Vector3[] {transform.position, v});
        
    }
}
