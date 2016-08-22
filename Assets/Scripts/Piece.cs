using UnityEngine;
using System.Collections;

public class Piece : MonoBehaviour {

	public enum PieceType{
		Pawn,
		Castle,
		Knight,
		Bishop,
		Queen,
		King
	};

	public enum PieceColour{
		BLACK,
		WHITE
	};

	public PieceType type;
	public PieceColour colour;

	public Square GetCurrentSquare(){
		return gameObject.transform.parent.GetComponent<Square> ();
	}
}
