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
    private bool isGround = true;
    public LayerMask layMask;


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

    private void Update()
    {
        IsGround();
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
        if(context.phase == InputActionPhase.Started && IsGround() == true)
        {
           rb.AddForce(Vector3.up *jumptForce,ForceMode.Impulse); //점프를 위해 up에 곱해주고 어떤 방식으로 줄건지
        }
    }

    private bool IsGround()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        RaycastHit hit;

        Debug.DrawRay(transform.position, Vector3.down * 6f);
        if (Physics.Raycast(ray, out hit, 2f, layMask))
        {
            return true;
        }

        return false;
    }

    public void OnWeqponChange(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            int weaponNumber = (int)context.ReadValue<float>();
        }
    }
    private void HandleWeaponInput(int weaponNumber)
    {
        switch (weaponNumber)
        {
            case 1:
                _attackManager.SetAttackStrategy(new GunAttack());
                break;
            case 2:
                _attackManager.SetAttackStrategy(new ThrowAttack());
                break;
            case 3:
                _attackManager.SetAttackStrategy(new CircularMagicAttack());
                break;
            default:
                Debug.Log("Invalid weapon number");
                break;
        }
    }


}
