﻿using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Reflection.Emit;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;

namespace Chess
{
    public partial class Form1 : Form
    {
        Chessboard Mychessboard = new Chessboard(); // Assuming this is the class that manages chess pieces.
        List<Chesspieces> pieces = new List<Chesspieces>();
        List<int[]> piecemovementpossibilities = new List<int[]>();

        public System.Windows.Forms.Label[,] labels;

        Chesspieces chesspieceClicked = null;


        public Form1()
        {  // Initialize the 2D array of labels
            InitializeComponent();
            labels = Mychessboard.InitializeChessboard();
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    this.Controls.Add(labels[row, col]);
                    labels[row, col].Click += new EventHandler(ChessCase_Click);
                }
            }
            #region Pawn   
            for (int i = 0; i < 8; i++)
            {
                piecemovementpossibilities.Add(new int[] {0, -2});           
                piecemovementpossibilities.Add(new int[] {0, -1});           

                Chesspieces pawn = new Chesspieces(Properties.Resources.pawn, 6, i, "white", piecemovementpossibilities, "Pawn");
                pawn.PlacePiece(pawn.PositionX, pawn.PositionY, labels);
                pieces.Add(pawn);

                piecemovementpossibilities.Clear();
            }

            for(int i = 0; i < 8; i++)
            {
                piecemovementpossibilities.Add(new int[] { 0, 2 });
                piecemovementpossibilities.Add(new int[] { 0, 1 });

                Chesspieces blackpawn = new Chesspieces(Properties.Resources.blackpawn, 1, i, "black", piecemovementpossibilities, "Pawn");
                blackpawn.PlacePiece(blackpawn.PositionX, blackpawn.PositionY, labels);
                pieces.Add(blackpawn);

                piecemovementpossibilities.Clear();
            }
            #endregion
            #region Knight


            // Move 2 squares up, 1 square right
            piecemovementpossibilities.Add(new int[] {1, -2});
            // Move 2 squares up, 1 square left
            piecemovementpossibilities.Add(new int[] { -1, -2 });
            // Move 2 squares down, 1 square right
            piecemovementpossibilities.Add(new int[] { 1, 2 });
            // Move 2 squares down, 1 square left
            piecemovementpossibilities.Add(new int[] { -1, 2 });
            // Move 1 square up, 2 squares right
            piecemovementpossibilities.Add(new int[] { 2, -1});
            // Move 1 square up, 2 squares left
            piecemovementpossibilities.Add(new int[] { -2, -1 });
            // Move 1 square down, 2 squares right
            piecemovementpossibilities.Add(new int[] { 2, 1 });
            // Move 1 square down, 2 squares left
            piecemovementpossibilities.Add(new int[] { -2, 1});

            Chesspieces knight = new Chesspieces(Properties.Resources.knight, 7, 6, "white", piecemovementpossibilities, "Knight"  );
            Chesspieces knight2 = new Chesspieces(Properties.Resources.knight, 7, 1, "white", piecemovementpossibilities, "Knight");
            knight.PlacePiece(knight.PositionX, knight.PositionY, labels);
            knight2.PlacePiece(knight2.PositionX, knight2.PositionY, labels);

            Chesspieces blacknight = new Chesspieces(Properties.Resources.blackknight, 0, 6, "black", piecemovementpossibilities, "Knight");
            Chesspieces blacknight2 = new Chesspieces(Properties.Resources.blackknight, 0, 1, "black", piecemovementpossibilities, "Knight");
            blacknight.PlacePiece(blacknight.PositionX, blacknight.PositionY, labels);
            blacknight2.PlacePiece(blacknight2.PositionX, blacknight2.PositionY, labels);

            piecemovementpossibilities.Clear();

            #endregion
            #region Rock


            for (int i = -7; i < 7; i++)
            {
                if(i != 0)
                {
                    piecemovementpossibilities.Add(new int[] { 0, i });
                }
            }            
            
            for (int i = -7; i < 7; i++)
            {
                if(i != 0)
                {
                    piecemovementpossibilities.Add(new int[] { i, 0 });
                }
            }

