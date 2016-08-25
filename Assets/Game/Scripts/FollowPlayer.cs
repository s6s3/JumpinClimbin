using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public Transform target;
    public float changeT = 1.0f;
    private bool lookingAtTarget = true;
    
    private Vector3 offset;
    private Vector3 fixedPosition;
    private bool fixedCamera = false;
    private float t = 1;
    
    // Use this for initialization
    void Start () {
        offset = GetComponent<Transform>().position - target.position;
	}

    public void SetPlayerManager(PlayerManager pm)
    {
        pm.onCollisionWithJumperEnter += (go) => {
            if(target.GetComponent<Rigidbody>().velocity.y < 0 
            && target.transform.position.y > go.transform.position.y)
            {
                SetFixedCamera(true);
                lookingAtTarget = false;
            }
            
        };
        pm.onCollisionWithJumperExit += (go) => {
            SetFixedCamera(false);
            lookingAtTarget = true;
        };
    }
	
	// Update is called once per frame
	void Update () {
        if (fixedCamera)
        {
            transform.position = fixedPosition;

        }
        else
        {
            if(t < 1)
            {
                transform.position = Vector3.Lerp(fixedPosition, target.position + offset, t);
                t += Time.deltaTime / changeT;
            }
            else
            {
                MoveToOffset();
            }
        }

        if (lookingAtTarget)
        {
            transform.LookAt(target);
        }
	
	}

    public void SetFixedCamera(bool val)
    {
        if (!fixedCamera && t < 1) return;
        fixedCamera = val;
        fixedPosition = transform.position;
        if (fixedCamera)
        {
            
            
        }
        else
        {
            if (changeT != 0) t = 0;
            else t = 1;
            
        }
    }

    public bool GetFixedCamera()
    {
        return fixedCamera;
    }

    public void SetLookingAtTarget(bool val)
    {
        if (!fixedCamera && t < 1) return;
        lookingAtTarget = val;
        
    }

    public bool GetLookingAtTarget()
    {
        return lookingAtTarget;
    }
    
    public void MoveToOffset()
    {
        transform.position = target.position + offset;
    }
}
