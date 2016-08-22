using UnityEngine;
using System.Collections;

public class KnightMoveValidator : MoveValidator {

	private Piece piece;

	void Start() {
		piece = GetComponent<Piece> ();
	}

	public override bool IsValidMove(Board board, Square dst){
		var src = piece.GetCurrentSquare ();
		if (MoveJump (src, dst)) {
			return true;
		}
		return false;
	}

	bool MoveJump(Square src, Square dst){
		// Cant jump onto your own piece
		if(!dst.IsEmpty() && (dst.GetPiece().colour == src.GetPiece().colour)){
			return false;
		}

		if ((src.col - 2) == dst.col &&
			(src.row + 1) == dst.row) {
			return true;
		} else if((src.col - 1) == dst.col &&
			(src.row + 2) == dst.row){
			return true;
		} else if((src.col + 1) == dst.col &&
			(src.row + 2) == dst.row){
			return true;
		} else if((src.col + 2) == dst.col &&
			(src.row + 1) == dst.row){
			return true;
		} else if((src.col + 2) == dst.col &&
			(src.row - 1) == dst.row){
			return true;
		} else if((src.col + 1) == dst.col &&
			(src.row - 2) == dst.row){
			return true;
		} else if((src.col - 1) == dst.col &&
			(src.row - 2) == dst.row){
			return true;
		} else if((src.col - 2) == dst.col &&
			(src.row - 1) == dst.row){
			return true;
		}

		return false;
	}
}
