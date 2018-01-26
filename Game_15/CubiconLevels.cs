using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_15
{
    public class CubiconLevels
    {
        private CubiconCell[,] field = null;
        public int PlayerRow { get; set; }
        public int PlayerCol { get; set; }

        public int RowCount
        {
            get
            {
                return field.GetLength(0);
            }
        }

        public int ColCount
        {
            get
            {
                return field.GetLength(1);
            }
        }

        public CubiconCell this[int row, int col]
        {
            get
            {
                return field[row, col];
            }
            set
            {
                field[row, col] = value;
            }
        }

        public CubiconLevels(CubiconCell[,] levelField)
        {
            this.field = levelField;

            // Проверяем позицию игрока на поле
            PlayerRow = -1;
            PlayerCol = -1;

            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    if (field[i, j].State == CubiconCellState.PLAYER)
                    {
                        PlayerRow = i;
                        PlayerCol = j;
                    }
                }
            }

            if (PlayerRow == -1)
                throw new Exception("На поле нет игрока");
        }

        public void SetFieldState(int row, int col, CubiconCellState state)
        {
            field[row, col].State = state;
        }

        public bool IsCellIndexesCorrect(int row, int column)
        {
            return row >= 0 && row < RowCount && column >= 0 && column < ColCount;
        }
    }
}

