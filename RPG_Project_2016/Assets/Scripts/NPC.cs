using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NPC : MonoBehaviour
{

	public TextAsset textFile;
	public string[] textLines;
	public static int currentLine;
	public int endLine;
	public GameObject textBox;
	public Text theText;

	public bool guiIsActive;

	void Start ()
	{

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}
		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}
		if (guiIsActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}

	void Update ()
	{
		if (!guiIsActive) {
			return;
		}
		theText.text = textLines [currentLine];
		if (currentLine > endLine) {
			DisableTextBox ();
		}
	}

	public void EnableTextBox ()
	{
		textBox.SetActive (true);

		PlayerMovement.isTalking = true;
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);
		PlayerMovement.isTalking = false;
	}

	public  void Action ()
	{
		EnableTextBox();
		currentLine += 1;
	}

	public void ReloadScript(TextAsset theText)
	{
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));
		}
	}
}
