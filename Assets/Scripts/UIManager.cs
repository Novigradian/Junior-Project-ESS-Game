using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    //public static UIManager Instance { get; private set; }

    public GameManager gameManager;

    public TextMeshProUGUI totalPollutionText;
    public TMP_FontAsset orangeFont;
    public TMP_FontAsset greenFont;

    public GameObject parkSelectImage;
    public GameObject factorySelectImage;
    public GameObject houseSelectImage;
    public GameObject waterSelectImage;

    public TextMeshProUGUI[] tilesToPlaceTexts;

    public GameObject VictoryPanel;

    // Start is called before the first frame update
    void Start()
    {
        VictoryPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTotalPollutionText();
        UpdateTileSelectButton();
        UpdateTilesToPlace();
    }

    private void UpdateTilesToPlace()
    {
        tilesToPlaceTexts[0].text = ""+gameManager.tilesToPlace[0];
        tilesToPlaceTexts[1].text = "" + gameManager.tilesToPlace[1];
        tilesToPlaceTexts[2].text = "" + gameManager.tilesToPlace[2];
        tilesToPlaceTexts[3].text = "" + gameManager.tilesToPlace[3];
    }
    private void UpdateTotalPollutionText()
    {
        int currentPollution = gameManager.CalculateTotalPollution();
        totalPollutionText.text = "Pollution: " + currentPollution+ "/" + gameManager.maxPollution;
        if (currentPollution> gameManager.maxPollution)
        {
            totalPollutionText.font = orangeFont;
        }
        else
        {
            totalPollutionText.font = greenFont;
        }
    }

    private void UpdateTileSelectButton()
    {
        parkSelectImage.SetActive(false);
        factorySelectImage.SetActive(false);
        houseSelectImage.SetActive(false);
        waterSelectImage.SetActive(false);

        switch (gameManager.selectedTileType)
        {
            case (TileManager.TileType.Factory):
                factorySelectImage.SetActive(true);
                break;
            case (TileManager.TileType.Park):
                parkSelectImage.SetActive(true);
                break;
            case (TileManager.TileType.House):
                houseSelectImage.SetActive(true);
                break;
            case (TileManager.TileType.Water):
                waterSelectImage.SetActive(true);
                break;
        }
    }
}
