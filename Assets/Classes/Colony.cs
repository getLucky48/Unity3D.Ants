using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

public class Colony : MonoBehaviour
{

    //todo ????????

    public Enums.Team team;

    public Transform basePos;
    public List<Transform> targetPos = new List<Transform>();

    public GameObject obj;

    #region ??? ???????, ???????????? ? ??????
    
    public GameObject PrefabWarrior;
    public GameObject PrefabElderWarrior;
    public GameObject PrefabLegendWarrior;
    public GameObject PrefabLegendCareWarrior;
    public GameObject PrefabUpperLegendWarrior;

    public GameObject PrefabWorker;
    public GameObject PrefabElderWorker;
    public GameObject PrefabEliteWorker;
    public GameObject PrefabProLikedWorker;
    public GameObject PrefabProWorker;

    #endregion

    public Dictionary<Enums.TypeResourse, int> inventory = new Dictionary<Enums.TypeResourse, int>() {

        {  Enums.TypeResourse.Twigs, 0 },
        {  Enums.TypeResourse.Leafs, 0 },
        {  Enums.TypeResourse.Rocks, 0 },
        {  Enums.TypeResourse.Drops, 0 }

    };

    public void Import(Enums.TypeResourse type, int count)   
    {

        this.inventory[type] += count;

    }

    public void InitTargetsAndBase()
    {

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {

            if (gameObj.name.Contains("Target"))
                targetPos.Add(gameObj.transform);

        }

        basePos = transform;

    }

    public void LoadResources()
    {

        PrefabWarrior = Resources.Load("Warriors/Warrior", typeof(GameObject)) as GameObject;
        PrefabElderWarrior = Resources.Load("Warriors/ElderWarrior", typeof(GameObject)) as GameObject;
        PrefabLegendWarrior = Resources.Load("Warriors/LegendWarrior", typeof(GameObject)) as GameObject;
        PrefabLegendCareWarrior = Resources.Load("Warriors/LegendCareWarrior", typeof(GameObject)) as GameObject;
        PrefabUpperLegendWarrior = Resources.Load("Warriors/UpperLegendWarrior", typeof(GameObject)) as GameObject;

        InstantiateWarrior("Warrior", 0, 0, 0, 0, true);
        InstantiateWarrior("ElderWarrior", 0, 0, 0, 0, true);
        InstantiateWarrior("LegendWarrior", 0, 0, 0, 0, true);
        InstantiateWarrior("LegendCareWarrior", 0, 0, 0, 0, true);
        InstantiateWarrior("UpperLegendWarrior", 0, 0, 0, 0, true);

        PrefabWorker = Resources.Load("Workers/Worker", typeof(GameObject)) as GameObject;
        PrefabElderWorker = Resources.Load("Workers/ElderWorker", typeof(GameObject)) as GameObject;
        PrefabEliteWorker = Resources.Load("Workers/EliteWorker", typeof(GameObject)) as GameObject;
        PrefabProLikedWorker = Resources.Load("Workers/ProLikedWorker", typeof(GameObject)) as GameObject;
        PrefabProWorker = Resources.Load("Workers/ProWorker", typeof(GameObject)) as GameObject;

        InstantiateWorker("Worker", 0, 0, 0, true);
        InstantiateWorker("ElderWorker", 0, 0, 0, true);
        InstantiateWorker("EliteWorker", 0, 0, 0, true);
        InstantiateWorker("ProLikedWorker", 0, 0, 0, true);
        InstantiateWorker("ProWorker", 0, 0, 0, true);

    }

    public void AddResourse(Enums.TypeResourse type, int count)
    {

        this.inventory[type] = +count;

    }

    public void InstantiateWarrior(string modelName, int health, int damage, int protection, int enemiesnum, bool isHidden = false)
    {

        GameObject cfg;

        if (modelName.Equals("Warrior"))
            cfg = Instantiate(PrefabWarrior);
        else if (modelName.Equals("ElderWarrior"))
            cfg = Instantiate(PrefabElderWarrior);
        else if (modelName.Equals("LegendWarrior"))
            cfg = Instantiate(PrefabLegendWarrior);
        else if (modelName.Equals("LegendCareWarrior"))
            cfg = Instantiate(PrefabLegendCareWarrior);
        else if (modelName.Equals("UpperLegendWarrior"))
            cfg = Instantiate(PrefabUpperLegendWarrior);
        else
            cfg = new GameObject();

        cfg.GetComponent<BaseWarrior>().Init(health, damage, protection, enemiesnum);
        cfg.GetComponent<BaseWarrior>().SetBase(basePos);
        cfg.GetComponent<BaseWarrior>().SetTargets(targetPos);
        cfg.GetComponent<BaseWarrior>().SetTeam(team);

        Vector3 currentPos = transform.position;

        Vector3 newPos = currentPos;
        newPos.x -= 0.5f;
        newPos.y = 0.76f;
        newPos.z -= 0.5f;

        cfg.transform.position = newPos;
        cfg.transform.rotation = new Quaternion(-90, 0, 0, 0);

        if (isHidden)
            cfg.SetActive(false);

    }

