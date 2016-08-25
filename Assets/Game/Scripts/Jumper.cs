using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpringJoint))]
public class Jumper : MonoBehaviour {
    //The power pushing the player
    public float pushForce = 1.0f;

    public float destroyDistance = 30;

    public float breakForce = 1;
    public float breakTorque = 1;
    
    public PlayerManager playerManager;

    private bool isCollided = false;
    private bool beforeBottom = true;
    private bool fallJumper = false;
    
    private SpringJoint sj;
    
	void Start () {
        sj = GetComponent<SpringJoint>();

	}
	
    void Update()
    {
        if (fallJumper)
        {
            if (transform.position.y < 3) Destroy(gameObject);
        }
        else
        {
            if (isCollided && playerManager.transform.position.y >= sj.connectedAnchor.y
            && playerManager.GetComponent<Rigidbody>().velocity.y > 0
            && playerManager.transform.position.y > transform.position.y)
            {
                playerManager.OnCollisionWithJumperToTop(this.gameObject);
                isCollided = false;
            }

            if ((playerManager.transform.position.y - this.transform.position.y) > destroyDistance)
            {
                sj.spring = 0;
                Rigidbody rb = gameObject.GetComponent<Rigidbody>();
                rb.constraints = RigidbodyConstraints.None;
                rb.useGravity = true;
                rb.AddForce(new Vector3(Random.Range(-breakForce, breakForce), 0, Random.Range(-breakForce, breakForce)), ForceMode.Impulse);
                rb.AddTorque(new Vector3(Random.value, Random.value, Random.value) * breakTorque, ForceMode.Impulse);
                gameObject.layer = LayerMask.NameToLayer("DummyJumper");
                fallJumper = true;
            }
        }
        
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
