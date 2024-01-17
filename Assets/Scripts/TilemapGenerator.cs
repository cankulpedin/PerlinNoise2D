using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    private int width = 32;
    private int height = 32;

    private float magnification = 15.0f;

    private Vector3 startPos = Vector3.zero;

    public Tilemap tileMap;

    public List<Tile> grassTiles = new List<Tile>();
    public List<Tile> stoneTiles = new List<Tile>();
    public List<Tile> interiorTiles = new List<Tile>();


    Hashtable tileLocations;

    Dictionary<int, List<Tile>> dict = new Dictionary<int, List<Tile>>();

    public GameObject player;

    private int XPlayerMove => (int)(player.transform.position.x - startPos.x);
    private int YPlayerMove => (int)(player.transform.position.y - startPos.y);

    private int XPlayerLocation => (int)Mathf.Floor(player.transform.position.x);
    private int YPlayerLocation => (int)Mathf.Floor(player.transform.position.y);

    private void Start()
    {
        dict.Add(0,grassTiles); 
        dict.Add(1,stoneTiles);
        dict.Add(2,interiorTiles);
        tileLocations = new Hashtable();
        GenerateTerrain();
    }

    private void Update()
    {
        if (Mathf.Abs(XPlayerMove) >= 1 || Mathf.Abs(YPlayerMove) >= 1)
        {
            GenerateTerrain();
        }
    }

    private int GenerateNoise(float x, float y)
    {
        float xCoord = x / magnification;
        float yCoord = y / magnification;

        float noise = Mathf.PerlinNoise(xCoord, yCoord);
        float clampNoise = Mathf.Clamp(noise, 0.0f, 1.0f);
        int scaleNoise = Mathf.FloorToInt(clampNoise * 3);

        if (scaleNoise > 2)
        {
            scaleNoise = 2;
        }

        return scaleNoise;
    }


    private void GenerateTerrain()
    {
        for (int i = -width; i < width; i++)
        {
            for (int j = -height; j < height; j++)
            {
                int noise = GenerateNoise(i + XPlayerLocation, j + YPlayerLocation);

                List<Tile> selectedTileSet = dict[noise];
                int randomIndex = Random.Range(0, selectedTileSet.Count);

                Vector3Int tileLocation = new Vector3Int(i + XPlayerLocation, j + YPlayerLocation);


                if (!tileLocations.ContainsKey(tileLocation))
                {
                    Tile selectedTile = selectedTileSet[randomIndex];

                    tileLocations.Add(tileLocation, selectedTile);

                    tileMap.SetTile(tileLocation, selectedTile);
                }
            }
        }
    }
}
