using System;
using System.Windows.Forms;
using KompasProgram;
using BucketSetting;
using BucketSetting.ExceptionFolder;

namespace Plagin
{
    /// <summary>
    /// Класс формы
    /// </summary>
    public partial class Bucket : Form
    {
        /// <summary>
        /// Обект ведра
        /// </summary>
        BucketParamtr _bucketParamtr = new BucketParamtr();

        /// <summary>
        /// Объект для построения детали
        /// </summary>
        ProgramKompas _kompas = new ProgramKompas();

        /// <summary>
        /// Инициализация компонентов
        /// </summary>
        public Bucket()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Включение компаса и построение модели
        /// </summary>
        /// <param name="sender">отправитель</param>
        /// <param name="e">событие</param>
        private void BuildModelButton_Click(object sender, EventArgs e)
        {
            try
            {
                _kompas.SetParametr(_bucketParamtr);
                _kompas.Construct();
            }
            catch (Exception)
            {
                MessageBox.Show("Непредвиденая ошибка",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Валидация данных дна ведра
        /// </summary>
        /// <param name="sender">отправитель</param>
        /// <param name="e">событие</param>
        private void DiameterOfTheBottomTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bucketParamtr.DiameterOfTheBottom =
                    Convert.ToDouble(_diameterOfTheBottomTextBox.Text);
            }
            catch (DiameterOfTheBottomException)
            {
                SelectedTextBox(_diameterOfTheBottomTextBox,
                    "Неправельно введены данные диаметра дна\n(185-220)");
            }
            catch (FormatException)
            {
                SelectedTextBox(_diameterOfTheBottomTextBox,
                    "Вы не ввели данные диаметра дна ");
            }
        }

        /// <summary>
        /// Валидация данных высоты ведра
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Событие</param>
        private void TheHeightOfTheBucketTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bucketParamtr.TheHeightOfTheBucket =
                    Convert.ToDouble(_theHeightOfTheBucketTextBox.Text);
            }
            catch (TheHeightOfTheBucketException)
            {
                SelectedTextBox(_theHeightOfTheBucketTextBox,
                    "Неправельно введены данные высоты ведра\n(275-235)");
            }
            catch (FormatException)
            {
                SelectedTextBox(_theHeightOfTheBucketTextBox,
                    "Вы не ввели даные высоты ведра");
            }
        }

        /// <summary>
        /// Валидация диаметра горла ведра
        /// </summary>
        /// <param name="sender">отправитель</param>
        /// <param name="e">Событие</param>
        private void TheDiameterOfTheThroatTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bucketParamtr.TheDiameterOfTheThroat =
                    Convert.ToDouble(_theDiameterOfTheThroatTextBox.Text);
            }
            catch (TheDiameterOfTheThroatException)
            {
                SelectedTextBox(_theDiameterOfTheThroatTextBox,
                    "Неправельно введены данные диаметра горла ведра\n(260-315)");
            }
            catch (FormatException)
            {
                SelectedTextBox(_theDiameterOfTheThroatTextBox,
                    "Вы не ввели даные горла ведра");
            }
        }

        /// <summary>
        /// Валидация данных толщены металла
        /// </summary>
        /// <param name="sender">Отправитель</param>
        /// <param name="e">Событие</param>
        private void ThicknessOfSteelTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bucketParamtr.ThicknessOfSteel =
                    Convert.ToDouble(_thicknessOfSteelTextBox.Text);
            }
            catch (ThicknessOfSteelException)
            {
                SelectedTextBox(_thicknessOfSteelTextBox,
                    "Неправельно введены данные"
                    + "толщены метала");
            }
            catch (FormatException)
            {
                SelectedTextBox(_thicknessOfSteelTextBox,
                    "Вы не ввели толщиу метала");
            }
        }

        /// <summary>
        /// Валидация данных толщены дужки
        /// </summary>
        /// <param name="sender">отправитель</param>
        /// <param name="e">Событие</param>
        private void ThicknessOfTheBowTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                _bucketParamtr.ThicknessOfTheBow =
                    Convert.ToDouble(_thicknessOfTheBowTextBox.Text);
            }
            catch (ThicknessOfTheBowException)
            {
                SelectedTextBox(_thicknessOfTheBowTextBox,
                    "Неправельно введены параметры дужки");
            }
            catch (FormatException)
            {
                SelectedTextBox(_thicknessOfTheBowTextBox,
                    "Вы не ввели толщиу дужки");
            }
        }

        /// <summary>
        /// Шаблон валидации
        /// </summary>
        /// <param name="textBox">Текст бокс</param>
        /// <param name="message">сообщение</param>
        private void SelectedTextBox(TextBox textBox, string message)
        {
            textBox.Clear();
            textBox.Select();
            MessageBox.Show(message, "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
