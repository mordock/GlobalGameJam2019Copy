using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    private new Rigidbody2D rigidbody2D;
    new Animation animation;

    private AudioSource audioSource;
    private Animator animator;

    private GameObject fObject;

    private float modifier;

    [Header("Floats")]
    public float speed = 20;
    public float potRechargeTime = 5f;
    public float rockPushVelocity;
    public float crabPushVelocity;
    
    [Header("Bools")]
    public bool canPickUpSmallPot = false;
    public bool canPickUpMediumPot = false;
    public bool canPickUpLargePot = false;

    public bool hasSmallPot = false;
    public bool hasMediumPot = false;
    public bool hasLargePot = false;

    [Header("---------")]
    public bool isFobject = false;
    public bool facingRight = false;
    public bool isOnBoat = false;

    [Header("Speed multipliers")]
    public float smallPotMultiplier = .8f;
    public float mediumPotMultiplier = .6f;
    public float largePotMultiplier = .4f;

    [Header("GameObjects")]
    public GameObject fPrefab;

    [Header("Sounds")]
    public AudioClip moving10;
    //public AudioClip moving8;
    public AudioClip moving6;
    public AudioClip moving4;
    public List<AudioClip> rockHitSounds;
    public List<AudioClip> potLiftSounds;

    [Header("Pots")]
    public GameObject smallPot;
    public GameObject mediumPot;
    public GameObject largePot;

    public int smallPotPoints;
    public int mediumPotPoints;
    public int largePotPoints;

    void Start() {
        rigidbody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();

        //fill pot variables so they can be picked up
        FindPots();
    }

    void FixedUpdate() {
        //movement
        if (Input.GetKey(KeyCode.D)) {
            transform.position += Vector3.right * speed * modifier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position += Vector3.left * speed * modifier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.W)) {
            transform.position += Vector3.up * speed * modifier * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position += Vector3.down * speed * modifier * Time.deltaTime;

        }

        if (!hasLargePot && !hasMediumPot && !hasSmallPot)
        {
            modifier = 1;
        }

        //idle animation
        if (!hasSmallPot && !hasMediumPot && !hasLargePot) {
            IdleAnimation("Idle");
        } else {
            IdleAnimation("IdlePot");
        }

        //P separate sound input because of GetKey
        /* if (Input.GetKeyDown(KeyCode.A)) {
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
         */

        //walking animation
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

                modifier = smallPotMultiplier;

                SpawnPots.spawnSmallPot = true;
                SpawnPots.smallTime = potRechargeTime;
            }
            if (canPickUpMediumPot) {
                Destroy(mediumPot);

                hasMediumPot = true;
                hasSmallPot = false;
                hasLargePot = false;

                modifier = mediumPotMultiplier;

                SpawnPots.spawnMediumPot = true;
                SpawnPots.mediumTime = potRechargeTime;
            }
            if (canPickUpLargePot) {
                Destroy(largePot);

                hasLargePot = true;
                hasSmallPot = false;
                hasMediumPot = false;

                modifier = largePotMultiplier;

                SpawnPots.spawnLargePot = true;
                SpawnPots.largeTime = potRechargeTime;
            }

            //check if on the boat and if you have a pot to score points
            if (isOnBoat) {
                if (hasSmallPot) {
                    ScoreKeeper.IncreaseScore(smallPotPoints);
                    hasSmallPot = false;
                } else if (hasMediumPot) {
                    ScoreKeeper.IncreaseScore(mediumPotPoints);
                    hasMediumPot = false;
                } else if (hasLargePot) {
                    ScoreKeeper.IncreaseScore(largePotPoints);
                    hasLargePot = false;
                }
            }
        }

        //make sure the F stays the correct way
        if (isFobject) {
            if (facingRight) {
                fObject.transform.localScale = new Vector3(-1, 1, 1);
            } else {
                fObject.transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    //P walking sound
    /*public void PlayWalkingSound(AudioClip audioClip) {
        audioSource.clip = audioClip;
        audioSource.loop = true;
        audioSource.Play();
    }
    */
    //walking animation
    public void WalkingAnimation(string animation) {
        if (Input.GetKey(KeyCode.A)) {
            transform.localScale = new Vector3(1, 1, 1);
            animator.Play(animation);
            facingRight = false;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.localScale = new Vector3(-1, 1, 1);
            animator.Play(animation);
            facingRight = true;
        }
    }

    //standing still
    public void IdleAnimation(string animationToPlay) {
        if (!Input.anyKey ) {
            animation.Stop("Walking");
            animation.Stop("WalkingPot");
            animation.Stop("Idle");
            if (facingRight) {
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

    private void DropPots() {
        hasSmallPot = false;
        hasMediumPot = false;
        hasLargePot = false;
    }

    //add a pot to the player if one excists in the scene
    void FindPots() {
        smallPot = GameObject.Find("SmallPotPrefab");
        mediumPot = GameObject.Find("MediumPotPrefab");
        largePot = GameObject.Find("LargePotPrefab");
    }

    //check for all triggers
    private void OnTriggerEnter2D(Collider2D collision) {
        //check if you are touching the pots
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

        //check if standing on the boat
        if (collision.gameObject.tag.Equals("Boat")) {
            isOnBoat = true;
        }
    }

    //check if exiting any trigger
    private void OnTriggerExit2D(Collider2D other) {
        //check if not touching pots
        canPickUpSmallPot = false;
        canPickUpMediumPot = false;
        canPickUpLargePot = false;
        isFobject = false;
        Destroy(fObject);

        //check if exiting boat
        if (other.gameObject.tag.Equals("Boat")) {
            isOnBoat = false;
        }
    }

    //P Check for all collisions
    void OnCollisionEnter2D(Collision2D collision) {
        //collide with rock
        if (collision.gameObject.tag.Equals("Rock")) {
            audioSource.clip = rockHitSounds[Random.Range(0, rockHitSounds.Count)];
            audioSource.Play();

            //calculate direction to be knocked back to
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.Normalize();
            rigidbody2D.velocity = direction * rockPushVelocity;

            Destroy(collision.gameObject);

            DropPots();
        }

        if (collision.gameObject.tag.Equals("Crab"))
        {
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.Normalize();
            rigidbody2D.velocity = direction * crabPushVelocity;

            DropPots();
        }
    }
}
