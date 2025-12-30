using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField] private MeshFilter _meshFilter;
    [SerializeField] private Mesh[] _meshs = new Mesh[2];
    [SerializeField] private GameObject go_mesh;
    [SerializeField] private float fspeedRotate = 1f;
    private int[] _int = new int[3] { 1, 1, 1 };

    private int Hasard(int a, int b) //Choisi un random.
    {
        System.Random rdm = new System.Random();
        int hasard = rdm.Next(a, b + 1); //Aller jusqu'a le b inclu.
        return hasard;
    }
    private void OnEnable()
    {
        _meshFilter.mesh = _meshs[Hasard(0, 1)];
        for(int i = 0; i<2; i++)
        {
            _int[i]= Hasard(-3, 3);
        }
        this.transform.localPosition = Vector3.zero;
    }

    private void Update()
    {
        go_mesh.transform.Rotate(new Vector3(_int[0]*fspeedRotate * Time.deltaTime, _int[1]*fspeedRotate * Time.deltaTime, _int[2]*fspeedRotate * Time.deltaTime), Space.Self);
    }
}
