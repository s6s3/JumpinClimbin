using UnityEngine;
using System.Collections;

public class JumpersController : MonoBehaviour {
    public float fieldWidth = 10;
    public float fieldDepth = 10;
    public int gridRow = 5;
    public int gridColumn = 5;

    private int[] order;
    private int orderIndex = 0;

	// Use this for initialization
	void Start () {
        order = new int[gridRow * gridColumn];
        
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //TBI
    private Vector3 getPosition(int index)
    {


        return new Vector3();
    }

    public int getOrderLength()
    {
        return order.Length;
    }

    public int getOrderIndex()
    {
        return orderIndex;
    }

    public void resetOrder()
    {
        for (int i = 0; i < order.Length; i++)
        {
            order[i] = i;
        }

        int tmp, no;
        for (int i = order.Length - 1; i > 0; i--)
        {
            no = Random.Range(0, i);
            tmp = order[i];
            order[i] = order[no];
            order[no] = tmp;
        }

        orderIndex = 0;
    }
}
