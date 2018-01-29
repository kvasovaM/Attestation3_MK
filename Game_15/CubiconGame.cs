namespace Game_15
{
    // Набор возможных состояний игры
    public enum CubiconGameState
    {
        NOT_STARTED,
        PLAYING,
        WIN
    }

    // Набор возможных состояний (типов) клеток
    public enum CubiconCellState
    {
        PLAYER, // блок, передвигающий остальные
        BORDER,
        EMPTY,
        BLUE_CELL,
        PINK_CELL,
        ORANGE_CELL,
        GREEN_CELL
    }

    // Набор возможных направлений движения игрока
    public enum CubiconDirection
    {
        LEFT, RIGHT, UP, DOWN, NONE
    }

    // Ячейка игрового поля
    public class CubiconCell
    {
        public int Col { get; set; }
        public int Row { get; set; }

        public CubiconCellState State { get; set; }
    }

    public class CubiconGame
    {
        // Экземпляр текущего уровня
        public CubiconLevels CurrentLevel { get; set; }

        // Текущее состояние игры
        private CubiconGameState state = CubiconGameState.NOT_STARTED;

        public CubiconGameState State
        {
            get
            {
                return state;
            }
        }

        public CubiconGame()
        {

        }

        public void NewGame(CubiconLevels level)
        {
            CurrentLevel = level;

            state = CubiconGameState.PLAYING;
        }

        // Пытается переместить игрока в указанном направлении
        public void Move(CubiconDirection direction)
        {
            // Если мы не находимся в состоянии игры, то ничего не делаем
            if (state != CubiconGameState.PLAYING)
                return;

            int movementX = 0;
            int movementY = 0;

            switch (direction)
            {
                case CubiconDirection.DOWN:
                    movementX = 0;
                    movementY = 1;
                    break;
                case CubiconDirection.UP:
                    movementX = 0;
                    movementY = -1;
                    break;
                case CubiconDirection.LEFT:
                    movementX = -1;
                    movementY = 0;
                    break;
                case CubiconDirection.RIGHT:
                    movementX = 1;
                    movementY = 0;
                    break;
            }

            int blockX = CurrentLevel.PlayerCol + movementX;
            int blockY = CurrentLevel.PlayerRow + movementY;

            if (!CurrentLevel.IsCellIndexesCorrect(blockY, blockX))
                return;

            CubiconCell player = CurrentLevel[CurrentLevel.PlayerRow, CurrentLevel.PlayerCol];
            CubiconCell block = CurrentLevel[blockY, blockX];

            if (CurrentLevel[blockY, blockX].State == CubiconCellState.EMPTY)
            {
                // Выполняем перемещение
                block.State = player.State;
                player.State = CubiconCellState.EMPTY;
            }
            else if (IsCellMovable(CurrentLevel[blockY, blockX]))
            {
                int targetX = blockX + movementX;
                int targetY = blockY + movementY;

                if (!CurrentLevel.IsCellIndexesCorrect(targetY, targetX)
                    || CurrentLevel[targetY, targetX].State != CubiconCellState.EMPTY)
                    return;

                CubiconCell target = CurrentLevel[targetY, targetX];

                // Выполняем перемещение
                target.State = block.State;
                block.State = player.State;
                player.State = CubiconCellState.EMPTY;
            }

            if (CurrentLevel[blockY, blockX].State != CubiconCellState.BORDER)
            {
                CurrentLevel.PlayerCol = blockX;
                CurrentLevel.PlayerRow = blockY;
            }

            UpdateGameState();
        }

        public bool IsCellMovable(CubiconCell cell)
        {
            return cell.State == CubiconCellState.BLUE_CELL ||
                cell.State == CubiconCellState.GREEN_CELL ||
                cell.State == CubiconCellState.ORANGE_CELL ||
                cell.State == CubiconCellState.PINK_CELL;
        }

        private void UpdateGameState()
        {
            bool isWin = true;

            for (int r = 0; r < CurrentLevel.RowCount; r++)
                for (int c = 0; c < CurrentLevel.ColCount; c++)
                {
                    CubiconCell cell = CurrentLevel[r, c];

                    if (IsCellMovable(cell) && !HasCellMovableNeighbor(cell))
                    {
                        isWin = false;
                    }
                }

            if (isWin)
                state = CubiconGameState.WIN;
        }

        private bool HasCellMovableNeighbor(CubiconCell cell)
        {
            return CheckNeighbor(cell.Row + 1, cell.Col, cell.State) ||
                CheckNeighbor(cell.Row - 1, cell.Col, cell.State) ||
                CheckNeighbor(cell.Row, cell.Col + 1, cell.State) ||
                CheckNeighbor(cell.Row, cell.Col - 1, cell.State);
        }

        private bool CheckNeighbor(int row, int col, CubiconCellState state)
        {
            return CurrentLevel.IsCellIndexesCorrect(row, col)
                && IsCellMovable(CurrentLevel[row, col])
                && CurrentLevel[row, col].State == state;
        }
    }

}


