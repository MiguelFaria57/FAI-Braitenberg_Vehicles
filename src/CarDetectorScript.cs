using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorScript : MonoBehaviour {

	public float angle = 360;
	public bool ApplyThresholds, ApplyLimits;
	public float MinX, MaxX, MinY, MaxY;
	private bool useAngle = true;

	public float output;
	public int numObjects;

	void Start()
	{
		output = 0;
		numObjects = 0;

		if (angle > 360)
		{
			useAngle = false;
		}
	}

	void Update()
	{
		// YOUR CODE HERE
		float min = Mathf.Infinity;

		GameObject[] cars = null; // array containing cars (visible or all)
		GameObject closestCar = null; // closest car to the sensor

		if (useAngle)
        {
			cars = getVisibleCars(); // use angle is true, get all cars within the view angle of the Sensor
		}
		else
        {
			cars = GetAllCars(); // use angle is false, get all cars in the enviroment
		}

		// iterate through cars and get the closest one
		foreach (GameObject car in cars)
        {
			var dist = Vector3.Distance(transform.position, car.transform.position);

			if (dist < min)
            {
				closestCar = car;
				min = dist;
            }
        }

		if (min < Mathf.Infinity)
        {
			output = min; /*given formula: 1.0f / (min + 1.0f)*/
		}
        else
        {
			output = 0;
		}
	}

	public virtual float GetOutput() { throw new NotImplementedException(); }

	// return all cars with the "CarToFollow" tag within the view angle of the Sensor
	GameObject[] getVisibleCars()
    {
		ArrayList visibleCars = new ArrayList(); // array containing visible cars
		float halfAngle = angle / 2.0f;

		GameObject[] cars = GameObject.FindGameObjectsWithTag("CarToFollow"); // get all cars with the "CarToFollow" tag

		foreach (GameObject car in cars)
        {
			Vector3 toVector = car.transform.position - transform.position; // vector between sensor and vehicle
			Vector3 forward = transform.forward; // normalized vector of the Z axis of sensor
			toVector.y = 0;
			forward.y = 0;
			float angleToTarget = Vector3.Angle(forward, toVector); // calculate angle between them

			if (angleToTarget <= halfAngle) // add car if it is within the angle
            {
				visibleCars.Add(car);
            }
        }

		return (GameObject[])visibleCars.ToArray(typeof(GameObject));
    }

	// Returns all "Light" tagged objects. The sensor angle is not taken into account.
	GameObject[] GetAllCars()
	{
		return GameObject.FindGameObjectsWithTag("CarToFollow");
	}

	// YOUR CODE HERE


}
