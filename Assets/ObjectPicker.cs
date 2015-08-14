using UnityEngine;
using System.Collections;

public class ObjectPicker : MonoBehaviour {

	public TextMesh RealText;
	public TextMesh FunText;
	public TextMesh GeeksText;

	public GameObject ContentPlane;

	public Texture Real;
	public Texture Fun;
	public Texture Geeks;

	public Camera Cam;


	private Ray ray;
	private RaycastHit hit;

	private Color _realColor;
	private Color _funColor;
	private Color _geeksColor;



	// Use this for initialization
	void Start () {
		_realColor = new Color(0.4314725f, 0.6392157f, 0.24313725f); // Green
		_funColor = new Color(0.9843137f, 0.717647f, 0.1686275f);    // Yellow
		_geeksColor = new Color(0.87451f, 0.24313725f, 0.254902f);   // Red
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount == 1) {
			var touch = Input.touches[0];

			//figure out what object was touched
			ray = Cam.ScreenPointToRay(touch.position);

			if(touch.phase == TouchPhase.Began && Physics.Raycast(ray, out hit))
			{
				Debug.Log("Hit: " + hit.collider.name);

				switch(hit.collider.name)
				{
				case "RealText":
					ContentPlane.GetComponent<Renderer>().material.mainTexture = Real;

					//selection code goes here...
					RealText.color = Color.blue;
					FunText.color = _funColor;
					GeeksText.color = _geeksColor;
					break;
				case "FunText":
					ContentPlane.GetComponent<Renderer>().material.mainTexture = Fun;

					//selection code goes here...
					RealText.color = _realColor;
					FunText.color = Color.blue;
					GeeksText.color = _geeksColor;


					break;
				case "GeeksTexts":
					
					ContentPlane.GetComponent<Renderer>().material.mainTexture = Geeks;

					//selection code goes here...
					RealText.color = _realColor;
					FunText.color = _funColor;
					GeeksText.color = Color.blue;
					break;
				}
			}
		}

	}
}
