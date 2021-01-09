using System;
using System.Collections.Generic;

class Chess {
	static int[,] Board = new int[10,10];
	static int PieceMove;
	static int MoveCount;
	static bool Turn = true; // T=White, F=Black
	static bool Gameover = false;
	static string UserInput;
	static string CurrentSystemMessage;
	static List<int> Moves = new List<int>();

  static void Main () {
		Game();
  }

	static void Game(){
		MoveCount = 1;
		GameSet();
		DrawBoard();
		CurrentSystemMessage = "Move : ";
		while(!Gameover){
			GetMove();
		}
	}


	static void GetMove(){
		DrawBoard();
		Console.Write(CurrentSystemMessage);
		bool InputChecker = true;
		while(InputChecker){
			UserInput = Console.ReadLine();
			if(SuitMove(UserInput)){
				InputChecker = !InputChecker; // Correct input
				Board[UserInput[2] - '`', UserInput[3] - '0'] = Board[UserInput[0] - '`', UserInput[1] - '0'];
				Board[UserInput[0] - '`', UserInput[1] - '0'] = 0;
				Turn = !Turn;
				if(Turn) MoveCount++;
				CurrentSystemMessage = "Move : ";
			}
			else CurrentSystemMessage = "System>\nInput isn't accepted. Please check your input.\nMove : ";
			DrawBoard();
			Console.Write(CurrentSystemMessage);
		}
	}

	static bool SuitMove(string move){
		try{
			switch (Board[move[0] - '`', move[1] - '0'] / 10){	// check turn
				case 0 :
					return false;
				case 1 :
					if(!Turn) return false;
					break;
				case 2 :
					if(Turn) return false;
					break;
			}
			return true;
		}
		catch(Exception ex){
			return false;
		}
	}

	static void GameSet(){
		Board[1, 1] = Board[8, 1] = 13;								// Rook
		Board[2, 1] = Board[7, 1] = 15;								// Knight
		Board[3, 1] = Board[6, 1] = 14;								// Bishop
		Board[4, 1] = 12;															// Queen
		Board[5, 1] = 11;															// King
		for(int i = 1; i < 9; i++) Board[i, 2] = 16;	// Pawn
		Board[1, 8] = Board[8, 8] = 23;
		Board[2, 8] = Board[7, 8] = 25;
		Board[3, 8] = Board[6, 8] = 24;
		Board[4, 8] = 22;
		Board[5, 8] = 21;
		for(int i = 1; i < 9; i++) Board[i, 7] = 26;
	}

	static void DrawBoard(){
		Console.Clear();
		Console.ResetColor();
		Console.Write(Turn ? "  White Move" : "  Black Move");
		Console.Write($"{MoveCount, 6}\n");
		for(int j = 8; j > 0; j--){
			Console.ResetColor();
			Console.Write($"{j} ");
			for(int i = 1; i < 9; i++){
				if((i + j) % 2 == 1) Console.BackgroundColor = ConsoleColor.Gray;
				else Console.BackgroundColor = ConsoleColor.Blue;
				Console.ForegroundColor = ConsoleColor.Black;
				switch (Board [i, j]){
					case 11:
						Console.Write("♔ ");
						break;
					case 12:
						Console.Write("♕ ");
						break;
					case 13:
						Console.Write("♖ ");
						break;
					case 14:
						Console.Write("♗ ");
						break;
					case 15:
						Console.Write("♘ ");
						break;
					case 16:
						Console.Write("♙ ");
						break;
					case 21:
						Console.Write("♚ ");
						break;
					case 22:
						Console.Write("♛ ");
						break;
					case 23:
						Console.Write("♜ ");
						break;
					case 24:
						Console.Write("♝ ");
						break;
					case 25:
						Console.Write("♞ ");
						break;
					case 26:
						Console.Write("♟ ");
						break;
					default:
						Console.Write("  ");
						break;
				}
				if(i == 8) Console.Write("\n");
			}
		}
		Console.ResetColor();
		Console.WriteLine("  ａｂｃｄｅｆｇｈ\n");
	}
}