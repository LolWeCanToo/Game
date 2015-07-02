using UnityEngine;
using System.Collections;

public class buildblocks : MonoBehaviour {
	//public GameObject pl;
	//public int numBlocks;
	//private Plane plane;
	public int sectorsamount;
	float BlockX, BlockY, BlockZ;
	float BlockXS, BlockYS, BlockZS;
	SectorsCreate sectors;
	// Use this for initialization
	void Start () {
		/*BlockX = (int)Terrain.activeTerrain.terrainData.size.x;
		BlockY = (int)Terrain.activeTerrain.terrainData.size.y;
		BlockZ = (int)Terrain.activeTerrain.terrainData.size.z;*/
		BlockXS = (float)gameObject.GetComponent<Collider>().bounds.size.x;
		BlockYS = (float)gameObject.GetComponent<Collider>().bounds.size.y;
		BlockZS = (float)gameObject.GetComponent<Collider>().bounds.size.z;
		BlockX = (float)gameObject.transform.position.x;
		BlockY = (float)gameObject.transform.position.y;
		BlockZ = (float)gameObject.transform.position.z;
		//print(BlockX+";"+BlockY+";"+BlockZ);
		sectors = gameObject.GetComponent<SectorsCreate> ();
		//sectors.CreateBlocks (world.transform, new Vector3 (BlockX, BlockY, BlockZ), sectorsamount);
	//	plane = (Plane)pl.GetComponent(Plane);
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetButtonDown ("Fire1")) {
			sectors.CreateBlock( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("Fire2")) {
			sectors.DestroyBlock();
		}
	}
}
