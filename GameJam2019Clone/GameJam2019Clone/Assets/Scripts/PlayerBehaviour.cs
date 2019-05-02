﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private new Rigidbody2D rigidbody2D;
    new Animation animation;
    private AudioSource audioSource;

    public Animator animator;

    public bool right = false;
    public float speed = 20;
    public float potRechargeTime = 5f;
    public bool isFobject = false;

    [Header("Bools")]
    public bool canPickUpSmallPot = false;
    public bool canPickUpMediumPot = false;
    public bool canPickUpLargePot = false;

    public bool hasSmallPot = false;
    public bool hasMediumPot = false;
    public bool hasLargePot = false;

    [Header("Speed multipliers")]
    public float smallPotMultiplier = .8f;
    public float mediumPotMultiplier = .6f;
    public float largePotMultiplier = .4f;

    [Header("GameObjects")]
    public GameObject fPrefab;

    private GameObject fObject;

    [Header("Sounds")]
    public AudioClip moving10;
    //public AudioClip moving8;
    public AudioClip moving6;
    public AudioClip moving4;

    [Header("Pots")]
    public GameObject smallPot;
    public GameObject mediumPot;
    public GameObject largePot;

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();

        FindPots();
    }

    void FixedUpdate() {
        //movement
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * speed * Time.deltaTime;

        }

        //idle
        if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
            IdleAnimation("Idle");
        } else {
            IdleAnimation("IdlePot");
        }

        //separate sound input because of GetKey
        if (Input.GetKeyDown(KeyCode.A)) {
            if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
                PlayWalkingSound(moving10);
            } else if (hasSmallPot) {
                //this moving sounds was lost, ask Pat for sound
            } else if (hasMediumPot) {
                PlayWalkingSound(moving6);
            } else if (hasLargePot) {
                PlayWalkingSound(moving4);
            }
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
                PlayWalkingSound(moving10);
            } else if (hasSmallPot) {
                //this moving sounds was lost, ask Pat for sound
            } else if (hasMediumPot) {
                PlayWalkingSound(moving6);
            } else if (hasLargePot) {
                PlayWalkingSound(moving4);
            }
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
                hasMediumPot = false;
                hasLargePot = false;

                SpawnPots.spawnSmallPot = true;
                SpawnPots.smallTime = potRechargeTime;
            }
            if (canPickUpMediumPot) {
                Destroy(mediumPot);

                hasMediumPot = true;
                hasSmallPot = false;
                hasLargePot = false;

                SpawnPots.spawnMediumPot = true;
                SpawnPots.mediumTime = potRechargeTime;
            }
            if (canPickUpLargePot) {
                Destroy(largePot);

                hasLargePot = true;
                hasSmallPot = false;
                hasMediumPot = false;

                SpawnPots.spawnLargePot = true;
                SpawnPots.largeTime = potRechargeTime;
            }
        }

        if (isFobject) {
            if (right) {
                fObject.transform.localScale = new Vector3(-1, 1, 1);
            } else {
                fObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    //walking sound
    public void PlayWalkingSound(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    //walking animation
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
            FindPots();
        }
    }

    //check if you are touching the pots
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("SmallPot")) {
            canPickUpSmallPot = true;
            //spawn floating F
            fObject = Instantiate(fPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 5), Quaternion.identity, transform);
            isFobject = true;
        }
        if (collision.CompareTag("MediumPot")) {
            canPickUpMediumPot = true;
            //spawn floating F
            fObject = Instantiate(fPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 5), Quaternion.identity, transform);
            isFobject = true;
        }
        if (collision.CompareTag("LargePot")) {
            canPickUpLargePot = true;
            //spawn floating F
            fObject = Instantiate(fPrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z - 5), Quaternion.identity, transform);
            isFobject = true;
        }
    }

    //check if not touching pots
    private void OnTriggerExit2D(Collider2D other) {
        canPickUpSmallPot = false;
        canPickUpMediumPot = false;
        canPickUpLargePot = false;
        isFobject = false;
        Destroy(fObject);
    }

    //add a pot to the player if one excists in the scene
    void FindPots() {
        smallPot = GameObject.Find("SmallPotPrefab");
        mediumPot = GameObject.Find("MediumPotPrefab");
        largePot = GameObject.Find("LargePotPrefab");
    }
}
