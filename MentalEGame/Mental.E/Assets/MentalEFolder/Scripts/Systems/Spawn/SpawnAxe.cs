using NUnit.Framework.Constraints;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAxe : MonoBehaviour
{
    public List<GameObject> GO_foes = new List<GameObject>(1);
    public List<GameObject> GO_asteroid = new List<GameObject>(1);
    public List<GameObject> GO_Projectil = new List<GameObject>(10);
    public Transform ProjectileParent;
    public int iCurrentProjectil = 0;
    private Transform tr_entity;
    public int iCurrentFoe = 0;
    public int iCurrentAsteroid = 0;
    public PlayerManager playerManager;
    public int iAxe = 0;

    private void Start()
    {
        tr_entity = GetComponent<Transform>();
    }
    public void Spawn(bool isEnemie)
    {
        if(isEnemie)
        {
            CheckSpawnEnemie();
            iCurrentFoe += 1;
        }
        else
        {
            CheckSpawnAsteroid();
            iCurrentAsteroid += 1;
        }
    }
    private void CheckSpawnEnemie()
    {
        if (iCurrentFoe >= GO_foes.Count && GO_foes[0].activeInHierarchy)
        {
            GO_foes.Add(Instantiate(GO_foes[0], transform.position, Quaternion.identity, tr_entity));
        }
        else if (iCurrentFoe >= GO_foes.Count)
        {
            iCurrentFoe = 0;
            GO_foes[0].SetActive(true);
            GO_foes[0].transform.position = transform.position;
        }
        else
        {
            GO_foes[iCurrentFoe].SetActive(true);
            GO_foes[0].transform.position = transform.position;
        }
    }
    private void CheckSpawnAsteroid()
    {
        if (iCurrentAsteroid >= GO_asteroid.Count && GO_asteroid[0].activeInHierarchy)
        {
            GO_asteroid.Add(Instantiate(GO_asteroid[0], transform.position, Quaternion.identity, tr_entity));
        }
        else if (iCurrentAsteroid >= GO_asteroid.Count)
        {
            iCurrentAsteroid = 0;
            GO_asteroid[0].SetActive(true);
            GO_asteroid[0].transform.position = transform.position;
        }
        else
        {
            GO_asteroid[iCurrentAsteroid].SetActive(true);
            GO_asteroid[0].transform.position = transform.position;
        }
    }

    public Transform WhatFoe(bool isPlayer, LayerMask layerMask)
    {
        float bullRange = playerManager.ps.bulletRange * 10;
        if (!isPlayer)
        {
            bullRange = bullRange*0.8f;
        }
        Vector3 PosStartRaycast = this.transform.position;
        RaycastHit hit;
        Vector3 direction = Vector3.forward;
        if (!isPlayer)
        {
            PosStartRaycast = new Vector3(transform.position.x, transform.position.y, this.gameObject.transform.position.z);
            direction = Vector3.back;
        }
        else
        {
            PosStartRaycast = new Vector3(transform.position.x, transform.position.y,  playerManager.gameObject.transform.position.z);
            direction = Vector3.forward;
        }
            Physics.Raycast(PosStartRaycast, direction, out hit, bullRange, layerMask);
        if (hit.collider == null)
        {
            return null;
        }
        else
        {
            /*FoeManager foeHit = hit.collider.GetComponent<FoeManager>();
            if (foeHit != null)
            {
                Debug.Log(foeHit.transform);
                return foeHit.transform;
            }
            else
            {
                return null;
            }*/
            return hit.collider.transform;
        }
    }
}
