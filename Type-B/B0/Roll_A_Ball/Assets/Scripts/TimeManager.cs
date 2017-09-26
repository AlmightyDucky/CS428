using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public float timeLeft = 120f;

    public Text timer;

	// Update is called once per frame
	void Update ()
    {
		if (GameManager.timeRanOut == false)
        {
            timeLeft -= Time.deltaTime;
            timer.text = timeLeft.ToString(".00");

        }

        if (timeLeft <= 0f)
        {
            GameManager.timeRanOut = true;
        }
    }
}
