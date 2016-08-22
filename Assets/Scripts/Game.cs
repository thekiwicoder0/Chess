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
		if (selectedPiece != null) {
			if (selectedPiece.GetComponent<MoveValidator> ().IsValidMove (board, square)) {
				MovePiece (selectedPiece, square);
				NextTurn ();
			} else {
				ClearSelection ();
			}
		}
	}

	public void PieceSelected(Square square, Piece piece){
		if (selectedPiece == null) {
			if (piece.colour == playersTurn) {
				SetSelection (piece);
			}
		} else {
			if (selectedPiece.GetComponent<MoveValidator> ().IsValidMove (board, square)) {
				MovePiece (selectedPiece, square);
				NextTurn ();
			} else if (piece.colour == playersTurn) {
				SetSelection (piece);
			} else {
				ClearSelection ();
			}
		}
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
			var take = square.GetPiece();
			Destroy (take.gameObject);
		}
		piece.gameObject.transform.SetParent (square.transform);
		piece.transform.localPosition = Vector3.zero;
	}
}
