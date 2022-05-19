using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    #region Variables
    #region Comment
    /*
        Comments that are multiline should
        be around this length before starting
        a new line.
     */
    #endregion
    private Bounds m_Bounds;
    private GameObject[] hidableObjects;
    #endregion

    #region Unity Triggers
    void Awake()
    {
        #region Comment
        /*
			We find all of the object called
			SUBCHUNKOBJECT and add them to an
			array and then find out what sub
			chunk they are in and finding out the
			bounds of that chunk.
         */
        #endregion

        hidableObjects = GameObject.FindGameObjectsWithTag("SubChunkObject");

        Terrain terrain = GetComponent<Terrain>();

        Vector3 dimensions = new Vector3(terrain.terrainData.heightmapResolution, 1000, terrain.terrainData.heightmapResolution);
        Vector3 pos = transform.position + new Vector3(dimensions.x / 2, 0, dimensions.z / 2);

        m_Bounds = new Bounds(pos, dimensions);
    }

    #endregion

    #region Methods

    #region Enable
    #region Comment
    /*
		For every item in the chunk and if
		it’s in said chunk than it gets set
		to active.
     */
    #endregion

    void OnEnable()
    {
        foreach (GameObject gameObject in hidableObjects)
            if (gameObject != null && m_Bounds.Contains(gameObject.transform.position))
                gameObject.SetActive(true);
    }
    #endregion

    #region Disable
    #region Comment
    /*
		For every item in the chunk and if
		it’s in said chunk than it gets set
		to not active.
     */
    #endregion

    void OnDisable()
    {
        foreach (GameObject gameObject in hidableObjects)
            if (gameObject != null && m_Bounds.Contains(gameObject.transform.position))
                gameObject.SetActive(false);
    }
    #endregion

    #endregion
}

#region Script Log

#region Creation
/*
 * This file was created on
 * DATE:	UNKNOWN
 * TIME:	UNKNOWN
 * BY:		Aaron Hamilton
 */
#endregion

#region Edit Logs
//Date: Wed, 18 May 2022 | Time: 20:00 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	Managing Large Worlds
 * By:		Gordon Stirling
 * URL: 	HNC OneNote Class
 */
#endregion
#endregion

//Uniq Studio