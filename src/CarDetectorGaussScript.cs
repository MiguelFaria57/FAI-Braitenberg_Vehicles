using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class CarDetectorGaussScript : CarDetectorScript {

	public float stdDev = 1.0f; 
	public float mean = 0.0f;
	public float value;
	// Get gaussian output value
	public override float GetOutput()
	{
		// YOUR CODE HERE
		//float value;

		//value = (1 / (stdDev * Mathf.Sqrt(2 * Mathf.PI))) * Mathf.Exp((-1 / 2) * ((Mathf.Pow(output - mean, 2)) / Mathf.Pow(stdDev, 2)));
		value = (1 / (stdDev * Mathf.Sqrt(2 * Mathf.PI)) * Mathf.Exp(-(Mathf.Pow((output - mean), 2) / (2 * Mathf.Pow(stdDev, 2)))));


		if (ApplyThresholds)
		{
			if (output < MinX)
				value = 0;
			if (output > MaxX)
				value = 0;
		}

		if (ApplyLimits)
		{
			if (value < MinY)
				value = MinY;
			if (value > MaxY)
				value = MaxY;
		}

		return value;
	}


}
