//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    [SerializeField] Paddle paddle;
    [SerializeField] float xLaunch = 0.0f;
    [SerializeField] float yLaunch = 15.0f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randamFactor = 0.5f;


    // State
    bool bBallLaunched = false;
    Vector2 v2PaddleToBall;

    // Cached Compnent References
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody;

    // Use this for initialization
    void Start () {
        v2PaddleToBall = transform.position - paddle.transform.position;    // Vector between paddle and ball
        myAudioSource = GetComponent<AudioSource>();    // Allow us to access the Audio Component on a specific Game Object
        myRigidBody = GetComponent<Rigidbody2D>();
        randamFactor = 0.5f;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!bBallLaunched)
        {
            LocateBallInitialPos();
            LaunchOnMouseClick();
        }
    }

    private void LocateBallInitialPos()
    {
        Vector2 v2Paddle = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = v2Paddle + v2PaddleToBall;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bBallLaunched = true;
            myRigidBody.velocity = new Vector2(xLaunch, yLaunch);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2( Random.Range(0f, randamFactor), Random.Range(0f, randamFactor) );
        if (bBallLaunched)
        {
            int iSoundID = UnityEngine.Random.Range(0, ballSounds.Length);
            AudioClip clip = ballSounds[iSoundID];
            myAudioSource.PlayOneShot(clip);
            myRigidBody.velocity += velocityTweak;
        }
    }
}
