using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapController : MonoBehaviour {

    public GameObject Tap1, Tap2, Tap3, Tap4;
    public int currentTapNumber = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnClickTap(int tapNumber)
    {
        if (tapNumber == 1)
        {
            if (tapNumber==currentTapNumber)
            {
                currentTapNumber = 0;
                Tap1.SetActive(false);
            }
            else
            {
                Tap1.SetActive(true);
                Tap2.SetActive(false);
                Tap3.SetActive(false);
                Tap4.SetActive(false);
                currentTapNumber = 1;
            }
        }

        if (tapNumber == 2)
        {
            if (tapNumber == currentTapNumber)
            {
                currentTapNumber = 0;
                Tap2.SetActive(false);
            }
            else
            {
                Tap1.SetActive(false);
                Tap2.SetActive(true);
                Tap3.SetActive(false);
                Tap4.SetActive(false);
                currentTapNumber = 2;
            }
        }
        if (tapNumber == 3)
        {
            if (tapNumber == currentTapNumber)
            {
                currentTapNumber = 0;
                Tap3.SetActive(false);
            }
            else
            {
                Tap1.SetActive(false);
                Tap2.SetActive(false);
                Tap3.SetActive(true);
                Tap4.SetActive(false);
                currentTapNumber = 3;
            }
        }
        if (tapNumber == 4)
        {
            if (tapNumber == currentTapNumber)
            {
                currentTapNumber = 0;
                Tap4.SetActive(false);
            }
            else
            {
                Tap1.SetActive(false);
                Tap2.SetActive(false);
                Tap3.SetActive(false);
                Tap4.SetActive(true);
                currentTapNumber = 4;
            }
        }
    }
}
