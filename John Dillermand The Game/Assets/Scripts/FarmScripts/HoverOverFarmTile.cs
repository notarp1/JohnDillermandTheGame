using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class HoverOverFarmTile : MonoBehaviour
{
    private Grid grid;
    [SerializeField] private Tilemap farmingTileMap = null;
    [SerializeField] private Tile dirtTile = null;
    [SerializeField] private Tile standardTile = null;
    [SerializeField] private Tile sunFlowerDirtTile = null;
    private Vector3Int previousMousePos = new Vector3Int();
    private Vector3Int currentMousePos = new Vector3Int();
    private Tile previousTile = null;
    private bool hasClicked;
    private bool canTile;
    private List<GameObject> tilesCollided = new List<GameObject>();
    public bool isHoldingHoe = false;
    public bool isHoldingSeed = false;
    public bool changedHolding = false;


    // Start is called before the first frame update
    void Start()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        hasClicked = false;
        canTile = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isHoldingHoe)
        {
            currentMousePos = getCurrentMousePos();
            if ((!currentMousePos.Equals(previousMousePos) || changedHolding) && farmingTileMap.GetTile(currentMousePos) != null && canTile)
            {
                if (!hasClicked)
                {
                    farmingTileMap.SetTile(previousMousePos, previousTile);
                }
                previousMousePos = currentMousePos;
                previousTile = (Tile)farmingTileMap.GetTile(currentMousePos);
                farmingTileMap.SetTile(currentMousePos, dirtTile);
                hasClicked = false;
                this.changedHolding = false;
            }

            if (Input.GetMouseButtonDown(0) && farmingTileMap.GetTile(currentMousePos) != null && canTile)
            {
                farmingTileMap.SetTile(currentMousePos, dirtTile);
                hasClicked = true;
            }
            if (Input.GetMouseButtonDown(1) && farmingTileMap.GetTile(currentMousePos) != null && canTile)
            {
                farmingTileMap.SetTile(currentMousePos, standardTile);
                hasClicked = true;
            }
        }

        if (isHoldingSeed)
        {
            currentMousePos = getCurrentMousePos();
            if ((!currentMousePos.Equals(previousMousePos) || changedHolding) && (farmingTileMap.GetTile(currentMousePos) == dirtTile || farmingTileMap.GetTile(currentMousePos) == sunFlowerDirtTile) && canTile)
            {
                if (!hasClicked)
                {
                    farmingTileMap.SetTile(previousMousePos, previousTile);
                }

                previousMousePos = currentMousePos;
                previousTile = (Tile)farmingTileMap.GetTile(currentMousePos);
                farmingTileMap.SetTile(currentMousePos, sunFlowerDirtTile);
                hasClicked = false;
                this.changedHolding = false;

            }

            if (Input.GetMouseButtonDown(0) && previousTile == dirtTile && canTile)
            {
                Debug.Log("CLICKED");
                farmingTileMap.SetTile(currentMousePos, sunFlowerDirtTile);
                hasClicked = true;
            }
            if (Input.GetMouseButtonDown(1) && farmingTileMap.GetTile(currentMousePos) != null && canTile)
            {
                farmingTileMap.SetTile(currentMousePos, dirtTile);
                hasClicked = true;
            }
        }
    }

    public void setHoldingHoe(bool isholding)
    {
        this.isHoldingHoe = isholding;
        this.isHoldingSeed = false;
        if (!isholding)
        {
            if (!hasClicked)
            {
                farmingTileMap.SetTile(previousMousePos, previousTile);
            }
            foreach (GameObject tiles in tilesCollided)
            {
                tilesCollided.Remove(tiles);
            }
        }
        else
        {
            changedHolding = true;
        }
    }

    public void setHoldingSeed(bool isHolding, string seedName)
    {
        this.isHoldingSeed = isHolding;
        this.isHoldingHoe = false;
        if (!isHolding)
        {
            if (!hasClicked)
            {
                farmingTileMap.SetTile(previousMousePos, previousTile);
            }
            foreach (GameObject tiles in tilesCollided)
            {
                tilesCollided.Remove(tiles);
            }
        }
        else
        {
            changedHolding = true;
        }
    }


    public Vector3Int getCurrentMousePos()
    {
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return grid.WorldToCell(mouseWorldPos);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player") && (isHoldingHoe || isHoldingSeed))
        {
            canTile = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag.Equals("Player") && (isHoldingHoe || isHoldingSeed))
        {
            tilesCollided.Remove(gameObject);
        }
        if (collider.tag.Equals("Player") && tilesCollided.Count == 0 && (isHoldingHoe || isHoldingSeed))
        {
            if (!hasClicked)
            {
                farmingTileMap.SetTile(previousMousePos, previousTile);
            }
            canTile = false;
        }
    }
}