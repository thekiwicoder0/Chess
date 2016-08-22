using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Square : MonoBehaviour {

	public Game game;
	private UnityAction action;
	public int row;
	public int col;

	void Start () {
		action = new UnityAction (OnClick);
		game = GameObject.FindObjectOfType<Game> ();
		GetComponent<Button> ().onClick.AddListener (action);
		row = GetRow ();
		col = GetCol ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick() {
		game.SquareSelected (this);
	}

	public bool IsEmpty() {
		return GetComponentInChildren<Piece> () == null;
	}

	public Piece GetPiece(){
		return GetComponentInChildren<Piece> ();
	}

	private int GetRow() {
		return Mathf.FloorToInt(transform.GetSiblingIndex () / 8.0f);
	}

	private int GetCol() {
		return transform.GetSiblingIndex () % 8;
	}

}
