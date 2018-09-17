using UnityEngine; 
using UnityEngine.UI; 
using System.Collections;

public class FixCaret : MonoBehaviour { 
	private Text txt = null; 
	private RectTransform rtText; 
	private Text txtPlaceholder = null; 
	LayoutElement caretLE = null; 
	RectTransform rtCaret = null; 
	int offset = 4;
	
	IEnumerator Start()
	{
		// Get the text
		Transform t = transform.Find("Text");
		if (t == null)
			throw new UnityException(string.Format("Child named Text not found in {0}!", gameObject.name));
		txt = t.gameObject.GetComponent<Text>();
		rtText = txt.gameObject.GetComponent<RectTransform>();
		rtText.offsetMin = new Vector2(rtText.offsetMin.x, offset);
		rtText.offsetMax = new Vector2(rtText.offsetMax.x, -offset);
		// Get the placeholder
		t = transform.Find("Placeholder");
		if (t)
		{
			// Set the placeholder text alignment to match
			txtPlaceholder = t.gameObject.GetComponent<Text>();
			txtPlaceholder.alignment = txt.alignment;
			RectTransform rtPlaceholder = t.gameObject.GetComponent<RectTransform>();
			rtPlaceholder.offsetMin = new Vector2(rtPlaceholder.offsetMin.x, offset);
			rtPlaceholder.offsetMax = new Vector2(rtPlaceholder.offsetMax.x, -offset);
		}
		// Wait a frame for the caret to appear
		yield return null;
		// Get the caret (only object with a LayoutElement)
		caretLE = gameObject.GetComponentInChildren<LayoutElement>();
		rtCaret = caretLE.gameObject.GetComponent<RectTransform>();
		rtCaret.offsetMin = new Vector2(rtCaret.offsetMin.x, offset);
		rtCaret.offsetMax = new Vector2(rtCaret.offsetMax.x, -offset);
	}
	void LateUpdate()
	{
		if (rtCaret == null)
			return;
		float height = rtText.rect.height;
		if (txt.alignment == TextAnchor.UpperLeft ||
		    txt.alignment == TextAnchor.UpperCenter ||
		    txt.alignment == TextAnchor.UpperRight)
		{
			// no adjustment necessary
			float diff = rtCaret.offsetMax.y;
			rtCaret.offsetMax = new Vector2(rtCaret.offsetMax.x, diff);
		}
		else if (txt.alignment == TextAnchor.MiddleLeft ||
		         txt.alignment == TextAnchor.MiddleCenter ||
		         txt.alignment == TextAnchor.MiddleRight)
		{
			float diff = -(height - txt.preferredHeight) - offset;
			rtCaret.offsetMax = new Vector2(rtCaret.offsetMax.x, diff);
		}
		else if (txt.alignment == TextAnchor.LowerLeft ||
		         txt.alignment == TextAnchor.LowerCenter ||
		         txt.alignment == TextAnchor.LowerRight)
		{
			float diff = -(height - txt.preferredHeight) * 2 - offset;
			rtCaret.offsetMax = new Vector2(rtCaret.offsetMax.x, diff);
		}
	}
	
}