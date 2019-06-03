using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SpatialTracking;

[ExecuteInEditMode]
public class TrackedElements : MonoBehaviour {

    public TrackedPoseDriver rightHand;
    public TrackedPoseDriver leftHand;
    public TrackedPoseDriver head;

    private void Start() {
        TrackedPoseDriver[] poseDriver = GetComponentsInChildren<TrackedPoseDriver>();
        foreach (TrackedPoseDriver driver in poseDriver) {
            switch (driver.poseSource) {
                case TrackedPoseDriver.TrackedPose.LeftPose:
                    if (leftHand == null)
                        leftHand = driver;
                break;
                case TrackedPoseDriver.TrackedPose.RightPose:
                    if (rightHand == null)
                        rightHand = driver;
                break;
                case TrackedPoseDriver.TrackedPose.Head:
                    if (head == null)
                        head = driver;
                break;
            }
        }
    }
}
