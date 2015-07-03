using UnityEngine;
using System.Collections;

public class SectorsCreate : MonoBehaviour {
	float BlockX, BlockY, BlockZ, sectors; 
	GameObject obj;
	public GameObject obj1;
	public GameObject obj2;
	GameObject enemy;
	public void CreateSectors(Transform world, Vector3 blockworld, int sectors)
	{
		BlockX = (int)blockworld.x;
		BlockY = (int)blockworld.y;
		BlockZ = (int)blockworld.z;
		this.sectors = sectors;
		float Xpos = ((BlockX / sectors) / 2) - 0.25f;//, ypos
		for (int i=0; i<sectors; i++) {
			float Ypos = ((BlockY / sectors) / 2) - 0.25f;//, ypos
			for (int j=0; j<sectors; j++) {
				float Zpos = ((BlockZ / sectors) / 2) - 0.25f;//, ypos
				for (int k=0; k<sectors; k++) {
					/*GameObject sector = GameObject.CreatePrimitive(PrimitiveType.Sphere);
					sector.name = "" + (i+1)+"-"+(j+1)+"-"+(k+1);
					sector.transform.parent=world;
					sector.transform.position = new Vector3(Xpos,Ypos,Zpos);
*/
						Instantiate(obj, new Vector3(Xpos,Ypos,Zpos), Quaternion.identity);
					Zpos+=(BlockZ/sectors);
				}
				Ypos+=(BlockY/sectors);
			}
			Xpos+=(BlockX/sectors);
		}
	}
	public void CreateBlocks(Transform world, Vector3 blockworld, int sectors)
	{
		BlockX = (int)blockworld.x;
		BlockY = (int)blockworld.y;
		BlockZ = (int)blockworld.z;
		sectors = 1;
		float Xpos = ((BlockX / sectors) / 2);
		float Ypos = 0f+0.25f;//((BlockY / sectors) / 2) - 1;
		float Zpos = ((BlockZ / sectors) / 2);
		Instantiate(obj, new Vector3(Xpos,Ypos,Zpos), Quaternion.identity);
		for (int i = 0; i<10; i++) {
			Zpos-=0.5f;
			enemy = (GameObject)Instantiate(obj, new Vector3(Xpos,Ypos,Zpos), Quaternion.identity);
			enemy.name = "block"+nextNameNumber;
			nextNameNumber++;
			//Instantiate(obj, new Vector3(Xpos,Ypos,Zpos), Quaternion.identity);
		}
	}
	int nextNameNumber = 0;
	public bool CreateBlock(Vector3 hpos, Vector3 hsize, int type)
	{
		if (type == 1)
			obj = obj1;
		if (type == 2)
			obj = obj2;
		RaycastHit hit;
		if (Physics.Raycast (Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0)), out hit, 80)) {
			if (hit.collider.gameObject == gameObject || hit.collider.gameObject.tag=="building") 
			{
				//print(hit.collider.gameObject.tag);
				if (hit.collider.gameObject.tag=="building") {
					Vector3 pos = hit.collider.transform.position;
					pos += hit.normal / 2;
					//obj.GetComponent<Collider>().bounds.size.x/2;
					if (Vector3.Distance (this.transform.position, pos) > 0) {
						enemy = (GameObject)Instantiate (obj, pos, Quaternion.AngleAxis(90,new Vector3(0f,0f,-90f)));//Quaternion.identity);
						enemy.name = "block" + nextNameNumber;
						if(type==2)
						{
							if(hit.normal.x<0)enemy.transform.position += new Vector3((0.5f-enemy.GetComponent<Collider>().bounds.size.x)/2,0f,0f);
							else enemy.transform.position -= new Vector3((0.5f-enemy.GetComponent<Collider>().bounds.size.x)/2,0f,0f);
						}
						nextNameNumber++;
						return true;
					}
				} else {
					Vector3 pos = transform.InverseTransformPoint (hit.point);//.collider.transform.position;
					if(hit.collider.gameObject.GetComponent<MeshFilter>())
					{
						pos.y += 0.25f;
						if(pos.x<0)pos.x -= 0.25f;
						else pos.x += 0.25f;
						if(pos.z<0)pos.z -= 0.25f;
						else pos.z += 0.25f;
						float Xpos2 = (pos.x) % 0.5f;
						pos.x -= Xpos2;
						float Zpos2 = (pos.z) % 0.5f;
						pos.z -= Zpos2;
						
						pos.x += hpos.x;
						pos.y += hpos.y;
						pos.z += hpos.z;
					}
					else if(hit.collider.gameObject.GetComponent<Terrain>())
					{
					pos.y += 0.25f;
					pos.x += 0.25f;
					pos.z += 0.25f;
					float Xpos2 = (pos.x) % 0.5f;
					pos.x -= Xpos2;
					float Zpos2 = (pos.z) % 0.5f;
					pos.z -= Zpos2;

					pos.x += hpos.x;
					pos.y += hpos.y;
					pos.z += hpos.z;
					}
					//print(pos.x+";"+pos.y+";"+pos.z);
				//	print(hpos.x+";"+hpos.y+";"+hpos.z);

					if (Vector3.Distance (this.transform.position, pos) > 0) {
						enemy = (GameObject)Instantiate (obj, pos, Quaternion.identity);
						enemy.name = "block" + nextNameNumber;
						nextNameNumber++;
						return true;
					}
				}
			}
		}
		return false;
	}
	public bool MoveBlocksUp(Vector3 hpos, Vector3 hsize)
	{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			//go.GetComponent<TowerController>().upgradeTowerProgress = false;    
			go.transform.position += new Vector3(0.0f, 0.5f, 0.0f);;    
		}
		return true;
	}
	public bool MoveBlocksDown(Vector3 hpos, Vector3 hsize)
	{
		bool canmove = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.transform.position.y < hpos.y+0.5)canmove=false;
		}
		if(canmove)
		{
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			go.transform.position -= new Vector3(0.0f, 0.5f, 0.0f);    
		}
			return true;
		}
		return false;
	}
	public bool MoveBlocksLeft(Vector3 hpos, Vector3 hsize)
	{
		bool canmove = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.transform.position.x <= hpos.x+0.5)canmove=false;
		} 
		if(canmove)
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				go.transform.position -= new Vector3(0.5f, 0.0f, 0.0f);
			}
			return true;
		}
		return false;
	}
	public bool MoveBlocksRight(Vector3 hpos, Vector3 hsize)
	{
		bool canmove = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.transform.position.x >= hpos.x+hsize.x-0.5)canmove=false;
		} 
		if(canmove)
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				go.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
			}
			return true;
		}
		return false;
	}
	public bool MoveBlocksForward(Vector3 hpos, Vector3 hsize)
	{
		bool canmove = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.transform.position.z >= hpos.z+hsize.z-0.5)canmove=false;
		} 
		if(canmove)
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				go.transform.position += new Vector3(0.0f, 0.0f, 0.5f);
			}
			return true;
		}
		return false;
	}
	public bool MoveBlocksBack(Vector3 hpos, Vector3 hsize)
	{
		bool canmove = true;
		foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.transform.position.z <= hpos.z+0.5)canmove=false;
		} 
		if(canmove)
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				go.transform.position -= new Vector3(0.0f, 0.0f, 0.5f);
			}
			return true;
		}
		return false;
	}
		public bool DestroyBlock()
		{
			RaycastHit hit;
			if (Physics.Raycast (Camera.main.ScreenPointToRay (new Vector3 (Screen.width / 2, Screen.height / 2, 0)), out hit, 80)) {
			if(hit.collider.gameObject!=gameObject)Destroy(hit.collider.gameObject);
			}
		return false;
		}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
