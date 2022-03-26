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

    #region Load on start
    // Start is called before the first frame update
    void Start()
    {
        #region Chunk Loader and checker
        //Adding all chuncks in an array
        subChunks = FindObjectsOfType<Terrain>();

        //Check method CheckSubChunk every checkRate time
        InvokeRepeating("CheckSubChunk", 0.0f, checkRate);
        #endregion
    }
    #endregion

    #region Check For Sub-Chunks
    void CheckSubChunk()
    {
        Vector3 playerPos = transform.position;
        playerPos.y = 0;

       /* 
        * For every chunk it checks, it will check if the player is close to the center and will make it active
        * if the player isnt close to the chunck / not on it, it will disable it and hide the chunk
        * this will help the game be resource friendly, 
        * Possibele future update I can add render distences where lower end PCs can run it and higher end PC
        * can have more chunks loaded.
        */
        foreach (Terrain subChunk in subChunks)
        {
        Vector3 subChunkCenterPos = subChunk.transform.position + new Vector3(chunkSize / 2, 0, chunkSize / 2);

            if (Vector3.Distance(playerPos, subChunkCenterPos) > visibleDistance)
            { subChunk.gameObject.SetActive(false);}
            else
            {subChunk.gameObject.SetActive(true);}
        }
    }
    #endregion
}
