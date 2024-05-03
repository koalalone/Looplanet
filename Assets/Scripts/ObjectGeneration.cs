using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.AI.Navigation;
using UnityEngine;

public class ObjectGeneration : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] miniPrefabs;
    public List<GameObject> props;
    public float noiseScale = 0.05f;
    public float density = 0.3f;
    public int size = 300;

    public NavMeshSurface navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {
        float[,] noiseMap = new float[size, size];
        float xOffset = Random.Range(-10000f, 10000f);
        float yOffset = Random.Range(-10000f, 10000f);
        for (int y = 0; y < size; y++)
        {
            for (int x = 0; x < size; x++)
            {
                float noiseValue = Mathf.PerlinNoise(x * noiseScale + xOffset, y * noiseScale + yOffset);
                noiseMap[x, y] = noiseValue;
            }
        }

        for (int y = 0; y < size/2; y++)
        {
            for (int x = 0; x < size/2; x++)
            {
                
                float v = Random.Range(0f, density);
                float g = Random.Range(0.8f, 1f);

                float xCoord = Random.Range(1.9f * (x - 75), 2.1f * (x - 75));
                float yCoord = Random.Range(1.9f * (y - 75), 2.1f * (y - 75));

                if (noiseMap[x, y] < v)
                {
                    GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
                    GameObject prop = Instantiate(prefab, transform);
                    ActivationCheck.props.Add(prop);
                    prop.transform.position = new Vector3(xCoord, 0, yCoord);
                    if (prop.name.StartsWith("Tree"))
                    {
                        prop.transform.rotation = Quaternion.Euler(-90, Random.Range(0, 360f), 0);
                    }
                    else
                    {
                        prop.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
                    }
                    prop.transform.localScale = Vector3.one * Random.Range(0.9f, 1.1f);
                }
                else if (noiseMap[x, y] > g)
                {
                    GameObject prefab = miniPrefabs[Random.Range(0, miniPrefabs.Length)];
                    GameObject prop = Instantiate(prefab, transform);
                    ActivationCheck.props.Add(prop);
                    prop.transform.position = new Vector3(xCoord, 0, yCoord);
                    prop.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
                    prop.transform.localScale = Vector3.one * Random.Range(0.9f, 1.1f);
                }
            }
        }

        navMeshSurface.BuildNavMesh();

    }
}