            Chesspieces rook = new Chesspieces(Properties.Resources.rock, 7, 7, "white", piecemovementpossibilities, "Rook");
            Chesspieces rook2 = new Chesspieces(Properties.Resources.rock, 7, 0, "white", piecemovementpossibilities, "Rook");
            rook.PlacePiece(rook.PositionX, rook.PositionY, labels);
            rook2.PlacePiece(rook2.PositionX, rook2.PositionY, labels);

            Chesspieces blackrook = new Chesspieces(Properties.Resources.blackrook, 0, 0, "black", piecemovementpossibilities, "Rook");
            Chesspieces blackrook2 = new Chesspieces(Properties.Resources.blackrook, 0, 7, "black", piecemovementpossibilities, "Rook");
            blackrook.PlacePiece(blackrook.PositionX, blackrook.PositionY, labels);
            blackrook2.PlacePiece(blackrook2.PositionX, blackrook2.PositionY, labels);

            piecemovementpossibilities.Clear();

            #endregion
            #region Bishop

            int[] bishopRange = new int[2];

            for (int i = 1; i < 7; i++)
            {
                // ++
                piecemovementpossibilities.Add(new int[] { i, i });

                // +-
                piecemovementpossibilities.Add(new int[] { i, i * -1 });

                // -+
                piecemovementpossibilities.Add(new int[] { i * -1, i });

                // --
                piecemovementpossibilities.Add(new int[] {  i * -1, i * -1 });


            }

            Chesspieces bishop = new Chesspieces(Properties.Resources.bishop,7,5 , "white", piecemovementpossibilities, "Bishop");
            Chesspieces bishop2 = new Chesspieces(Properties.Resources.bishop, 7, 2, "white", piecemovementpossibilities, "Bishop");
            bishop.PlacePiece(bishop.PositionX, bishop.PositionY, labels);
            bishop2.PlacePiece(bishop2.PositionX, bishop2.PositionY, labels);

            Chesspieces blackbishop = new Chesspieces(Properties.Resources.blackbishop, 0, 5, "black", piecemovementpossibilities, "Bishop");
            Chesspieces blackbishop2 = new Chesspieces(Properties.Resources.blackbishop, 0, 2, "black", piecemovementpossibilities, "Bishop");
            blackbishop.PlacePiece(blackbishop.PositionX, blackbishop.PositionY, labels);
            blackbishop2.PlacePiece(blackbishop2.PositionX, blackbishop2.PositionY, labels);

            piecemovementpossibilities.Clear();

            #endregion
            #region queen
            for (int i = 1; i < 7; i++)
            {
                // ++
                piecemovementpossibilities.Add(new int[] { i, i });

                // +-

                piecemovementpossibilities.Add(new int[] { i, i * -1 });

                // -+

                piecemovementpossibilities.Add(new int[] { i * -1, i });
                // --

                piecemovementpossibilities.Add(new int[] { i * -1,  i * -1 });
            }

            for (int i = -7; i < 7; i++)
            {
                if(i != 0)
                {

                    piecemovementpossibilities.Add(new int[] { 0, i });

                    piecemovementpossibilities.Add(new int[] { i, 0 });
                }
            }
            Chesspieces queen = new Chesspieces(Properties.Resources.queen, 7, 3, "white", piecemovementpossibilities, "Queen");
            Chesspieces blackqueen = new Chesspieces(Properties.Resources.blackqueen, 0, 3, "black", piecemovementpossibilities, "Queen");
            queen.PlacePiece(queen.PositionX, queen.PositionY, labels);
            blackqueen.PlacePiece(blackqueen.PositionX, blackqueen.PositionY, labels);


            piecemovementpossibilities.Clear();
            #endregion
            #region king
            int[] kingrange = new int[2];

           
            piecemovementpossibilities.Add(new int[] { 0, 1 });

            piecemovementpossibilities.Add(new int[] { 1, 0 });

            piecemovementpossibilities.Add(new int[] { -1, 0 });
        
            piecemovementpossibilities.Add(new int[] { 0, -1 });

            piecemovementpossibilities.Add(new int[] { 1, 1 });

            piecemovementpossibilities.Add(new int[] { -1, -1 });

            piecemovementpossibilities.Add(new int[] { -1, 1 });

            piecemovementpossibilities.Add(new int[] { 1, -1 });

