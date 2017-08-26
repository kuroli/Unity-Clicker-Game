using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text TextGold;

	// Use this for initialization
	void Start () {
        TextGold.text = DataController.Instance.Gold.ToString(); //숫자를 문자로 바꿔줌
        StartCoroutine(StartCollectGold()); //코루틴 실행!
	}
	
    IEnumerator StartCollectGold() //코루틴. 1초에 1번씩 ~해라 할때 or 애니메이션 or 시간순서. 비동기식. multy-thread와는 다름. 
    {

        while (true)
        {
            yield return new WaitForSecondsRealtime(1f); //현실 시간으로 1초를 쉰다.
            DataController.Instance.Gold += DataController.Instance.GoldPerSec;
            TextGold.text = DataController.Instance.Gold.ToString();
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
