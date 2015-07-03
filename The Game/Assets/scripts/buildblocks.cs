using UnityEngine;
using System.Collections;

public class buildblocks : MonoBehaviour {
	//public GameObject pl;
	//public int numBlocks;
	//private Plane plane;
	public int sectorsamount;
	float BlockX, BlockY, BlockZ;
	float BlockXS, BlockYS, BlockZS;
	int type = 1;
	SectorsCreate sectors;
	// Use this for initialization
	Crosshair camera;
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
		camera = Camera.main.GetComponent<Crosshair> ();
		//sectors.CreateBlocks (world.transform, new Vector3 (BlockX, BlockY, BlockZ), sectorsamount);
	//	plane = (Plane)pl.GetComponent(Plane);
	}
	
	// Update is called once per frame
	void Update () {

	if (Input.GetButtonDown ("Fire1")) {
			if(!camera.showcursor)sectors.CreateBlock( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS),type);
		}
		if (Input.GetButtonDown ("Fire2")) {
			if(!camera.showcursor)sectors.DestroyBlock();
		}
		if (Input.GetButtonDown ("MoveUp")) {
			sectors.MoveBlocksUp( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("MoveDown")) {
			sectors.MoveBlocksDown( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("MoveLeft")) {
			if(gameObject.GetComponent<Terrain>())sectors.MoveBlocksLeft( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
			else if(gameObject.GetComponent<MeshFilter>())sectors.MoveBlocksLeft( new Vector3 (BlockX-BlockXS/2, BlockY-BlockYS/2, BlockZ-BlockZS/2),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("MoveRight")) {
			if(gameObject.GetComponent<Terrain>())sectors.MoveBlocksRight( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
			else if(gameObject.GetComponent<MeshFilter>())sectors.MoveBlocksRight( new Vector3 (BlockX-BlockXS/2, BlockY-BlockYS/2, BlockZ-BlockZS/2),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("MoveForward")) {
			if(gameObject.GetComponent<Terrain>())sectors.MoveBlocksForward( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
			else if(gameObject.GetComponent<MeshFilter>())sectors.MoveBlocksForward( new Vector3 (BlockX-BlockXS/2, BlockY-BlockYS/2, BlockZ-BlockZS/2),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("MoveBack")) {
			if(gameObject.GetComponent<Terrain>())sectors.MoveBlocksBack( new Vector3 (BlockX, BlockY, BlockZ),new Vector3 (BlockXS, BlockYS, BlockZS));
			else if(gameObject.GetComponent<MeshFilter>())sectors.MoveBlocksBack( new Vector3 (BlockX-BlockXS/2, BlockY-BlockYS/2, BlockZ-BlockZS/2),new Vector3 (BlockXS, BlockYS, BlockZS));
		}
		if (Input.GetButtonDown ("1")) {
			type=1;
		}
		if (Input.GetButtonDown ("2")) {
			type=2;
		}

	}
}
