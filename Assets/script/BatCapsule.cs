using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatCapsule : MonoBehaviour
{
	[SerializeField]
	private BatCapsuleFollower _batCapsuleFollowerPrefab;
	BatCapsuleFollower batfollower;
	public Vector3 conVel;
	public Vector3 conAngularVel;
	
	private void SpawnBatCapsuleFollower()
	{
		var follower = Instantiate(_batCapsuleFollowerPrefab);
		follower.transform.position = transform.position;
		follower.SetFollowTarget(this);
	}

	private void Start()
	{
		SpawnBatCapsuleFollower();
		
	}
	/*
	private void OnTriggerEnter(Collider collider)
	{
        if (collider.tag == "ball")
        {
			conVel = batfollower.GetComponent<Rigidbody>().velocity;
			conAngularVel = batfollower.GetComponent<Rigidbody>().angularVelocity;
        }
	}*/
	void Update()
	{

		
	}

	
	/*
	private void OnCollisionExit(Collision collision)
	{
		sp.Write("b");
	}
	*/

	
}
