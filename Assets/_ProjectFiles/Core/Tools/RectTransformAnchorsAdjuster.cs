using UnityEngine;
using UnityEditor;

public class RectTransformAnchorsAdjuster : EditorWindow
{

	[MenuItem("Test/example #F1")]
	private static void Adjust()
	{
		var targetObject = Selection.activeGameObject.gameObject;

		if (targetObject == null)
		{
			Debug.LogError("No GameObject selected.");
			return;
		}

		RectTransform rectTransform = targetObject.GetComponent<RectTransform>();

		Vector2 offsetMin = rectTransform.offsetMin;
		Vector2 offsetMax = rectTransform.offsetMax;

		RectTransform parent = rectTransform.parent.GetComponent<RectTransform>();

		Vector2 newAnchorMin = rectTransform.anchorMin + (offsetMin / parent.rect.size);
		Vector2 newAnchorMax = rectTransform.anchorMax + (offsetMax / parent.rect.size);

		rectTransform.anchorMin = newAnchorMin;
		rectTransform.anchorMax = newAnchorMax;

		rectTransform.offsetMin = Vector2.zero;
		rectTransform.offsetMax = Vector2.zero;
	}
}