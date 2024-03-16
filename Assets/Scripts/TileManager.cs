using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TileManager : MonoBehaviour
{
    public bool isChangeable;

    public enum TileType
    {
        Neutral,
        Park,
        Water,
        PollutedWater,
        House,
        Factory,
        Road,
        None
    }

    [Header("Tile")]
    public TileType tileType;

    private GameObject neutralTile;
    private GameObject parkTile;
    private GameObject waterTile;
    private GameObject houseTile;
    private GameObject factoryTile;
    private GameObject pollutedWaterTile;

    public TileManager[] adjacentTiles;

    [Header("Pollution")]
    public int pollution;
    private TextMeshProUGUI pollutionText;
    public TMP_FontAsset orangeFont;
    public TMP_FontAsset greenFont;

    // Start is called before the first frame update
    void Start()
    {
        pollutionText = transform.GetChild(10).GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        neutralTile = transform.GetChild(0).gameObject;
        houseTile = transform.GetChild(1).gameObject;
        factoryTile = transform.GetChild(2).gameObject;
        parkTile = transform.GetChild(3).gameObject;
        waterTile = transform.GetChild(4).gameObject;
        pollutedWaterTile = transform.GetChild(5).gameObject;

        UpdateTileArt();

        pollution = 0;

    }

    // Update is called once per frame
    void Update()
    {
        CalculateAdjacentTileEffects();
        UpdateTileArt();

        if (pollution > 0)
        {
            pollutionText.text= "+"+pollution;
            pollutionText.font = orangeFont;
        }
        else if (pollution < 0)
        {
            pollutionText.text = "" + pollution;
            pollutionText.font = greenFont;
        }
        else
        {
            pollutionText.text = "";
        }
    }

    private void CalculateAdjacentTileEffects()
    {
        if (tileType != TileType.Neutral && tileType != TileType.Road)
        {
            int p = 0;
            bool alreadyWaterPolluted = false;

            foreach (TileManager tm in adjacentTiles)
            {
                switch (tm.tileType)
                {
                    case TileType.Neutral:

                        break;
                    case TileType.Park:
                        if (tileType != TileType.Water && tileType != TileType.PollutedWater)
                        {
                            p -= 1;
                        }
                        break;
                    case TileType.Water:

                        break;
                    case TileType.PollutedWater:
                        if (tileType != TileType.Water && tileType != TileType.PollutedWater)
                        {
                            if (!alreadyWaterPolluted)
                            {
                                p += 1;
                                alreadyWaterPolluted = true;
                            }
                        }
                        else
                        {
                            tileType = TileType.PollutedWater;
                        }
                        break;
                    case TileType.House:

                        break;
                    case TileType.Factory:
                        if (tileType != TileType.Water && tileType != TileType.PollutedWater)
                        {
                            p += 1;
                        }
                        else
                        {
                            tileType = TileType.PollutedWater;
                        }
                        break;
                }
            }

            if (tileType == TileType.Factory)
            {
                p += 1;
            }
            else if (tileType == TileType.Park)
            {
                p -= 1;
            }

            //Debug.Log(p);
            pollution = p;

        }

    }

    public void ChangeTileType(TileType tType)
    {
        if (isChangeable && tileType!=tType)
        {
            tileType = tType;
            UpdateTileArt();
        }
    }

    private void UpdateTileArt()
    {
        if (isChangeable)
        {
            neutralTile.SetActive(false);
            parkTile.SetActive(false);
            waterTile.SetActive(false);
            houseTile.SetActive(false);
            factoryTile.SetActive(false);
            pollutedWaterTile.SetActive(false);

            switch (tileType)
            {
                case TileType.Neutral:
                    neutralTile.SetActive(true);
                    break;
                case TileType.Park:
                    parkTile.SetActive(true);
                    break;
                case TileType.Water:
                    waterTile.SetActive(true);
                    break;
                case TileType.PollutedWater:
                    pollutedWaterTile.SetActive(true);
                    break;
                case TileType.House:
                    houseTile.SetActive(true);
                    break;
                case TileType.Factory:
                    factoryTile.SetActive(true);
                    break;
            }


        }
    }
}
