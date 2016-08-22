using UnityEngine;
using System.Collections;

public class KingMoveValidator : MoveValidator {

	private Piece piece;

	void Start(){
		piece = GetComponent<Piece> ();
	}
	public override bool IsValidMove(Board board, Square dst){		
		var src = piece.GetCurrentSquare ();
		if (MoveDiagonal (src, dst, board)) {
			return true;
		} else if (MoveStraight (src, dst, board)) {
			return true;
		}
		return false;
	}

	bool MoveDiagonal(Square src, Square dst, Board board){
		int rowDelta = (dst.row - src.row);
		int colDelta = (dst.col - src.col);

		// Must move diagonally
		if (Mathf.Abs(rowDelta) != Mathf.Abs(colDelta))
			return false;

		// Cant jump onto your own piece
		if(!dst.IsEmpty() && (dst.GetPiece().colour == src.GetPiece().colour)){
			return false;
		}

		// Cant move more than 1 square
		if (Mathf.Abs (rowDelta) > 1)
			return false;

		// Cant move more than 1 square
		if (Mathf.Abs (colDelta) > 1)
			return false;
		
		// Normalise direction
		if (rowDelta != 0)
			rowDelta /= Mathf.Abs (rowDelta);
		if (colDelta != 0)
			colDelta /= Mathf.Abs (colDelta);

		int row = src.row+rowDelta;
		int col = src.col+colDelta;
		while (row != dst.row && col != dst.col) {
			if (!board.GetSquare (row, col).IsEmpty ())
				return false;

			row += rowDelta;
			col += colDelta;
		}

		return true;
	}

	bool MoveStraight(Square src, Square dst, Board board){
		int rowDelta = (dst.row - src.row);
		int colDelta = (dst.col - src.col);

		// Must move straight
		if (rowDelta != 0 && colDelta != 0)
			return false;

		// Cant move more than 1 square
		if (Mathf.Abs (rowDelta) > 1)
			return false;

		// Cant move more than 1 square
		if (Mathf.Abs (colDelta) > 1)
			return false;
		
		if (rowDelta != 0)
			rowDelta /= Mathf.Abs (rowDelta);
		if (colDelta != 0)
			colDelta /= Mathf.Abs (colDelta);

		// Cant jump onto your own piece
		if(!dst.IsEmpty() && (dst.GetPiece().colour == src.GetPiece().colour)){
			return false;
		}

		int row = src.row+rowDelta;
		int col = src.col+colDelta;
		while (!((row == dst.row) && (col == dst.col))) {
			if (!board.GetSquare (row, col).IsEmpty ())
				return false;
			row += rowDelta;
			col += colDelta;
		}

		return true;
	}
}
