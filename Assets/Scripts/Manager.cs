using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
	[Header("Vegetables")]
	[SerializeField] Vegetable cucumberPrefab;
	[SerializeField] Vegetable tomatoPrefab;
    [SerializeField] Vegetable cherryTomatoPrefab;
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


	Vegetable cucumber;
	Vegetable kidATomato;
	Vegetable kidBTomato;
	Vegetable momTomato;
	Vegetable peach;
	Vegetable pear;
	Vegetable banana;
	Vegetable broccolli;
	Vegetable potato;

	IEnumerator Start()
	{
		//Time.timeScale = 3f;
        /*
		yield return CucumberScript();
		yield return TomatoScript();
		yield return PeachStrawberryScript();
		yield return BananaScript();
		yield return BroccoliScript();
        */
		yield return PotatoScript();
    }


	IEnumerator CucumberScript()
	{
		Stu.Singleton.ToggleThrowing(false);

		yield return new WaitForSeconds(1f);

		if (cucumber == null)
			cucumber = Spawn(cucumberPrefab, lobbyEntrace);

		yield return cucumber.WalkTo(middlePoolEntrance);

		cucumber.Face.LookAt(Stu.Singleton);

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

		cucumber.Face.LookAt(gateEntrace);

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Looks like we've got company!", 3f);

		cucumber.Face.StopLooking();

		yield return cucumber.WalkTo(leftPoolSeat);
	}

	IEnumerator TomatoScript()
	{
		Stu.Singleton.ToggleThrowing(false);

		if(cucumber == null)
			cucumber = Spawn(cucumberPrefab, leftPoolSeat);

		if(kidATomato == null)
			kidATomato = Spawn(cherryTomatoPrefab, gateEntrace);

		yield return kidATomato.WalkTo(rightPoolEntrance);

		yield return Dialogue.Create(kidATomato, "Cannonball!");

		yield return kidATomato.JumpTo(rightPoolSeat);

		if(kidBTomato == null)
			kidBTomato = Spawn(cherryTomatoPrefab, gateEntrace);

		yield return kidBTomato.WalkTo(rightPoolEntrance);

		kidBTomato.Face.LookAt(cucumber);

		yield return Dialogue.Create(kidBTomato, "You have to wait for mom!");

		kidBTomato.Face.StopLooking();

		if(momTomato == null)
			momTomato = Spawn(tomatoPrefab, gateEntrace);

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
		yield return Dialogue.Create(momTomato, "Children! Don't be rude. That Potato is setting a bad example...");

		yield return momTomato.WaitTillShrunk();

		yield return cucumber.WaitTillShrunk();

		yield return Dialogue.Create(momTomato, "Thank you so much.");

	}

	IEnumerator PeachStrawberryScript()
	{
		yield return null;
	}

	IEnumerator BananaScript()
	{
		yield return null;
	}

	IEnumerator BroccoliScript()
	{
		yield return null;
	}

	IEnumerator PotatoScript()
	{
        Stu.Singleton.ToggleThrowing(false);

        if (potato == null)
			    potato = Spawn(potatoPrefab, gateEntrace);

        yield return potato.WalkTo(middlePoolEntrance);

        yield return Dialogue.Create(potato, "Hot potato comin' through!");

        yield return potato.JumpTo(middlePoolSeat);

        yield return Dialogue.Create(potato, "I'm not too much for you huh?");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "All these other fruits and veggies can't handle a straight shooter like me");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "I just tell it like it is, you know?");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "Like what's with that silly hand of yours? I bet you couldn't throw a syringe 3 feet..");

        Stu.Singleton.ToggleThrowing(true);

        StartCoroutine(potato.Expand(60f, new List<int>() { 0, 1, 2}));

        yield return Dialogue.Create(potato, "Uh oh... Dagnabbit! I forgot about this part!");

        yield return potato.WaitTillShrunk();

        yield return Dialogue.Create(potato, "*cough* *cough* Well... anybody could throw a syringe like that ---");

        StartCoroutine(potato.Expand(60f, new List<int>() { 0, 1, 2 })); //will make bigger

        yield return Dialogue.Create(potato, "Oh no, here comes a big one!!!");

        yield return potato.WaitTillShrunk();

        yield return Dialogue.Create(potato, "Wow, you've really got a knack for that. Thanks for saving me.");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "I really need to apologize for my behavior.");

        yield return Dialogue.Create(potato, "Ever since my wife left I've been in a downward spiral...");

        yield return Dialogue.Create(potato, "Well I'm lucky I met you. I'll let you finally relax. Have a good night!");

        yield return potato.JumpTo(middlePoolEntrance);

        yield return potato.WalkTo(gateEntrace);

    //destroy potato
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
