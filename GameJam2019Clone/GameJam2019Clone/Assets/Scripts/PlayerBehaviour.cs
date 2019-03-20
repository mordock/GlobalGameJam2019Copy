using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private new Rigidbody2D rigidbody2D;
    new Animation animation;
    private AudioSource audioSource;

    public Animator animator;

    public bool right = false;

    public bool canPickUpSmallPot = false;
    public bool canPickUpMediumPot = false;
    public bool canPickUpLargePot = false;

    public bool hasSmallPot = false;
    public bool hasMediumPot = false;
    public bool hasLargePot = false;

    public float speed = 20;
    public float potRechargeTime = 5f;

    [Header("Sounds")]
    public AudioClip moving10;

    [Header("Pots")]
    public GameObject smallPot;
    public GameObject mediumPot;
    public GameObject largePot;

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();

        findPots();
    }

    void FixedUpdate() {
        //movement
        Vector2 moveSpeed = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        rigidbody2D.MovePosition(rigidbody2D.position + moveSpeed);

        //idle
        if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
            IdleAnimation("Idle");
        } else {
            Debug.Log("BOB");
            IdleAnimation("IdlePot");
        }

        //separate sound input because of GetKey
        if (Input.GetKeyDown(KeyCode.A)) {
            audioSource.clip = moving10;
            audioSource.loop = true;
            audioSource.Play();
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            audioSource.clip = moving10;
            audioSource.loop = true;
            audioSource.Play();
        }

        //walking
        if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
            WalkingAnimation("Walking");
        } else {
            WalkingAnimation("WalkingPot");
        }

        //pick up pots
        if (Input.GetKeyDown(KeyCode.F)) {
            if (canPickUpSmallPot) {
                Destroy(smallPot);
                hasSmallPot = true;
                SpawnPots.spawnSmallPot = true;
                SpawnPots.smallTime = potRechargeTime;
            }
            if (canPickUpMediumPot) {
                Destroy(mediumPot);
                hasMediumPot = true;
                SpawnPots.spawnMediumPot = true;
                SpawnPots.mediumTime = potRechargeTime;
            }
            if (canPickUpLargePot) {
                Destroy(largePot);
                hasLargePot = true;
                SpawnPots.spawnLargePot = true;
                SpawnPots.largeTime = potRechargeTime;
            }
        }
    }

    //walking
    public void WalkingAnimation(string animation) {
        if (Input.GetKey(KeyCode.A)) {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play(animation);
            right = false;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play(animation);
            right = true;
        }
    }

    //standing still
    public void IdleAnimation(string animationToPlay) {
        if (Input.anyKey == false) {
            animation.Stop("Walking");
            animation.Stop("WalkingPot");
            animation.Stop("Idle");
            if (right) {
                transform.localScale = new Vector3(-1, 1, 1);
                animator.Play(animationToPlay);
                audioSource.Stop();
            } else {
                transform.localScale = new Vector3(1, 1, 1);
                animator.Play(animationToPlay);
                audioSource.Stop();
            }
            findPots();
        }
    }

    //check if you are touching the pots
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("SmallPot")) {
            canPickUpSmallPot = true;
        }
        if (collision.CompareTag("MediumPot")) {
            canPickUpMediumPot = true;
        }
        if (collision.CompareTag("LargePot")) {
            canPickUpLargePot = true;
        }
    }

    //check if not touching pots
    private void OnTriggerExit2D(Collider2D other) {
        canPickUpSmallPot = false;
        canPickUpMediumPot = false;
        canPickUpLargePot = false;
    }

    //add a pot to the player if one excists
    void findPots() {
        smallPot = GameObject.Find("SmallPotPrefab");
        mediumPot = GameObject.Find("MediumPotPrefab");
        largePot = GameObject.Find("LargePotPrefab");
    }
}
