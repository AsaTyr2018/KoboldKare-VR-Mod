using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class FoxControllerBindingsTip : MonoBehaviour
{
    public static string controllerName;

    [SerializeField] GameObject indexBindings;
    [SerializeField] GameObject viveBindings;
    [SerializeField] GameObject metaBindings;
    [SerializeField] GameObject oculusBindings;
    [SerializeField] GameObject wmrBindings;
    [SerializeField] GameObject focusBindings;
    // Start is called before the first frame update
    void Start()
    {
    }
}
