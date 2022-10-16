using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FootToMeterForm
{
    public partial class Form1 : Form
    {
        private const int MAX_VALUE_LENGTH = 10;

        private string _valueToConvert = string.Empty;
        private readonly char _comma = ',';

        public Form1()
        {
            InitializeComponent();
        }
        #region Buttons
        private void Button1_Click(object sender, EventArgs e) => AssignNum(Button1);

        private void Button2_Click(object sender, EventArgs e) => AssignNum(Button2);

        private void Button3_Click(object sender, EventArgs e) => AssignNum(Button3);

        private void Button4_Click(object sender, EventArgs e) => AssignNum(Button4);

        private void Button5_Click(object sender, EventArgs e) => AssignNum(Button5);

        private void Button6_Click(object sender, EventArgs e) => AssignNum(Button6);

        private void Button7_Click(object sender, EventArgs e) => AssignNum(Button7);

        private void Button8_Click(object sender, EventArgs e) => AssignNum(Button8);

        private void Button9_Click(object sender, EventArgs e) => AssignNum(Button9);

        private void Button0_Click(object sender, EventArgs e)
        {
            if (_valueToConvert.Length < 1)
                return;

            AssignNum(Button0);
        }
        #endregion

        private void AssignNum(Button button)
        {
            if (_valueToConvert.Length >= MAX_VALUE_LENGTH)
                return;

            _valueToConvert += button.Text;

            UpdateFootLabel();
            UpdateMeterLabel();
        }

        private void UpdateFootLabel()
        {
            FootLabel.Text = _valueToConvert;
        }


        private void UpdateMeterLabel()
        {
            var valueToConvert = Convert.ToDouble(_valueToConvert);
            var meter = valueToConvert / 3.28084;
            var radText = meter.ToString().Substring(0, MAX_VALUE_LENGTH);

            if (radText[radText.Length - 1] == _comma)
            radText = radText.Remove(radText.Length - 1, 1);

            MeterLabel.Text = radText;
        }

        private void Comma_Click(object sender, EventArgs e)
        {
            if (_valueToConvert.Contains(_comma))
                return;
            AssignNum(Comma);
        }

        private void PlusMinusButton_Click(object sender, EventArgs e)
        {
            var value = Convert.ToDouble(_valueToConvert) * -1;
            _valueToConvert = value.ToString();

            UpdateFootLabel();
            UpdateMeterLabel();
        }

        private void ClearButton_Click(object sender, EventArgs e) => AssignZeroValues();

        private void AssignZeroValues()
        {
            _valueToConvert = string.Empty;
            FootLabel.Text = "0";
            MeterLabel.Text = "0";
        }

        private void RemoveLastCharButton_Click(object sender, EventArgs e)
        {
            if (_valueToConvert.Length <= 1)
            {
                AssignZeroValues();
                return;
            }

            _valueToConvert = _valueToConvert.Remove(_valueToConvert.Length - 1, 1);

            UpdateFootLabel();
            UpdateMeterLabel();
        }
    }
}
