using UnityEngine;
using System.Collections;

public class UnityChanAnimationController : MonoBehaviour {
    public void Jump()
    {
        GetComponent<Animator>().SetTrigger("Jump");
    }

    public void ToGround()
    {
        GetComponent<Animator>().SetTrigger("ToGround");
    }

}
