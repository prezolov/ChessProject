using System;
using System.Collections.Generic;
namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        /// <summary>
        /// The maximum width of the chess board.
        /// </summary>
        public static readonly int MaxBoardWidth = 7;
        /// <summary>
        /// The maximum height of the chess board.
        /// </summary>
        public static readonly int MaxBoardHeight = 7;
        /// <summary>
        /// Used to keep track of the number of pieces placed on the board.
        /// </summary>
        public Dictionary<string, PieceInfo> boardInfo = new Dictionary<string, PieceInfo>();
        /// <summary>
        /// 2D array containing all of the pieces currently active on the board.
        /// </summary>
        private Piece[,] pieces;

        /// <summary>
        /// Chessboard constructor.
        /// </summary>
        public ChessBoard()
        {
            pieces = new Pawn[MaxBoardWidth, MaxBoardHeight];
        }

        /// <summary>
        /// Adds a piece to the chessboard, if possible.
        /// </summary>
        public void Add(Piece piece, int xCoordinate, int yCoordinate)
        {

            // Avoid adding too many pieces and avoid illegal positions
            if (piece.PieceColor == PieceColor.Black && GetBoardInfo(piece.GetType().Name, PieceColor.Black) >= piece.PieceLimit ||
                piece.PieceColor == PieceColor.White && GetBoardInfo(piece.GetType().Name, PieceColor.White) >= piece.PieceLimit ||
                !IsLegalBoardPosition(xCoordinate, yCoordinate))
            {
                // Set pawn coordinates outside of chessboard
                piece.XCoordinate = -1;
                piece.YCoordinate = -1;

                return;
            }
            // Assign coordinates to piece
            piece.XCoordinate = xCoordinate;
            piece.YCoordinate = yCoordinate;
            // Add to chessboard
            pieces[xCoordinate, yCoordinate] = piece;
            // Increment number of pieces
            UpdateBoardInfo(piece.GetType().Name, piece.PieceColor);
        }

        /// <summary>
        /// Returns the number of pieces of the specified type and color that are on the board.
        /// </summary>
        public int GetBoardInfo(string piece, PieceColor pieceColor)
        {
            PieceInfo pieceInfo = new PieceInfo(0, 0);
            // Check if key exists
            if (boardInfo.TryGetValue(piece, out pieceInfo))
            {
                switch (pieceColor)
                {
                    case PieceColor.Black:
                        return pieceInfo.black;
                    case PieceColor.White:
                        return pieceInfo.white;
                    default:
                        // Should never run
                        break;
                }
            }
            return 0;
        }
        /// <summary>
        /// Updates the number of pieces of the specified type and color that are on the board.
        /// </summary>
        public void UpdateBoardInfo(string piece, PieceColor pieceColor)
        {
            PieceInfo pieceInfo = new PieceInfo(0, 0);
            switch (pieceColor)
            {
                case PieceColor.Black:
                    // Increment the number of black pieces of the current piece type
                    if (boardInfo.TryGetValue(piece, out pieceInfo))
                        pieceInfo.black++;
                    // Create new PieceInfo entry in dictionary and increment the number of
                    // black pieces of the current piece type
                    else
                        boardInfo.Add(piece, new PieceInfo(1, 0));
                    break;
                case PieceColor.White:
                    // Increment the number of white pieces of the current piece type
                    if (boardInfo.TryGetValue(piece, out pieceInfo))
                        pieceInfo.white++;
                    // Create new PieceInfo entry in dictionary and increment the number of
                    // white pieces of the current piece type
                    else
                        boardInfo.Add(piece, new PieceInfo(0, 1));
                    break;
            }
        }
        /// <summary>
        /// Checks whether a specified coordinate is a legal board position.
        /// </summary>
        public bool IsLegalBoardPosition(int xCoordinate, int yCoordinate)
        {
            // Check if coordinates are inside chessboard bounds
            return (xCoordinate < MaxBoardWidth && yCoordinate < MaxBoardHeight &&
                    xCoordinate >= 0 && yCoordinate >= 0 && pieces[xCoordinate, yCoordinate] == null);
        }

    }
}
