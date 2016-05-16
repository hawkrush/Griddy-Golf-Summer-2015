using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialControllerLvl3 : MonoBehaviour {

	public GridLinesTut03 gridLines;
	public TriangleControllerTut03 triangleController;
	public ManipulateVerticesTut03 manipulateVertices;
	public InstantiateHelperDotTut03 instantiateHelperDot;
	
	public GameObject tutorialPanel;
	private Text tutorialDialogue1;
	private Text tutorialDialogue2;
	private Text tutorialDialogue3;
	private Text tutorialDialogue4;
	private Text tutorialDialogue5;
	private Text tutorialDialogue6;
	private Text tutorialDialogue7;
	private Text tutorialDialogue8;
	//private Text tutorialDialogue9;
	//private Text tutorialDialogue10;
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
	private Text pressEnter;
	
	private float characterDelay = 0.03f;
	private string tutorialMessage1, tutorialMessage2, tutorialMessage3, tutorialMessage4, tutorialMessage5;
	private string tutorialMessage6, tutorialMessage7, tutorialMessage8, tutorialMessage9, tutorialMessage10; 
	private string tutorialMessage11, tutorialMessage12, tutorialMessage13, tutorialMessage14, tutorialMessage15;
	private string tutorialMessage16, tutorialMessage17, tutorialMessage18, tutorialMessage19, tutorialMessage20;
	private string pressEnterMessage;
	
	private bool doneTypingMessage;
	public bool freezeTime;
	
	private float typingDelayCtr;
	private float typingDelay;
	private float freezeTimeCtr = 0f;
	
	public int messageCurrentlyOn = 1;
	
	public bool startPart1, startPart2, startPart3, startPart4, startPart5, startPart6;
	public bool inTutorialMV, inTutorialTC, inTutorialGL, inTutorialBC, inTutorialHDC;
	
	// Use this for initialization
	void Awake () {
		tutorialDialogue1 = GameObject.Find ("Tutorial Text 1").GetComponent<Text> ();
		tutorialDialogue2 = GameObject.Find ("Tutorial Text 2").GetComponent<Text> ();
		tutorialDialogue3 = GameObject.Find ("Tutorial Text 3").GetComponent<Text> ();
		tutorialDialogue4 = GameObject.Find ("Tutorial Text 4").GetComponent<Text> ();
		tutorialDialogue5 = GameObject.Find ("Tutorial Text 5").GetComponent<Text> ();
		tutorialDialogue6 = GameObject.Find ("Tutorial Text 6").GetComponent<Text> ();
		tutorialDialogue7 = GameObject.Find ("Tutorial Text 7").GetComponent<Text> ();
		tutorialDialogue8 = GameObject.Find ("Tutorial Text 8").GetComponent<Text> ();
		//tutorialDialogue9 = GameObject.Find ("Tutorial Text 9").GetComponent<Text> ();
		//tutorialDialogue10 = GameObject.Find ("Tutorial Text 10").GetComponent<Text> ();
		tutorialDialogue11 = GameObject.Find ("Tutorial Text 11").GetComponent<Text> ();
		tutorialDialogue12 = GameObject.Find ("Tutorial Text 12").GetComponent<Text> ();
		tutorialDialogue13 = GameObject.Find ("Tutorial Text 13").GetComponent<Text> ();
		tutorialDialogue14 = GameObject.Find ("Tutorial Text 14").GetComponent<Text> ();
		tutorialDialogue15 = GameObject.Find ("Tutorial Text 15").GetComponent<Text> ();
		tutorialDialogue16 = GameObject.Find ("Tutorial Text 16").GetComponent<Text> ();
		tutorialDialogue17 = GameObject.Find ("Tutorial Text 17").GetComponent<Text> ();
		tutorialDialogue18 = GameObject.Find ("Tutorial Text 18").GetComponent<Text> ();
		tutorialDialogue19 = GameObject.Find ("Tutorial Text 19").GetComponent<Text> ();
		tutorialDialogue20 = GameObject.Find ("Tutorial Text 20").GetComponent<Text> ();
		pressEnter = GameObject.Find ("Press Enter to Continue").GetComponent<Text> ();
		
		instantiateHelperDot = GetComponent<InstantiateHelperDotTut03> ();
		
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
		//tutorialMessage9 = tutorialDialogue9.text.ToString ();
		//tutorialDialogue9.text = "";
		//tutorialMessage10 = tutorialDialogue10.text.ToString ();
		//tutorialDialogue10.text = "";
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
		tutorialMessage16 = tutorialDialogue16.text.ToString ();
		tutorialDialogue16.text = "";
		tutorialMessage17 = tutorialDialogue17.text.ToString ();
		tutorialDialogue17.text = "";
		tutorialMessage18 = tutorialDialogue18.text.ToString ();
		tutorialDialogue18.text = "";
		tutorialMessage19 = tutorialDialogue19.text.ToString ();
		tutorialDialogue19.text = "";
		tutorialMessage20 = tutorialDialogue20.text.ToString ();
		tutorialDialogue20.text = "";
		pressEnterMessage = pressEnter.text.ToString ();
		pressEnter.text = "";
		
		inTutorialMV = inTutorialTC = inTutorialGL = inTutorialBC = inTutorialHDC = false;
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
				Debug.Log ("C'mon");
				if (messageCurrentlyOn == 6) {
					messageCurrentlyOn += 1;
					Time.timeScale = 0f;
					startPart3 = true;
				} else if (messageCurrentlyOn == 12) {
					messageCurrentlyOn += 1;
					Time.timeScale = 0f;
					startPart4 = true;
				} else if (messageCurrentlyOn == 13) {
					messageCurrentlyOn += 1;
					Time.timeScale = 0f;
					startPart4 = true;
				} else if (messageCurrentlyOn == 14) {
					Time.timeScale = 0f;
					startPart4 = true;
				}

				freezeTime = false;
				freezeTimeCtr = 0f;
			}
		}
		
		if (doneTypingMessage) {
			typingDelayCtr += Time.unscaledDeltaTime;
			if (typingDelayCtr >= typingDelay) {
				if ((messageCurrentlyOn != 4) && (messageCurrentlyOn != 6) && (messageCurrentlyOn != 9) 
				    && (messageCurrentlyOn != 12) && (messageCurrentlyOn != 13) && (messageCurrentlyOn != 14)
				    && (messageCurrentlyOn != 17) && (messageCurrentlyOn != 19)) {
					pressEnter.text = pressEnterMessage;
				} else {
					doneTypingMessage = false;
				}
				if (Input.GetButtonUp ("Next") && doneTypingMessage && (messageCurrentlyOn != 4) && 
				    (messageCurrentlyOn != 6) && (messageCurrentlyOn != 9) && (messageCurrentlyOn != 12) &&
				    (messageCurrentlyOn != 13) && (messageCurrentlyOn != 14) && (messageCurrentlyOn != 17)
				    && (messageCurrentlyOn != 19)) {
					//Debug.Log (messageCurrentlyOn.ToString ());
					
					messageCurrentlyOn += 1;
					if ((messageCurrentlyOn >= 1) && (messageCurrentlyOn <= 3)) {
						startPart1 = true;
					} else if ((messageCurrentlyOn >= 4) && (messageCurrentlyOn <= 6)) {
						startPart2 = true;
					} else if ((messageCurrentlyOn >= 7) && (messageCurrentlyOn <= 9)) {
						startPart3 = true;
					} else if ((messageCurrentlyOn >= 10) && (messageCurrentlyOn <= 14)) {
						startPart4 = true;
					} else if ((messageCurrentlyOn >= 15) && (messageCurrentlyOn <= 19)) {
						startPart5 = true;
					} else if ((messageCurrentlyOn >= 20) || (messageCurrentlyOn <= 21)) {
						startPart6 = true;
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
				instantiateHelperDot.Instantiate ();
				tutorialDialogue2.text = "";
				tutorialDialogue2.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage3, tutorialDialogue3));
				startPart1 = StartController ();
				inTutorialGL = true;
				inTutorialHDC = true;
				messageCurrentlyOn += 1;
			}
		} else if (startPart2) {
			if (messageCurrentlyOn == 4) {
				tutorialDialogue3.text = "";
				tutorialDialogue3.gameObject.SetActive (false);
				messageCurrentlyOn += 1;
				Debug.Log ("Time for part 2");
			} else if (messageCurrentlyOn == 5) {
				StartCoroutine (TypeTutorial (tutorialMessage4, tutorialDialogue4));
				startPart2 = StartController ();
			} else if (messageCurrentlyOn == 6) {
				tutorialDialogue4.text = "";
				tutorialDialogue4.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage5, tutorialDialogue5));
				startPart2 = StartController ();
				inTutorialGL = true;
				inTutorialBC = true;
				//messageCurrentlyOn += 1;
			}
		} else if (startPart3) {
			if (messageCurrentlyOn == 7) {
				tutorialDialogue5.text = "";
				tutorialDialogue5.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage6, tutorialDialogue6));
				startPart3 = StartController ();
			} else if (messageCurrentlyOn == 8) {
				instantiateHelperDot.Instantiate ();
				tutorialDialogue6.text = "";
				tutorialDialogue6.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage7, tutorialDialogue7));
				startPart3 = StartController ();
				//messageCurrentlyOn += 1;
			} else if (messageCurrentlyOn == 9) {
				Debug.Log ("now at 9");
				tutorialDialogue7.text = "";
				tutorialDialogue7.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage8, tutorialDialogue8));
				startPart3 = StartController ();
				inTutorialGL = true;
				inTutorialHDC = true;
				//inTutorialGL = true;
				//messageCurrentlyOn += 1;
			} 
		} else if (startPart4) {
			if (messageCurrentlyOn == 10) {
				tutorialDialogue8.text = "";
				tutorialDialogue8.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage11, tutorialDialogue11));
				startPart4 = StartController ();
				//inTutorialGL = true;
				//messageCurrentlyOn += 1;
			}
			else if (messageCurrentlyOn == 11) {
				//instantiateHelperDot.Instantiate ();
				tutorialDialogue11.text = "";
				tutorialDialogue11.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage12, tutorialDialogue12));
				startPart4 = StartController ();
				//messageCurrentlyOn += 1;
			}
			else if (messageCurrentlyOn == 12) {
				tutorialDialogue12.text = "";
				tutorialDialogue12.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage13, tutorialDialogue13));
				startPart4 = StartController ();
				inTutorialGL = true;
				//messageCurrentlyOn += 1;
			}
			else if (messageCurrentlyOn == 13) {
				instantiateHelperDot.Instantiate ();
				tutorialDialogue13.text = "";
				tutorialDialogue13.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage14, tutorialDialogue14));
				startPart4 = StartController ();
				inTutorialGL = true;
				inTutorialHDC = true;
			}
			else if (messageCurrentlyOn == 14) {
				instantiateHelperDot.Instantiate ();
				tutorialDialogue14.text = "";
				tutorialDialogue14.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage15, tutorialDialogue15));
				startPart4 = StartController ();
				inTutorialGL = true;
				inTutorialHDC = true;
				//messageCurrentlyOn += 1;
			}
		} else if (startPart5) {
			if (messageCurrentlyOn == 15) {
				tutorialDialogue15.text = "";
				tutorialDialogue15.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage16, tutorialDialogue16));
				startPart5 = StartController ();
			}
			else if (messageCurrentlyOn == 16) {
				tutorialDialogue16.text = "";
				tutorialDialogue16.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage17, tutorialDialogue17));
				startPart5 = StartController ();
				inTutorialTC = true;
				messageCurrentlyOn += 1;
			}
			else if (messageCurrentlyOn == 17) {
				tutorialDialogue17.text = "";
				tutorialDialogue17.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage18, tutorialDialogue18));
				startPart5 = StartController ();
				messageCurrentlyOn += 1;
			}
			if (messageCurrentlyOn == 19) {
				tutorialDialogue18.text = "";
				tutorialDialogue18.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage19, tutorialDialogue19));
				startPart5 = StartController ();
				inTutorialGL = true;
				//messageCurrentlyOn += 1;
			}
		} else if (startPart6) {
			if (messageCurrentlyOn == 20) {
				//Time.timeScale = 0f;
				tutorialDialogue19.text = "";
				tutorialDialogue19.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage20, tutorialDialogue20));
				startPart6 = StartController ();
				//messageCurrentlyOn += 1;
			}
			else if (messageCurrentlyOn == 21) {
				Application.LoadLevel (Application.loadedLevel + 1);
			}
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
