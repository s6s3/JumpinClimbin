using UnityEngine;
using System.Collections;

public class ToGroundArea : MonoBehaviour {
    [SerializeField]
    private PlayerAnimator playerAnimator;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Jumper"))playerAnimator.ToGround();
    }
}
