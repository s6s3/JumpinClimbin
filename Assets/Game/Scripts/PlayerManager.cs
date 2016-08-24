using UnityEngine;
using System.Collections;
using System;

[RequireComponent(typeof(Rigidbody))]
public class PlayerManager : MonoBehaviour {
    public PlayerController playerController;
    public PlayerAnimator playerAnimator;
    public FollowPlayer followPlayer;

    public event Action<GameObject> onCollisionWithJumperEnter = (GameObject go) => { };
    public event Action<GameObject> onCollisionWithJumperExit = (GameObject go) => { };
    public event Action<GameObject> onCollisionWithJumperToDown = (GameObject go) => { };

    private bool isCollidedWithPlayer = false;
    private Rigidbody rb;
    private Vector3 initPosition;

    void Start()
    {
        playerAnimator.SetPlayerManager(this);
        followPlayer.SetPlayerManager(this);
        rb = GetComponent<Rigidbody>();
        initPosition = gameObject.transform.position;

        onCollisionWithJumperExit += (go) =>
        {
            if (go.CompareTag("Jumper"))
            {
                Jumper jumper = go.GetComponent<Jumper>();
                rb.AddForce(Vector3.up * jumper.pushForce, ForceMode.Impulse);
            }
        };

        ToTitle();

    }

    public void ToTitle()
    {
        gameObject.transform.position = initPosition;
        rb.isKinematic = true;
        playerController.enableControl = false;
        followPlayer.MoveToOffset();
        followPlayer.lookingAtTarget = true;
        followPlayer.SetFixedCamera(true);
    }

    public void ToMain()
    {
        gameObject.transform.position = initPosition;
        rb.isKinematic = false;
        playerController.enableControl = true;
        followPlayer.MoveToOffset();
        followPlayer.LookAt();
        gameObject.layer = LayerMask.NameToLayer("Player");

    }

    public void ToGameOver()
    {
        playerController.enableControl = false;
        followPlayer.SetFixedCamera(true);
        followPlayer.lookingAtTarget = true;
        gameObject.layer = LayerMask.NameToLayer("DummyPlayer");

    }

    public void OnCollisionWithJumperEnter(GameObject go)
    {
        onCollisionWithJumperEnter(go);
        isCollidedWithPlayer = true;

    }

    public void OnCollisionWithJumperExit(GameObject go)
    {
        if(rb.velocity.y > 0)onCollisionWithJumperExit(go);
        
    }

    public void OnCollisionWithJumperToDown(GameObject go)
    {
        if (isCollidedWithPlayer && rb.velocity.y >= 0) 
        {
            onCollisionWithJumperToDown(go);
            isCollidedWithPlayer = false;
        }
        
    }
    
}
