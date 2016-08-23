using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Jumper : MonoBehaviour {

    //The power pushing the player
    [SerializeField]
    private float pushForce = 1.0f;

    //The flag 
    private bool isCollidedWithPlayer = false;

    //The Player (Unity-Chan)
    private GameObject Player;
    private PlayerController playerController;
    private Rigidbody rb;
    private SpringJoint sj;
    
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        sj = GetComponent<SpringJoint>();

	}
	

    void FixedUpdate()
    {
        //UnityChanと衝突済みの場合、SpringJointで引き戻す際に仮想的な力をUnityChanに与える
        if (isCollidedWithPlayer && rb.velocity.y > 0 
            && Player.gameObject.transform.position.y > sj.connectedAnchor.y)
        {
            Rigidbody playerRb = Player.GetComponent<Rigidbody>();
            if(playerRb.velocity.y > 0)
            {
                playerController.PushPlayer(pushForce);
                isCollidedWithPlayer = false;
                
            }

        }
        
    }
    
    void OnCollisionEnter(Collision collision)
    {
        //UnityChanと衝突済みのフラグを立てる
        if (collision.gameObject.CompareTag("Player"))
        {
            playerController.ToGround();
            isCollidedWithPlayer = true;

        }

    }
}
