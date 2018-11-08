using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Linq;
using ChessDotNet;
using System.Diagnostics;
using ChessController;

namespace DanielMcHugh.AI.ChessBoard
{ 
    public partial class ChessBoard : BoardWindow
    {
        private const int RowCount = 8;
        private const int ColCount = 8;

        public static ChessGame Game { get; set; }

        public ObservableCollection<ChessPiece> ChessPieces { get; set; }

        public ChessBoard()
        {
            ChessPieces = new ObservableCollection<ChessPiece>();
            Game = new ChessGame();

            InitializeComponent();
            DataContext = this;
            CreateBoard();
            SetupBoard();

            //Testing piece moves
            ChessPieces[24].AttemptMove(File.A, 4);
            ChessPieces[8].AttemptMove(File.A, 6);

        }

        private void CreateBoard()
        {
            for (var row = 0; row < RowCount; row++)
            {
                var isBlack = row % 2 == 1;
                for (int col = 0; col < ColCount; col++)
                {
                    var square = new Rectangle { Fill = isBlack ? Brushes.Black : Brushes.White };
                    SquaresGrid.Children.Add(square);
                    isBlack = !isBlack;
                }
            }
        }

        private void SetupBoard()
        {
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 0, Type = ChessPieceTypes.Tower, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 1, Type = ChessPieceTypes.Knight, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 2, Type = ChessPieceTypes.Bishop, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 3, Type = ChessPieceTypes.Queen, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 4, Type = ChessPieceTypes.King, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 5, Type = ChessPieceTypes.Bishop, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 6, Type = ChessPieceTypes.Knight, IsBlack = true });
            ChessPieces.Add(new ChessPiece() { Row = 0, Column = 7, Type = ChessPieceTypes.Tower, IsBlack = true });

            Enumerable
                .Range(0, 8)
                .Select(x => new ChessPiece()
                {
                    Row = 1,
                    Column = x,
                    IsBlack = true,
                    Type = ChessPieceTypes.Pawn
                })
                .ToList()
                .ForEach(ChessPieces.Add);

            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 0, Type = ChessPieceTypes.Tower, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 1, Type = ChessPieceTypes.Knight, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 2, Type = ChessPieceTypes.Bishop, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 3, Type = ChessPieceTypes.Queen, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 4, Type = ChessPieceTypes.King, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 5, Type = ChessPieceTypes.Bishop, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 6, Type = ChessPieceTypes.Knight, IsBlack = false });
            ChessPieces.Add(new ChessPiece() { Row = 7, Column = 7, Type = ChessPieceTypes.Tower, IsBlack = false });

            Enumerable.Range(0, 8).Select(x => new ChessPiece()
            {
                Row = 6,
                Column = x,
                IsBlack = false,
                Type = ChessPieceTypes.Pawn
            }).ToList().ForEach(ChessPieces.Add);

            foreach (var piece in ChessPieces)
            {
                piece.Init();
            }

        }
    }
}