    public void InstantiateWorker(string modelName, int health, int protection, int inventoryCapacity, bool isHidden = false)
    {

        GameObject cfg;

        if (modelName.Equals("Worker"))
            cfg = Instantiate(PrefabWorker);
        else if (modelName.Equals("ElderWorker"))
            cfg = Instantiate(PrefabElderWorker);
        else if (modelName.Equals("EliteWorker"))
            cfg = Instantiate(PrefabEliteWorker);
        else if (modelName.Equals("ProLikedWorker"))
            cfg = Instantiate(PrefabProLikedWorker);
        else if (modelName.Equals("ProWorker"))
            cfg = Instantiate(PrefabProWorker);
        else
            cfg = new GameObject();

        cfg.GetComponent<BaseWorker>().Init(health, protection);
        cfg.GetComponent<BaseWorker>().SetBase(basePos);
        cfg.GetComponent<BaseWorker>().SetTargets(targetPos);
        cfg.GetComponent<BaseWorker>().SetTeam(team);

        if (modelName.Equals("Worker"))
        {

            cfg.GetComponent<BaseWorker>().SetInventoryType(new Dictionary<Enums.TypeResourse, int>() {

                { Enums.TypeResourse.Drops, 0 }

            }, 1);

        }
        else if (modelName.Equals("ElderWorker"))
        {

            cfg.GetComponent<BaseWorker>().SetInventoryType(new Dictionary<Enums.TypeResourse, int>() {

                { Enums.TypeResourse.Leafs, 0 },
                { Enums.TypeResourse.Twigs, 0 }

            }, 1);

        }
        else if (modelName.Equals("EliteWorker"))
        {

            cfg.GetComponent<BaseWorker>().SetInventoryType(new Dictionary<Enums.TypeResourse, int>() {

                { Enums.TypeResourse.Leafs, 0 }

            }, 2);

        }
        else if (modelName.Equals("ProLikedWorker"))
        {

            cfg.GetComponent<BaseWorker>().SetInventoryType(new Dictionary<Enums.TypeResourse, int>() {

                { Enums.TypeResourse.Rocks, 0 },
                { Enums.TypeResourse.Drops, 0 }

            }, 2);

        }
        else if (modelName.Equals("ProWorker"))
        {

            cfg.GetComponent<BaseWorker>().SetInventoryType(new Dictionary<Enums.TypeResourse, int>() {

                { Enums.TypeResourse.Rocks, 0 },
                { Enums.TypeResourse.Twigs, 0 },
                { Enums.TypeResourse.Leafs, 0 }

            }, 2);

        }

        Vector3 currentPos = transform.position;

        Vector3 newPos = currentPos;
        newPos.x -= 0.5f;
        newPos.y = 0.76f;
        newPos.z -= 0.5f;

        cfg.transform.position = newPos;
        cfg.transform.rotation = new Quaternion(-90, 0, 0, 0);

        if (isHidden)
            cfg.SetActive(false);

    }

    void Start()
    {

        LoadResources();

        InitTargetsAndBase();

        //InstantiateWarrior("Warrior", 10, 10, 0, 10);
        //InstantiateWarrior("ElderWarrior", 10, 10, 0, 10);
        //InstantiateWarrior("LegendWarrior", 10, 10, 0, 10);
        //InstantiateWarrior("LegendCareWarrior", 10, 10, 0, 10);
        //InstantiateWarrior("UpperLegendWarrior", 10, 10, 0, 10);

        InstantiateWorker("Worker", 1000, 0, 0);
        InstantiateWorker("ElderWorker", 1000, 0, 0);
        InstantiateWorker("EliteWorker", 1000, 0, 0);
        InstantiateWorker("ProLikedWorker", 1000, 0, 0);
        InstantiateWorker("ProWorker", 1000, 0, 0);

    }

    void Update()
    {

    }

}
