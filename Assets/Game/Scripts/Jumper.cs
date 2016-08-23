using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Jumper : MonoBehaviour {
    //The power pushing the player
    public float pushForce = 1.0f;

    [SerializeField]
    private PlayerManager playerManager;

    //The Player (Unity-Chan)

    private Rigidbody rb;
    private SpringJoint sj;
    
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        sj = GetComponent<SpringJoint>();

	}
	
    void Update()
    {
        playerManager.OnCollisionWithJumperToDown(this.gameObject);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerManager.OnCollisionWithJumperEnter(this.gameObject);
           
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerManager.OnCollisionWithJumperExit(this.gameObject);

        }
        
    }
}
