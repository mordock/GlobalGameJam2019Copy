using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayer : MonoBehaviour {
    public GameObject player;
    public GameObject pot;
    public GameObject walkbackPoint;

    private Animator animator;
    private new Animation animation;
    private AudioSource audioSource;

    public float BeginmoveSpeed;
    public float backMoveSpeed;
    public float timer;

    [Header("Cutscene Timers")]
    public float standStilltime;

    [Header("Cutscene Bool")]
    public bool beginWalk = true;
    public bool walkback = false;

    [Header("Sounds")]
    public AudioClip backgroundSound;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        animation = this.gameObject.GetComponent<Animation>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        //first walk
        if (timer < standStilltime && beginWalk)
        {
            animator.Play("Idle");
        }

        if (timer >= standStilltime && beginWalk) {
            animation.Stop("Idle");
            animator.Play("Walking");
            player.transform.position =
                Vector3.MoveTowards(transform.position, pot.transform.position, BeginmoveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, pot.transform.position) <= 0.1f && beginWalk)
        {
            timer = 0;

            beginWalk = false;
            animation.Stop("Walking");
            animator.Play("IdlePot");
            walkback = true;

            pot.gameObject.SetActive(false);
        }

        //back walk
        if (timer >= 0.5f && walkback)
        {
            audioSource.clip = backgroundSound;
            audioSource.Play();
            player.transform.localScale = new Vector3(1, 1, 1);
            animation.Stop("IdlePot");
            animator.Play("WalkingPot");
            player.transform.position =
                Vector3.MoveTowards(transform.position, walkbackPoint.transform.position, backMoveSpeed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, walkbackPoint.transform.position) <= 0.1f && walkback) {
            timer = 0;

            walkback = false;
            animation.Stop("WalkingPot");
            animator.Play("IdlePot");
        }
    }
}
