namespace Plagin
{
    partial class Bucket
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this._diameterOfTheBottomTextBox = new System.Windows.Forms.TextBox();
            this._theHeightOfTheBucketTextBox = new System.Windows.Forms.TextBox();
            this._theDiameterOfTheThroatTextBox = new System.Windows.Forms.TextBox();
            this._thicknessOfSteelTextBox = new System.Windows.Forms.TextBox();
            this._thicknessOfTheBowTextBox = new System.Windows.Forms.TextBox();
            this.BuildModelButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _diameterOfTheBottomTextBox
            // 
            this._diameterOfTheBottomTextBox.Location = new System.Drawing.Point(107, 2);
            this._diameterOfTheBottomTextBox.Name = "_diameterOfTheBottomTextBox";
            this._diameterOfTheBottomTextBox.Size = new System.Drawing.Size(100, 20);
            this._diameterOfTheBottomTextBox.TabIndex = 0;
            this._diameterOfTheBottomTextBox.Leave += new System.EventHandler(this.DiameterOfTheBottomTextBox_Leave);
            // 
            // _theHeightOfTheBucketTextBox
            // 
            this._theHeightOfTheBucketTextBox.Location = new System.Drawing.Point(107, 28);
            this._theHeightOfTheBucketTextBox.Name = "_theHeightOfTheBucketTextBox";
            this._theHeightOfTheBucketTextBox.Size = new System.Drawing.Size(100, 20);
            this._theHeightOfTheBucketTextBox.TabIndex = 1;
            this._theHeightOfTheBucketTextBox.Leave += new System.EventHandler(this.TheHeightOfTheBucketTextBox_Leave);
            // 
            // _theDiameterOfTheThroatTextBox
            // 
            this._theDiameterOfTheThroatTextBox.Location = new System.Drawing.Point(107, 54);
            this._theDiameterOfTheThroatTextBox.Name = "_theDiameterOfTheThroatTextBox";
            this._theDiameterOfTheThroatTextBox.Size = new System.Drawing.Size(100, 20);
            this._theDiameterOfTheThroatTextBox.TabIndex = 2;
            this._theDiameterOfTheThroatTextBox.Leave += new System.EventHandler(this.TheDiameterOfTheThroatTextBox_Leave);
            // 
            // _thicknessOfSteelTextBox
            // 
            this._thicknessOfSteelTextBox.Location = new System.Drawing.Point(107, 80);
            this._thicknessOfSteelTextBox.Name = "_thicknessOfSteelTextBox";
            this._thicknessOfSteelTextBox.Size = new System.Drawing.Size(100, 20);
            this._thicknessOfSteelTextBox.TabIndex = 3;
            this._thicknessOfSteelTextBox.Leave += new System.EventHandler(this.ThicknessOfSteelTextBox_Leave);
            // 
            // _thicknessOfTheBowTextBox
            // 
            this._thicknessOfTheBowTextBox.Location = new System.Drawing.Point(107, 106);
            this._thicknessOfTheBowTextBox.Name = "_thicknessOfTheBowTextBox";
            this._thicknessOfTheBowTextBox.Size = new System.Drawing.Size(100, 20);
            this._thicknessOfTheBowTextBox.TabIndex = 4;
            this._thicknessOfTheBowTextBox.Leave += new System.EventHandler(this.ThicknessOfTheBowTextBox_Leave);
            // 
            // BuildModelButton
            // 
            this.BuildModelButton.Location = new System.Drawing.Point(132, 136);
            this.BuildModelButton.Name = "BuildModelButton";
            this.BuildModelButton.Size = new System.Drawing.Size(75, 23);
            this.BuildModelButton.TabIndex = 5;
            this.BuildModelButton.Text = "Построить";
            this.BuildModelButton.UseVisualStyleBackColor = true;
            this.BuildModelButton.Click += new System.EventHandler(this.BuildModelButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Диаметр дна";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Выстота ведра";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Даметр горла";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Толщина стали";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Толщина дужки";
            // 
            // Bucket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 171);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuildModelButton);
            this.Controls.Add(this._thicknessOfTheBowTextBox);
            this.Controls.Add(this._thicknessOfSteelTextBox);
            this.Controls.Add(this._theDiameterOfTheThroatTextBox);
            this.Controls.Add(this._theHeightOfTheBucketTextBox);
            this.Controls.Add(this._diameterOfTheBottomTextBox);
            this.Name = "Bucket";
            this.Text = "Bucket";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _diameterOfTheBottomTextBox;
        private System.Windows.Forms.TextBox _theHeightOfTheBucketTextBox;
        private System.Windows.Forms.TextBox _theDiameterOfTheThroatTextBox;
        private System.Windows.Forms.TextBox _thicknessOfSteelTextBox;
        private System.Windows.Forms.TextBox _thicknessOfTheBowTextBox;
        private System.Windows.Forms.Button BuildModelButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

