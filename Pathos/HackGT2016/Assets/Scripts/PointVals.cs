using UnityEngine;
using System.Collections;

public class PointVals : MonoBehaviour {

    public float xPos;
    public float yPos;
    public float zPos;
    public float fourthStock;
    public float val;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setValues(float x,float y,float z,float f,float v)
    {

        xPos = x;
        yPos = y;
        zPos = z;
        fourthStock = f;
        val = v;

    }
}
