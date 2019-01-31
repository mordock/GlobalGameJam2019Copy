using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    public float speed = 20;
    private new Rigidbody2D rigidbody2D;

    public Animator animator;

    public bool right = false;

    new Animation animation;
	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 moveSpeed = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + moveSpeed);

        if(Input.anyKey == false) {
            animation.Stop("Walking");
            if (right) {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.Play("Idle");
            } else {
               transform.localScale = new Vector3(1, 1, 1);
                animator.Play("Idle");
            }
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play("Walking");
            right = false;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play("Walking");
            right = true;
        }
    }
}
