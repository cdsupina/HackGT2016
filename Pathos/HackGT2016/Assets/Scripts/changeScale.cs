using UnityEngine;
using System.Collections;

public class changeScale : MonoBehaviour {

    public float growDelay = 0.05f;
    public float growTimer = 0f;
    public float shrinkDelay = 0.05f;
    public float shrinkTimer = 0f;
    public float multiplier = 0.01f;

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        grow();
        shrink();

        if (Input.GetButton("Menu")) {

            Application.LoadLevel(0);
        }
	}

    void grow() {

        if (Input.GetButton("Fire1") && (growTimer > growDelay))
        {
            transform.localScale += new Vector3(multiplier, multiplier, multiplier);
            growTimer = 0f;
        }
        else if (Input.GetButton("Fire1"))
        {
            growTimer += Time.deltaTime;
        }
        else
        {
            growTimer = 0f;
        }
    }

    void shrink()
    {

        if (Input.GetButton("Fire2") && (shrinkTimer > shrinkDelay))
        {
            transform.localScale += new Vector3(-multiplier,-multiplier,-multiplier);
            shrinkTimer = 0f;
        }
        else if (Input.GetButton("Fire2"))
        {
            shrinkTimer += Time.deltaTime;
        }
        else
        {
            shrinkTimer = 0f;
        }
    }
}
