using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    void Start()
    {

        GameObject obj = Resources.Load("ElderWarrior", typeof(GameObject)) as GameObject;
        
        obj.GetComponent<ElderWarrior>().Init(10, 10, 10, 10);

        Instantiate(obj);

    }


    void Update()
    {


        
    }

}
