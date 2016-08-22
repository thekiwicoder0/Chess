using UnityEngine;
using System.Collections;

public class Board : MonoBehaviour {

	void Start(){
		
	}

	public Square GetSquare(int row, int col){
		int index = (row*8) + col;
		var square = transform.GetChild (index);
		return square.GetComponent<Square> ();
	}
}
