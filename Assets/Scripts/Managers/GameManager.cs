using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Game manager.
/// </summary>
public class GameManager : MonoBehaviour 
{
	public TilesetInfos tilesetInfos;
	
	private TextAsset jsonSystemMap;
	private JSONObject jsonObject;	
	
	private GameObject tile;
	private GameObject player;
	
	// Use this for initialization
	void Awake () 
	{
		jsonSystemMap = Resources.Load("GameData/sistema1") as TextAsset;		
		jsonObject = new JSONObject(jsonSystemMap.text);
		
		tilesetInfos = TilesetInfos.GetInstance();
		tilesetInfos.SetTilesetInfos((int)jsonObject["width"].n, (int)jsonObject["height"].n,
										(int)jsonObject["tilewidth"].n, (int)jsonObject["tileheight"].n,
										(int)jsonObject["tilesets"][0]["imagewidth"].n, (int)jsonObject["tilesets"][0]["imageheight"].n,
										jsonObject["layers"][0]["data"].list, jsonObject["properties"]["sistema"].str);

		this.gameObject.AddComponent<TileMapManager>();
		
		CreateMap();
		CreatePlayer();
	}

	/// <summary>
	/// Creates the map.
	/// </summary>
	private void CreateMap()
	{
		Material atlasMap = Resources.Load("Materials/System1") as Material;
		float planeWidth = 3.0f;
		float planeHeight = 2.0f;
		
		Vector2[] meshUV = new Vector2[]{};
		int numberOfImages = (tilesetInfos.GetImageWidth() / tilesetInfos.GetTileWidth()) * 
								(tilesetInfos.GetImageHeight() / tilesetInfos.GetTileHeight());
		
		int widthTileValue = (int)tilesetInfos.GetTileWidthSize() / 2;
		
		int arrayData;
		float tileWidthPercent = (float)tilesetInfos.GetTileWidth() / tilesetInfos.GetImageWidth();
		float tileHeightPercent = (float)tilesetInfos.GetTileHeight() / tilesetInfos.GetImageHeight();
		
		for(int i = 0; i < tilesetInfos.GetTilesetWidth(); i++)
		{
			for(int j = 0; j < tilesetInfos.GetTilesetHeight(); j++)
			{
				tile = PlaneCreation.CreatePlane(atlasMap, "Tile", planeWidth, planeHeight);
				arrayData = int.Parse(tilesetInfos.GetTiles()[(i * tilesetInfos.GetTilesetHeight()) + j].ToString());
					
				if(arrayData % widthTileValue == 0)
				{
					meshUV = new Vector2[] {new Vector2((widthTileValue - 1) * tileWidthPercent, ((int)(((numberOfImages - arrayData) / widthTileValue) + 1)) * tileHeightPercent),
										    new Vector2(widthTileValue * tileWidthPercent, ((int)(((numberOfImages - arrayData) / widthTileValue)) + 1) * tileHeightPercent),
										    new Vector2(widthTileValue * tileWidthPercent, ((int)((numberOfImages - arrayData) / widthTileValue)) * tileHeightPercent),
										    new Vector2((widthTileValue - 1) * tileWidthPercent, ((int)((numberOfImages - arrayData) / widthTileValue)) * tileHeightPercent)};
				}
				else
				{	
					meshUV = new Vector2[] {new Vector2((arrayData % widthTileValue - 1) * tileWidthPercent, ((int)(((numberOfImages - arrayData) / widthTileValue) + 1)) * tileHeightPercent),
										    new Vector2((arrayData % widthTileValue) * tileWidthPercent, ((int)(((numberOfImages - arrayData) / widthTileValue)) + 1) * tileHeightPercent),
										    new Vector2((arrayData % widthTileValue) * tileWidthPercent, ((int)((numberOfImages - arrayData) / widthTileValue)) * tileHeightPercent),
										    new Vector2((arrayData % widthTileValue - 1) * tileWidthPercent, ((int)((numberOfImages - arrayData) / widthTileValue)) * tileHeightPercent)};
				}
				
				tile.GetComponent<MeshFilter>().mesh.uv = meshUV;
				tile.AddComponent<Tile>();
				tile.transform.localPosition = new Vector3((j * (planeWidth * 2)),
															-(i * (planeHeight * 2)),
															0);
			}
		}
	}
	
	/// <summary>
	/// Creates the player.
	/// </summary>
	private void CreatePlayer()
	{
		Material playerMaterial;
		
		playerMaterial = Resources.Load("Materials/Player") as Material;
		
		player = PlaneCreation.CreatePlane(playerMaterial, "Player", 0.1f, 0.1f);
		player.AddComponent<Player>();
		
		player.transform.localPosition = new Vector3(tilesetInfos.GetTileWidthSize() + tilesetInfos.GetTileWidthSize() / 2,
													 -tilesetInfos.GetTileHeightSize() - tilesetInfos.GetTileHeightSize() / 2,
													 -0.01f);
	}
}