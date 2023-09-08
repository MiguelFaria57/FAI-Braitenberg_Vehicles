using UnityEngine;
using System.Collections;
using System.Linq;
using System;

public class LightDetectorLinearScript : LightDetectorScript {

	public override float GetOutput()
	{
		// YOUR CODE HERE
		float value = output;

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
