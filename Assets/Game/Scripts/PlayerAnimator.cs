using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void setPlayerManager(PlayerManager pm)
    {
        pm.onCollisionWithJumperToDown += (GameObject go) => { Jump(); };

    }


    public void ToGround()
    {
        animator.SetTrigger("ToGround");
        
    }

    public void Jump()
    {
        animator.SetTrigger("Jump");

    }

    //表情変化のために呼ばれるダミーメソッド
    public void OnCallChangeFace(string str)
    {

    }

}
