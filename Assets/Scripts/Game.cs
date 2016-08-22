using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	public Piece.PieceColour playersTurn = Piece.PieceColour.WHITE;
	public Piece selectedPiece = null;
	public Board board = null;
	public GameObject highlight = null;
	public GameObject turnIndicator = null;

	void Start () {
		ClearSelection ();
	}

	public void SquareSelected(Square square){
		// Selected a piece
		if (!square.IsEmpty() && square.GetPiece().colour == playersTurn) {
			SetSelection (square.GetPiece ());
			return;
		}

		// Selected a destination
		if (selectedPiece != null && selectedPiece.GetComponent<MoveValidator> ().IsValidMove (board, square)) {
			MovePiece (selectedPiece, square);
			NextTurn ();
			return;
		}
			
		ClearSelection();
	}

	void ClearSelection(){
		selectedPiece = null;
		highlight.SetActive (false);
	}

	void SetSelection(Piece piece){
		selectedPiece = piece;
		highlight.SetActive (true);
		highlight.transform.position = piece.transform.position;
	}

	void NextTurn() {
		ClearSelection ();
		if (playersTurn == Piece.PieceColour.WHITE) {
			playersTurn = Piece.PieceColour.BLACK;
			turnIndicator.GetComponent<Text> ().text = "Black Moves";
		} else {
			playersTurn = Piece.PieceColour.WHITE;
			turnIndicator.GetComponent<Text> ().text = "White Moves";
		}			
	}

	void MovePiece(Piece piece, Square square){
		if (!square.IsEmpty ()) {			
			Destroy (square.GetPiece().gameObject);
		}
		piece.gameObject.transform.SetParent (square.transform);
		piece.transform.localPosition = Vector3.zero;
	}
}
