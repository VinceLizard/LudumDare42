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
    bool increaseForce = false;
    float forceMultiplier;
    [SerializeField] float forceMultiplierIncreaseRate;
    [SerializeField] float cooldownDuration;
    Rigidbody rb;
	Slider forceSlider;
    Vector3 handPosition;
    bool cooledDown = true;
    bool startCooling = false;
    float startCoolingTime;
    bool syringeInstantiated = false;

    private void Start()
    {
		forceSlider = UI.Singleton.forceSlider;
        forceSlider.value = 0;
        forceMultiplier = FORCEMULTIPLIERSTARTVALUE;

    }

    void Update () {
        if((Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) && cooledDown)
		{
            rb = GameObject.Instantiate(launchPrefab, launchFrom.position, launchFrom.rotation);
            rb.isKinematic = true;
            rb.transform.SetParent(this.transform);
            rb.gameObject.GetComponent<OrientToVelocity>().enabled = false;
            increaseForce = true;
            handPosition = transform.localPosition;
            handPosition.z -= HANDPOSITIONCHANGE;
            transform.localPosition = handPosition;
            syringeInstantiated = true;
		}

        if((Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space)) && syringeInstantiated)
        {
            handPosition = transform.localPosition;
            handPosition.z += HANDPOSITIONCHANGE;
            transform.localPosition = handPosition;
            rb.isKinematic = false;
            rb.transform.SetParent(null);
            rb.gameObject.GetComponent<OrientToVelocity>().enabled = true;
            rb.AddForce(rb.transform.forward * launchForce * (forceMultiplier + FORCEMULTIPLIERSTARTVALUE), ForceMode.Impulse);// = launchFrom.forward * launchSpeed;
            GameObject.Destroy(rb.gameObject, launchMaxTime);
            increaseForce = false;
            forceSlider.value = forceMultiplier = 0;
            startCooling = true;
            startCoolingTime = Time.time;
            cooledDown = false;
            syringeInstantiated = false;
        }

        if(increaseForce)
        {
            
            if (forceMultiplier <= 1)
            {
                forceMultiplier += forceMultiplierIncreaseRate;
            }

            forceSlider.value = forceMultiplier;
        }

        if(startCooling)
        {
            if(Time.time - startCoolingTime > cooldownDuration)
            {
                startCooling = false;
                cooledDown = true;
            }
        }
	}
}
