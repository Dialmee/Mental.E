using NUnit.Framework.Constraints;
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
        }
        else
        {
            GO_foes[iCurrentFoe].SetActive(true);
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

    public Transform WhatFoe(bool isPlayer)
    {
        float bullRange = playerManager.ps.bulletRange * 10;
        if (!isPlayer)
        {
            bullRange *= 0.5f;
        }
        int layer= ~LayerMask.GetMask("Player");

        Vector3 PosStartRaycast = new Vector3(transform.position.x, transform.position.y,
            playerManager.gameObject.transform.position.z);

        RaycastHit hit;
        Physics.Raycast(PosStartRaycast, Vector3.forward, out hit, bullRange, layer);
        if (hit.collider == null)
            return null;

        FoeManager foeHit = hit.collider.GetComponent<FoeManager>();
        if (foeHit != null)
            return foeHit.transform;

        return null;

    }

}
