using UnityEngine;
using System.Collections;

public class TilesetInfos
{
	private int tilesetWidth;
	private int tilesetHeight;
	private int tileWidth;
	private int tileHeight;
	private int imageWidth;
	private int imageHeight;
	private ArrayList tiles;
	private string systemName;
	private float tileWidthSize;
	private float tileHeightSize;
	
	private static TilesetInfos instance;

	private TilesetInfos()
	{}
	
	public static TilesetInfos GetInstance()
   	{
		if (instance == null) instance = new TilesetInfos();

		return instance;
	}
	
	public int GetTilesetWidth() { return tilesetWidth; }
	public int GetTilesetHeight() { return tilesetHeight; }
	public int GetTileWidth() { return tileWidth; }
	public int GetTileHeight() { return tileHeight; }
	public int GetImageWidth() { return imageWidth;}
	public int GetImageHeight() { return imageHeight; }
	public ArrayList GetTiles() { return tiles; }	
	public string GetSystemName() { return systemName; }
	public float GetTileWidthSize() { return tileWidthSize; }
	public float GetTileHeightSize() { return tileHeightSize; }

   	public void SetTilesetInfos(int tilesetWidth, int tilesetHeight, int tileWidth, int tileHeight, 
								int imageWidth, int imageHeight, ArrayList tiles, string systemName)
	{
		this.tilesetWidth = tilesetWidth;
		this.tilesetHeight = tilesetHeight;
		this.tileWidth = tileWidth;
		this.tileHeight = tileHeight;
		this.imageWidth = imageWidth;
		this.imageHeight = imageHeight;
		this.tiles = tiles;
		this.systemName = systemName;
		this.tileWidthSize = (imageWidth / tileWidth) * 2;
		this.tileHeightSize = (imageHeight / tileHeight) * 2;
	}
}