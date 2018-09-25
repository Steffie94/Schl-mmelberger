using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityStandardAssets.Characters.FirstPerson;
//[RequireComponent(typeof(FirstPersonController))]

public class Schwimmen : MonoBehaviour {
    /*
    public string Water = “Aqua”;
	[Range(-0.2f, 0.2f)] public float toleranceHeight = 0.1f;// Höhentoleranz
    [Range(-0.5f, 2.0f)] public float speedVertical = 1.5f; // vertikale Geschwindigkeit
    private FirstPersonController FPSController;
    private CharacterController controller;
    private bool insideWater = false; //Im Wasser true or false
                                      //Wasserhöhe in der Welt, Höhenreglereinstellung
    private float waterHeight, AdjustmentController;
    private float originalWalkSpeed, originalRunSpeed, originalJumpSpeed, originalGravity;

    void Awake()
    {
        FPSController = GetComponent<FirstPersonController>();
        controller = GetComponent<CharacterController>();
        AdjustmentController = 0.275f * controller.height;
        originalWalkSpeed = FPSController.m_WalkSpeed;
        originalRunSpeed = FPSController.m_RunSpeed;
        originalJumpSpeed = FPSController.m_JumpSpeed;
        originalGravity = FPSController.m_GravityMultiplier;
    }
    void Update()
    {
        if (insideWater == true && (transform.position.y < (waterHeight - AdjustmentController + (toleranceHeight * AdjustmentController))))
        {
            FPSController.m_WalkSpeed = 2.0f;
            PSController.m_RunSpeed = 2.0f;
            FPSController.m_JumpSpeed = 0.0f;
            //
            float inputGravityY = (-Camera.main.transform.forward.y / 20.0f) * Input.GetAxis(“Vertical”) * speedVertical;
            if (Input.GetKey(KeyCode.Space))
            { inputGravityY -= 0.15f * speedVertical; }
            if (Mathf.Abs(controlador.velocity.y) > 2.0f)
            { inputGravityY += controller.velocity.y * speedVertical; }
            FPSController.m_GravityMultiplier = inputGravityY;
            if (Mathf.Abs(Input.GetAxis(“Vertical”)) < 0.5f && Mathf.Abs(Input.GetAxis(“Horizontal”)) < 0.5f && !Input.GetKey(KeyCode.Space))
            {
                FPSController.m_GravityMultiplier = 0;
                FPSController.m_MoveDir = Vector3.Lerp(FPSController.m_MoveDir, Vector3.zero, Time.deltaTime * 2.0f);
            }
        }
        else
        {
            FPSController.m_WalkSpeed = Math.Lerp(FPSController.m_WalkSpeed, originalWalkSpeed, Time.deltaTime * 2.0f);
            PSController.m_RunSpeed = Math.Lerp(FPSController.m_ RunSpeed, original RunSpeed, Time.deltaTime * 2.0f);
            FPSController.m_JumpSpeed = Math.Lerp(FPSController.m_ JumpSpeed, original JumpSpeed, Time.deltaTime * 0.5f);
            FPSController.m_GravityMultiplier = Math.Lerp(FPSController.m_ GravityMultiplier, original Gravity, Time.deltaTime * 2.0f);

        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag(Water))
        {
            insideWater = true;
            waterHeight = collider.gameObject.GetComponent<BoxCollider>().bounds.center.y + collider.gameObject.GetComponent<BoxCollider>().bounds.extents.y;
        }
    }
    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag(Water))
        {
            insideWater = false;
        }
    }
*/
}
