using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialControllerLvl2 : MonoBehaviour {

	public GridLinesTut02 gridLines;
	public TriangleControllerTut02 triangleController;
	public ManipulateVerticesTut02 manipulateVertices;
	public InstantiateHelperDotTut02 instantiateHelperDot;

	public GameObject tutorialPanel;
	private Image triesPanel;
	private Text triesText01;
	private Text triesText02;

	private Text tutorialDialogue1;
	private Text tutorialDialogue2;
	private Text tutorialDialogue3;
	private Text tutorialDialogue4;
	private Text tutorialDialogue5;
	private Text tutorialDialogue6;
	private Text tutorialDialogue7;
	private Text tutorialDialogue8;
	private Text tutorialDialogue9;
	private Text tutorialDialogue10;
	private Text tutorialDialogue11;
	private Text tutorialDialogue12;
	private Text tutorialDialogue13;
	private Text tutorialDialogue14;
	private Text tutorialDialogue15;
	private Text tutorialDialogue16;
	private Text tutorialDialogue17;
	private Text tutorialDialogue18;
	private Text tutorialDialogue19;
	private Text tutorialDialogue20;
	private Text tutorialDialogue21;
	private Text tutorialDialogue22;
	private Text tutorialDialogue23;
	private Text tutorialDialogue24;
	private Text tutorialDialogue25;
	private Text tutorialDialogue26;
	private Text pressEnter;

	private float characterDelay = 0.03f;
	private string textController01, textController02;
	private string tutorialMessage1, tutorialMessage2, tutorialMessage3, tutorialMessage4, tutorialMessage5;
	private string tutorialMessage6, tutorialMessage7, tutorialMessage8, tutorialMessage9, tutorialMessage10; 
	private string tutorialMessage11, tutorialMessage12, tutorialMessage13, tutorialMessage14, tutorialMessage15;
	private string tutorialMessage16, tutorialMessage17, tutorialMessage18, tutorialMessage19, tutorialMessage20;
	private string tutorialMessage21, tutorialMessage22, tutorialMessage23, tutorialMessage24, tutorialMessage25, tutorialMessage26;
	private string pressEnterMessage;
	
	private bool doneTypingMessage;
	public bool freezeTime;
	
	private float typingDelayCtr;
	private float typingDelay;
	private float freezeTimeCtr = 0f;
	
	public int messageCurrentlyOn = 1;
	
	public bool startPart1, startPart2, startPart3, startPart4, startPart5, startPart6;
	public bool inTutorialMV, inTutorialTC, inTutorialGL, inTutorialBC, inTutorialHDC;
	public bool inTutorialTileDot1, inTutorialTileDot2, inTutorialAT;
	// Use this for initialization
	void Awake () {
		triesPanel = GameObject.Find ("Tries Left Panel").GetComponent<Image> ();
		triesText01 = GameObject.Find ("Number of Tries").GetComponent<Text> ();
		triesText02 = GameObject.Find ("Time Recorded").GetComponent<Text> ();

		triesPanel.gameObject.SetActive (false);
		textController01 = triesText01.ToString ();
		textController02 = triesText02.ToString ();
		triesText01.text = "";
		triesText02.text = "";
		//triesPanel.SetActive (false);

		tutorialDialogue1 = GameObject.Find ("Tutorial Text 1").GetComponent<Text> ();
		tutorialDialogue2 = GameObject.Find ("Tutorial Text 2").GetComponent<Text> ();
		tutorialDialogue3 = GameObject.Find ("Tutorial Text 3").GetComponent<Text> ();
		tutorialDialogue4 = GameObject.Find ("Tutorial Text 4").GetComponent<Text> ();
		tutorialDialogue5 = GameObject.Find ("Tutorial Text 5").GetComponent<Text> ();
		tutorialDialogue6 = GameObject.Find ("Tutorial Text 6").GetComponent<Text> ();
		tutorialDialogue7 = GameObject.Find ("Tutorial Text 7").GetComponent<Text> ();
		tutorialDialogue8 = GameObject.Find ("Tutorial Text 8").GetComponent<Text> ();
		tutorialDialogue9 = GameObject.Find ("Tutorial Text 9").GetComponent<Text> ();
		tutorialDialogue10 = GameObject.Find ("Tutorial Text 10").GetComponent<Text> ();
		tutorialDialogue11 = GameObject.Find ("Tutorial Text 11").GetComponent<Text> ();
		tutorialDialogue12 = GameObject.Find ("Tutorial Text 12").GetComponent<Text> ();
		tutorialDialogue13 = GameObject.Find ("Tutorial Text 13").GetComponent<Text> ();
		tutorialDialogue14 = GameObject.Find ("Tutorial Text 14").GetComponent<Text> ();
		tutorialDialogue15 = GameObject.Find ("Tutorial Text 15").GetComponent<Text> ();
		//tutorialDialogue16 = GameObject.Find ("Tutorial Text 16").GetComponent<Text> ();
		tutorialDialogue17 = GameObject.Find ("Tutorial Text 17").GetComponent<Text> ();
		tutorialDialogue18 = GameObject.Find ("Tutorial Text 18").GetComponent<Text> ();
		tutorialDialogue19 = GameObject.Find ("Tutorial Text 19").GetComponent<Text> ();
		tutorialDialogue20 = GameObject.Find ("Tutorial Text 20").GetComponent<Text> ();
		tutorialDialogue21 = GameObject.Find ("Tutorial Text 21").GetComponent<Text> ();
		tutorialDialogue22 = GameObject.Find ("Tutorial Text 22").GetComponent<Text> ();
		tutorialDialogue23 = GameObject.Find ("Tutorial Text 23").GetComponent<Text> ();
		tutorialDialogue24 = GameObject.Find ("Tutorial Text 24").GetComponent<Text> ();
		tutorialDialogue25 = GameObject.Find ("Tutorial Text 25").GetComponent<Text> ();
		tutorialDialogue26 = GameObject.Find ("Tutorial Text 26").GetComponent<Text> ();
		pressEnter = GameObject.Find ("Press Enter to Continue").GetComponent<Text> ();

		instantiateHelperDot = GetComponent<InstantiateHelperDotTut02> ();
		
		startPart1 = true;
		startPart2 = startPart3 = startPart4 = startPart5 = startPart6 = false;

		tutorialMessage1 = tutorialDialogue1.text.ToString ();
		tutorialDialogue1.text = "";
		tutorialMessage2 = tutorialDialogue2.text.ToString ();
		tutorialDialogue2.text = "";
		tutorialMessage3 = tutorialDialogue3.text.ToString ();
		tutorialDialogue3.text = "";
		tutorialMessage4 = tutorialDialogue4.text.ToString ();
		tutorialDialogue4.text = "";
		tutorialMessage5 = tutorialDialogue5.text.ToString ();
		tutorialDialogue5.text = "";
		tutorialMessage6 = tutorialDialogue6.text.ToString ();
		tutorialDialogue6.text = "";
		tutorialMessage7 = tutorialDialogue7.text.ToString ();
		tutorialDialogue7.text = "";
		tutorialMessage8 = tutorialDialogue8.text.ToString ();
		tutorialDialogue8.text = "";
		tutorialMessage9 = tutorialDialogue9.text.ToString ();
		tutorialDialogue9.text = "";
		tutorialMessage10 = tutorialDialogue10.text.ToString ();
		tutorialDialogue10.text = "";
		tutorialMessage11 = tutorialDialogue11.text.ToString ();
		tutorialDialogue11.text = "";
		tutorialMessage12 = tutorialDialogue12.text.ToString ();
		tutorialDialogue12.text = "";
		tutorialMessage13 = tutorialDialogue13.text.ToString ();
		tutorialDialogue13.text = "";
		tutorialMessage14 = tutorialDialogue14.text.ToString ();
		tutorialDialogue14.text = "";
		tutorialMessage15 = tutorialDialogue15.text.ToString ();
		tutorialDialogue15.text = "";
		//tutorialMessage16 = tutorialDialogue16.text.ToString ();
		//tutorialDialogue16.text = "";
		tutorialMessage17 = tutorialDialogue17.text.ToString ();
		tutorialDialogue17.text = "";
		tutorialMessage18 = tutorialDialogue18.text.ToString ();
		tutorialDialogue18.text = "";
		tutorialMessage19 = tutorialDialogue19.text.ToString ();
		tutorialDialogue19.text = "";
		tutorialMessage20 = tutorialDialogue20.text.ToString ();
		tutorialDialogue20.text = "";
		tutorialMessage21 = tutorialDialogue21.text.ToString ();
		tutorialDialogue21.text = "";
		tutorialMessage22 = tutorialDialogue22.text.ToString ();
		tutorialDialogue22.text = "";
		tutorialMessage23 = tutorialDialogue23.text.ToString ();
		tutorialDialogue23.text = "";
		tutorialMessage24 = tutorialDialogue24.text.ToString ();
		tutorialDialogue24.text = "";
		tutorialMessage25 = tutorialDialogue25.text.ToString ();
		tutorialDialogue25.text = "";
		tutorialMessage26 = tutorialDialogue26.text.ToString ();
		tutorialDialogue26.text = "";
		pressEnterMessage = pressEnter.text.ToString ();
		pressEnter.text = "";

		inTutorialMV = inTutorialTC = inTutorialGL = inTutorialBC = inTutorialHDC = false;
		inTutorialTileDot1 = inTutorialTileDot2 = inTutorialAT = false;
		freezeTime = false;
		
		typingDelayCtr = 0f;
		typingDelay = 0.5f;
		freezeTimeCtr = 0f;
		
		StartCoroutine (TypeTutorial (tutorialMessage1, tutorialDialogue1));
		startPart1 = StartController ();
	}

	void Update () {
		if (freezeTime) {
			freezeTimeCtr += Time.unscaledDeltaTime;
			if (freezeTimeCtr >= 0.2f) {
				Time.timeScale = 0f;
				messageCurrentlyOn += 1;
				startPart3 = true;
				freezeTime = false;
			}
		}
		
		if (doneTypingMessage) {
			typingDelayCtr += Time.unscaledDeltaTime;
			if (typingDelayCtr >= typingDelay) {
				if ((messageCurrentlyOn != 4) && (messageCurrentlyOn != 5) && 
				    (messageCurrentlyOn != 12) && (messageCurrentlyOn != 14) && 
				    (messageCurrentlyOn != 15) && (messageCurrentlyOn != 18)) {
					pressEnter.text = pressEnterMessage;
				} else {
					doneTypingMessage = false;
				}
				if (Input.GetButtonUp ("Next") && doneTypingMessage && (messageCurrentlyOn != 4) && 
				    (messageCurrentlyOn != 5) && (messageCurrentlyOn != 12) && 
				    (messageCurrentlyOn != 14) && (messageCurrentlyOn != 15) &&
				    (messageCurrentlyOn != 18)) {
					//Debug.Log (messageCurrentlyOn.ToString ());
					
					messageCurrentlyOn += 1;
					if ((messageCurrentlyOn >= 1) && (messageCurrentlyOn <= 4)) {
						startPart1 = true;
					} else if ((messageCurrentlyOn >= 5) && (messageCurrentlyOn <= 15)) {
						startPart2 = true;
					} else if ((messageCurrentlyOn >= 18) && (messageCurrentlyOn <= 19)) {
						startPart3 = true;
					} else if (messageCurrentlyOn == 20) {//change
						Debug.Log ("unfreeze");
						Time.timeScale = 1f;
					} else if ((messageCurrentlyOn >= 20) && (messageCurrentlyOn <= 26)) {//change
						startPart4 = true;
					} else if (messageCurrentlyOn >= 27) {//change
						startPart5 = true;
					}

					pressEnter.text = "";
					typingDelayCtr = 0f;
					doneTypingMessage = false;
				}
				
			}
		}

		if (startPart1) {
			if (messageCurrentlyOn == 2) {
				tutorialDialogue1.text = "";
				tutorialDialogue1.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage2, tutorialDialogue2));
				startPart1 = StartController ();
			} else if (messageCurrentlyOn == 3) {
				//instantiateHelperDot.Instantiate ();
				tutorialDialogue2.text = "";
				tutorialDialogue2.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage3, tutorialDialogue3));
				startPart1 = StartController ();
			} else if (messageCurrentlyOn == 4) {
				instantiateHelperDot.Instantiate ();
				tutorialDialogue3.text = "";
				tutorialDialogue3.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage4, tutorialDialogue4));
				startPart1 = StartController ();
				inTutorialGL = true;
				inTutorialHDC = true;
				inTutorialTileDot1 = true;
			}
		} else if (startPart2) {
			if (messageCurrentlyOn == 5) {
				tutorialDialogue4.text = "";
				tutorialDialogue4.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage5, tutorialDialogue5));
				startPart2 = StartController ();
				inTutorialGL = true;
				inTutorialBC = true;
			} else if (messageCurrentlyOn == 7) {
				Debug.Log ("Draw the line");
				tutorialDialogue5.text = "";
				tutorialDialogue5.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage6, tutorialDialogue6));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 8) {
				tutorialDialogue6.text = "";
				tutorialDialogue6.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage7, tutorialDialogue7));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 9) {
				tutorialDialogue7.text = "";
				tutorialDialogue7.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage8, tutorialDialogue8));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 10) {
				tutorialDialogue8.text = "";
				tutorialDialogue8.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage9, tutorialDialogue9));
				startPart2 = StartController ();
				//messageCurrentlyOn += 1;
			} else if (messageCurrentlyOn == 11) {
				//instantiateHelperDot.InstantiateAdjustments ();
				tutorialDialogue9.text = "";
				tutorialDialogue9.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage21, tutorialDialogue21));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 12) {
				tutorialDialogue21.text = "";
				tutorialDialogue21.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage25, tutorialDialogue25));
				startPart2 = StartController ();
				inTutorialGL = true;
				inTutorialAT = true;
			} else if (messageCurrentlyOn == 13) {
				tutorialDialogue25.text = "";
				tutorialDialogue25.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage22, tutorialDialogue22));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 14) {//make it 13
				instantiateHelperDot.InstantiateAdjustments ();
				tutorialDialogue22.text = "";
				tutorialDialogue22.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage10, tutorialDialogue10));
				startPart2 = StartController ();
				//inTutorialGL = true;
				inTutorialMV = true;
				inTutorialTileDot1 = false;
				inTutorialTileDot2 = true;
			} else if (messageCurrentlyOn == 15) {//make it 14
				instantiateHelperDot.InstantiateAdjustments ();
				tutorialDialogue10.text = "";
				tutorialDialogue10.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage11, tutorialDialogue11));
				startPart2 = StartController ();
				//inTutorialGL = true;
				inTutorialMV = true;
			} else if (messageCurrentlyOn == 16) {
				tutorialDialogue10.text = "";
				tutorialDialogue10.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage23, tutorialDialogue23));
				startPart2 = StartController ();
				inTutorialAT = true;
			} else if (messageCurrentlyOn == 17) {
				tutorialDialogue23.text = "";
				tutorialDialogue23.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage24, tutorialDialogue24));
				startPart2 = StartController ();
			}
		} else if (startPart3) {
			if (messageCurrentlyOn == 18) {//17
				inTutorialTileDot2 = false;
				//tutorialDialogue11.text = "";
				//tutorialDialogue11.gameObject.SetActive (false);
				tutorialDialogue10.text = "";
				tutorialDialogue10.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage12, tutorialDialogue12));
				startPart3 = StartController ();
				inTutorialGL = true;
				inTutorialBC = true;
				//messageCurrentlyOn += 1;
			}
			if (messageCurrentlyOn == 19) {//18
				tutorialDialogue12.text = "";
				tutorialDialogue12.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage13, tutorialDialogue13));
				startPart3 = StartController ();
			}
		} else if (startPart4) {
			if (messageCurrentlyOn == 20) {
				tutorialDialogue13.text = "";
				tutorialDialogue13.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage14, tutorialDialogue14));
				startPart4 = StartController ();
				//Make dots appear on screen
				//instantiateHelperDot.Instantiate ();
			} else if (messageCurrentlyOn == 21) {
				triesPanel.gameObject.SetActive (true);
				triesText01.text = textController01;
				triesText02.text = textController02;
				tutorialDialogue14.text = "";
				tutorialDialogue14.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage15, tutorialDialogue15));
				startPart4 = StartController ();
			} else if (messageCurrentlyOn == 22) {
				tutorialDialogue15.text = "";
				tutorialDialogue15.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage17, tutorialDialogue17));
				startPart4 = StartController ();
				//inTutorialHDC = true;
				//messageCurrentlyOn += 1;
			} else if (messageCurrentlyOn == 23) {
				tutorialDialogue17.text = "";
				tutorialDialogue17.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage18, tutorialDialogue18));
				startPart4 = StartController ();
				//inTutorialHDC = true;
				//messageCurrentlyOn += 1;
			} else if (messageCurrentlyOn == 24) {
				tutorialDialogue18.text = "";
				tutorialDialogue18.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage26, tutorialDialogue26));
				startPart4 = StartController ();
				//inTutorialHDC = true;
				//messageCurrentlyOn += 1;
			} else if (messageCurrentlyOn == 25) {
				tutorialDialogue26.text = "";
				tutorialDialogue26.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage19, tutorialDialogue19));
				startPart4 = StartController ();

			} else if (messageCurrentlyOn == 26) {
				tutorialDialogue19.text = "";
				tutorialDialogue19.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage20, tutorialDialogue20));
				startPart4 = StartController ();
				//inTutorialHDC = true;
				//messageCurrentlyOn += 1;
			} /*else if (messageCurrentlyOn == 27) {
				tutorialDialogue19.text = "";
				tutorialDialogue19.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage20, tutorialDialogue20));
				startPart4 = StartController ();
			} */
		} else if (startPart5) {
			//Application.Quit ();
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}

	IEnumerator TypeTutorial (string message, Text tutDialogue) {
		foreach (char c in message) {
			float pauseEndTime = Time.realtimeSinceStartup + 0.02f;
			while (Time.realtimeSinceStartup < pauseEndTime){
				yield return 0;
			}
			tutDialogue.text += c;
			
		}
		
		doneTypingMessage = true;
		Debug.Log ("Typing message: " + doneTypingMessage.ToString ());
		
	}
	
	bool StartController () {
		return false;
	}
}
