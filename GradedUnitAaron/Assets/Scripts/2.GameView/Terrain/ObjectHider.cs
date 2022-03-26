using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    private Bounds m_Bounds;
    private GameObject[] hidableObjects;

    void Awake()
    {
        //Find the objects tagged with Sub Chunk Object
        hidableObjects = GameObject.FindGameObjectsWithTag("SubChunkObject");


        //Find out which Terrain its in
        Terrain terrain = GetComponent<Terrain>();

        Vector3 dimensions = new Vector3(terrain.terrainData.heightmapResolution, 1000, terrain.terrainData.heightmapResolution);
        Vector3 pos = transform.position + new Vector3(dimensions.x / 2, 0, dimensions.z / 2);

        m_Bounds = new Bounds(pos, dimensions);
    }

    void OnEnable()
    {
        foreach (GameObject gameObject in hidableObjects)
        {
            if (gameObject != null && m_Bounds.Contains(gameObject.transform.position))
            {
                gameObject.SetActive(true);
            }

        }
    }

    void OnDisable()
    {
        foreach (GameObject gameObject in hidableObjects)
        {
            if (gameObject != null && m_Bounds.Contains(gameObject.transform.position))
            {
                gameObject.SetActive(false);
            }

        }
    }
}
