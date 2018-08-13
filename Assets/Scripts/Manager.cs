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
		yield return BroccoliScript();  */
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

        StartCoroutine(peach.WalkTo(rightPoolEntrance));

        yield return new WaitForSeconds(.5f);

        StartCoroutine(Dialogue.Create(peach, "This guy Carl wanted to write my dialogue, but he was totally like $@#% that !%!@!"));
   
        yield return new WaitForSeconds(.5f);

        cucumber.Face.LookAt(peach);
    
        if (pear == null)
            pear = Spawn(pearPrefab, lobbyEntrace);

        pear.Face.LookAt(peach);

        StartCoroutine(pear.WalkTo(middlePoolEntrance));

        yield return new WaitForSeconds(4f);

        StartCoroutine(Dialogue.Create(pear, "OMG seriously?"));

        yield return new WaitForSeconds(3f);

        yield return peach.JumpTo(rightPoolSeat);

        yield return pear.JumpTo(middlePoolSeat);

        StartCoroutine(Dialogue.Create(cucumber, "hi"));

        yield return new WaitForSeconds(.5f);

        peach.Face.LookAt(cucumber);

        pear.Face.LookAt(cucumber);

        yield return new WaitForSeconds(6f);
    
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

        yield return Dialogue.Create(peach, "I mean, I guess I would if I didn't have so much social anxiety");

        pear.Face.LookAt(peach);

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(pear, "You say that, but what if you don't have social anxiety and just hate everyone you meet?");

        peach.Face.LookAt(pear);

        yield return new WaitForSeconds(2f);

        yield return Dialogue.Create(peach, "It's really just that potato that puts me over the edge...");

        peach.Face.StopLooking();

        pear.Face.StopLooking();

        yield return new WaitForSeconds(1f);

        yield return Dialogue.Create(broccolli, "The water is nice...");

        StartCoroutine(broccolli.Expand(30f, new List<int>() { 0, 1}));

        yield return Dialogue.Create(broccolli, "woop, spoke too soon");

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

        StartCoroutine(pear.JumpTo(leftPoolEntrance));
    
        StartCoroutine(peach.JumpTo(rightPoolEntrance));

        yield return new WaitForSeconds(1f);

        StartCoroutine(pear.WalkTo(lobbyEntrace));

        StartCoroutine(peach.WalkTo(lobbyEntrace));

        StartCoroutine(banana.JumpTo(leftPoolEntrance));

        StartCoroutine(broccolli.JumpTo(rightPoolEntrance));

        yield return new WaitForSeconds(1f);

        StartCoroutine(banana.WalkTo(lobbyEntrace));
    
        StartCoroutine(broccolli.WalkTo(sideDoorEntrace));

        StartCoroutine(cucumber.JumpTo(leftPoolEntrance));
    
        yield return potato.JumpTo(middlePoolSeat);

        StartCoroutine(cucumber.WalkTo(lobbyEntrace));

        yield return Dialogue.Create(potato, "I'm not too much for you huh?");

        yield return new WaitForSeconds(2f);

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
}
