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
    private bool beforeBottom = true;
    
    private SpringJoint sj;
    
	void Start () {
        sj = GetComponent<SpringJoint>();

	}
	
    void Update()
    {
        if (isCollided && playerManager.transform.position.y  >= sj.connectedAnchor.y
            && playerManager.GetComponent<Rigidbody>().velocity.y > 0
            && playerManager.transform.position.y > transform.position.y)
        {
            playerManager.OnCollisionWithJumperToTop(this.gameObject);
            isCollided = false;
        }

        if ((playerManager.transform.position.y - this.transform.position.y) > destroyDistance)
            Destroy(gameObject);

    }
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerManager.OnCollisionWithJumperEnter(this.gameObject);
            if (collision.rigidbody.velocity.y < 0)
            {
                isCollided = true;
                beforeBottom = true;
            }
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            playerManager.OnCollisionWithJumperExit(this.gameObject);

    }
    
    void OnCollisionStay(Collision collision)
    {
        if (beforeBottom && collision.gameObject.CompareTag("Player") 
            && collision.rigidbody.velocity.y >= 0)
        {
            playerManager.OnCollisionWithJumperToDown(this.gameObject);
            beforeBottom = false;

        }

    }
}
