using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour 
{
    static float FORCEMULTIPLIERSTARTVALUE = .2f;
    static float HANDPOSITIONCHANGE = .1f;

	[SerializeField] Rigidbody launchPrefab;
	[SerializeField] Transform launchFrom;
	[SerializeField] float launchForce;
	[SerializeField] float launchMaxTime;
    float forceMultiplier;
    [SerializeField] float forceMultiplierIncreaseRate;
    [SerializeField] float cooldownDuration;
    Rigidbody rb;
	Slider forceSlider;
    Vector3 handPosition;
    float startCoolingTime;

    private void Start()
    {
		forceSlider = UI.Singleton.forceSlider;
        forceSlider.value = 0;
        forceMultiplier = FORCEMULTIPLIERSTARTVALUE;
    }

    enum State
    {
        Inactive = 0,
        ReadyToLaunch = 1,
        Cooldown = 2
    }
    private State state = State.Inactive;


    void Update () {

        switch(state)
        {
            case State.Inactive:

                if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                {
                    rb = GameObject.Instantiate(launchPrefab, launchFrom.position, launchFrom.rotation);
                    rb.isKinematic = true;
                    rb.transform.SetParent(this.transform);
                    rb.gameObject.GetComponent<OrientToVelocity>().enabled = false;
                    handPosition = transform.localPosition;
                    handPosition.z -= HANDPOSITIONCHANGE;
                    transform.localPosition = handPosition;

                    state = State.ReadyToLaunch;
                }

                break;

            case State.ReadyToLaunch:

                if (forceMultiplier <= 1)
                {
                    forceMultiplier += forceMultiplierIncreaseRate;
                }

                forceSlider.value = forceMultiplier;

                if ((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)))
                {
                    handPosition = transform.localPosition;
                    handPosition.z += HANDPOSITIONCHANGE;
                    transform.localPosition = handPosition;
                    rb.isKinematic = false;
                    rb.transform.SetParent(null);
                    rb.gameObject.GetComponent<OrientToVelocity>().enabled = true;
                    rb.AddForce(rb.transform.forward * launchForce * (forceMultiplier + FORCEMULTIPLIERSTARTVALUE), ForceMode.Impulse);// = launchFrom.forward * launchSpeed;
                    GameObject.Destroy(rb.gameObject, launchMaxTime);
                    forceSlider.value = forceMultiplier = 0;
                    startCoolingTime = Time.time;

                    state = State.Cooldown;
                }

                break;

            case State.Cooldown:
                
                    if (Time.time - startCoolingTime > cooldownDuration)
                    {
                        state = State.Inactive;
                    }

                break;
        }


	}
}
