using UnityEngine;

public class SpawnGrid : MonoBehaviour
{
    public float fTimer = 0f;
    public float fFrequence = 10f;
    [SerializeField]private SpawnAxe[] spawnAxes = new SpawnAxe[9];
    private int iHasard(int a, int b) //Si 0 alors vaisseau ennemi, sinon asteroid
    {
        System.Random rdm = new System.Random();
        int hasard = rdm.Next(a, b + 1); //Aller jusqu'a le b inclu.
        return hasard;
    }
    private void Start()
    {
        spawnAxes[iHasard(0, 8)].Spawn(iHasard(0, 1));
    }
    private void Update()
    {
        fTimer += Time.deltaTime;
        if (fTimer > fFrequence)
        {
            spawnAxes[iHasard(0, 8)].Spawn(iHasard(0, 1));
            fTimer = 0f;
        }
    }
}
