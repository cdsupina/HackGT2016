using UnityEngine;
using System.Collections;

public class StockGUI : MonoBehaviour {

    // Use this for initialization
    void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 200, 100), SpawnBall.stock1Name+ " Allocation: " + PointDetection.stock_1 + "\n"+SpawnBall.stock2Name+ " Allocation: " + PointDetection.stock_2 + "\n" + SpawnBall.stock3Name + " Allocation: "+ PointDetection.stock_3 + "\n" + SpawnBall.stock4Name + " Allocation: "+PointDetection.stock_4 + "\nReturn: " + PointDetection.returnVal);
    }
}
