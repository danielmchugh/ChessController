using System;
using System.ComponentModel;
using System.Diagnostics;
using ChessController;
using ChessDotNet;

namespace DanielMcHugh.AI.ChessBoard
{
    public class ChessPiece : INotifyPropertyChanged
    {
        public bool IsBlack { get => _isBlack; set => _isBlack = value; }

        public ChessPieceTypes Type { get => _type; set => _type = value; }

        public Piece LocalPiece { get => _localPiece; set => _localPiece = value; }

        private File file;
        public File File { get => file; set => file = value; }

        private int rank;
        public int Rank { get => rank; set => rank = value; }


        public void Init()
        {
            LocalPiece = ChessBoard.Game.GetPieceAt(Row, Column);
        }

        private int _row;
        public int Row
        {
            get { return _row; }
            set
            {
                Rank = Helper.ConvertColumnToRank(value);

                _row = value;
                OnPropertyChanged("Row");
            }
        }

        private int _column;
        private Piece _localPiece;
        private ChessPieceTypes _type;
        private bool _isBlack;

        public int Column
        {
            get
            {
                return _column;
            }
            set
            {
                File = (File)value;

                _column = value;
                OnPropertyChanged("Column");
            }
        }

        public string CurrentStringPosition
        {
            get
            {
                return Helper.BoardLocations[Column, Row];
            }
        }




        public bool AttemptMove(File file, int rank)
        {
            Move move = new Move(new Position(this.File, this.Rank), new Position(file, rank), IsBlack ? Player.Black : Player.White);
            MoveType type;

            if (ChessBoard.Game.IsValidMove(move))
            {
                type = ChessBoard.Game.ApplyMove(move, true);

                Column = (int)file;
                Row = Helper.ConvertRankToColumn(rank);

                return true;
            }
            else
            {
                Debug.WriteLine($"This move was not valid! {move}");

                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string ImageSource
        {
            get { return "R:/Projects/ChessController/ChessController/img/" + (IsBlack ? "Black" : "White") + Type.ToString() + ".png"; }
        }


    }
}