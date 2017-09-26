using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
	// Update is called once per frame
	void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);

        Destroy(gameObject, 7f);
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
