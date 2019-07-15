using System.Collections;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    public static EnvironmentManager instance;

    private float positionZOffset = 10f;
    private float positionYOffset;
    private float coinZPosition = 6f;
    private float coinOffset = 5f;

    [SerializeField]
    private GameObject coinPrefab;
    [SerializeField]
    private GameObject[] environmentPrefabs;

    private float[] cointRailsPositions = { -1.85f, 0, 1.75f };
 /*
    #region Singleton
    public static EnvironmentManager Instance()
    {
        {
            if (instance == null)
            {
                GameObject go = new GameObject("EnvironmentManager");
                go.AddComponent<EnvironmentManager>();
                return go.GetComponent<EnvironmentManager>();
            }
            else
            {
                return instance;
            }
        }
    }
    #endregion
 */

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 EnvironmentManager in the scene!");
            return;
        }
        instance = this;
    }

    void Start()
    {
        Vector3 position = new Vector3(0, 0, 0);

        position.z += 10;

        for (int i = 1; i < 20; i++)
        {
            int randPrefab = Random.Range(0, environmentPrefabs.Length);
            Instantiate(environmentPrefabs[randPrefab], position, Quaternion.identity);
            position.z += 10;

            positionZOffset = position.z;

            CoinGenerator(position, environmentPrefabs[randPrefab].tag);
        }
    }

    private void CoinGenerator(Vector3 position,string tag)
    {
        for (int j = 0; j <= 5; j++)
        {
            float coinYPosition = position.y + 1f;
            int randomIndex = Random.Range(0, 3);
            float randXCoinPos = cointRailsPositions[randomIndex];

            Vector3 coinPos = new Vector3(randXCoinPos, coinYPosition, coinZPosition);
            Instantiate(coinPrefab, coinPos, Quaternion.identity);

            coinZPosition += coinOffset;
        }
    }

    public void ReplacePlatform(GameObject platfrom)
    {
        //reposition to next z offset
        platfrom.transform.position = new Vector3(0, positionYOffset, positionZOffset);
        positionZOffset += 10;
    }
}
