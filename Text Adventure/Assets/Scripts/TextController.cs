using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States{	niklas,	derp,	testnytt,
	};
	private States myStates;

	// Use this for initialization
	void Start () {
		text.text = "Jag har bytt texten nu";
		myStates = States.niklas;
	}
	
	// Update is called once per frame
	void Update () {
		if (myStates == States.niklas){Niklas();}
		else if (myStates == States.niklas){Niklas();}
		else if (myStates == States.derp){Derp();}
		else if (myStates == States.testnytt){Testnytt();}
	}

	void Niklas(){
    text.text = "testar lite text\n\nalternativ 1 press '1' alternativ 2 press '2'";
    if (Input.GetKeyDown(KeyCode.Alpha1)){
        myStates = States.derp;
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)){
        myStates = States.derp;
    }
    
}
		void Derp(){
    text.text = "testar lite mer\n\nett första alternativ press '1' ett andra alternativ press '2' ett tredje alternativ press '3' ett fjärde alternativ press '4'";
    if (Input.GetKeyDown(KeyCode.Alpha1)){
        myStates = States.niklas;
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)){
        myStates = States.niklas;
    }
    if (Input.GetKeyDown(KeyCode.Alpha3)){
        myStates = States.niklas;
    }
    if (Input.GetKeyDown(KeyCode.Alpha4)){
        myStates = States.niklas;
    }
     
}
			void Testnytt(){
    text.text = "med lite längre text bara för att se vad som händer\n\nMed ett försa alternativ som kan vara roligt press '1' andra alternativet leder till niklas press '2' tredje alternativet leder till sig själv press '3'";
    if (Input.GetKeyDown(KeyCode.Alpha1)){
        myStates = States.derp;
    }
    if (Input.GetKeyDown(KeyCode.Alpha2)){
        myStates = States.niklas;
    }
    if (Input.GetKeyDown(KeyCode.Alpha3)){
        myStates = States.testnytt;
    }
    
}




}
