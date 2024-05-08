using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerationManager : MonoBehaviour
{
    public Transform playerTransform;
    // Grid Tiers
    public GameObject[] gridTier1;
    public GameObject[] gridTier2;
    public GameObject[] gridTier3;

    public GameObject spawngridPrefab;
    public int gridSize = 5;
    public int chunkSize = 10;
    public float tileSize = 1.0f;
    public float loadDistance = 10.0f;
    public int difficultyTier = 1;

    private Vector3 lastPlayerPosition;
    private Dictionary<Vector2Int, GameObject> activeChunks = new Dictionary<Vector2Int, GameObject>();

    void Start()
    {
        lastPlayerPosition = playerTransform.position;
        UpdateChunks();
    }

    void Update()
    {
        if (Vector3.Distance(new Vector3(playerTransform.position.x, 0, playerTransform.position.z), new Vector3(lastPlayerPosition.x, transform.position.y, lastPlayerPosition.z)) > tileSize)
        {
            lastPlayerPosition = playerTransform.position;
            UpdateChunks();
        }
    }

    void UpdateChunks()
    {
        Vector2Int playerChunk = GetChunkPosition(playerTransform.position);

        List<Vector2Int> chunksToLoad = new List<Vector2Int>();

        for (int x = -gridSize; x <= gridSize; x += chunkSize)
        {
            for (int y = -gridSize; y <= gridSize; y += chunkSize)
            {
                Vector2Int chunkPos = new Vector2Int(x, y) + playerChunk;

                if (Vector2.Distance(new Vector2(chunkPos.x * tileSize, chunkPos.y * tileSize), new Vector2(playerTransform.position.x, playerTransform.position.z)) < loadDistance)
                {
                    if (!activeChunks.ContainsKey(chunkPos))
                    {
                        LoadChunk(chunkPos);
                    }
                    chunksToLoad.Add(chunkPos);
                }
                else
                {
                    if (activeChunks.ContainsKey(chunkPos))
                    {
                        UnloadChunk(chunkPos);
                    }
                }
            }
        }

        List<Vector2Int> chunksToUnload = new List<Vector2Int>(activeChunks.Keys);
        chunksToUnload.RemoveAll(chunk => chunksToLoad.Contains(chunk));
        foreach (var chunkPos in chunksToUnload)
        {
            UnloadChunk(chunkPos);
        }
    }

    Vector2Int GetChunkPosition(Vector3 position)
    {
        int x = Mathf.FloorToInt(position.x / (chunkSize * tileSize));
        int y = Mathf.FloorToInt(position.z / (chunkSize * tileSize));
        return new Vector2Int(x, y);
    }

    void LoadChunk(Vector2Int chunkPos)
    {
        GameObject chunk = new GameObject("Chunk_" + chunkPos.x + "_" + chunkPos.y);
        chunk.transform.position = new Vector3(chunkPos.x * chunkSize * tileSize, transform.position.y, chunkPos.y * chunkSize * tileSize);

        for (int x = 0; x < chunkSize; x++)
        {
            for (int z = 0; z < chunkSize; z++)
            {
                Vector3 spawnPosition = new Vector3(x * tileSize, 0, z * tileSize) + chunk.transform.position;
                int gridIndex = Random.Range(0, gridTier1.Length);
                if (chunk.transform.position == transform.position && Time.time < 10)
                {
                    Instantiate(spawngridPrefab, spawnPosition, Quaternion.identity, chunk.transform);
                }
                else
                {
                    if (difficultyTier == 1)
                    {
                        gridIndex = Random.Range(0, gridTier1.Length);
                        Instantiate(gridTier1[gridIndex], spawnPosition, Quaternion.identity, chunk.transform);
                    }
                    if (difficultyTier == 2)
                    {
                        gridIndex = Random.Range(0, gridTier2.Length);
                        Instantiate(gridTier2[gridIndex], spawnPosition, Quaternion.identity, chunk.transform);
                    }
                    if (difficultyTier >= 3)
                    {
                        gridIndex = Random.Range(0, gridTier3.Length);
                        Instantiate(gridTier3[gridIndex], spawnPosition, Quaternion.identity, chunk.transform);
                    }
                }
            }
        }

        activeChunks.Add(chunkPos, chunk);
    }

    void UnloadChunk(Vector2Int chunkPos)
    {
        if (activeChunks.TryGetValue(chunkPos, out GameObject chunk))
        {
            Destroy(chunk);
            activeChunks.Remove(chunkPos);
        }
    }
}
