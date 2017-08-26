using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text TextGold;
    public Camera MainCamera;
    public GameObject EffectSpark;
    public AudioClip SFXClick;
    public Text TextUpGradeCollectGold;

	// Use this for initialization
	void Start () {
        TextGold.text = DataController.Instance.Gold.ToString(); //숫자를 문자로 바꿔줌
        StartCoroutine(StartCollectGold()); //코루틴 실행! http://unityindepth.tistory.com/21 참조
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
        if (Input.GetMouseButtonDown(0))         {
            DataController.Instance.Gold += DataController.Instance.GoldPerSec;
            TextGold.text = DataController.Instance.Gold.ToString();

            Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit; //3D공간에서 레이저가 진행하다 collider에 충돌한 정보를 저장.
            if (Physics.Raycast(ray, out hit, 100f)){ //부딪힌 정보가 hit에 저장되고, 100f 거리의 레이저가 나감.
                Debug.Log(hit.point);
                Debug.DrawLine(ray.origin, hit.point, Color.red);

                Instantiate(EffectSpark, hit.point, EffectSpark.transform.rotation); //위치와 회전값을 넣어줌.
                MainCamera.gameObject.GetComponent<AudioSource>().PlayOneShot(SFXClick);
            }           
        }
	}

    public void upgradeCollectGold()
    {
        int Cost = DataController.Instance.CollectGoldLevel * DataController.Instance.CollectGoldLevel;
        if (DataController.Instance.Gold < Cost)
        {
            return;
        }
        else
        {
            
            DataController.Instance.CollectGoldLevel += 1;
            DataController.Instance.GoldPerSec = DataController.Instance.CollectGoldLevel;
            DataController.Instance.Gold -= Cost;
            TextGold.text = DataController.Instance.Gold.ToString();
            string upgradeText = string.Format("Gold up \n now:{0} value:{1}", DataController.Instance.CollectGoldLevel, Cost);
            TextUpGradeCollectGold.text = upgradeText;
        }
    }
}
