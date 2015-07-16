using UnityEngine;
using System.Collections;

public class Tools
{
	public RectTransform InitUIPrefabs(Transform prefab) {
		return null;
	}

	public RectTransform InitUIPrefabs(Transform prefab, Vector3 offset) {
		RectTransform ret = ((RectTransform)GameObject.Instantiate (prefab, offset, new Quaternion()));

		return ret;
	}
}

