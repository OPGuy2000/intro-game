using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour  
{
    public CharacterController controller;
    public TrailRenderer trailrenderer;
    public float moveSpeed;

    public float dashAmplifier = 20f;
    private float dashTime = 0.25f;
    private float dashCooldown = 3f;
    private bool dashAvailaible = true;

    private Vector3 direction;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        direction = new Vector3(horizontal, 0f, vertical).normalized;
        if (!controller.isGrounded)
            direction.y = -0.5f;

        if (direction.magnitude >= 0.1f) {
            controller.Move(direction * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashAvailaible) 
            StartCoroutine(Dash());
    }

    IEnumerator Dash() {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime) {
            dashAvailaible = false;
            trailrenderer.emitting = true;
            controller.Move(direction*dashAmplifier*Time.deltaTime);
            yield return null;
        }
        trailrenderer.emitting = false;
        
        yield return new WaitForSeconds(dashCooldown);
        dashAvailaible = true;
    }
}