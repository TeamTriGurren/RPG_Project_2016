using UnityEngine;
using System.Collections;

public class NPC : MonoBehaviour {

    public string[] Dialog = new string[]  { "Hey, Its me Scott!", "Dont you remember me?" };
    public string ScreenText;
    public int quotes = 0;

    void OnTriggerStay2D(Collider2D Other)
    {
        if (Other.gameObject.tag == "Player")
        {
            Debug.Log("Yo " + quotes);
            if (Input.GetKeyDown(KeyCode.Space) && !PlayerMovement.isTalking)
            {
                PlayerMovement.isTalking = true;
                Action();
                quotes++;
            }
            if (Input.GetKeyDown(KeyCode.Space) && PlayerMovement.isTalking)
            {
                PlayerMovement.isTalking = false;
            }
        }
    }

    void Action()
    {
        for(int i = 0; i < Dialog.Length; i++)
        {
            ScreenText = Dialog[i];
        }
        OnGUI(); 
    }

    void OnGUI()
    {
        GUI.Label(new Rect(Screen.width/2, Screen.height-100, 500, 20), ScreenText);
    }
}
