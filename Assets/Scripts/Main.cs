using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public void ConfigureTargets()
    {

        List<GameObject> result = new List<GameObject>();

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {

            Target t = gameObj.GetComponent<Target>();

            if (!t) continue;
            
            result.Add(gameObj);

        }

        if(result.Count < 5)
            throw new System.Exception("Ќе удовлетвор€ет условию задачи: п€ть куч");

        result[0].GetComponent<Target>().Init(10, 10, 10, 10);
        result[1].GetComponent<Target>().Init(15, 10, 10, 10);
        result[2].GetComponent<Target>().Init(10, 15, 10, 10);
        result[3].GetComponent<Target>().Init(10, 10, 15, 10);
        result[4].GetComponent<Target>().Init(10, 10, 10, 15);

    }

    void Start()
    {

        ConfigureTargets();


    }


    void FixedUpdate()
    {



    }

}
