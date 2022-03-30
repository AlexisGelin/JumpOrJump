using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    private int nbrJump = 0;
    private int maxJump = 2;
    private float JumpForce = 6f;

    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Jump") && nbrJump < maxJump) {
            
            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            _animator.SetBool("Jump", true);
            nbrJump +=1;
            if (nbrJump == 2)
            {
                _animator.SetBool("DoubleJump", true);
            }
        }

        if (Mathf.Abs(_rigidbody.velocity.y) < 0.001f)
        {
            nbrJump =0; 
            _animator.SetBool("isGrounded", true);
            _animator.SetBool("Jump", false);
            _animator.SetBool("DoubleJump", false);
        }
        else
        {
            _animator.SetBool("isGrounded", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Die();
        }
    }

    private void Die()
    {
        //GameOver
    }

}
