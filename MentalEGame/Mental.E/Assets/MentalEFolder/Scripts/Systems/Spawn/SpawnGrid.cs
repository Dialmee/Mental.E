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
        int hasardAxe = iHasard(0, 8);
        int hasardEntity = iHasard(0, 1);
        Debug.Log("l'axe est " + hasardAxe + " et l'entite est " + hasardEntity);
        spawnAxes[hasardAxe].Spawn(hasardEntity);
    }
    private void Update()
    {
        fTimer += Time.deltaTime;
        if (fTimer > fFrequence)
        {
            int hasardAxe = iHasard(0, 8);
            int hasardEntity = iHasard(0, 1);
            Debug.Log("l'axe est " + hasardAxe + " et l'entite est " + hasardEntity);
            spawnAxes[hasardAxe].Spawn(hasardEntity);
            fTimer = 0f;
        }
    }
}
