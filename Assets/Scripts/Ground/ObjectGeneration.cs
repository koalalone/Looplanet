using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectGeneration : MonoBehaviour
{
    public GameObject[] prefabs;
    public GameObject[] miniPrefabs;
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    //public List<GameObject> props;
    //public List<GameObject> enemies;
    public float noiseScale;
    public float prefabDensity;
    public float miniPrefabDensity;
    public float enemyPrefabDensity;

    public float prefabScaleMin;
    public float prefabScaleMax;
    public float miniPrefabScaleMin;
    public float miniPrefabScaleMax;

    public Texture2D tex;

    public int size = 300;

    public NavMeshSurface navMeshSurface;

    // Start is called before the first frame update
    void Start()
    {

        gameObject.GetComponent<Terrain>().terrainData.terrainLayers[0].diffuseTexture = tex;

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

        //Vector3 bossCoord = Random.onUnitSphere * size / 2;

        float angle = Random.Range(0.0f, 2.0f * Mathf.PI);
        float xCo = (130) * Mathf.Cos(angle);
        float yCo = (130) * Mathf.Sin(angle);
        Vector3 bossCoord = new Vector3 (xCo, 0, yCo);

        int cleanArea = 10;
        int cleanOffset = 75 - (cleanArea / 2);

        for (int y = 0; y < cleanArea; y++)
        {
            for (int x = 0; x < cleanArea; x++)
            {
                noiseMap[x + cleanOffset, y + cleanOffset] = 0.4f;
                //noiseMap[x + (int)bossCoord.x + 150, y + (int)bossCoord.z + 150] = 0.4f;
            }
        }

        GameObject boss = Instantiate(bossPrefab, new Vector3(bossCoord.x, 0, bossCoord.z), Quaternion.identity);
        //boss.transform.position = new Vector3(bossCoord.x, 0 , bossCoord.z);
        boss.transform.localScale = Vector3.one * 2;

        int enemycount = 0;

        for (int y = 0; y < size/2; y++)
        {
            for (int x = 0; x < size/2; x++)
            {
                
                float v = Random.Range(0f, prefabDensity);
                float g = Random.Range(miniPrefabDensity, 0.90f);
                float e = Random.Range(enemyPrefabDensity, 0.95f);

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
                    prop.transform.localScale = Vector3.one * Random.Range(prefabScaleMin, prefabScaleMax);
                }
                else if (noiseMap[x, y] > g)
                {
                    GameObject prefab1 = miniPrefabs[Random.Range(0, miniPrefabs.Length)];
                    GameObject prop1 = Instantiate(prefab1, new Vector3(xCoord, 0, yCoord), Quaternion.identity);
                    ActivationCheck.props.Add(prop1);
                    if (prop1.name.StartsWith("Enemy")) { enemycount++; }
                    //prop1.transform.position = new Vector3(xCoord, 0, yCoord);
                    prop1.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
                    prop1.transform.localScale = prop1.transform.lossyScale * Random.Range(miniPrefabScaleMin, miniPrefabScaleMax);
                    
                }
                /*else if (noiseMap[x, y] > e)
                {
                    GameObject prefab2 = enemyPrefabs[0];
                    GameObject prop2 = Instantiate(prefab2, new Vector3(xCoord, 0, yCoord), Quaternion.identity);
                    ActivationCheck.props.Add(prop2);
                    enemycount++;
                    //prop2.transform.position = new Vector3(xCoord, 0, yCoord);
                    prop2.transform.rotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
                    prop2.transform.localScale = prop2.transform.lossyScale * Random.Range(miniPrefabScaleMin, miniPrefabScaleMax);
                }
                */
            }
        }
        Debug.Log(enemycount);
        navMeshSurface.BuildNavMesh();

    }
}
