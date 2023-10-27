using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class ThrowEventHandler : MonoBehaviour
{
    [SerializeField] private InputActionReference throwActionReference;
    [SerializeField] private Transform rightControllerTransform;
    [SerializeField] private Transform leftControllerTransform;
    [SerializeField] public float throwForce = 500.0f;

    public Vector3 releasePosition { get; private set; }
    private Rigidbody body;
    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        body = GetComponent<Rigidbody>();
        grabInteractable = GetComponent<XRGrabInteractable>();
        
        if (grabInteractable)
            grabInteractable.onSelectExited.AddListener(HandleRelease);
    }

    private void OnEnable()
    {
        if (throwActionReference)
        {
            throwActionReference.action.performed += HandleThrow;
            throwActionReference.action.Enable();
        }
    }

    private void OnDisable()
    {
        if (throwActionReference)
        {
            throwActionReference.action.performed -= HandleThrow;
            throwActionReference.action.Disable();
        }

        if (grabInteractable)
            grabInteractable.onSelectExited.RemoveListener(HandleRelease);
    }

    private void HandleThrow(InputAction.CallbackContext context)
    {
        Transform activeController = (context.control.device.name.Contains("Right")) ? rightControllerTransform : leftControllerTransform;
        Vector3 throwDirection = (activeController.forward + Vector3.up).normalized;
        body.AddForce(throwDirection * throwForce);
    }

    private void HandleRelease(XRBaseInteractor interactor)
    {
        releasePosition = transform.position;
        Transform activeController = (interactor.transform == rightControllerTransform) ? rightControllerTransform : leftControllerTransform;
        Vector3 throwDirection = (activeController.forward + Vector3.up).normalized;
        body.AddForce(throwDirection * throwForce);
    }
}
