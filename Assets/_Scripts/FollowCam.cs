using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    static public GameObject POI; // point of interest

	[Header("Set in Inspector")]
	public float easing = 0.05f;
	public Vector3 minXY = Vector3.zero;

	[Header("Set Dynamically")]
	public float camZ; // the desired z pos of the camera

	void Awake(){
		camZ = this.transform.position.z;
	}

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate () {
		if (POI == null) return;  // make sure we know the POI
		
		Vector3 destination;
		// If there is no poi, return to P:[ 0, 0, 0 ]
		if (POI ==null ) {
		destination =Vector3.zero;
		}else {
		// Get the position of the poi
		destination = POI.transform.position;
		// If poi is a Projectile, check to see if it's at rest
		if (POI.tag == "Projectile" ) {
		// if it is sleeping (that is, not moving)
		if ( POI.GetComponent<Rigidbody>().IsSleeping() ) {
		// return to default view
		POI =null ;
		// in the next update
		return ;
		}
		}
		}
		destination.x = Mathf.Max( minXY.x, destination.x );



		// Get the position of the POI
		/*Vector3 destination = POI.transform.position;
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.x = Mathf.Max (minXY.y, destination.y);


		destination = Vector3.Lerp (transform.position, destination, easing);

		destination.z = camZ;
		// sets the camera to the destination
		transform.position = destination;

		Camera.main.orthographicSize = destination.y + 10;*/
	
	}

	// Update is called once per frame
	void Update () {
		
	}
}
