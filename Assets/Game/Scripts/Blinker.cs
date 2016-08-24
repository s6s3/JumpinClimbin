using UnityEngine;
using System.Collections;

public class Blinker : MonoBehaviour {
    private float nextTime;
    public float interval = 1.0f;

	// Use this for initialization
	void Start () {
        nextTime = Time.time;
	
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > nextTime)
        {
            float alpha = gameObject.GetComponent<CanvasRenderer>().GetAlpha();
            if (alpha == 1.0f)
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(0.0f);
            else
                gameObject.GetComponent<CanvasRenderer>().SetAlpha(1.0f);
            nextTime += interval;
        }
	
	}
}
