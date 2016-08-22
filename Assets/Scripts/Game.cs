using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public Piece.PieceColour playersTurn = Piece.PieceColour.WHITE;
	public Piece selectedPiece = null;
	public Board board = null;

	void Start () {
		board = GameObject.FindObjectOfType<Board> ();
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
				selectedPiece = piece;
			}
		} else {
			if (selectedPiece.GetComponent<MoveValidator> ().IsValidMove (board, square)) {
				MovePiece (selectedPiece, square);
				NextTurn ();
			} else {
				ClearSelection ();
			}
		}
	}

	void ClearSelection(){
		selectedPiece = null;
	}

	void NextTurn() {
		ClearSelection ();

		if (playersTurn == Piece.PieceColour.WHITE) {
			playersTurn = Piece.PieceColour.BLACK;
		} else {
			playersTurn = Piece.PieceColour.WHITE;
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
