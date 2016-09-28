using UnityEngine;
using System.Collections;
using UnityEngine.UI;





public class PointDetection : MonoBehaviour {

    public static string stock_1;
    public static string stock_2;
    public static string stock_3;
    public static string stock_4;
    public static string returnVal;

    public int inspectDist = 20;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

        
        RaycastHit hit;
        Debug.DrawRay(transform.position, transform.forward * inspectDist);
        if (Physics.SphereCast(transform.position, 0.5f, transform.forward * inspectDist, out hit, 1 << 8)) {

            if (hit.collider.tag == "Point")
            {

                GameObject target = hit.collider.gameObject;
                stock_1 = (target.GetComponent<PointVals>().xPos).ToString();
                stock_2 = (target.GetComponent<PointVals>().yPos).ToString();
                stock_3 = (target.GetComponent<PointVals>().zPos).ToString();
                stock_4 = (target.GetComponent<PointVals>().fourthStock).ToString();
                returnVal = (target.GetComponent<PointVals>().val).ToString();
            }
            else {

                stock_1 = "";
                stock_2 = "";
                stock_3 = "";
                stock_4 = "";
                returnVal = "";
            }



        }
    }
}
