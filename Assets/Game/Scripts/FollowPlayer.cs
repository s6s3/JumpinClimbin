using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
    public Transform target;
    public float changeT = 1.0f;

    private Vector3 offset;
    private Vector3 fixedPosition;
    private bool fixedCamera = false;
    private float t = 1;
    private bool lookingAtTarget = true;

    // Use this for initialization
    void Start () {
        offset = GetComponent<Transform>().position - target.position;
	}

    public void setPlayerManager(PlayerManager pm)
    {
        pm.onCollisionWithJumperEnter += (go) => {
            setFixedCamera(true);
            lookingAtTarget = false;
        };
        pm.onCollisionWithJumperExit += (go) => {
            setFixedCamera(false);
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
                transform.position = target.position + offset;
            }
        }

        if (lookingAtTarget)
        {
            transform.LookAt(target);
        }
	
	}

    public void setFixedCamera(bool val)
    {
        fixedCamera = val;
        if (fixedCamera)
        {
            fixedPosition = transform.position;
            
            
        }
        else
        {
            if (changeT != 0) t = 0;
            else t = 1;
            
        }
    }

    public bool getFixedCamera()
    {
        return fixedCamera;
    }
}
