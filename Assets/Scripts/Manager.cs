using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
	[Header("Vegetables")]
	[SerializeField] Vegetable cucumberPrefab;

	[Header("Entrances")]
	[SerializeField] Transform gateEntrace;
	[SerializeField] Transform lobbyEntrace;
	[SerializeField] Transform sideDoorEntrace;

	[Header("Pool Entrances")]
	[SerializeField] Transform leftPoolEntrance;
	[SerializeField] Transform middlePoolEntrance;
	[SerializeField] Transform rightPoolEntrance;

	[Header("Pool Seats")]
	[SerializeField] Transform farLeftPoolSeat;
	[SerializeField] Transform leftPoolSeat;
	[SerializeField] Transform middlePoolSeat;
	[SerializeField] Transform rightPoolSeat;
	[SerializeField] Transform farRightPoolSeat;

	private IEnumerator Start()
	{

		yield return new WaitForSeconds(1f);

		var cucumber = Spawn(cucumberPrefab, gateEntrace);


		yield return cucumber.WalkTo(middlePoolEntrance);

		yield return new WaitForSeconds(2f);

		yield return cucumber.JumpTo(middlePoolSeat);

	}

	Vegetable Spawn( Vegetable prefab, Transform spawnAt )
	{
		return GameObject.Instantiate(prefab, spawnAt.transform.position, spawnAt.transform.rotation);
	}

	private void OnDrawGizmos()
	{
		GizmosDrawTransform(gateEntrace,Color.red);
		GizmosDrawTransform(lobbyEntrace, Color.red);
		GizmosDrawTransform(sideDoorEntrace, Color.red);

		GizmosDrawTransform(leftPoolEntrance, Color.yellow);
		GizmosDrawTransform(middlePoolEntrance, Color.yellow);
		GizmosDrawTransform(rightPoolEntrance, Color.yellow);

		GizmosDrawTransform(farLeftPoolSeat,Color.green);
		GizmosDrawTransform(leftPoolSeat, Color.green);
		GizmosDrawTransform(middlePoolSeat, Color.green);
		GizmosDrawTransform(rightPoolSeat, Color.green);
		GizmosDrawTransform(farRightPoolSeat, Color.green);
	}

	void GizmosDrawTransform(Transform t, Color color)
	{
		if(t != null)
		{
			Gizmos.color = color;
			Gizmos.DrawWireSphere(t.position, 0.5f);
		}
	}
}
