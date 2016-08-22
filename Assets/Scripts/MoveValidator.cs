using UnityEngine;
using System.Collections;

public abstract class MoveValidator : MonoBehaviour {
	abstract public bool IsValidMove (Board board, Square square);
}
