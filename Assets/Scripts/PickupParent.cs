using UnityEngine;
using System.Collections;

[RequireComponent (typeof(SteamVR_TrackedObject))]
public class PickupParent : MonoBehaviour {
    SteamVR_TrackedObject trackedObj;
    SteamVR_Controller.Device device;



    void Awake () {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
	}
	

	void FixedUpdate () {
        device = SteamVR_Controller.Input((int)trackedObj.index);

        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You're currently touching the 'Touch' trigger");

        }

        if (device.GetTouchDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You're currently using the TouchDown method on the trigger");
        }

        if (device.GetTouchUp(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You're currently using the TouchUp method on the trigger");
        }

        if (device.GetPress(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You're currently using the Press method on the trigger");
        }

    }

    void OnTriggerStay (Collider col)
    {
        Debug.Log("You have collided with " + col.name +  " and activated OnTriggerStay");
        if (device.GetTouch(SteamVR_Controller.ButtonMask.Trigger))
        {
            Debug.Log("You have collided with " + col.name + " while holding down touch");
            col.attachedRigidbody.isKinematic = true;
            col.gameObject.transform.SetParent(gameObject.transform);

        }
        else {
            col.attachedRigidbody.isKinematic = false;
            Debug.Log("You let go of " + col.name);
        }
    }
}
