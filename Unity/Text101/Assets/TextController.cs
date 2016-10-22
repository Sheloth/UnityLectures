using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	
	enum States  {Cell, Sheets_0, Mirror, Lock_0, Sheets_1, Cell_mirror, Lock_1, 
							Corridor_0, Stairs_0, Stairs_1, Stairs_2, Courtyard, Floor, Corridor_1, Corridor_2, Corridor_3, Closet_door, In_closet};
	
	States currentState;

	// Use this for initialization
	void Start () {
		currentState = States.Cell;
	}
	
	// Update is called once per frame
	void Update () {
		if(currentState == States.Cell) {Cell ();}
		else if(currentState == States.Sheets_0) {Sheets_0 ();}
		else if(currentState == States.Mirror) {Mirror ();}
		else if(currentState == States.Lock_0) {Lock_0 ();}
		else if(currentState == States.Sheets_1) {Sheets_1 ();}
		else if(currentState == States.Cell_mirror) {Cell_mirror ();}
		else if(currentState == States.Lock_1) {Lock_1 ();}
		else if(currentState == States.Corridor_0) {Corridor_0 ();}
		else if (currentState == States.Corridor_0) {Corridor_0();}
		else if (currentState == States.Stairs_0) {Stairs_0();}
		else if (currentState == States.Stairs_1) {Stairs_1();}
		else if (currentState == States.Stairs_2) {Stairs_2();}
		else if (currentState == States.Courtyard) {Courtyard();}
		else if (currentState == States.Floor) {Floor();}
		else if (currentState == States.Corridor_1) {Corridor_1();}
		else if (currentState == States.Corridor_2) {Corridor_2();}
		else if (currentState == States.Corridor_3) {Corridor_3();}
		else if (currentState == States.Closet_door) {Closet_door();}
		else if (currentState == States.In_closet) {In_closet();}
	}
	
	private void Cell() {
		text.text =	"You are in a prison cell, and you want to escape. There are " +
							"some dirty sheets on the bed, a mirror on the wall, and the door " +
							"is locked from the outside.\n\n" +
							"Press S to view Sheets, M to view Mirror and L to view Lock";
							
		if(Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Sheets_0;
		}
		else if(Input.GetKeyDown(KeyCode.M)) {
			currentState = States.Mirror;
		}
		else if(Input.GetKeyDown(KeyCode.L)) {
			currentState = States.Lock_0;
		}
	}
	
	private void Sheets_0() {
		text.text =	"You can't believe you sleep in these things. Surely it's " +
							"time somebody changed them. The pleasures of prison life " +
							"I guess!\n\n" +
							"Press R to Return to roaming your cell" ;
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Cell;
		}
	}
	
	private void Lock_0() {
		text.text = "This is one of those button locks. You have no idea what the " +
							"combination is. You wish you could somehow see where the dirty " +
							"fingerprints were, maybe that would help.\n\n" +
							"Press R to Return to roaming your cell" ;
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Cell;
		}
	}
	
	private void Mirror() {
		text.text =	"The dirty old mirror on the wall seems loose.\n\n" +
							"Press T to Take the mirror, or R to Return to cell" ;
							
		if(Input.GetKeyDown(KeyCode.T)) {
			currentState = States.Cell_mirror;
		}
		else if(Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Cell;
		}
	}
	
	private void Cell_mirror() {
		text.text = "You are still in your cell, and you STILL want to escape! There are " +
							"some dirty sheets on the bed, a mark where the mirror was, " +
							"and that pesky door is still there, and firmly locked!\n\n" +
							"Press S to view Sheets, or L to view Lock" ;
		if(Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Sheets_1;
		}
		else if(Input.GetKeyDown(KeyCode.L)) {
			currentState = States.Lock_1;
		}
	}
	
	private void Sheets_1() {
		text.text =	"Holding a mirror in your hand doesn't make the sheets look " +
							"any better.\n\n" +
							"Press R to Return to roaming your cell";
							
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Cell_mirror;
		}
	}
	
	private void Lock_1() {
		text.text = "You carefully put the mirror through the bars, and turn it round " +
							"so you can see the lock. You can just make out fingerprints around " +
							"the buttons. You press the dirty buttons, and hear a click.\n\n" +
							"Press O to Open, or R to Return to your cell" ;
							
		if(Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Cell_mirror;
		}
		else if(Input.GetKeyDown(KeyCode.O)) {
			currentState = States.Corridor_0;
		}
	}
	
	private void Freedom() {
		text.text = "You are FREE!\n\n" +
							"Press P to Play again";
		if(Input.GetKeyDown(KeyCode.P)) {
			currentState = States.Cell;
		}
	}	
	
	void In_closet() {
		text.text = "Inside the closet you see a cleaner's uniform that looks about your size! " +
							"Seems like your day is looking-up.\n\n" +
							"Press D to Dress up, or R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Corridor_2;
		}
		else if (Input.GetKeyDown(KeyCode.D)) {
			currentState = States.Corridor_3;
		}
	}
	
	void Closet_door() {
		text.text = "You are looking at a closet door, unfortunately it's locked. " +
							"Maybe you could find something around to help enourage it open?\n\n" +
							"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Corridor_0;
		}
	}
	
	void Corridor_0() {
		text.text = "You're out of your cell, but not out of trouble." +
							"You are in the corridor, there's a closet and some stairs leading to " +
							"the Courtyard. There's also various detritus on the Floor.\n\n" +
							"C to view the Closet, F to inspect the Floor, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Stairs_0;
		}
		else if (Input.GetKeyDown(KeyCode.F)) {
			currentState = States.Floor;
		}
		else if (Input.GetKeyDown(KeyCode.C)) {
			currentState = States.Closet_door;
		}
	}
	
	void Corridor_1() {
		text.text = "Still in the corridor. Floor still dirty. Hairclip in hand. " +
			"Now what? You wonder if that lock on the closet would succumb to " +
				"to some lock-picking?\n\n" +
				"P to Pick the lock, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.P)) {currentState = States.In_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Stairs_1;
		}
	}
	
	void Corridor_2() {
		text.text = "Back in the corridor, having declined to dress-up as a cleaner.\n\n" +
			"Press C to revisit the Closet, and S to climb the stairs";
		if (Input.GetKeyDown(KeyCode.C)) {currentState = States.In_closet;}
		else if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Stairs_2;
		}
	}
	
	void Corridor_3() {
		text.text = "You're standing back in the corridor, now convincingly dressed as a cleaner. " +
							"You strongly consider the run for freedom.\n\n" +
							"Press S to take the Stairs, or U to Undress";
		if (Input.GetKeyDown(KeyCode.S)) {
			currentState = States.Courtyard;
		}
		else if (Input.GetKeyDown(KeyCode.U)) {
			currentState = States.In_closet;
		}
	}
	
	void Floor () {
		text.text = "Rummagaing around on the dirty Floor, you find a hairclip.\n\n" +
							"Press R to Return to the standing, or H to take the Hairclip." ;
		if (Input.GetKeyDown(KeyCode.R)) {currentState = States.Corridor_0;}
		else if (Input.GetKeyDown(KeyCode.H)) {
			currentState = States.Corridor_1;
		}
	}
	
	void Courtyard () {
		text.text = "You walk through the Courtyard dressed as a cleaner. " +
							"The guard tips his hat at you as you waltz past, claiming " +
							"your freedom. You heart races as you walk into the sunset.\n\n" +
							"Press P to Play again." ;
		if (Input.GetKeyDown(KeyCode.P)) {
			currentState = States.Cell;
		}
	}
	
	void Stairs_0 () {
		text.text = "You start walking up the stairs towards the outside light. " +
							"You realise it's not break time, and you'll be caught immediately. " +
							"You slither back down the stairs and reconsider.\n\n" +
							"Press R to Return to the corridor." ;
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Corridor_0;
		}
	}
	
	void Stairs_1 () {
		text.text = "Unfortunately weilding a puny hairclip hasn't given you the " +
							"confidence to walk out into a Courtyard surrounded by armed guards!\n\n" +
							"Press R to Retreat down the stairs" ;
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Corridor_1;
		}
	}
	
	void Stairs_2() {
		text.text = "You feel smug for picking the closet door open, and are still armed with " +
							"a hairclip (now badly bent). Even these achievements together don't give " +
							"you the courage to climb up the staris to your death!\n\n" +
							"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			currentState = States.Corridor_2;
		}
	}
}
