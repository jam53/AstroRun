using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EnableDisablePP : MonoBehaviour
{
    public Camera MainCamera;
    // Start is called before the first frame update
    void Start()
    {
        if (GPGSAutenthicator.GPGSZelf.LoadBool(31))//if true, use post processing
        {
            MainCamera.GetUniversalAdditionalCameraData().renderPostProcessing = true;
        }

        else if (!GPGSAutenthicator.GPGSZelf.LoadBool(31))//if false, dont use post processing
        {
            MainCamera.GetUniversalAdditionalCameraData().renderPostProcessing = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
