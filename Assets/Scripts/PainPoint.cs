using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class PainPoint : MonoBehaviour 
{
	private static GameObject painModelPrefab;

	[SerializeField] SphereCollider sphereCollider;

	int _painAmount = 0;
	public int PainAmount
	{
		get
		{
			return _painAmount;
		}
		set
		{
			
			_painAmount = Mathf.Max(value, 0);
			painModel.GetComponent<BobRotate>().scaleSpeed = _painAmount;
			this.gameObject.SetActive(_painAmount > 0);
		}
	}
	private GameObject painModel;



	private void Awake()
	{
		if (painModelPrefab == null)
			painModelPrefab = Resources.Load("PainPointModel") as GameObject;

		painModel = GameObject.Instantiate(painModelPrefab, this.transform);
		this.PainAmount = 0;
	}

	public void AddPain()
	{
		PainAmount += 1;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Syringe"))
		{
			PainAmount -= 1;
			if(PainAmount <= 0)
			{
				StickSyringe(other);
				PainAmount = 0;
			}
		}
	}

	void StickSyringe(Collider syringe)
	{
		syringe.gameObject.GetComponent<OrientToVelocity>().enabled = false;
		var rb = syringe.gameObject.GetComponent<Rigidbody>();
		rb.isKinematic = true;
		syringe.enabled = false;


		var painPoint = this.transform;

		var dir = (painPoint.parent.position - painPoint.position);
		dir.y = 0f;
		dir.Normalize();
		dir.y = Random.Range(-0.25f, 0.25f);
		dir.Normalize();

		syringe.transform.position = painPoint.position + (dir * -0.35f);
		syringe.transform.forward = dir;
		syringe.transform.SetParent(painPoint.parent, true);

		GameObject.Destroy(syringe.gameObject, 4f);
	}

	private void OnDrawGizmos()
	{
		Color color = Color.red;
		color.a = 0.5f;
		Gizmos.color = color;

		if(sphereCollider != null)
			Gizmos.DrawSphere(this.transform.position, sphereCollider.radius);
	}
}
