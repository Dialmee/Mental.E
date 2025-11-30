using System.Collections.Generic;
using UnityEngine;

public class SpawnAxe : MonoBehaviour
{
    public List<GameObject> GO_foes = new List<GameObject>(1);
    public List<GameObject> GO_asteroid = new List<GameObject>(1);
    private Transform tr_entity;
    public int iCurrentFoe = 0;
    public int iCurrentAsteroid = 0;
    public PlayerManager playerManager;
    public int iAxe = 0;
    private void Start()
    {
        tr_entity = this.GetComponent<Transform>();
    }
    public void Spawn(int hasard)
    {
        if(hasard < 70)
        {
            CheckEntityEnable(iCurrentFoe, GO_foes);
            iCurrentFoe += 1;
        }
        else
        {
            CheckEntityEnable(iCurrentAsteroid, GO_asteroid);
            iCurrentAsteroid += 1;
        }
    }
    private void CheckEntityEnable(int iCurrentEntity, List<GameObject> GO_entity)
    {
        if (iCurrentEntity >= GO_entity.Count && GO_entity[0].activeInHierarchy)
        {
            GO_entity.Add(Instantiate(GO_entity[0], this.transform.position, Quaternion.identity, tr_entity));
        }
        else if (iCurrentEntity >= GO_entity.Count)
        {
            iCurrentEntity = 0;
            GO_entity[0].SetActive(true);
        }
        else
        {
            GO_entity[iCurrentEntity].SetActive(true);
        }
    }

    public Transform WhatFoe()
    {
        Transform transform = this.transform;
        float greatestDistance = 0f;
        float newDistance = 0f;
        GameObject Go_far = null;
        foreach (GameObject go_foe in GO_foes)
        {
            if(go_foe.activeInHierarchy)
            {
                newDistance = this.transform.position.z - go_foe.transform.position.z;
                if (newDistance > greatestDistance)
                {
                    greatestDistance = newDistance;
                    Go_far = go_foe;
                }
            }
        }
        foreach (GameObject go_ast in GO_asteroid)
        {
            if (go_ast.activeInHierarchy)
            {
                newDistance = this.transform.position.z - go_ast.transform.position.z;
                if (newDistance > greatestDistance)
                {
                    greatestDistance = newDistance;
                    Go_far = null;
                }
            }
        }
        if(newDistance < playerManager.ps.bulletRange*10)
        {
            Go_far = null;
        }
        if (Go_far!=null)
        {
            transform = Go_far.transform;
            return transform;
        }
        else
        {
            return null;
        }
    }
}
