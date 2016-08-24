using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Jumper : MonoBehaviour {
    //The power pushing the player
    public float pushForce = 1.0f;

    public float destroyDistance = 100;
    
    public PlayerManager playerManager;

    private bool isCollided = false;
    
    private SpringJoint sj;
    
	void Start () {
        sj = GetComponent<SpringJoint>();

	}
	
    void Update()
    {
        playerManager.OnCollisionWithJumperToDown(this.gameObject);
        if ((playerManager.transform.position.y - this.transform.position.y) > destroyDistance)
            Destroy(gameObject);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && collision.gameObject.GetComponent<Rigidbody>().velocity.y < 0)
        {
            playerManager.OnCollisionWithJumperEnter(this.gameObject);
            isCollided = true;
        }

    }
    
    void OnCollisionStay(Collision collision)
    {
        if (isCollided && collision.gameObject.transform.position.y >= sj.connectedAnchor.y 
            && collision.gameObject.GetComponent<Rigidbody>().velocity.y >= 0)
        {
            playerManager.OnCollisionWithJumperExit(this.gameObject);
            isCollided = false;
        }

    }
}
