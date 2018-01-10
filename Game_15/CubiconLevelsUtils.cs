using System;
using System.Collections.Generic;
using MKLibrary;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_15
{
    public class CubiconLevelsUtils
    {
        private static Dictionary<int, CubiconCellState> states = new Dictionary<int, CubiconCellState>() {
                { 0, CubiconCellState.PLAYER },
                { 1, CubiconCellState.EMPTY },
                { 2, CubiconCellState.BORDER },
                { 3, CubiconCellState.BLUE_CELL },
                { 4, CubiconCellState.PINK_CELL },
                { 5, CubiconCellState.ORANGE_CELL },
                { 6, CubiconCellState.GREEN_CELL },
        };

        public static CubiconLevels LoadLevelFromFile(string path)
        {
            return new CubiconLevels(LoadLevelFieldFromFile(path));
        }

        // Загружает игровое поле из файла
        private static CubiconCell[,] LoadLevelFieldFromFile(string path)
        {
            string levelStr = FilesUtils.Read(path);
            string[] rows = levelStr.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            // Если прочитали пустой набор столбцов
            if (rows.Length == 0)
                throw new Exception();

            string[] firstRowParts = rows[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Создаём массив для хранения данных поля
            int rowsCount = rows.Length;
            int colsCount = firstRowParts.Length;
            CubiconCell[,] field = new CubiconCell[rows.Length, firstRowParts.Length];

            // Заполняем массив поля
            for (int i = 0; i < rowsCount; i++)
            {
                string[] rowParts = rows[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (rowParts.Length != colsCount)
                    throw new Exception();

                for (int j = 0; j < colsCount; j++)
                {
                    field[i, j].Row = i;
                    field[i, j].Col = j;

                    field[i, j].State = states[int.Parse(rowParts[j])];
                }
            }

            return field;
        }
    }
}
