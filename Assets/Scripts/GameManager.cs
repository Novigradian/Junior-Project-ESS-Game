using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //public static GameManager Instance { get; private set; }

    public TileManager[] tiles;
    public TileManager.TileType selectedTileType;

    [Header("Level Stats")]
    public int maxPollution;
    public int[] tilesToPlace; //park factory house water
    
    // Start is called before the first frame update
    void Start()
    {
        selectedTileType = TileManager.TileType.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int CalculateTotalPollution()
    {
        int pollution = 0;
        foreach (TileManager tm in tiles)
        {
            pollution += tm.pollution;
        }

        return pollution;
    }

    public void ApplyTile(TileManager tm)
    {
        if (CheckTilePlacementValidity() && tm.tileType==TileManager.TileType.Neutral)
        {
            UpdateTilesToPlace();
            tm.ChangeTileType(selectedTileType);
            Debug.Log("changed tile to: " + selectedTileType);
            //selectedTileType = TileManager.TileType.None;
        }
    }

    private bool CheckTilePlacementValidity()
    {
        switch (selectedTileType)
        {
            case TileManager.TileType.None:
                return false;
            case TileManager.TileType.Factory:
                if (tilesToPlace[1] <= 0)
                {
                    return false;
                }
                break;
            case TileManager.TileType.Park:
                if (tilesToPlace[0] <= 0)
                {
                    return false;
                }
                break;
            case TileManager.TileType.House:
                if (tilesToPlace[2] <= 0)
                {
                    return false;
                }
                break;
            case TileManager.TileType.Water:
                if (tilesToPlace[3] <= 0)
                {
                    return false;
                }
                break;
        }
        return true;
    }

    private void UpdateTilesToPlace()
    {
        switch (selectedTileType)
        {
            case TileManager.TileType.Factory:
                tilesToPlace[1] -= 1;
                break;
            case TileManager.TileType.Park:
                tilesToPlace[0] -= 1;
                break;
            case TileManager.TileType.House:
                tilesToPlace[2] -= 1;
                break;
            case TileManager.TileType.Water:
                tilesToPlace[3] -= 1;
                break;
        }
    }

    public void SelectFactory()
    {
        selectedTileType = TileManager.TileType.Factory;
    }

    public void SelectPark()
    {
        selectedTileType = TileManager.TileType.Park;
    }

    public void SelectHouse()
    {
        selectedTileType = TileManager.TileType.House;
    }

    public void SelectWater()
    {
        selectedTileType = TileManager.TileType.Water;
    }
}
