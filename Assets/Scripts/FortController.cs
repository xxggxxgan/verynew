﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FortController : MonoBehaviour {

	public int numberOfSoldiers = 20;
	int remainingSoldiers;
	public GameObject spawnpoint1;
	public GameObject spawnpoint2;
	public GameObject spawnpoint3;
	public GameObject spawnpoint4;
    public GameObject spawnpoint5;
    public GameObject spawnpoint6;
	private float Prsudo_Time = 1f;
	public int FortLevel;
	public bool Flyable;
	public Text CountText;
    public bool isWhite;
    public bool isZhongli = true;



	// Use this for initialization
	void Start () {



	}
	
	// Update is called once per frame
	void Update () {
        if (!isZhongli) {
			AddToScore ();
		}
		setCount ();

	}

	void AddToScore(){
		Prsudo_Time -= Time.deltaTime;
		if(Prsudo_Time <=0 ){
			numberOfSoldiers+= 1;
			Prsudo_Time = 1f;
		//	Debug.Log (numberOfSoldiers);
		}

	
	}





	void OnTriggerEnter(Collider other) 
	{
        Debug.Log(other.name);
		if (other.name == "FlyGabby(Clone)") {
			Debug.Log (numberOfSoldiers);
			GabbyController gabby = other.gameObject.GetComponent<GabbyController> ();
			FlyGabbyMovement flygabby = other.gameObject.GetComponent<FlyGabbyMovement> ();
			if (other.gameObject == flygabby.gameObject && flygabby.des == this.gameObject) {
				Destroy (other.gameObject);
				if (gameObject.tag == other.gameObject.tag) {
					int i = numberOfSoldiers;
					numberOfSoldiers = numberOfSoldiers + gabby.numberOfMovingSoldiers;
					Debug.Log (i + " + " + gabby.numberOfMovingSoldiers + " = " + numberOfSoldiers);
				} else { 
					int j = numberOfSoldiers;
					numberOfSoldiers = numberOfSoldiers - gabby.numberOfMovingSoldiers / FortLevel;
					Debug.Log (j + " - " + gabby.numberOfMovingSoldiers / FortLevel + " = " + numberOfSoldiers);
					if (numberOfSoldiers < 0) {
						gameObject.tag = other.gameObject.tag;
					}
				}
			}
		}
		//Destroy (other.gameObject);

		else{
            GabbyController gabby = other.gameObject.GetComponent<GabbyController>();
			Destroy (other.gameObject);
            if ((gabby.GoodOrNot == isWhite) && !isZhongli) {
				int i = numberOfSoldiers;
				numberOfSoldiers = numberOfSoldiers + gabby.numberOfMovingSoldiers;
				Debug.Log (i + " + " + gabby.numberOfMovingSoldiers + " = " + numberOfSoldiers);
			} else { 
				int j = numberOfSoldiers;
				numberOfSoldiers = numberOfSoldiers - gabby.numberOfMovingSoldiers/FortLevel;
				Debug.Log (j + " - " + gabby.numberOfMovingSoldiers/FortLevel + " = " + numberOfSoldiers);
				if (numberOfSoldiers < 0) {
						numberOfSoldiers = Mathf.Abs(numberOfSoldiers);
                    isWhite = gabby.GoodOrNot;
                    isZhongli = false;
					//numberOfSoldiers = -numberOfSoldiers;
						Debug.Log("this is the number" + numberOfSoldiers);


				}
			}
//			Debug.Log (numberOfSoldiers);
		}
	}

	public string reportDes(){
		
		if (gameObject.name == "fort1") {
			return "spawnpoint1";

		} else if (gameObject.name == "fort2") {
			return "spawnpoint2";

		} else if (gameObject.name == "fort3") {
			return "spawnpoint3";

		} else if (gameObject.name == "fort4") {
			return "spawnpoint4";
		} else if (gameObject.name == "fort5") {
			return "spawnpoint5";
		} else if (gameObject.name == "fort6") {
			return "spawnpoint6";
		} else if (gameObject.name == "fort7") {
			return "spawnpoint7";
		}
		else if (gameObject.name == "fort8") {
			return "spawnpoint8";
		}
		else if (gameObject.name == "fort9") {
			return "spawnpoint9";
		}
		else if (gameObject.name == "fort10") {
			return "spawnpoint10";
		}
		else if (gameObject.name == "fort11") {
			return "spawnpoint11";
		}
		else if (gameObject.name == "fort12") {
			return "spawnpoint12";
		}
		else if (gameObject.name == "fort13") {
			return "spawnpoint13";
		}
		else if (gameObject.name == "fort14") {
			return "spawnpoint14";
		}
		else{
			Debug.Log ("error on reportDes()");
			return "false";
	}

}
	public void setCount(){

//		CountText.text = numberOfSoldiers.ToString();
	}
}
