using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour 
{
	[SerializeField] Rigidbody launchPrefab;
	[SerializeField] Transform launchFrom;
	[SerializeField] float launchForce;
	[SerializeField] float launchMaxTime;
    bool increaseForce = false;
    float forceMultiplier;
    [SerializeField] float forceMultiplierIncreaseRate;

	Slider forceSlider;
    private void Start()
    {
		forceSlider = Main.Singleton.forceSlider;
        forceSlider.value = 0;
    }

    void Update () {
		if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
		{
            increaseForce = true;
		}

        if(Input.GetMouseButtonUp(0) || Input.GetKeyUp(KeyCode.Space))
        {
            var rb = GameObject.Instantiate(launchPrefab, launchFrom.position, launchFrom.rotation);
            rb.AddForce(rb.transform.forward * launchForce * forceMultiplier, ForceMode.Impulse);// = launchFrom.forward * launchSpeed;
            GameObject.Destroy(rb.gameObject, launchMaxTime);
            increaseForce = false;
            forceSlider.value = forceMultiplier = 0;
        }

        if(increaseForce)
        {
            if (forceMultiplier <= 1)
            {
                forceMultiplier += forceMultiplierIncreaseRate;
            }

            forceSlider.value = forceMultiplier;
        }
	}
}
