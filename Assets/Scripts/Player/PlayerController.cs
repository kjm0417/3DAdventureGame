using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float speed;
    private Vector2 curMoveInput;
    public float jumptForce;


    [Header("Look")]
    public Transform cameraContainer;
    public float minAngle; //너무 아래를 안쳐다보게
    public float maxAngle; //너무 위를 안쳐다보게
    private float camCurXRot; //x각도로 얼마나 이동했는지
    public float lookSpeed; //속도
    private Vector2 mouseDelta;

    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        CameraLook();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMoveInput = context.ReadValue<Vector2>();
        }
        else if(context.phase == InputActionPhase.Canceled)
        {
            curMoveInput = Vector2.zero;
        }
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMoveInput.y + transform.right * curMoveInput.x;
        dir *= speed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();   
    }

    private void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSpeed;
        camCurXRot = Mathf.Clamp(camCurXRot, minAngle, maxAngle);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSpeed, 0);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
           rb.AddForce(Vector2.up *jumptForce,ForceMode.Impulse); //점프를 위해 up에 곱해주고 어떤 방식으로 줄건지
        }
    }



}
