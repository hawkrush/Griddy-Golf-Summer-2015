using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialControllerLvl1 : MonoBehaviour {

	public GridLinesTut01 gridLines;
	public TriangleControllerTut01 triangleController;
	public ManipulateVerticesTut01 manipulateVertices;
	public GameObject orientationPart1, orientationPart2;

	public GameObject tutorialPanel;
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
	private Text pressEnter;

	private float characterDelay = 0.01f;
	private string tutorialMessage1, tutorialMessage2, tutorialMessage3, tutorialMessage4, tutorialMessage5;
	private string tutorialMessage6, tutorialMessage7, tutorialMessage8, tutorialMessage9, tutorialMessage10, tutorialMessage11;
	private string tutorialMessage12, tutorialMessage13, tutorialMessage14, tutorialMessage15, tutorialMessage16;
	private string tutorialMessage17, tutorialMessage18, tutorialMessage19, tutorialMessage20, tutorialMessage21;
	private string tutorialMessage22, tutorialMessage23, tutorialMessage24, tutorialMessage25;
	private string pressEnterMessage;

	private bool doneTypingMessage;
	public bool freezeTime;

	private float typingDelayCtr;
	private float typingDelay;
	private float freezeTimeCtr = 0f;

	public int messageCurrentlyOn = 1;
	public int count = 0;
	
	public bool startPart1, startPart2, startPart3, startPart4, startPart5, startPart6, startPart7;
	public bool inTutorialMV, inTutorialTC, inTutorialGL, inTutorialBC, inTutorialTDC, inTutorialAT;
	public bool psuedoInTut;

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
		tutorialDialogue9 = GameObject.Find ("Tutorial Text 9").GetComponent<Text> ();
		tutorialDialogue10 = GameObject.Find ("Tutorial Text 10").GetComponent<Text> ();
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
		tutorialDialogue21 = GameObject.Find ("Tutorial Text 21").GetComponent<Text> ();
		tutorialDialogue22 = GameObject.Find ("Tutorial Text 22").GetComponent<Text> ();
		tutorialDialogue23 = GameObject.Find ("Tutorial Text 23").GetComponent<Text> ();
		tutorialDialogue24 = GameObject.Find ("Tutorial Text 24").GetComponent<Text> ();
		tutorialDialogue25 = GameObject.Find ("Tutorial Text 25").GetComponent<Text> ();

		pressEnter = GameObject.Find ("Press Enter to Continue").GetComponent<Text> ();

		startPart1 = true;
		startPart2 = startPart3 = startPart4 = startPart5 = startPart6 = startPart7 = false;

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

		pressEnterMessage = pressEnter.text.ToString ();
		pressEnter.text = "";

		inTutorialMV = inTutorialTC = inTutorialGL = inTutorialBC = inTutorialTDC = inTutorialAT = false;
		psuedoInTut = false;
		freezeTime = false;

		typingDelayCtr = 0f;
		typingDelay = 0.5f;
		freezeTimeCtr = 0f;

		StartCoroutine (TypeTutorial (tutorialMessage1, tutorialDialogue1));
		startPart1 = StartController ();
	}
	
	// Update is called once per frame
	void Update () {
		if (freezeTime) {
			freezeTimeCtr += Time.unscaledDeltaTime;
			if (freezeTimeCtr >= 0.2f) {
				startPart6 = true;
				freezeTime = false;
			}
		}

		if (doneTypingMessage) {
			typingDelayCtr += Time.unscaledDeltaTime;
			if (typingDelayCtr >= typingDelay) {
				if ((messageCurrentlyOn != 4) && (messageCurrentlyOn != 6) && (messageCurrentlyOn != 11) 
				    && (messageCurrentlyOn != 13) && (messageCurrentlyOn != 15) && (messageCurrentlyOn != 16)
				    && (messageCurrentlyOn != 18) && (messageCurrentlyOn != 20) && (messageCurrentlyOn != 21)) {
					pressEnter.text = pressEnterMessage;
					//typingDelayCtr = 0f;
				} else {
					doneTypingMessage = false;
					typingDelayCtr = 0f;
				}
				if (Input.GetButtonUp ("Next") && doneTypingMessage && (messageCurrentlyOn != 4) && 
				    (messageCurrentlyOn != 6) && (messageCurrentlyOn != 11) && (messageCurrentlyOn != 13) &&
				    (messageCurrentlyOn != 15) && (messageCurrentlyOn != 16) && (messageCurrentlyOn != 18) &&
				    (messageCurrentlyOn != 20) && (messageCurrentlyOn != 21)) {
					//Debug.Log (messageCurrentlyOn.ToString ());

					messageCurrentlyOn += 1;
					//if (messageCurrentlyOn == 20) {
					//	messageCurrentlyOn += 1;
					//}

					if ((messageCurrentlyOn >= 1) && (messageCurrentlyOn <= 6)) {
						startPart1 = true;
					} else if ((messageCurrentlyOn >= 7) && (messageCurrentlyOn <= 11)) {
						startPart2 = true;
					} else if ((messageCurrentlyOn >= 12) && (messageCurrentlyOn <= 18)) {
						startPart3 = true;
					} else if ((messageCurrentlyOn >= 19) && (messageCurrentlyOn <= 25)) {
						startPart4 = true;
					} else if (messageCurrentlyOn >= 26) {
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
				tutorialDialogue1.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage2, tutorialDialogue2));
				startPart1 = StartController ();
			}
			else if (messageCurrentlyOn == 3) {
				tutorialDialogue2.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage3, tutorialDialogue3));
				startPart1 = StartController ();
			}
			else if (messageCurrentlyOn == 4) {
				tutorialDialogue3.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage4, tutorialDialogue4));
				startPart1 = StartController ();
				inTutorialBC = true;
			}
			else if (messageCurrentlyOn == 5) {
				tutorialDialogue4.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage5, tutorialDialogue5));
				startPart1 = StartController ();
			}
			else if (messageCurrentlyOn == 6) {
				Debug.Log ("c'mon");
				tutorialDialogue5.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage6, tutorialDialogue6));
				startPart1 = StartController ();
				inTutorialGL = true;
			}
		} else if (startPart2) {
			if (messageCurrentlyOn == 7) {
				tutorialDialogue6.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage7, tutorialDialogue7));
				startPart2 = StartController ();
			}
			else if (messageCurrentlyOn == 8) {
				tutorialDialogue7.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage8, tutorialDialogue8));
				startPart2 = StartController ();
			}
			else if (messageCurrentlyOn == 9) {
				tutorialDialogue8.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage9, tutorialDialogue9));
				startPart2 = StartController ();
			}
			else if (messageCurrentlyOn == 10) {
				tutorialDialogue9.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage10, tutorialDialogue10));
				startPart2 = StartController ();
			}
			else if (messageCurrentlyOn == 11) {
				tutorialDialogue10.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage11, tutorialDialogue11));
				startPart2 = StartController ();
				inTutorialGL = true;
				inTutorialBC = true;
			}
		} else if (startPart3) {
			if (messageCurrentlyOn == 12) {
				tutorialDialogue11.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage12, tutorialDialogue12));
				startPart3 = StartController ();
				//inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 13) {
				tutorialDialogue12.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage13, tutorialDialogue13));
				startPart3 = StartController ();
				inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 14) {
				tutorialDialogue13.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage14, tutorialDialogue14));
				startPart3 = StartController ();
				//inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 15) {
				tutorialDialogue14.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage15, tutorialDialogue15));
				startPart3 = StartController ();
				inTutorialTDC = true;
				//inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 16) {
				tutorialDialogue15.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage16, tutorialDialogue16));
				startPart3 = StartController ();
				inTutorialTDC = true;
				//inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 17) {
				tutorialDialogue16.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage17, tutorialDialogue17));
				startPart3 = StartController ();
				//inTutorialTDC = true;
				//inTutorialGL = true;
			}
			else if (messageCurrentlyOn == 18) {
				tutorialDialogue17.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage18, tutorialDialogue18));
				startPart3 = StartController ();
				inTutorialAT = true;
			}
		} else if (startPart4) {
			if (messageCurrentlyOn == 19) {
				tutorialDialogue18.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage19, tutorialDialogue19));
				startPart4 = StartController ();
				//messageCurrentlyOn += 1;
				inTutorialAT = true;
			}
			else if (messageCurrentlyOn == 20) {
				tutorialDialogue19.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage20, tutorialDialogue20));
				startPart4 = StartController ();
				inTutorialAT = true;
			}
			else if (messageCurrentlyOn == 21) {
				tutorialDialogue20.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage21, tutorialDialogue21));
				startPart4 = StartController ();
				inTutorialGL = true;
				inTutorialBC = true;
			}
			else if (messageCurrentlyOn == 22) {
				tutorialDialogue21.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage22, tutorialDialogue22));
				startPart4 = StartController ();
				//inTutorialAT = true;
			}
			else if (messageCurrentlyOn == 23) {
				tutorialDialogue22.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage23, tutorialDialogue23));
				startPart4 = StartController ();
				//inTutorialAT = true;
			}
			else if (messageCurrentlyOn == 24) {
				tutorialDialogue23.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage24, tutorialDialogue24));
				startPart4 = StartController ();
				//inTutorialAT = true;
			}
			else if (messageCurrentlyOn == 25) {
				tutorialDialogue24.gameObject.SetActive (false);
				StartCoroutine (TypeTutorial (tutorialMessage25, tutorialDialogue25));
				startPart4 = StartController ();
				//inTutorialAT = true;
			}
		} else if (startPart5) {
			orientationPart1.SetActive (false);
			Application.LoadLevel (Application.loadedLevel + 1);
		}
	}

	IEnumerator TypeTutorial (string message, Text tutDialogue) {
		int numOfChar = 0;
		bool psuedoAnimation = false;
		foreach (char c in message) {
			numOfChar += 1;
			float pauseEndTime = Time.realtimeSinceStartup + 0.0175f;
			psuedoAnimation = true;
			while (Time.realtimeSinceStartup < pauseEndTime) {
				typingDelayCtr = 0f;
				doneTypingMessage = false;
				if ((psuedoAnimation) && (messageCurrentlyOn == 8) && (numOfChar%12 == 0)) {
					//Debug.Log ("Create tutorial dots");
					if (count == 0) {
						triangleController.CreateGridDot (new Vector3 (2.0f, -12.3f, 26.7f));
					} else if (count == 1) {
						triangleController.CreateGridDot (new Vector3 (0.0f, -12.3f, 26.7f));
					} else if (count == 2) {
						triangleController.CreateGridDot (new Vector3 (2.0f, -12.3f, 28.7f));
					} else if (count == 3) {
						triangleController.CreateGridDot (new Vector3 (-2.5f, -12.3f, 34.7f));
					} else if (count == 4) {
						triangleController.CreateGridDot (new Vector3 (-5.0f, -12.3f, 32.7f));
					} else if (count == 5) {
						triangleController.CreateGridDot (new Vector3 (-2.0f, -12.3f, 30.2f));
					} else if (count == 6) {
						triangleController.CreateGridDot (new Vector3 (4.0f, -12.3f, 32.7f));
					} else if (count == 7) {
						triangleController.CreateGridDot (new Vector3 (8.0f, -12.3f, 32.7f));
					} else if (count == 8) {
						triangleController.CreateGridDot (new Vector3 (6.0f, -12.3f, 28.7f));
					}
					count++;
					psuedoAnimation = false;
				} else if ((psuedoAnimation) && (messageCurrentlyOn == 9) && (numOfChar%12 == 0)) {
					//Debug.Log ("Reset tutorial dots");
					if (count == 0) {
						triangleController.TutReset ();
					} else if (count == 1) {
						triangleController.TutReset ();
					} else if (count == 2) {
						triangleController.TutReset ();
					} else if (count == 3) {
						triangleController.TutReset ();
					} else if (count == 4) {
						triangleController.TutReset ();
					} else if (count == 5) {
						triangleController.TutReset ();
					} 
					count++;
					psuedoAnimation = false;
				} else if ((psuedoAnimation) && (messageCurrentlyOn == 12) && (numOfChar == 30)) {
					//Vector3 velocity = Vector3.zero;
					//orientationPart1.transform.position = Vector3.SmoothDamp (orientationPart1.transform.position, 
					                                                          //new Vector3 (-55f, orientationPart1.transform.position.y, orientationPart1.transform.position.z),
					                                                          //ref velocity,
					                                                          //1f);
					//orientationPart2.transform.position = Vector3.SmoothDamp (orientationPart2.transform.position, 
					                                                          //new Vector3 (-4.961178f, orientationPart2.transform.position.y, orientationPart2.transform.position.z),
					                                                          //ref velocity,
					                                                          //1f);
					orientationPart1.transform.Translate (new Vector3 (-51f, 0f, 0f));
					orientationPart2.transform.Translate (new Vector3 (-49.961178f, 0f, 0f));
					GameObject.Find ("Dots For Horizontal Grid Line").transform.parent = orientationPart2.transform; //-0.961178
					GameObject.Find ("Dots For Horizontal Grid Line").transform.position = new Vector3 (0f, GameObject.Find ("Dots For Horizontal Grid Line").transform.position.y, GameObject.Find ("Dots For Horizontal Grid Line").transform.position.z);
					GameObject.Find ("Dots For Vertical Grid Line").transform.parent = orientationPart2.transform;
					GameObject.Find ("Dots For Vertical Grid Line").transform.position = new Vector3 (0f, GameObject.Find ("Dots For Vertical Grid Line").transform.position.y, GameObject.Find ("Dots For Vertical Grid Line").transform.position.z);
					psuedoAnimation = false;
				} else if ((psuedoAnimation) && (messageCurrentlyOn == 20) && (numOfChar%12 == 0)) {
					if (count == 2) {
						psuedoInTut = true;
					}
					if (count == 4) {
						psuedoInTut = true;
					}
					if (count == 6) {
						inTutorialAT = true;
					}
					psuedoAnimation = false;
					count++;
				}
				yield return 0;
			}
			tutDialogue.text += c;
		}
		
		doneTypingMessage = true;
		count = 0;

		//Debug.Log ("Typing message: " + doneTypingMessage.ToString ());
		//Debug.Log (numOfChar.ToString ());
		
	}
	
	bool StartController () {
		return false;
	}
}
