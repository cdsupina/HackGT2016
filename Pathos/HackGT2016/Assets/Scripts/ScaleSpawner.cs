using UnityEngine;
using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections;

public class ScaleSpawner : MonoBehaviour {

    public GameObject stadium;
    public int dataSet = 0;
    public static String dataSetName;
    public static float stadiumCapacity = 3000;
    public float stadiumSpacingX;
    public float stadiumSpacingZ;

    private List<float> StartInfo = new List<float>();
    private List<float> Months = new List<float>();
    private List<float> Deaths = new List<float>();
    public List<float> TotalDeaths = new List<float>();

    public static float currentYear;
    public static float currentDivision;
    public static float totalDivisions;
    public static float extrapolated = 0;
    public static String extrapolatedStr;

    private int currentIdx;

    public float timeDelay;
    public float forwardTimer = 0f;
    public float backwardTimer = 0f;

    public GameObject[] stadiums;

    // Use this for initialization
    void Start () {

        if (dataSet == 0) {
            dataSetName = "Gun Deaths\nin US";
        } else {

            dataSetName = "Deaths in\nAleppo";
        }

        getData();

        currentYear = StartInfo[0];
        currentDivision = StartInfo[1];
        totalDivisions = StartInfo[2];

        float yearTemp = currentYear;
        float divTemp = currentDivision;

        for (int k = -1; k < extrapolated; k++) {
            if (divTemp > totalDivisions) {
                yearTemp++;
                divTemp = 0;
            }
            divTemp++;
                
        }

        extrapolatedStr = "[Year: " + yearTemp + "  Div: " + divTemp + "]";

        currentIdx = 0;
        float startval = TotalDeaths[0];
        //find starting point
        while (startval < stadiumCapacity) {
            currentIdx++;
            startval = TotalDeaths[currentIdx];
        }

        currentDivision += currentIdx;
        while (currentDivision > totalDivisions) {
            currentDivision -= totalDivisions;
            currentYear++;
        }

        int stadiumCount = (int)(TotalDeaths[currentIdx] / stadiumCapacity);
        for (int i = 0; i < stadiumCount; i++)
        {

            Instantiate(stadium, new Vector3(i * stadiumSpacingX, 0, 0), Quaternion.identity);
        }

        if (TotalDeaths[50] > 3000)
        {
            timeDelay = 0.8f;
        }
        else {

            timeDelay = 0.03f;
        }

        /*
        int stadiumCount = (int)(stat / stadiumCapacity);
        
        */

    }
	
	// Update is called once per frame
	void Update () {

        timeForward();
        timeBackward();
        

    }

    void getData() //Reads data from CSV file
    {

        var reader = new StreamReader(File.OpenRead(@"result2.csv"));

        if (dataSet == 0) {
            reader = new StreamReader(File.OpenRead(@"gunOutput.csv"));
        }

        
        int i = 0;
        while (!reader.EndOfStream)
        {
            var line = reader.ReadLine();
            var values = line.Split(',');

            //Months.Add(Convert.ToSingle(values[0]));

            if (i == 0){
                var startVals = values[0].Split(' ');
                for (int j = 0; j < 3; j++) {
                    StartInfo.Add(Convert.ToSingle(startVals[j]));
                }

            }
            else if (i == 1) {

                TotalDeaths.Add(Convert.ToSingle(values[1]));
            }else if(Convert.ToSingle(values[1]) == -1) {

                extrapolated = i+1;
            }
            else
            {

                //Deathss.Add(Convert.ToSingle(values[1]));
                if (extrapolated == 0) {
                    TotalDeaths.Add(TotalDeaths[i - 2] + Convert.ToSingle(values[1]));
                }
                else {

                    TotalDeaths.Add(TotalDeaths[i - 3] + Convert.ToSingle(values[1]));
                }
                
                
            }

            i++;
        }
    }

    void timeForward()
    {

        if (Input.GetButton("Fire3") && (forwardTimer > timeDelay))
        {
            currentDivision++;
            currentIdx++;
            forwardTimer = 0;
            simplifyTime();
            stadiums = GameObject.FindGameObjectsWithTag("Stadium");
            foreach (GameObject s in stadiums) {
                Destroy(s);
            }
            spawnStadiums();
        }
        else if (Input.GetButton("Fire3"))
        {
            forwardTimer += Time.deltaTime;
        }
        else
        {
            forwardTimer = 0f;
        }
    }

    void timeBackward()
    {

        if (Input.GetButton("Fire4") && (backwardTimer > timeDelay))
        {
            currentDivision--;
            currentIdx--;
            backwardTimer = 0;
            simplifyTime();
            stadiums = GameObject.FindGameObjectsWithTag("Stadium");
            foreach (GameObject s in stadiums)
            {
                Destroy(s);
            }
            spawnStadiums();
        }
        else if (Input.GetButton("Fire4"))
        {
            backwardTimer += Time.deltaTime;
        }
        else
        {
            backwardTimer = 0f;
        }
    }

    void spawnStadiums() {
        int stadiumCount = (int)(TotalDeaths[currentIdx] / stadiumCapacity);
        float leftDist = stadiumSpacingX;
        float rightDist = stadiumSpacingX;
        float upDist = stadiumSpacingZ;
        float botDist = stadiumSpacingZ;

        int direction = 0;

        for (int i = 0; i < stadiumCount; i++)
        {
            if (i == 0) {
                Instantiate(stadium, new Vector3(0, 0, 0), Quaternion.identity);
            }else if (direction == 0)
            {
                Instantiate(stadium, new Vector3((leftDist), 0, 0), Quaternion.identity);
                leftDist += stadiumSpacingX;
                direction++;
            }else if (direction == 1)
            {
                Instantiate(stadium, new Vector3(-(rightDist), 0, 0), Quaternion.identity);
                rightDist += stadiumSpacingX;
                direction++;
            }else if (direction == 2)
            {
                Instantiate(stadium, new Vector3(0, 0, (upDist)), Quaternion.identity);
                upDist += stadiumSpacingZ;
                direction=0;
            }

        }
    }

    void simplifyTime() {

        while (currentDivision > totalDivisions)
        {
            currentDivision -= totalDivisions;
            currentYear++;
        }
    }
}
