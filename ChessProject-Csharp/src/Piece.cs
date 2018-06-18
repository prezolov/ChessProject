﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Abstract piece class containing a reference to the chessboard, 
    /// a 2D coordinate and a piece color.
    /// </summary>
    public abstract class Piece
    {
        protected ChessBoard chessBoard;
        /// <summary>
        /// The x coordinate.
        /// </summary>
        protected int xCoordinate;
        /// <summary>
        /// The y coordinate.
        /// </summary>
        protected int yCoordinate;
        /// <summary>
        /// The color of the chess piece, can be either black or white.
        /// </summary>
        protected PieceColor pieceColor;

        public ChessBoard ChessBoard
        {
            get { return chessBoard; }
            set { chessBoard = value; }
        }

        public int XCoordinate
        {
            get { return xCoordinate; }
            set { xCoordinate = value; }
        }

        public int YCoordinate
        {
            get { return yCoordinate; }
            set { yCoordinate = value; }
        }

        public PieceColor PieceColor
        {
            get { return pieceColor; }
            private set { pieceColor = value; }
        }

        protected Piece(PieceColor pieceColor)
        {
            this.pieceColor = pieceColor;
        }

        public abstract void Move(MovementType movementType, int newX, int newY);

    }
}
