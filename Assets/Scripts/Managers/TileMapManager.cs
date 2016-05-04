using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TileMapManager : MonoBehaviour 
{
	private Tile[] tiles;
	private TilesetInfos tilesetInfos;
	
	private Vector2 mapPosMin;
	private Vector2 mapPosMax;
	
	// Use this for initialization
	void Start () 
	{
		mapPosMin = mapPosMax = Vector2.zero;		
		tiles = (Tile[])GameObject.FindObjectsOfType(typeof(Tile));
		
		tilesetInfos = TilesetInfos.GetInstance();
		
		GetInitialMapBounds();
	}
	
	// Update is called once per frame
	void Update () { UpdateMap(); }
	
	/// <summary>
	/// Gets the initial map bounds.
	/// </summary>
	private void GetInitialMapBounds()
	{
		foreach(Tile tile in tiles)
		{
			if(tile.transform.localPosition.x <= mapPosMin.x)
				mapPosMin = new Vector2(tile.transform.localPosition.x, mapPosMin.y);
			else if(tile.transform.localPosition.x > mapPosMax.x)
				mapPosMax = new Vector2(tile.transform.localPosition.x, mapPosMax.y);

			if(tile.transform.localPosition.y <= mapPosMin.y)
				mapPosMin = new Vector2(mapPosMin.x, tile.transform.localPosition.y);
			else if(tile.transform.localPosition.y > mapPosMin.y)
				mapPosMax = new Vector2(mapPosMax.x, tile.transform.localPosition.y);
		}
	}
	
	/// <summary>
	/// Updates the map.
	/// </summary>
	private void UpdateMap()
	{
		if(Camera.main.transform.localPosition.x < mapPosMin.x + tilesetInfos.GetTileWidthSize() / 2)
		{
			foreach(Tile tile in tiles)
			{
				if(mapPosMax.x == tile.transform.localPosition.x)
				{
					tile.transform.localPosition = new Vector3(mapPosMin.x - tilesetInfos.GetTileWidthSize(),
																tile.transform.localPosition.y,
																tile.transform.localPosition.z);
					
				}
			}
			
			mapPosMin = new Vector2(mapPosMin.x - tilesetInfos.GetTileWidthSize(), mapPosMin.y);
			mapPosMax = new Vector2(mapPosMax.x - tilesetInfos.GetTileWidthSize(), mapPosMax.y);
		}
		else if(Camera.main.transform.localPosition.x > mapPosMax.x - tilesetInfos.GetTileWidthSize() / 2)
		{
			foreach(Tile tile in tiles)
			{
				if(mapPosMin.x == tile.transform.localPosition.x)
				{
					tile.transform.localPosition = new Vector3(mapPosMax.x + tilesetInfos.GetTileWidthSize(),
																tile.transform.localPosition.y,
																tile.transform.localPosition.z);
					
				}
			}
			
			mapPosMin = new Vector2(mapPosMin.x + tilesetInfos.GetTileWidthSize(), mapPosMin.y);
			mapPosMax = new Vector2(mapPosMax.x + tilesetInfos.GetTileWidthSize(), mapPosMax.y);
		}
		else if(Camera.main.transform.localPosition.y < mapPosMin.y + tilesetInfos.GetTileHeightSize() / 2)
		{
			foreach(Tile tile in tiles)
			{
				if(mapPosMax.y == tile.transform.localPosition.y)
				{
					tile.transform.localPosition = new Vector3(tile.transform.localPosition.x,
																mapPosMin.y - tilesetInfos.GetTileHeightSize(),
																tile.transform.localPosition.z);
					
				}
			}
			
			mapPosMin = new Vector2(mapPosMin.x, mapPosMin.y - tilesetInfos.GetTileHeightSize());
			mapPosMax = new Vector2(mapPosMax.x, mapPosMax.y - tilesetInfos.GetTileHeightSize());
		}
		else if(Camera.main.transform.localPosition.y > mapPosMax.y - tilesetInfos.GetTileHeightSize() / 2)
		{
			foreach(Tile tile in tiles)
			{
				if(mapPosMin.y == tile.transform.localPosition.y)
				{
					tile.transform.localPosition = new Vector3(tile.transform.localPosition.x,
																mapPosMax.y + tilesetInfos.GetTileHeightSize(),
																tile.transform.localPosition.z);
					
				}
			}
			
			mapPosMin = new Vector2(mapPosMin.x, mapPosMin.y + tilesetInfos.GetTileHeightSize());
			mapPosMax = new Vector2(mapPosMax.x, mapPosMax.y + tilesetInfos.GetTileHeightSize());
		}
	}
}