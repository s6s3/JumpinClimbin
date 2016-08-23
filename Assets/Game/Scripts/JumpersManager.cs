using UnityEngine;
using System.Collections;

public class JumpersManager : MonoBehaviour {
    public float fieldWidth = 10;
    public float fieldDepth = 10;
    public int gridRow = 5;
    public int gridColumn = 5;

    [SerializeField, Space(10)]
    public Jumper startJumper;
    public float intervalJumper = 5;
    [SerializeField, Range(0, 1)]
    public float powerJumperRate = 0.1f;
    

    private int[] order;
    private int orderIndex = 0;
    private Vector3 offset;
    private float normRow, normColumn;

    private float startJumperY;

	// Use this for initialization
	void Start () {
        order = new int[gridRow * gridColumn];
        resetOrder();

        offset = new Vector3(-fieldWidth / 2, 0, -fieldDepth);
        normColumn = fieldWidth / gridColumn;
        normRow = fieldDepth / gridRow;
        startJumperY = startJumper.transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void generateJumper()
    {
        if (orderIndex >= order.Length) resetOrder();


    }
    
    public Vector3 getPosition(int index)
    {
        return new Vector3(index % gridColumn, 0, index / gridRow);
    }

    public Vector3 getPosition(int index, float y)
    {
        return new Vector3(index % gridColumn, y, index / gridRow);
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
        for (int i = 0; i < order.Length; i++)
        {
            no = Random.Range(i, order.Length);
            if (i == no) continue;
            tmp = order[i];
            order[i] = order[no];
            order[no] = tmp;
        }

        orderIndex = 0;
    }
}
