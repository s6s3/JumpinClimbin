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
    public event Action<GameObject> onCollisionWithJumperToTop = (GameObject go) => { };
    public event Action<GameObject> onCollisionWithJumperToDown = (GameObject go) => { };
    
    private Rigidbody rb;
    private Vector3 initPosition;

    void Start()
    {
        playerAnimator.SetPlayerManager(this);
        followPlayer.SetPlayerManager(this);
        rb = GetComponent<Rigidbody>();
        initPosition = gameObject.transform.position;

        onCollisionWithJumperToTop += (go) =>
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
        followPlayer.SetLookingAtTarget(true);
        followPlayer.SetFixedCamera(true);
    }

    public void ToMain()
    {
        gameObject.transform.position = initPosition;
        rb.isKinematic = false;
        playerController.enableControl = true;
        followPlayer.MoveToOffset();
        followPlayer.SetFixedCamera(false);
        followPlayer.SetLookingAtTarget(true);
        gameObject.layer = LayerMask.NameToLayer("Player");

    }

    public void ToGameOver()
    {
        playerController.enableControl = false;
        followPlayer.SetFixedCamera(true);
        followPlayer.SetLookingAtTarget(true);
        gameObject.layer = LayerMask.NameToLayer("DummyPlayer");

    }

    public void OnCollisionWithJumperEnter(GameObject go)
    {
        onCollisionWithJumperEnter(go);

    }

    public void OnCollisionWithJumperExit(GameObject go)
    {
        onCollisionWithJumperExit(go);
        
    }

    public void OnCollisionWithJumperToTop(GameObject go)
    {
        onCollisionWithJumperToTop(go);
    }

    public void OnCollisionWithJumperToDown(GameObject go)
    {
        onCollisionWithJumperToDown(go);
        
    }
    
}
