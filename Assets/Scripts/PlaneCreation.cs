using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlaneCreation
{
	private static Mesh mesh;
	
	/*public static List<GameObject> CreatePlane(int numberOfPlanes, Material m, string planeName, float width = 1.0f, float height = 1.0f)
	{
		GameObject plane;
		List<GameObject> planes = new List<GameObject>();
		
		for(int i = 0; i < numberOfPlanes; i++)
		{		
			plane = new GameObject(planeName, typeof(MeshRenderer), typeof(MeshFilter));
			plane.GetComponent<MeshFilter>().mesh = CreateMesh(width, height);
			plane.GetComponent<MeshRenderer>().material = m;
			
			planes.Add(plane);
		}
		
		return planes;
	}*/
	
	/// <summary>
	/// Creates the plane.
	/// </summary>
	/// <returns>
	/// The plane.
	/// </returns>
	/// <param name='m'>
	/// The material of the plane.
	/// </param>
	/// <param name='planeName'>
	/// Plane name.
	/// </param>
	/// <param name='width'>
	/// Width.
	/// </param>
	/// <param name='height'>
	/// Height.
	/// </param>
	public static GameObject CreatePlane(Material m, string planeName, float width = 1.0f, float height = 1.0f)
	{
		GameObject plane;
		
		plane = new GameObject(planeName, typeof(MeshRenderer), typeof(MeshFilter));
		plane.GetComponent<MeshFilter>().mesh = CreateMesh(width, height);
		plane.GetComponent<MeshRenderer>().material = m;
		
		return plane;
	}
	
	/// <summary>
	/// Creates the mesh.
	/// </summary>
	/// <returns>
	/// The mesh.
	/// </returns>
	/// <param name='width'>
	/// Width.
	/// </param>
	/// <param name='height'>
	/// Height.
	/// </param>
	private static Mesh CreateMesh(float width = 1.0f, float height = 1.0f)
	{
		mesh = new Mesh();
		mesh.name = "Mesh";
		mesh.vertices = new Vector3[] {new Vector3(-width, height, 0),     // 0----1
										new Vector3(width, height, 0),     // ||||||
										new Vector3(width, -height, 0),    // ||||||
										new Vector3(-width, -height, 0)};  // 3----2
		
			
		mesh.uv = new Vector2[] {Vector2.up, Vector2.one, Vector2.right, Vector2.zero};
		mesh.triangles = new int[] {0, 1, 2,
									0, 2, 3};
			
		mesh.RecalculateNormals();
		
		return mesh;
	}
}