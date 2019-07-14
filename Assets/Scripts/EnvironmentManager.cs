using System.Collections;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager instance;

    private float positionZOffset = 10f;
    private float positionYOffset;


    [SerializeField]
    private GameObject[] environmentPrefabs;

    #region Singleton
    public static EnvironmentManager Instance()
    {   
        {
            if (instance == null)
            {
                GameObject go = new GameObject("EnvironmentManager");
                go.AddComponent<EnvironmentManager>();
            }
            return instance;
        }
    }
    #endregion

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Vector3 position = new Vector3(0, 0, 0);

        Instantiate(environmentPrefabs[2], position, Quaternion.identity);
        position.z += 10;

        for (int i = 1; i < 20; i++)
        {
            int randPrefab = Random.Range(0, environmentPrefabs.Length);
            Instantiate(environmentPrefabs[randPrefab], position, Quaternion.identity);
            position.z += 10;

            if (environmentPrefabs[randPrefab].tag == "Stairs")
            {
                position.y += 4.75f;
                positionYOffset = position.y;
                position.z += 0.1f; 
            }
            positionZOffset = position.z;
        }
    }

    public void ReplacePlatform(GameObject platfrom)
    {
        //reposition to next z offset
        platfrom.transform.position = new Vector3(0, positionYOffset, positionZOffset);
        positionZOffset += 10;
        if (platfrom.tag == "Stairs")
        {
            positionYOffset += 4.75f;
        }
    }
}
