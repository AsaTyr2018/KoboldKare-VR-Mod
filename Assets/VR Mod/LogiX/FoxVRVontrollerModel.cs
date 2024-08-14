using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FoxVRVontrollerModel : MonoBehaviour
{



    [SerializeField]
    private Transform controllerVisual;
    [SerializeField]
    private Transform handVisual;
    private List<InputDevice> devices = new List<InputDevice>(); 
    [SerializeField]
    private List<aboutController> controllerData = new List<aboutController>();
    public UnityEngine.InputSystem.InputActionReference controllerActivity;



    void OnEnable()
    {
        InputDevices.deviceConnected += DeviceConnected; 
        InputDevices.GetDevices(devices);
        foreach (var device in devices)
            DeviceConnected(device);
        InputDevices.deviceDisconnected += DeviceDisconnected;
    }

    void OnDisable()
    {
        InputDevices.deviceConnected -= DeviceConnected;
        InputDevices.deviceDisconnected -= DeviceDisconnected;
    }




    void DeviceConnected(InputDevice device) //Make it go into one handed/seated mode if one/none controllers presented
    {
        print(device.name);
        print(device.manufacturer);
        print(device.characteristics);
        UpdateVisuals(device);
        
        /*
        if ((device.characteristics & InputDeviceCharacteristics.Left) != 0)
        {
            UpdateVisuals(device);
        }
        else if ((device.characteristics & InputDeviceCharacteristics.Right) != 0)
        {
            UpdateVisuals(device);
        }*/
    }



    void DeviceDisconnected(InputDevice device) //Make it go into one handed/seated mode if one/none controllers presented
    {
        StartCoroutine(FoxVRLoader.ControllerDiedAt(transform.position));
    }




    private void UpdateVisuals(InputDevice device)
    {
        if (device.characteristics.HasFlag(InputDeviceCharacteristics.Controller))
        {
            if (device.characteristics.HasFlag(InputDeviceCharacteristics.Left))
                controllerVisual.localScale = new Vector3(1, 1, 1);
            else
                controllerVisual.localScale = new Vector3(-1, 1, 1);
        }
        //Wanted to use switch, but im too dumb to work with flags

        foreach (aboutController controller in controllerData)   
        {
            if (device.name.Contains(controller.name))
            {
                controllerVisual.GetComponent<MeshFilter>().mesh = controller.mesh;

                controllerVisual.localPosition = controller.modelPositionOffset;
                controllerVisual.localRotation = Quaternion.Euler(controller.modelRotationOffset);

                handVisual.localPosition = controller.handPositionOffset;
                handVisual.localRotation = Quaternion.Euler(controller.handRotationOffset);

                return;
            }
        }
    }












    [System.Serializable]
    private class aboutController
    {
        public string name;
        [Space(5)]
        public Mesh mesh;
        [Space(15)]
        public Vector3 modelPositionOffset;
        public Vector3 modelRotationOffset;
        [Space(5)]
        public Vector3 handPositionOffset;
        public Vector3 handRotationOffset;
    }

}
