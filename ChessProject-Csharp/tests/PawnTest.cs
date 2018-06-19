﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;  

namespace SolarWinds.MSP.Chess
{
    [TestClass]
	public class PawnTest
	{
		private ChessBoard chessBoard;
		private Pawn pawn;

		[TestInitialize]
		public void SetUp()
		{
			chessBoard = new ChessBoard();
			pawn = new Pawn(PieceColor.Black);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_XCoordinate()
		{
			chessBoard.Add(pawn, 6, 3);
			Assert.AreEqual(pawn.XCoordinate, 6);
		}

		[TestMethod]
		public void ChessBoard_Add_Sets_YCoordinate()
		{
			chessBoard.Add(pawn, 6, 3);
			Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3);
			pawn.Move(MovementType.Move, 7, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

		[TestMethod]
		public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
		{
			chessBoard.Add(pawn, 6, 3);
			pawn.Move(MovementType.Move, 4, 3);
            Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 3);
		}

        [TestMethod]
        public void Pawn_Move_IllegalCoordinates_Backward_DoesNotMove()
        {
            Pawn whitePawn = new Pawn(PieceColor.White);
            chessBoard.Add(whitePawn, 6, 3);
            pawn.Move(MovementType.Move, 6, 2);

            Pawn blackPawn = new Pawn(PieceColor.Black);
            chessBoard.Add(blackPawn, 6, 4);
            pawn.Move(MovementType.Move, 6, 5);

            Assert.AreEqual(whitePawn.XCoordinate, 6);
            Assert.AreEqual(whitePawn.YCoordinate, 3);

            Assert.AreEqual(blackPawn.XCoordinate, 6);
            Assert.AreEqual(blackPawn.YCoordinate, 4);
        }

        [TestMethod]
		public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
		{
			chessBoard.Add(pawn, 6, 3);
			pawn.Move(MovementType.Move, 6, 2);
			Assert.AreEqual(pawn.XCoordinate, 6);
            Assert.AreEqual(pawn.YCoordinate, 2);
		}

	}
}
