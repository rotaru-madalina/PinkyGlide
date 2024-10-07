using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    public float jumpForce = 0.2f;
    public float angleQ = 1f;
    public Action OnCollision;

    private bool needsRelease = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleJump();
        AdjustHandle();
    }

    private void PlaySound() => this.GetComponent<AudioSource>().Play();

    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) || (Input.touchCount > 0 && !needsRelease))
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            PlaySound();
            needsRelease = true;
        }
        if(Input.touchCount == 0)
        {
            needsRelease = false;
        }
    }

    public void AdjustHandle()
    {
        this.transform.eulerAngles = 
            Vector3.forward * angleQ * this.GetComponent<Rigidbody2D>().velocity.y;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnCollision.Invoke();
    }
}
