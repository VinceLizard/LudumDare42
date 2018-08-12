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
		Debug.Log("Direct HIT");
		PainAmount -= 1;
		if(PainAmount <= 0)
		{
			PainAmount = 0;
		}
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
