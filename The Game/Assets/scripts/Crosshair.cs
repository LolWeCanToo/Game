using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	
	public Texture2D crosshairTexture;
	Rect position;
	public bool showcursor=false;
	bool forward=false;
	
	// Use this for initialization
	void Start (){  
		Cursor.visible = false;
		position = new Rect(( Screen.width - crosshairTexture.width)/2,(Screen.height - crosshairTexture.height)/2,
		                    crosshairTexture.width, crosshairTexture.height);
		
	}
	
	// Update is called once per frame
	void OnGUI (){
		
		//if (showcursor)
			//Cursor.visible = true;

			GUI.DrawTexture(position, crosshairTexture);
		if(GUI.Button(new Rect(10, 10, 50, 50), "Push!"))
			
		{
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				go.AddComponent<Rigidbody>();//.transform.position += new Vector3(0.5f, 0.0f, 0.0f);
			}
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building"))
			{
				int index=0;
				foreach(GameObject go2 in GameObject.FindGameObjectsWithTag("building")) {
				//go.GetComponent<Rigidbody>().mass=0;
			    if(go!=go2)
					{
					go.AddComponent<ConfigurableJoint>();
						go.GetComponents<ConfigurableJoint>()[index].connectedBody=go2.GetComponent<Rigidbody>();//.ConnectedBody = object_B;
						go.GetComponents<ConfigurableJoint>()[index].xMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].yMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].zMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].angularXMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].angularYMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].angularZMotion=ConfigurableJointMotion.Locked;
						go.GetComponents<ConfigurableJoint>()[index].projectionAngle=0;
						go.GetComponents<ConfigurableJoint>()[index].projectionDistance=0;
						go.GetComponents<ConfigurableJoint>()[index].projectionMode=JointProjectionMode.PositionAndRotation;

					index++;
					}
			}
			}
			//print("Good job");
		}
	}
	void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)) {
			showcursor=!showcursor;
			Cursor.visible=showcursor;
			if(showcursor)Cursor.lockState=CursorLockMode.None;
			else Cursor.lockState=CursorLockMode.Locked;
		}
		if (Input.GetKeyDown (KeyCode.UpArrow))
			forward = true;
		if (Input.GetKeyUp (KeyCode.UpArrow))
			forward = false;
		if (forward) {
			foreach(GameObject go in GameObject.FindGameObjectsWithTag("building")) {
				if(go.GetComponent<MeshCollider>())
					//if(go.GetComponent<MeshCollider>().attachedRigidbody.tran
				{
					//go.AddComponent<ConstantForce>();
					if ( go.GetComponent<MeshCollider>().attachedRigidbody.velocity.magnitude < 1.0 )go.GetComponent<MeshCollider>().attachedRigidbody.AddForce(go.transform.forward * 200f);//.AddForce(go.transform.rotation.x/360*200,go.transform.rotation.y/360*200,go.transform.rotation.z/360*200);//.force=200f*go.transform.rotation.eulerAngles;
				}
			}
		}
		foreach (GameObject go in GameObject.FindGameObjectsWithTag("building")) {
			if(go.GetComponent<ConstantForce>())
			{
				//if(go.GetComponent<ConstantForce>().force.z>0)go.GetComponent<ConstantForce>().force=new Vector3(0f,0f,go.GetComponent<ConstantForce>().force.z-10);
			}
		}
	}
}