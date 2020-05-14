using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxbackground : MonoBehaviour {

    [SerializeField] private float parallaxEffectMultiplier;
    
    private Transform cameraTransform;
    private Vector3 LastCameraPosition;

    private void Start() {
        cameraTransform = Camera.main.transform;
        LastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate() {
        Vector3 deltaMovement = cameraTransform.position - LastCameraPosition;
        transform.position += deltaMovement * parallaxEffectMultiplier;
        LastCameraPosition = cameraTransform.position;
    }

}
