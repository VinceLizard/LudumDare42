using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour 
{
    static int currentScene = 0;

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

        if(currentScene == 0)
		{
			yield return CucumberScript();
			currentScene++;
		}

		if (currentScene == 1)
		{
			yield return TomatoScript(); 
			currentScene++;
		}

		if (currentScene == 2)
		{
			yield return PeachStrawberryScript();
			currentScene++;
		}

		if (currentScene == 3)
		{
			yield return BananaScript();
			currentScene++;
		}

		if (currentScene == 4)
		{
			yield return BroccoliScript();
			currentScene++;
		}

		if (currentScene == 5)
		{
			yield return PotatoScript();
			currentScene++;
		}

		yield return null;
		UI.Singleton.ShowFinished();
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

		yield return Dialogue.Create(cucumber, "How's the water?");

		yield return new WaitForSeconds(1f);

		yield return cucumber.JumpTo(middlePoolSeat);

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "I'm Paul. What's your name?");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Stu, huh?");

		yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(cucumber, "Oh man Stu... This is embarrassing, but I'm swelling up");

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

		yield return Dialogue.Create(cucumber, "Looks like we've got company", 3f);

		cucumber.Face.StopLooking();

		yield return cucumber.WalkTo(leftPoolSeat);
	}

	IEnumerator TomatoScript()
	{

        Stu.Singleton.ToggleThrowing(false);

        if (cucumber == null)
                cucumber = Spawn(cucumberPrefab, leftPoolSeat);

		if(kidATomato == null)
			kidATomato = Spawn(cherryTomatoPrefab, gateEntrace);

        StartCoroutine(kidATomato.WalkTo(rightPoolEntrance));

        if (kidBTomato == null)
            kidBTomato = Spawn(cherryTomatoPrefab, gateEntrace);

        yield return Dialogue.Create(kidATomato, "CANNONBALL!");

        StartCoroutine(kidATomato.JumpTo(rightPoolSeat));

        StartCoroutine(kidBTomato.WalkTo(rightPoolEntrance));

		kidBTomato.Face.LookAt(kidATomato);

		yield return Dialogue.Create(kidBTomato, "YOU HAVE TO WAIT FOR MOM!");

		if(momTomato == null)
			momTomato = Spawn(tomatoPrefab, gateEntrace);

        kidBTomato.Face.LookAt(momTomato);

        StartCoroutine(momTomato.WalkTo(middlePoolEntrance));

		yield return Dialogue.Create(momTomato, "Bobby, there are other people in the hottub");

		yield return Dialogue.Create(cucumber, "It's fine. Hop on in");

        StartCoroutine(momTomato.JumpTo(middlePoolSeat));

        kidBTomato.Face.StopLooking();

        yield return kidBTomato.JumpTo(farRightPoolSeat);

		yield return Dialogue.Create(kidBTomato, "Ahhh HOT!");

        StartCoroutine(Dialogue.Create(kidATomato, "It's a hot tub dummy!"));

		yield return kidBTomato.TurnTo(farRightPoolSeat.rotation, true);

		yield return kidBTomato.JumpTo(rightPoolEntrance, true);

		yield return kidBTomato.TurnTo(rightPoolEntrance.rotation, false);

		yield return Dialogue.Create(momTomato, "It feels so good. Oh my!");

		StartCoroutine(momTomato.Expand(60f, new List<int>() { 0, 1 }));

		yield return Dialogue.Create(cucumber, "We're swelling again. Stu, can you help?");

		Stu.Singleton.ToggleThrowing(true);

		StartCoroutine(cucumber.Expand(60f, new List<int>() { 0, 1 }));

		yield return Dialogue.Create(kidATomato, "Mom looks like an elephant!");

		yield return Dialogue.Create(kidBTomato, "Whoah, Mom is bigger than Jupiter!");

        yield return new WaitForSeconds(1f);

		yield return Dialogue.Create(momTomato, "Children! Don't be rude");

		yield return momTomato.WaitTillShrunk();

		yield return cucumber.WaitTillShrunk();

		yield return Dialogue.Create(momTomato, "Thank you so much");

        Stu.Singleton.ToggleThrowing(false);

        yield return Dialogue.Create(momTomato, "I think that's enough for us");

        StartCoroutine(kidBTomato.WalkTo(gateEntrace));    

        momTomato.Face.LookAt(kidATomato);

        yield return Dialogue.Create(momTomato, "You two need to stop acting like that potato");

        GameObject.Destroy(kidBTomato.gameObject);

        momTomato.Face.StopLooking();

        StartCoroutine(kidATomato.JumpTo(rightPoolEntrance));

        yield return momTomato.JumpTo(middlePoolEntrance);

        StartCoroutine(kidATomato.WalkTo(gateEntrace));

        yield return momTomato.JumpTo(middlePoolEntrance);

        yield return momTomato.WalkTo(gateEntrace);

        GameObject.Destroy(momTomato.gameObject);
        GameObject.Destroy(kidATomato.gameObject);

    }

	IEnumerator PeachStrawberryScript()
	{
        Stu.Singleton.ToggleThrowing(false);

        if (cucumber == null)
            cucumber = Spawn(cucumberPrefab, leftPoolSeat);

        if (peach == null)
                peach = Spawn(peachPrefab, lobbyEntrace);

		StartCoroutinePending(peach.WalkTo(rightPoolEntrance));

        yield return new WaitForSeconds(.5f);

        StartCoroutine(Dialogue.Create(peach, "Can you believe the nerve of that guy?"));
   
        yield return new WaitForSeconds(.5f);

        cucumber.Face.LookAt(peach);
    
        if (pear == null)
            pear = Spawn(pearPrefab, lobbyEntrace);

		StartCoroutinePending(pear.WalkTo(middlePoolEntrance));

        yield return new WaitForSeconds(4f);

		StartCoroutinePending(Dialogue.Create(pear, "Seriously, he's just a spin instructor."));

		yield return WaitForPending();

		yield return new WaitForSeconds(1f);

        yield return peach.JumpTo(rightPoolSeat);

        yield return pear.JumpTo(middlePoolSeat);

		yield return new WaitForSeconds(2f);

        yield return Dialogue.Create(cucumber, "Hey, how you ladies doing today?");

		yield return new WaitForSeconds(0.5f);

		peach.Face.LookAt(farRightPoolSeat);
		yield return Dialogue.Create(peach, "Ugh ...");

        pear.Face.LookAt(cucumber);

		yield return Dialogue.Create(pear, "Pretty good, what about you?");

		cucumber.Face.LookAt(pear);

		yield return Dialogue.Create(cucumber, "Great, I'm enjoying all these bubbles!");

		yield return Dialogue.Create(pear, "Oh, I bet you are!");

		peach.Face.LookAt(pear);

		pear.Face.LookAt(peach);
		yield return Dialogue.Create(peach, "Linda, don't encourage him.");

		yield return new WaitForSeconds(0.5f);
		pear.Face.LookAt(peach);
		yield return Dialogue.Create(pear, "What, he's kinda cute.");

		peach.Face.StopLooking();
		yield return Dialogue.Create(peach, "Whatever.");

		// expansion begins
		StartCoroutine(cucumber.Expand(60f, new List<int>() { 0 }));

		StartCoroutine(peach.Expand(60f, new List<int>() { 0 }));

		StartCoroutine(pear.Expand(60f, new List<int>() { 0 }));

		Stu.Singleton.ToggleThrowing(true);

		peach.Face.StopLooking();
		pear.Face.StopLooking();
		cucumber.Face.StopLooking();

		yield return new WaitForSeconds(3f);

		cucumber.Face.LookAt(pear);

		yield return Dialogue.Create(cucumber, "You guys on business or vacation?");

		pear.Face.LookAt(cucumber);

		yield return Dialogue.Create(pear, "We're here for a wedding.");

		yield return Dialogue.Create(cucumber, "Nice, I love weddings, they're so much fun.");

		peach.Face.LookAt(cucumber);

		yield return Dialogue.Create(peach, "I'm the maid of honor.");

		cucumber.Face.LookAt(peach);

		yield return Dialogue.Create(cucumber, "Ok ...~~ that's cool I guess.");

		cucumber.Face.StopLooking();
		peach.Face.StopLooking();
		pear.Face.StopLooking();

		yield return cucumber.WaitTillShrunk();

		yield return peach.WaitTillShrunk();

		yield return pear.WaitTillShrunk();

        yield return new WaitForSeconds(3f);
    }

	IEnumerator BananaScript()
	{
        Stu.Singleton.ToggleThrowing(false);

        if (cucumber == null)
            cucumber = Spawn(cucumberPrefab, leftPoolSeat);

        if (peach == null)
            peach = Spawn(peachPrefab, rightPoolSeat);

        if (pear == null)
            pear = Spawn(pearPrefab, middlePoolSeat);

        if (banana == null)
            banana = Spawn(bananaPrefab, sideDoorEntrace);

        StartCoroutine(Dialogue.Create(banana, "I don't think you guys are ready for this!"));

        yield return banana.WalkTo(leftPoolEntrance);

        peach.Face.StopLooking();

        pear.Face.StopLooking();

        StartCoroutine(Dialogue.Create(cucumber, "I'm not"));

        yield return cucumber.WalkTo(farLeftPoolSeat);

        yield return new WaitForSeconds(2f);

        yield return Dialogue.Create(banana, "I'm gonna send it!");

        yield return banana.JumpTo(leftPoolSeat);

        yield return new WaitForSeconds(.5f);

        StartCoroutine(Dialogue.Create(banana, "WOO! THAT'S HOT"));

        yield return new WaitForSeconds(3f);

        pear.Face.LookAt(peach);

        peach.Face.LookAt(pear);

    }

	IEnumerator BroccoliScript()
	{

        Stu.Singleton.ToggleThrowing(false);

        if (cucumber == null)
            cucumber = Spawn(cucumberPrefab, farLeftPoolSeat);

        if (peach == null)
            peach = Spawn(peachPrefab, rightPoolSeat);

        if (pear == null)
            pear = Spawn(pearPrefab, middlePoolSeat);

        if (banana == null)
            banana = Spawn(bananaPrefab, leftPoolSeat);

        yield return new WaitForSeconds(2f);

        peach.Face.LookAt(pear);

        yield return new WaitForSeconds(1f);

        peach.Face.StopLooking();

        pear.Face.StopLooking();

        if (broccolli == null)
                broccolli = Spawn(broccolliPrefab, gateEntrace);

        yield return broccolli.WalkTo(rightPoolEntrance);

        yield return Dialogue.Create(broccolli, "Oh hello, it's quite the party in here");

        yield return broccolli.JumpTo(farRightPoolSeat);

        yield return Dialogue.Create(banana, "WOOOO! we love to party!!! right ladies??");

        yield return new WaitForSeconds(2f);

        yield return Dialogue.Create(peach, "Oh great, now there's more of them.");

        pear.Face.LookAt(peach);

        yield return new WaitForSeconds(1f);

		pear.Face.LookAt(banana);
        yield return Dialogue.Create(pear, "I don't know, you guys be too crazy for us.");
		pear.Face.LookAt(peach);

        yield return new WaitForSeconds(1.5f);

		peach.Face.LookAt(pear);
        yield return Dialogue.Create(peach, "Omg, you're so bad - hahaha.");

		peach.Face.StopLooking();
		pear.Face.StopLooking();

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(broccolli, "The water is nice...");

        StartCoroutine(broccolli.Expand(30f, new List<int>() { 0, 1}));

        yield return Dialogue.Create(broccolli, "woop, spoke too soon");

		AudioManager.Singleton.PlayExcitingMusic();
        Stu.Singleton.ToggleThrowing(true);

        StartCoroutine(cucumber.Expand(30f, new List<int>() { 0 }));

        yield return Dialogue.Create(cucumber, "Ack! us too");

        StartCoroutine(banana.Expand(30f, new List<int>() { 0 }));

        StartCoroutine(peach.Expand(30f, new List<int>() { 0 }));

        StartCoroutine(pear.Expand(30f, new List<int>() { 0 }));

        yield return broccolli.WaitTillShrunk();

        yield return cucumber.WaitTillShrunk();

        yield return banana.WaitTillShrunk();

        yield return peach.WaitTillShrunk();

        yield return pear.WaitTillShrunk();

        yield return Dialogue.Create(broccolli, "Impressive!");

        AudioManager.Singleton.PlayNormalMusic();

    }

	IEnumerator PotatoScript()
	{

        Stu.Singleton.ToggleThrowing(false);

        if (cucumber == null)
            cucumber = Spawn(cucumberPrefab, farLeftPoolSeat);

        if (peach == null)
            peach = Spawn(peachPrefab, rightPoolSeat);

        if (pear == null)
            pear = Spawn(pearPrefab, middlePoolSeat);

        if (banana == null)
            banana = Spawn(bananaPrefab, leftPoolSeat);

        if (potato == null)
			    potato = Spawn(potatoPrefab, lobbyEntrace);

        if (broccolli == null)
            broccolli = Spawn(broccolliPrefab, farRightPoolSeat);

        yield return Dialogue.Create(pear, "Oh no...");

        yield return potato.WalkTo(middlePoolEntrance);

        yield return Dialogue.Create(potato, "Hot potato comin' through!");

        StartCoroutinePending(pear.JumpTo(leftPoolEntrance));
    
		StartCoroutinePending(peach.JumpTo(rightPoolEntrance));

        yield return new WaitForSeconds(1f);

		StartCoroutinePending(pear.WalkTo(lobbyEntrace));

		StartCoroutinePending(peach.WalkTo(lobbyEntrace));

		StartCoroutinePending(banana.JumpTo(leftPoolEntrance));

		StartCoroutinePending(broccolli.JumpTo(rightPoolEntrance));

        yield return new WaitForSeconds(1f);

		StartCoroutinePending(banana.WalkTo(lobbyEntrace));
    
		StartCoroutinePending(broccolli.WalkTo(sideDoorEntrace));

		StartCoroutinePending(cucumber.JumpTo(leftPoolEntrance));
    
        yield return potato.JumpTo(middlePoolSeat);

		StartCoroutinePending(cucumber.WalkTo(lobbyEntrace));

        yield return Dialogue.Create(potato, "I'm not too much for you huh?");

        yield return new WaitForSeconds(2f);

		yield return WaitForPending();

        GameObject.Destroy(cucumber.gameObject);

        GameObject.Destroy(pear.gameObject);

        GameObject.Destroy(peach.gameObject);

        GameObject.Destroy(banana.gameObject);

        GameObject.Destroy(broccolli.gameObject);

        yield return Dialogue.Create(potato, "All these other fruits and veggies can't handle a straight shooter like me");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "I just tell it like it is, you know?");
    
        Stu.Singleton.ToggleThrowing(true);

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "Like what's with that silly hand of yours? I bet you couldn't throw a syringe 3 feet..");

        yield return new WaitForSeconds(2f);

        StartCoroutine(potato.Expand(10f, new List<int>() { 0, 1}));

        AudioManager.Singleton.PlayExcitingMusic();

        yield return Dialogue.Create(potato, "Uh oh... Dagnabbit! I forgot about this part!");

        yield return potato.WaitTillShrunk();

        yield return Dialogue.Create(potato, "*cough* *cough* Well... anybody could throw a syringe like that ---");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "Oh no, here comes a big one!!!");

        StartCoroutine(potato.Expand(15f, new List<int>() { 0, 1, 2, 3, 4, 5}));

        yield return new WaitForSeconds(2f);

        yield return potato.WaitTillShrunk();

        yield return Dialogue.Create(potato, "Wow, you've really got a knack for that. Thanks for saving me.");

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(potato, "I really need to apologize for my behavior.");

        yield return Dialogue.Create(potato, "Ever since my wife left I've been in a downward spiral...");

        yield return Dialogue.Create(potato, "Well, I was lucky you were here. I'll let you finally relax. Have a good night!");

        yield return potato.JumpTo(middlePoolEntrance);

        yield return potato.WalkTo(gateEntrace);

        GameObject.Destroy(potato.gameObject);
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


	List<Coroutine> pending = new List<Coroutine>();
	void StartCoroutinePending(IEnumerator e)
	{
		pending.Add(StartCoroutine(e));
	}

	IEnumerator WaitForPending()
	{
		foreach (var p in pending)
			yield return p;

		pending.Clear();
	}
}
