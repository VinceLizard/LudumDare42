using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtThis : MonoBehaviour {

    //public bool isLooking;
	public Transform lookTarget;
	public Transform[] eyesAndLids;

	public Transform root;
	public float degreesPerSecond = 240f;
	public float yRotMaxDegrees = 60f;
	public float xRotMaxDegrees = 30f;

	void LateUpdate () {

		if ( eyesAndLids != null && root != null)
		{
			foreach (Transform looker in eyesAndLids)
			{
				looker.transform.rotation = Quaternion.RotateTowards(
					looker.rotation,
					Quaternion.LookRotation(GetLookAtDirection()),
					degreesPerSecond * Time.deltaTime
				); //Quaternion.LookRotation(lookDir);
			}
		}
	}

	static float ConstrainAngle(float angle, float max)
	{
		if (angle > max)
			return max;
		else if (angle < -max)
			return -max;
		else
			return angle;
	}

	Vector3 GetLookAtDirection()
	{
		if (this.lookTarget == null)
			return root.forward;
		
		var pos = root.InverseTransformPoint(this.lookTarget.position);
		var xzPos = new Vector3(pos.x, 0, pos.z);
		var yzPos = new Vector3(0, pos.y, pos.z);

		float yRotation = ConstrainAngle(Mathf.Rad2Deg * Mathf.Atan2(pos.x, pos.z), yRotMaxDegrees);
		float xRotation = ConstrainAngle(Mathf.Rad2Deg * Mathf.Atan2(-1 * pos.y, pos.z), xRotMaxDegrees);

		var yLookAt = Quaternion.Euler(0, yRotation, 0) * Vector3.forward;
		var xLookAt = Quaternion.Euler(xRotation, 0, 0) * Vector3.forward;

		var finalLookAt = (Quaternion.Euler(xRotation, 0, 0) * Quaternion.Euler(0, yRotation, 0)) * Vector3.forward;
		finalLookAt.Normalize();

		return root.TransformDirection( finalLookAt );
	}

	/*private void OnDrawGizmos()
	{
		if(root != null && lookTarget != null)
		{
			var pos = root.InverseTransformPoint(this.lookTarget.transform.position);
			var xzPos = new Vector3(pos.x, 0, pos.z);
			var yzPos = new Vector3(0, pos.y, pos.z);

			float yRotation = ConstrainAngle( Mathf.Rad2Deg * Mathf.Atan2(pos.x,pos.z), 60f );
			float xRotation = ConstrainAngle( Mathf.Rad2Deg * Mathf.Atan2( -1*pos.y, pos.z) , 30f );

			var yLookAt = Quaternion.Euler(0, yRotation, 0) * Vector3.forward;
			var xLookAt = Quaternion.Euler(xRotation, 0, 0) * Vector3.forward;

			var finalLookAt = (Quaternion.Euler(xRotation, 0, 0) * Quaternion.Euler(0, yRotation, 0)) * Vector3.forward;
			//finalLookAt.Normalize();

			if(xzPos.z < 0)
			{
				Gizmos.color = Color.black;
			}
			else
			{
				Gizmos.color = Color.cyan;
			}

			Gizmos.DrawRay(Vector3.zero, finalLookAt);
			Gizmos.DrawWireSphere(pos, 0.6f);
			Gizmos.DrawWireSphere(finalLookAt, 0.3f);

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(xzPos, 0.25f);

			Gizmos.color = Color.red;
			Gizmos.DrawSphere(yLookAt, 0.125f);

			Gizmos.color = Color.green;
			Gizmos.DrawSphere(yzPos, 0.25f);

			Gizmos.color = Color.green;
			Gizmos.DrawSphere(xLookAt, 0.125f);

		}
	}*/
}
