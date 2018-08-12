using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
	[Header("Vegetables")]
	[SerializeField] Vegetable cucumberPrefab;
	[SerializeField] Vegetable tomatoPrefab;
	[SerializeField] Vegetable peachPrefab;
	[SerializeField] Vegetable pearPrefab;
	[SerializeField] Vegetable bananaPrefab;
	[SerializeField] Vegetable broccolliPrefab;
	[SerializeField] Vegetable potatoPrefab;

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

	void Start()
	{
		//Time.timeScale = 3f;
		//StartCoroutine(CucumberScript());

        //StartCoroutine(BananaScript());

        StartCoroutine(TomatoScript());
    }

	IEnumerator BananaScript()
	{
		yield return null;
	}

    IEnumerator TomatoScript()
    {
        Stu.Singleton.ToggleThrowing(false);

        var cucumber = Spawn(cucumberPrefab, leftPoolSeat);

        var kidATomato = Spawn(cucumberPrefab, gateEntrace);

        yield return kidATomato.WalkTo(rightPoolEntrance);

        yield return Dialogue.Create(kidATomato, "Cannonball!");

        yield return kidATomato.JumpTo(rightPoolSeat);

        var kidBTomato = Spawn(cucumberPrefab, gateEntrace);

        yield return kidBTomato.WalkTo(rightPoolEntrance);

        yield return Dialogue.Create(kidBTomato, "You have to wait for mom!");

        var momTomato = Spawn(cucumberPrefab, gateEntrace);

        yield return momTomato.WalkTo(middlePoolEntrance);

        yield return Dialogue.Create(momTomato, "Bobby, there are other people in the hottub.");

        yield return Dialogue.Create(cucumber, "It's fine. Hop on in.");

        yield return momTomato.JumpTo(middlePoolSeat);

        yield return kidBTomato.JumpTo(farRightPoolSeat);

        yield return Dialogue.Create(kidBTomato, "It's too hot!");

        yield return kidBTomato.TurnTo(farRightPoolSeat.rotation, true);

        yield return kidBTomato.JumpTo(rightPoolEntrance, true);

        yield return kidBTomato.TurnTo(rightPoolEntrance.rotation, false);

        yield return Dialogue.Create(momTomato, "It feels so good. Oh my!");

        StartCoroutine(momTomato.Expand(60f, new List<int>() { 0, 1 }));

        yield return Dialogue.Create(cucumber, "Here we go. Stu, can you help?");

        Stu.Singleton.ToggleThrowing(true);

        StartCoroutine(cucumber.Expand(60f, new List<int>() { 0, 1 }));

        yield return Dialogue.Create(kidATomato, "Mom looks like an elephant!");
        yield return Dialogue.Create(kidBTomato, "Whoah, Mom is bigger than Jupiter!");
        yield return Dialogue.Create(momTomato, "Children! Don't be rude.");

        yield return momTomato.WaitTillShrunk();

        yield return cucumber.WaitTillShrunk();

        yield return Dialogue.Create(momTomato, "Thank you so much.");

    }

	IEnumerator CucumberScript()
	{
		Stu.Singleton.ToggleThrowing(false);

		yield return new WaitForSeconds(1f);

		var cucumber = Spawn(cucumberPrefab, gateEntrace);

		yield return cucumber.WalkTo(middlePoolEntrance);

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Hey there!");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "How's the water?");

		yield return new WaitForSeconds(1f);

		yield return cucumber.JumpTo(middlePoolSeat);

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "I'm Paul. What's your name?");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Stu, huh?");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Oh man Stu, I'm getting a little puffy in here.");

		StartCoroutine(cucumber.Expand(30f, new List<int>() { 0 }));

		yield return new WaitForSeconds(1f);

		StartCoroutine(Dialogue.Create(cucumber, "Toss me some saline solution will ya?"));

		yield return new WaitForSeconds(1f);

		Stu.Singleton.ToggleThrowing(true);

		yield return cucumber.WaitTillShrunk();

		yield return Dialogue.Create(cucumber, "Oh god, thanks. That felt great!");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Catch you later Stu!", 3f);

		yield return cucumber.TurnTo(middlePoolSeat.rotation, true);
		yield return cucumber.JumpTo(middlePoolEntrance, true);

		yield return cucumber.WalkTo(lobbyEntrace, true);

		GameObject.Destroy(cucumber.gameObject);
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
			color.a = 0.5f;
			Gizmos.color = color;
			Gizmos.DrawSphere(t.position, 0.25f);
			Gizmos.DrawRay(t.transform.position + new Vector3(0,0.1f,0), t.forward);
		}
	}
}
