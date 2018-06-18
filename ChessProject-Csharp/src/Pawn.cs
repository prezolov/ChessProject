using System;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Pawn class, can move only forward by 1 step.
    /// </summary>
    public class Pawn : Piece
    {
        public Pawn(PieceColor pieceColor) : base(pieceColor) { }
        /// <summary>
        /// Used to move a pawn around the chessboard, can also be used to capture other chess pieces.
        /// </summary>
        public override void Move(MovementType movementType, int newX, int newY)
        {
            // Move
            if (movementType == MovementType.Move)
            {
                // Black piece
                if (pieceColor == PieceColor.Black)
                {
                    if (yCoordinate - 1 == newY && newX == xCoordinate)
                    {
                        xCoordinate = newX;
                        yCoordinate = newY;
                    }
                }
                // White piece
                else
                {
                    if (yCoordinate + 1 == newY && newX == xCoordinate)
                    {
                        xCoordinate = newX;
                        yCoordinate = newY;
                    }
                }

            }
            // Capture
            else
            {
                // TODO: Implement in future
            }
        }

        public override string ToString()
        {
            return CurrentPositionAsString();
        }

        protected string CurrentPositionAsString()
        {
            return string.Format("Current X: {1}{0}Current Y: {2}{0}Piece Color: {3}", Environment.NewLine, XCoordinate, YCoordinate, PieceColor);
        }

    }
}
