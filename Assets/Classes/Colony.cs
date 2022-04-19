using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colony : MonoBehaviour
{

    //todo ��������
    //todo �����
    //todo ��������)0

    public Ant.Team team;

    public Transform basePos;
    public List<Transform> targetPos = new List<Transform>();

    //�������
    public int twigs = 0;
    //������
    public int leafs = 0;
    //�������
    public int rocks = 0;
    //�������
    public int drops = 0;

    public void InitTargetsAndBase()
    {

        foreach (var gameObj in FindObjectsOfType(typeof(GameObject)) as GameObject[])
        {

            if (gameObj.name.Contains("Target"))
                targetPos.Add(gameObj.transform);

        }

        basePos = transform;

    }

    public void InstantiateWarrior(string modelName, int health, int damage, int protection, int enemiesnum)
    {

        GameObject obj = Resources.Load(modelName, typeof(GameObject)) as GameObject;

        obj.GetComponent<BaseWarrior>().Init(health, damage, protection, enemiesnum);
        obj.GetComponent<BaseWarrior>().SetBase(basePos);
        obj.GetComponent<BaseWarrior>().SetTargets(targetPos);
        obj.GetComponent<BaseWarrior>().SetTeam(team);

        Vector3 currentPos = transform.position;

        Vector3 newPos = currentPos;
        newPos.x -= 0.5f;
        newPos.y = 0.76f;
        newPos.z -= 0.5f;

        obj.transform.position = newPos;
        obj.transform.rotation = new Quaternion(-90, 0, 0, 0);

        Instantiate(obj);

    }

    void Start()
    {

        InitTargetsAndBase();

        InstantiateWarrior("Warrior", 10, 10, 0, 10);

    }

    void Update()
    {

        //todo
        //if (Vector3.Distance(transform.position, targetPos[targetNum].position) < 4f)
        //������, ������� ������ �� ���� - �������� ���������, �������� ���������

    }

}
