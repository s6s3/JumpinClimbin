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

    void Start()
    {
        playerController.setPlayerManager(this);
        playerAnimator.setPlayerManager(this);
        followPlayer.setPlayerManager(this);
        rb = GetComponent<Rigidbody>();

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
