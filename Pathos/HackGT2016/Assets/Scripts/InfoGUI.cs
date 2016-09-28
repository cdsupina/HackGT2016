using UnityEngine;
using System.Collections;

public class InfoGUI : MonoBehaviour
{

    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 600 , 25), "Year: " + ScaleSpawner.currentYear + "  Current Division: " + ScaleSpawner.currentDivision + "  Divisions per Year: " + ScaleSpawner.totalDivisions +" Extrapolation Point: " + ScaleSpawner.extrapolatedStr);
        GUI.Box(new Rect(0, 25, 150, 100), "Data Set:\n" + ScaleSpawner.dataSetName + "\n\nNFL Field Capacity: \n" + ScaleSpawner.stadiumCapacity);
    }

    
}
