using UnityEngine;
using System.Collections;

public class PawnMoveValidator : MoveValidator {

	private Piece piece;

	void Start(){
		piece = GetComponent<Piece> ();		
	}

	public override bool IsValidMove(Board board, Square dest){		
		var src = piece.GetCurrentSquare ();
		if (MoveForward (src, dest, board)) {
			return true;
		} else if(TakeDiagonal(src, dest, board)) {
			return true;
		}
		return false;
	}

	bool MoveForward(Square src, Square dst, Board board) {
		if (!dst.IsEmpty ())
			return false;
		
		if (piece.colour == Piece.PieceColour.WHITE) {			
			if (src.col == dst.col && (src.row + 1) == dst.row) {
				return true;
			}
		} else {
			if (src.col == dst.col && (src.row - 1) == dst.row) {
				return true;
			}
		}
		return false;
	}

	bool TakeDiagonal(Square src, Square dst, Board board){
		// Square must be occupied
		if (dst.IsEmpty ()) {
			return false;
		}

		// Square must contain opposite colour
		if (dst.GetPiece ().colour == src.GetPiece().colour) {
			return false;
		}

		// Square must be in adjacent column
		if (Mathf.Abs(src.col - dst.col) != 1) {
			return false;
		}

		if (piece.colour == Piece.PieceColour.WHITE) {			
			if ((src.row+1) == dst.row) {
				return true;
			}
		} else {
			if ((src.row- 1) == dst.row) {
				return true;
			}
		}

		return false;
	}
}
