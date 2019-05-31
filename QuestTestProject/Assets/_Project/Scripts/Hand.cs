using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{

    public Pickable pickedObject { get; private set; }
    private Pickable currentlyPickable { get; set; }


    private void OnTriggerEnter(Collider other) {
        Pickable currentlyPickable = other.GetComponent<Pickable>();

    }

}
