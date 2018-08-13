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

		AudioManager.Singleton.PlayNormalMusic();

		yield return CucumberScript();
		yield return TomatoScript();
		yield return PeachStrawberryScript();
		yield return BananaScript();
		yield return BroccoliScript();
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

		yield return cucumber.WalkTo(farLeftPoolSeat);
	}

	IEnumerator TomatoScript()
	{
		Stu.Singleton.ToggleThrowing(false);

		if(kidATomato == null)
			kidATomato = Spawn(cherryTomatoPrefab, gateEntrace);

		yield return kidATomato.WalkTo(rightPoolEntrance);

		yield return Dialogue.Create(kidATomato, "Cannonball!");

		yield return kidATomato.JumpTo(rightPoolSeat);

		if(kidBTomato == null)
			kidBTomato = Spawn(cherryTomatoPrefab, gateEntrace);

		yield return kidBTomato.WalkTo(rightPoolEntrance);

		kidBTomato.Face.LookAt(kidATomato);

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
        //temporary positioning
        yield return kidBTomato.JumpTo(gateEntrace, true);
        yield return kidATomato.JumpTo(gateEntrace, true);
        yield return momTomato.JumpTo(gateEntrace, true);

        if (peach == null)
            peach = Spawn(peachPrefab, lobbyEntrace);

        if (pear == null)
            pear = Spawn(pearPrefab, lobbyEntrace);

        yield return peach.JumpTo(rightPoolSeat);

        yield return pear.JumpTo(middlePoolSeat);
    }

	IEnumerator BananaScript()
	{
        if (banana == null)
            banana = Spawn(bananaPrefab, lobbyEntrace);

        yield return banana.JumpTo(leftPoolSeat);
    }

	IEnumerator BroccoliScript()
	{
        if (broccolli == null)
            broccolli = Spawn(broccolliPrefab, rightPoolEntrance);

        yield return broccolli.WalkTo(rightPoolEntrance);

        yield return Dialogue.Create(broccolli, "Oh hello, it's quite the party in here");

        yield return broccolli.JumpTo(farRightPoolSeat);

        yield return Dialogue.Create(banana, "WOOOO we love to party!!! right ladies??");

        yield return new WaitForSeconds(2f);

        yield return Dialogue.Create(peach, "I mean, I guess I would if I didn't have so much social anxiety");

        yield return Dialogue.Create(pear, "You say that, but what if you don't have social anxiety and just hate everyone you meet?");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(peach, "fair point, but that potato really puts me over the edge...");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(broccolli, "The water is nice...");

        StartCoroutine(broccolli.Expand(60f, new List<int>() { 0, 1}));

        yield return Dialogue.Create(broccolli, "woop, spoke too soon");

        StartCoroutine(cucumber.Expand(60f, new List<int>() { 0 }));

        yield return Dialogue.Create(cucumber, "Ack! us too");

        StartCoroutine(banana.Expand(60f, new List<int>() { 0 }));

        StartCoroutine(peach.Expand(60f, new List<int>() { 0 }));

        StartCoroutine(pear.Expand(60f, new List<int>() { 0 }));

        yield return broccolli.WaitTillShrunk();

        yield return cucumber.WaitTillShrunk();

        yield return banana.WaitTillShrunk();

        yield return peach.WaitTillShrunk();

        yield return pear.WaitTillShrunk();

        yield return Dialogue.Create(broccolli, "Impressive!");

    }

	IEnumerator PotatoScript()
	{
        Stu.Singleton.ToggleThrowing(false);

        if (potato == null)
			    potato = Spawn(potatoPrefab, gateEntrace);

        yield return Dialogue.Create(pear, "Oh no...");

        yield return potato.WalkTo(middlePoolEntrance);

        yield return Dialogue.Create(potato, "Hot potato comin' through!");

        yield return pear.JumpTo(leftPoolEntrance);

        yield return peach.JumpTo(rightPoolEntrance);

        yield return pear.WalkTo(lobbyEntrace);

        yield return peach.WalkTo(lobbyEntrace);

        yield return banana.JumpTo(leftPoolEntrance);
    
        yield return broccolli.JumpTo(rightPoolEntrance);

        yield return banana.WalkTo(lobbyEntrace);

        yield return broccolli.WalkTo(sideDoorEntrace);

        yield return cucumber.JumpTo(leftPoolEntrance);

        yield return cucumber.WalkTo(gateEntrace);

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
