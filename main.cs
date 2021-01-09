using System;
using System.Collections.Generic;

class Chess {
	static int wk, wq, wkr, wqr, wkb, wqb, wkn, wqn, wp1, wp2, wp3, wp4, wp5, wp6, wp7, wp8;
	static int bk, bq, bkr, bqr, bkb, bqb, bkn, bqn, bp1, bp2, bp3, bp4, bp5, bp6, bp7, bp8;
	static int[,] Board = new int[10, 10];
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
				InputChecker = !InputChecker; // Correct InputChecker
				Turn = !Turn;
				if(Turn) MoveCount++;
				CurrentSystemMessage = "Move : ";
			}
			else CurrentSystemMessage = "System>\nInput isn't accepted. Please check your input.\nMove : ";
			DrawBoard();
			Console.Write(CurrentSystemMessage);
		}
	}

	static bool SuitMove(string Move){
		try{
			int Now = Board[Move[0] - '`', Move[1] - '0'];
			int Next = Board[Move[2] - '`', Move[3] - '0'];
			switch (Now / 10){	// check turn
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

	static bool CheckPiece(int Now, int Next, string Move, bool Turn){
		switch (Now % 10){
			case 1 :																		// King

				break;
			case 2 :																		// Queen
				break;
			case 3 :																		// Rook
				break;
			case 4 :																		// Bishop
				break;
			case 5 :																		// Knight
				break;
			case 6 :																		// Pawn
				break;
		}
		return false;
	}

	static void GameSet(){
		wk = 51;	wq = 41;	wkr = 81;	wqr = 11;
		wkb = 61;	wqb = 31;	wkn = 71;	wqn = 21;
		wp1 = 12; wp2 = 22; wp3 = 32; wp4 = 42;
		wp5 = 52; wp6 = 62; wp7 = 72; wp8 = 82;

		bk = 58;	bq = 48;	bkr = 88;	bqr = 18;
		bkb = 68;	bqb = 38;	bkn = 78;	bqn = 28;
		bp1 = 17; bp2 = 27; bp3 = 37; bp4 = 47;
		bp5 = 57; bp6 = 67; bp7 = 77; bp8 = 87;
	}

	static void GetBoardInfo(){
		for(int i = 0; i < 10; i++){
			for(int j = 0; j < 10; j++) Board[i, j] = 0;
		}
		Board[wk / 10, wk % 10] = 11;	Board[wq / 10, wq % 10] = 12;	Board[wkr / 10, wkr % 10] = 13;	Board[wqr / 10, wqr % 10] = 13;
		Board[wkb / 10, wkb % 10] = 14;	Board[wqb / 10, wqb % 10] = 14;	Board[wkn / 10, wkn % 10] = 15;	Board[wqn / 10, wqn % 10] = 15;
		Board[wp1 / 10, wp1 % 10] = 16;	Board[wp2 / 10, wp2 % 10] = 16;	Board[wp3 / 10, wp3 % 10] = 16;	Board[wp4 / 10, wp4 % 10] = 16;
		Board[wp5 / 10, wp5 % 10] = 16;	Board[wp6 / 10, wp6 % 10] = 16;	Board[wp7 / 10, wp7 % 10] = 16;	Board[wp8 / 10, wp8 % 10] = 16;

		Board[bk / 10, bk % 10] = 21;	Board[bq / 10, bq % 10] = 22;	Board[bkr / 10, bkr % 10] = 23;	Board[bqr / 10, bqr % 10] = 23;
		Board[bkb / 10, bkb % 10] = 24;	Board[bqb / 10, bqb % 10] = 24;	Board[bkn / 10, bkn % 10] = 25;	Board[bqn / 10, bqn % 10] = 25;
		Board[bp1 / 10, bp1 % 10] = 26;	Board[bp2 / 10, bp2 % 10] = 26;	Board[bp3 / 10, bp3 % 10] = 26;	Board[bp4 / 10, bp4 % 10] = 26;
		Board[bp5 / 10, bp5 % 10] = 26;	Board[bp6 / 10, bp6 % 10] = 26;	Board[bp7 / 10, bp7 % 10] = 26;	Board[bp8 / 10, bp8 % 10] = 26;
	}

	static void DrawBoard(){
		GetBoardInfo();
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