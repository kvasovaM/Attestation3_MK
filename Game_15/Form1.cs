using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MKLibrary;

namespace Game_15
{
    public partial class Form1 : Form
    {
        // набор общедоступных уровней
        public enum LevelType
        {
            FIRST, SECOND, THIRD, FOURTH
        }

        private const int CELL_SIZE = 40;

        private CubiconGame game = new CubiconGame();

        // Таблица доступных уровней
        private Dictionary<CubiconCellState, Color> cellsBackgrounds = new Dictionary<CubiconCellState, Color> {
            { CubiconCellState.BORDER, Color.Gray },
            { CubiconCellState.BLUE_CELL, Color.Blue },
            { CubiconCellState.EMPTY, Color.White },
            { CubiconCellState.GREEN_CELL, Color.Green },
            { CubiconCellState.ORANGE_CELL, Color.Orange },
            { CubiconCellState.PINK_CELL, Color.Pink },
            { CubiconCellState.PLAYER, Color.Red }
        };

        // Таблица доступных уровней
        private Dictionary<LevelType, string> levels;

        private static StringFormat cellStringFormat = null;

        static Form1()
        {
            cellStringFormat = new StringFormat();
            cellStringFormat.Alignment = StringAlignment.Center;
            cellStringFormat.LineAlignment = StringAlignment.Center;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void GameField_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Если игра ещё не начата, то закрашиваем ячейки поля белым цветом
            if (game.State == CubiconGameState.NOT_STARTED)
            {
                e.CellStyle.BackColor = Color.White;
                e.PaintBackground(e.CellBounds, false);
                e.Handled = true;

                return;
            }

            CubiconCell cell = game.CurrentLevel[e.RowIndex, e.ColumnIndex];

            // Рисуем ячейку
            e.CellStyle.BackColor = cellsBackgrounds[cell.State];
            e.PaintBackground(e.CellBounds, false);

            // сообщаем, что ячейка полностью отрисована
            e.Handled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // настраиваем DataGridView
            GameField.RowTemplate.Height = CELL_SIZE;
            GameField.Font = new Font("Comic Sans MS", 12);
            DataGridViewUtils.InitGridForArr(GameField, CELL_SIZE, true, false, false, false, false);

            // Заполняем таблицу доступных уровней
            levels = new Dictionary<LevelType, string>() {
                { LevelType.FIRST, "level_01.txt" },
                { LevelType.SECOND, "level_02.txt" },
                { LevelType.THIRD, "level_03.txt" },
            };
        }

        private void ResizeField(int rows, int cols)
        {
            // Ставим размеры GridView
            GameField.RowCount = rows;
            GameField.ColumnCount = cols;
            GameField.Height = rows * CELL_SIZE + 3;
            GameField.Width = cols * CELL_SIZE + 3;

            this.Width = GameField.Width + 35;
            this.Height = GameField.Height + 110;
        }

        // Начиаем новую игру на указанном уровне
        private void StartNewGame(LevelType levelType)
        {
            try
            {
                string path = Environment.CurrentDirectory + "\\Levels\\" + levels[levelType];
                CubiconLevels level = CubiconLevelsUtils.LoadLevelFromFile(path);

                game.NewGame(level);

                ResizeField(level.RowCount, level.ColCount);
                UpdateView();
            }
            catch (Exception e)
            {
                MessagesUtils.Show("Ошибка загрузки уровня");
            }

        }

        private void UpdateView()
        {
            switch (game.State)
            {
                case CubiconGameState.PLAYING:
                    GameState.Text = "IN GAME";
                    GameState.ForeColor = Color.Black;
                    break;
                case CubiconGameState.WIN:
                    GameState.Text = "YOU HAVE WON!";
                    GameState.ForeColor = Color.DarkGreen;
                    break;
            }

            GameField.Invalidate();
        }

        private void gameFieldDataGridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Если игра ещё не начата, то закрашиваем ячейки поля белым цветом
            if (game.State == CubiconGameState.NOT_STARTED)
            {
                e.CellStyle.BackColor = Color.White;
                e.PaintBackground(e.CellBounds, false);
                e.Handled = true;

                return;
            }

            CubiconCell cell = game.CurrentLevel[e.RowIndex, e.ColumnIndex];

            // Рисуем ячейку
            e.CellStyle.BackColor = cellsBackgrounds[cell.State];
            e.PaintBackground(e.CellBounds, false);

            // сообщаем, что ячейка полностью отрисована
            e.Handled = true;
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Если нажали клавишу перемещения и находимся в режиме активной игры
            if (game.State == CubiconGameState.PLAYING && (keyData == Keys.Left || keyData == Keys.Right
                || keyData == Keys.Up || keyData == Keys.Down))
            {
                switch (keyData)
                {
                    case Keys.Left:
                        game.Move(CubiconDirection.LEFT);
                        break;

                    case Keys.Right:
                        game.Move(CubiconDirection.RIGHT);
                        break;

                    case Keys.Up:
                        game.Move(CubiconDirection.UP);
                        break;

                    case Keys.Down:
                        game.Move(CubiconDirection.DOWN);
                        break;
                }

                UpdateView();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        // Клик по кнопке запуска первого уровня
        private void MainMenuGameLevel1_Click(object sender, EventArgs e)
        {
            StartNewGame(LevelType.FIRST);
        }

        // Клик по кнопке запуска второго уровня
        private void MainMenuGameLevel2_Click(object sender, EventArgs e)
        {
            StartNewGame(LevelType.SECOND);
        }

        // Клик по кнопке запуска третьего уровня
        private void MainMenuGameLevel3_Click(object sender, EventArgs e)
        {
            StartNewGame(LevelType.THIRD);
        }

        // Клик по кнопке выхода
        private void MainMenuGameExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
