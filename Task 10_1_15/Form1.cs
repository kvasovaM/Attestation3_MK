using MKLibrary;
using UsefulUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_10_1_15
{
    public partial class Form1 : Form
    {
        public ArraysHelper helper;

        public Form1()
        {
            InitializeComponent();
            helper = new ArraysHelper();
            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            DataGridViewUtils.InitGridForArr(InputDGV, 32, false, true, true, true, true);
        }

        private void RandomizeBtn_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            double[,] lst = new double[100, 6];
            for (int r = 0; r < 100; r++)
            {
                for (int c = 0; c < 6; c++)
                {
                    lst[r, c] = rnd.Next(10);
                }
                DataGridViewUtils.Array2ToGrid(InputDGV, lst);
            }
        }

        private void SubmitBTN_Click(object sender, EventArgs e)
        {
            try
            {
                List<Triangle> triangles = TriangleUtils.PointArrayToTriangles(DataGridViewUtils.GridToArray2<int>(InputDGV));
                TriangleUtils utils = new TriangleUtils(triangles);

                utils.GetAnswer(out int[][] result);
                OutLB.Items.Clear();
                for (int i = 0; i < result.Length; i++)
                {
                    OutLB.Items.Add(new ArraysHelper().ArrayToStr<int>(result[i], "; ") + "\n");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearBTN_Click(object sender, EventArgs e)
        {
            InputDGV.Rows.Clear();
        }

        private void OpenBTN_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Читаем содержимое выбранного файла и преобразуем его в массив
                    string arrText = FilesUtils.Read(openFileDialog.FileName);
                    int[,] arr = ArraysHelper.StrToArray2D<int>(arrText);

                    // Копируем полученный массив в DataGridView
                    DataGridViewUtils.Array2ToGrid(InputDGV, arr);

                    MessagesUtils.Show("Данные загружены. Можем начинать!");
                }
                catch
                {
                    MessagesUtils.ShowError("Ошибка загрузки данных");
                }
            }
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Преобразуем содержимое DataGridView в массив
                    int[,] arr = DataGridViewUtils.GridToArray2<int>(InputDGV);

                    // Записываем полученный массив в файл, предварительно
                    // преобразовав его в строку
                    FilesUtils.Write(saveFileDialog.FileName, helper.Array2DToStr<int>(arr));

                    //MessagesUtils.Show("Данные сохранены");
                }
                catch
                {
                    MessagesUtils.ShowError("Ошибка сохранения данных");
                }
            }
        }
    }
}
