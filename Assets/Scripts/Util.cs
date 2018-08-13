using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
	public static bool CreateIfNull(ref Transform t, Transform parent)
	{
		return CreateIfNull(ref t, parent, Vector3.zero, Quaternion.identity);
	}

	public static bool CreateIfNull(ref Transform t, Transform parent, Vector3 offset, Quaternion rotOffset)
	{
		if (t == null)
		{
			t = new GameObject("DialogueAnchorGenerated").transform;
			t.SetParent(parent, false);
			t.localPosition = offset;
			t.localRotation = rotOffset;
		}
		return t;
	}
}
