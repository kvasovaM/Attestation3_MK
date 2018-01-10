using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public struct CubiconCell
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
    }

}
