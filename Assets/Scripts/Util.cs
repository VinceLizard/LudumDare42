using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	
	public static bool CreateIfNull(ref Transform t, Transform parent)
	{
		if (t == null)
		{
			t = new GameObject("DialogueAnchorGenerated").transform;
			t.SetParent(parent, false);
			t.localPosition = new Vector3(0, 4.0f, 0);
			t.localRotation = Quaternion.identity;
		}
		return t;
	}
}
