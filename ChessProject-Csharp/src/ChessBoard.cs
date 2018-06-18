using System;
using System.Collections.Generic;
namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public static readonly int MaxBoardWidth = 7;
        public static readonly int MaxBoardHeight = 7;
        public Dictionary<PieceType, PieceInfo> boardInfo = new Dictionary<PieceType, PieceInfo>();
        private Piece[,] pieces;

        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        public void Add(Pawn pawn, int xCoordinate, int yCoordinate, PieceColor pieceColor)
        {
            // Avoid adding too many pieces and avoid illegal positions
            if (pieceColor == PieceColor.Black && GetBoardInfo(PieceType.Pawn, PieceColor.Black) >= MaxBoardWidth ||
                pieceColor == PieceColor.White && GetBoardInfo(PieceType.Pawn, PieceColor.White) >= MaxBoardWidth ||
                !IsLegalBoardPosition(xCoordinate,yCoordinate))
            {
                // Set pawn coordinates outside of chessboard
                pawn.XCoordinate = -1;
                pawn.YCoordinate = -1;

                return;
            }
            // Assign coordinates to piece
            pawn.XCoordinate = xCoordinate;
            pawn.YCoordinate = yCoordinate;
            // Add to chessboard
            pieces[xCoordinate, yCoordinate] = pawn;
            // Increment number of pieces
            UpdateBoardInfo(PieceType.Pawn, pieceColor);
        }
        /// <summary>
        /// Returns the number of pieces of the specified type and color that are on the board.
        /// </summary>
        public int GetBoardInfo(PieceType pieceType, PieceColor pieceColor)
        {
            PieceInfo pieceInfo = new PieceInfo(0, 0);
            if (boardInfo.TryGetValue(pieceType, out pieceInfo))
            {
                switch (pieceColor)
                {
                    case PieceColor.Black:
                        return pieceInfo.black;
                    case PieceColor.White:
                        return pieceInfo.white;
                    default:
                        break;
                }
            }
            return 0;
        }
        /// <summary>
        /// Updates the number of pieces of the specified type and color that are on the board.
        /// </summary>
        public void UpdateBoardInfo(PieceType pieceType, PieceColor pieceColor)
        {
            PieceInfo pieceInfo = new PieceInfo(0, 0);
            switch (pieceColor)
            {
                case PieceColor.Black:
                    // Increment the number of black pieces of the current piece type
                    if (boardInfo.TryGetValue(pieceType, out pieceInfo))
                        pieceInfo.black++;
                    // Create new PieceInfo entry in dictionary and increment the number of
                    // black pieces of the current piece type
                    else
                        boardInfo.Add(pieceType, new PieceInfo(1, 0));
                    break;
                case PieceColor.White:
                    // Increment the number of white pieces of the current piece type
                    if (boardInfo.TryGetValue(pieceType, out pieceInfo))
                        pieceInfo.white++;
                    // Create new PieceInfo entry in dictionary and increment the number of
                    // white pieces of the current piece type
                    else
                        boardInfo.Add(pieceType, new PieceInfo(0, 1));
                    break;
            }
        }

        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            // Check if coordinates are inside chessboard bounds
            return (xCoordinate < MaxBoardWidth && yCoordinate < MaxBoardHeight &&
                    xCoordinate >= 0 && yCoordinate >= 0 && pieces[xCoordinate, yCoordinate] == null);
        }

    }
}
