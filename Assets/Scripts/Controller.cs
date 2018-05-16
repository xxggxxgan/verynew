using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public static Controller Instance { set; get; }

    public static int counter = 0;
    GameObject startFort;
    public static GameObject desFort;
    public GameObject gabby;
    public GameObject gabby2;
    public GameObject gabby3;
    public GameObject clone;
    public GameObject badgabby;
    public GameObject flyGabby;
    public static int number;
    public Camera camera;
    private GameObject[] xiaobingmen;
    private Client client;
    public bool isLeft;


    // Use this for initialization
    void Start()
    {
        Instance = this;
        client = FindObjectOfType<Client>();
        isLeft = client.ishost;

        if (isLeft){
            FortController castle2 = GameObject.Find("fort2").GetComponent<FortController>();
            castle2.isWhite = true;
        }
        else{
            FortController castle6 = GameObject.Find("fort6").GetComponent<FortController>();
            castle6.isWhite = false;
        }


    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }


    void Click()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                FortController fort1 = hit.collider.gameObject.GetComponent<FortController>();

                if (hit.collider.tag != "fort")
                {
                    counter = 0;
                }

                //if (hit.collider.tag != "you" && hit.collider.tag != "me" && hit.collider.tag != "him")
                //{
                //  counter = 0;
                //}


                //else if (counter == 0 && hit.collider.tag == "him")
                //{
                //   counter = 0;
                //}

                else if (counter == 0 && fort1.isZhongli){
                    counter = 0;
                }

                else
                {
                    
                    if (counter == 0 && isLeft && fort1.isWhite){
                        counter += 1;
                        startFort = hit.collider.gameObject;

                        Debug.Log(fort1.numberOfSoldiers);
                        
                    }
                    else if (counter == 0 && !isLeft && !fort1.isWhite){
                        counter += 1;
                        startFort = hit.collider.gameObject;

                        Debug.Log(fort1.numberOfSoldiers);
                    }


                    else if (counter >= 1 && hit.collider.gameObject == startFort)
                        counter++;
                    


                    if (counter >= 2 && hit.collider.gameObject != startFort)
                    {
                        FortController fort = startFort.GetComponent<FortController>();

                        if (fort.Flyable)
                        {
                            //Debug.Log ("hello");
                            if (counter >= 4) counter = 4;
                            desFort = hit.collider.gameObject;
                            Vector3 direction = (desFort.transform.position - fort.transform.position).normalized;
                            clone = Instantiate(flyGabby, fort.spawnpoint1.transform.position, Quaternion.identity);
                            clone.SetActive(true);
                            number = (counter - 1) * fort.numberOfSoldiers / 3;
                            fort.numberOfSoldiers -= number;
                            counter = 0;

                        }
                        else
                        {
                            if (counter >= 4) counter = 4;
                            desFort = hit.collider.gameObject;
                            number = (counter - 1) * fort.numberOfSoldiers / 3;
                            //Debug.Log("are you herer rer er er er e");
                            //spawn(startFort, desFort, number);
                            if (client) {
                            string msg = "CMOV|";
                            msg += startFort.name.ToString() + "|";
                            msg += desFort.name.ToString() + "|";
                            msg += number.ToString();

                            client.Send(msg);
                            }

                            //fort.numberOfSoldiers -= number;
                            Debug.Log(fort.numberOfSoldiers);
                            Debug.Log(number);
                            counter = 0;
                        }
                    }
                }
            }
            Debug.Log("this is counter:" + counter);
        }

    }

    public void spawn(GameObject from, GameObject to, int num)
    {
        FortController start = from.GetComponent<FortController>();
        FortController end = to.GetComponent<FortController>();
        desFort = to;
        start.numberOfSoldiers -= num;



        if (num >= 50)
        {
            if (end.reportDes() == start.spawnpoint1.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint2.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint3.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint4.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint5.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint6.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby3, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
        }




        else if (num >= 30)
        {
            if (end.reportDes() == start.spawnpoint1.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint2.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint3.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint4.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;

                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint5.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint6.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby2, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
        }





        else if (num >= 0)
        {
            if (end.reportDes() == start.spawnpoint1.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint1.transform.position, start.spawnpoint1.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint2.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint2.transform.position, start.spawnpoint2.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint3.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint3.transform.position, start.spawnpoint3.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint4.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint4.transform.position, start.spawnpoint4.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }

            }
            else if (end.reportDes() == start.spawnpoint5.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint5.transform.position, start.spawnpoint5.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
            else if (end.reportDes() == start.spawnpoint6.name)
            {
                if (start.isWhite)
                {
                    clone = Instantiate(gabby, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = true;
                }
                else
                {
                    clone = Instantiate(badgabby, start.spawnpoint6.transform.position, start.spawnpoint6.transform.rotation);
                    clone.SetActive(true);
                    GabbyController cnm = clone.GetComponent<GabbyController>();
                    cnm.numberOfMovingSoldiers = num;
                    cnm.GoodOrNot = false;
                }
            }
        }


    }
}










