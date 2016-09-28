using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;
public class SpawnBall : MonoBehaviour {

    public GameObject point;

    public bool test = false;

    public String testStr;

    public float testMax;
    public float testMin;

    public static String stock1Name;
    public static String stock2Name;
    public static String stock3Name;
    public static String stock4Name;

	// Use this for initialization
	void Start () {
        stock1Name = "Stock 1";
        stock2Name = "Stock 2";
        stock3Name = "Stock 3";
        stock4Name = "Stock 4";
        createGraph();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void spawnPoint(float xPos, float yPos, float zPos, float pVal, float minVal, float maxVal) {

        Color pointColor;
        if (pVal < 0)
        {

            pointColor = new Color((1-((minVal - pVal)*155) / (255*minVal)), 0, 0, (1 - ((minVal - pVal) * 155) / (255 * minVal)));
        }
        else
        {

            pointColor = new Color(0, 0, (1 - ((maxVal - pVal) * 155) / (255 * maxVal)), (1 - ((maxVal - pVal) * 155) / (255 * maxVal)));
        }
        GameObject newPoint = Instantiate(point, new Vector3(xPos, yPos, zPos), Quaternion.identity) as GameObject;
        newPoint.GetComponent<PointVals>().setValues(xPos, yPos, zPos, 100 - xPos - yPos - zPos, pVal);

        newPoint.GetComponent<MeshRenderer>().material.SetColor("_Color", pointColor);


    }


	void createGraph()
	{
        test = true;
		System.IO.StreamReader file = new System.IO.StreamReader ("testVals.csv");
		String[] maxMin = file.ReadLine ().Split (',');
		float maxVal = Convert.ToSingle (maxMin [0]);
		float minVal = Convert.ToSingle (maxMin [1]);

        maxVal += .000001f;
        minVal -= -.000001f;
        String[] stockNames = file.ReadLine().Split(',');
        stock1Name = stockNames[0];
        stock2Name = stockNames[1];
        stock3Name = stockNames[2];
        stock4Name = stockNames[3];

        testMax = maxVal;
        testMin = minVal;

		String line =  file.ReadLine();
        testStr = line;
        do
        {

            String[] spl = line.Split(',');
            spawnPoint(Convert.ToSingle(spl[0]), Convert.ToSingle(spl[1]), Convert.ToSingle(spl[2]), Convert.ToSingle(spl[3]), Convert.ToSingle(minVal), Convert.ToSingle(maxVal));
            test = true;
            line = file.ReadLine();
        } while (line != null);


		file.Close();

	}
}