            Chesspieces blacking = new Chesspieces(Properties.Resources.blackking,0,4 , "black", piecemovementpossibilities, "King");
            Chesspieces king = new Chesspieces(Properties.Resources.king, 7, 4, "white", piecemovementpossibilities, "King");
            blacking.PlacePiece(blacking.PositionX, blacking.PositionY, labels);
            king.PlacePiece(king.PositionX, king.PositionY, labels);


            piecemovementpossibilities.Clear();
            #endregion



            pieces.Add(rook2);
            pieces.Add(knight);
            pieces.Add(knight2);
            pieces.Add(rook);
            pieces.Add(queen);
            pieces.Add(bishop);
            pieces.Add(bishop2);
            pieces.Add(king);
            pieces.Add(blacknight);
            pieces.Add(blacknight2);
            pieces.Add(blackqueen);
            pieces.Add(blacking);
            pieces.Add(blackbishop);
            pieces.Add(blackbishop2);
            pieces.Add(blackrook);
            pieces.Add(blackrook2);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void ChessCase_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Label clicked_label = sender as System.Windows.Forms.Label;
            string coordinates = Convert.ToString(clicked_label.Tag);

            // For debugging
            MessageBox.Show(Convert.ToString(clicked_label.Tag));

            // If there's already a piece selected and we click somewhere that's not a valid move
            if (chesspieceClicked != null &&
                !Convert.ToString(clicked_label.Tag).Contains("/Canmove") &&
                !Convert.ToString(clicked_label.Tag).Contains("/Cantake"))
            {
                // Clear all move indicators
                ClearMoveIndicators();
                chesspieceClicked = null;
                return;
            }

            // If we clicked on a piece to select it
            if (chesspieceClicked == null && clicked_label.Image != null && clicked_label.Image != Properties.Resources.dot)
            {
                foreach (var item in pieces)
                {
                    // Extract X and Y positions from the tag
                    string[] tagParts = coordinates.Split('/');
                    if (tagParts.Length > 0)
                    {
                        string[] posParts = tagParts[0].Split('-');
                        if (posParts.Length >= 2)
                        {
                            int clickedX = Convert.ToInt32(posParts[0]);
                            int clickedY = Convert.ToInt32(posParts[1]);

                            // If this is the piece at the clicked position
                            if (item.PositionX == clickedX && item.PositionY == clickedY)
                            {
                                item.GetMovePossibilities(labels);
                                chesspieceClicked = item;
                                break;
                            }
                        }
                    }
                }
            }
            // If we clicked on a valid move or capture
            else if (chesspieceClicked != null &&
                    (Convert.ToString(clicked_label.Tag).Contains("/Canmove") ||
                     Convert.ToString(clicked_label.Tag).Contains("/Cantake")))
            {
                // Extract X and Y positions from the tag
                string[] tagParts = coordinates.Split('/');
                if (tagParts.Length > 0)
                {
                    string[] posParts = tagParts[0].Split('-');
                    if (posParts.Length >= 2)
                    {
                        int clickedX = Convert.ToInt32(posParts[0]);
                        int clickedY = Convert.ToInt32(posParts[1]);

                        // Move the piece to the new position
                        chesspieceClicked.MovePiece(Convert.ToString(clickedX), Convert.ToString(clickedY), labels);
                        chesspieceClicked = null;
                    }
                }
            }
        }

        // Helper method to clear all move indicators
        private void ClearMoveIndicators()
        {
            foreach (var item in labels)
            {
                if (item.Tag != null)
                {
                    string tagStr = Convert.ToString(item.Tag);

                    // Handle Canmove tags
                    if (tagStr.Contains("/Canmove"))
                    {
                        item.Image = null;
                        string[] tag = tagStr.Split('/');
                        if (tag.Length > 0)
                        {
                            item.Tag = tag[0]; // Remove all tags after the first "/"
                        }
                    }

                    // Handle Cantake tags
                    if (tagStr.Contains("/Cantake"))
                    {
                        // Don't clear the image for capturable pieces
                        string[] tag = tagStr.Split('/');
                        if (tag.Length > 0)
                        {
                            item.Tag = tag[0]; // Remove all tags after the first "/"
                        }
                    }
                }
            }
        }

    }
}
