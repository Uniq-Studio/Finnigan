using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkLoader : MonoBehaviour
{
    #region Variables

    private Terrain[] subChunks;

    public int chunkSize;
    public float visibleDistance;
    public float checkRate;

    #endregion

    #region Unity Triggers

    void Start()
    {
        #region Comment

        /*
			Adding all chunks to the array.
         */

        #endregion

        subChunks = FindObjectsOfType<Terrain>();
        InvokeRepeating("CheckSubChunk", 0.0f, checkRate);
    }

    #endregion

    #region Methods

    #region Check Sub Chunk

    #region Comment
    /*
		For every chunk it checks, it will 
		check if the player is close to the
		canter and will make it active if the
		player isn’t close to the chuck / not
		on it, it will disable it and hide
		the chunk this will help the game be
		resource friendly, Possible future
		update I can add render distances
		where lower end PCs can run it and
		higher end PC can have more chunks
		loaded.
     */
    #endregion

    void CheckSubChunk()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0;

        foreach (Terrain subChunk in subChunks)
        {
            Vector3 subChunkCenterPos = subChunk.transform.position + new Vector3(chunkSize / 2, 0, chunkSize / 2);

            if (Vector3.Distance(playerPos, subChunkCenterPos) > visibleDistance)
                subChunk.gameObject.SetActive(false);
            else
                subChunk.gameObject.SetActive(true);
        }

        

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
//Date: Wed, 18 May 2022 | Time: 14:20 | Edit by: Aaron Hamilton
#endregion

#region Sources
/* Title:	Inventory System
 * By:		Gordon Stirling
 * URL: 	HNC Class OneNote 
 */
#endregion
#endregion

//Uniq Studio