namespace MapGenerator
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.forestsCountTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.fromForest = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.toForest = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.toRiver = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.fromRiver = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.riversCountTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.toMountain = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.fromMountain = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.mountainsCountTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.mapHeight = new System.Windows.Forms.TextBox();
            this.mapWidth = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 25);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(271, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Generate new map";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(268, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Forests count:";
            // 
            // forestsCountTextBox
            // 
            this.forestsCountTextBox.Location = new System.Drawing.Point(362, 21);
            this.forestsCountTextBox.Name = "forestsCountTextBox";
            this.forestsCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.forestsCountTextBox.TabIndex = 3;
            this.forestsCountTextBox.Text = "2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(268, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Forest size:";
            // 
            // fromForest
            // 
            this.fromForest.Location = new System.Drawing.Point(378, 53);
            this.fromForest.Name = "fromForest";
            this.fromForest.Size = new System.Drawing.Size(100, 20);
            this.fromForest.TabIndex = 6;
            this.fromForest.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(342, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "From";
            // 
            // toForest
            // 
            this.toForest.Location = new System.Drawing.Point(378, 79);
            this.toForest.Name = "toForest";
            this.toForest.Size = new System.Drawing.Size(100, 20);
            this.toForest.TabIndex = 8;
            this.toForest.Text = "200";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(345, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "To";
            // 
            // toRiver
            // 
            this.toRiver.Location = new System.Drawing.Point(378, 163);
            this.toRiver.Name = "toRiver";
            this.toRiver.Size = new System.Drawing.Size(100, 20);
            this.toRiver.TabIndex = 15;
            this.toRiver.Text = "200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "To";
            // 
            // fromRiver
            // 
            this.fromRiver.Location = new System.Drawing.Point(378, 137);
            this.fromRiver.Name = "fromRiver";
            this.fromRiver.Size = new System.Drawing.Size(100, 20);
            this.fromRiver.TabIndex = 13;
            this.fromRiver.Text = "100";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "From";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(268, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "River size:";
            // 
            // riversCountTextBox
            // 
            this.riversCountTextBox.Location = new System.Drawing.Point(362, 105);
            this.riversCountTextBox.Name = "riversCountTextBox";
            this.riversCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.riversCountTextBox.TabIndex = 10;
            this.riversCountTextBox.Text = "2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(268, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Rivers count:";
            // 
            // toMountain
            // 
            this.toMountain.Location = new System.Drawing.Point(378, 247);
            this.toMountain.Name = "toMountain";
            this.toMountain.Size = new System.Drawing.Size(100, 20);
            this.toMountain.TabIndex = 22;
            this.toMountain.Text = "200";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(345, 250);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "To";
            // 
            // fromMountain
            // 
            this.fromMountain.Location = new System.Drawing.Point(378, 221);
            this.fromMountain.Name = "fromMountain";
            this.fromMountain.Size = new System.Drawing.Size(100, 20);
            this.fromMountain.TabIndex = 20;
            this.fromMountain.Text = "100";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(342, 224);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "From";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(268, 221);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 18;
            this.label11.Text = "Mountain size:";
            // 
            // mountainsCountTextBox
            // 
            this.mountainsCountTextBox.Location = new System.Drawing.Point(362, 189);
            this.mountainsCountTextBox.Name = "mountainsCountTextBox";
            this.mountainsCountTextBox.Size = new System.Drawing.Size(100, 20);
            this.mountainsCountTextBox.TabIndex = 17;
            this.mountainsCountTextBox.Text = "2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(268, 192);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 16;
            this.label12.Text = "Mountains count:";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 363);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 23;
            this.button2.Text = "Start live";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(113, 363);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Stop live";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(551, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Map height:";
            // 
            // mapHeight
            // 
            this.mapHeight.Location = new System.Drawing.Point(620, 21);
            this.mapHeight.Name = "mapHeight";
            this.mapHeight.Size = new System.Drawing.Size(100, 20);
            this.mapHeight.TabIndex = 26;
            this.mapHeight.Text = "100";
            // 
            // mapWidth
            // 
            this.mapWidth.Location = new System.Drawing.Point(620, 47);
            this.mapWidth.Name = "mapWidth";
            this.mapWidth.Size = new System.Drawing.Size(100, 20);
            this.mapWidth.TabIndex = 28;
            this.mapWidth.Text = "100";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(551, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(59, 13);
            this.label14.TabIndex = 27;
            this.label14.Text = "Map width:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(583, 377);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 24);
            this.label15.TabIndex = 29;
            this.label15.Text = "CHECK README";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.mapWidth);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.mapHeight);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.toMountain);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.fromMountain);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.mountainsCountTextBox);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.toRiver);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.fromRiver);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.riversCountTextBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.toForest);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.fromForest);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.forestsCountTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox forestsCountTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox fromForest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox toForest;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox toRiver;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox fromRiver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox riversCountTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox toMountain;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox fromMountain;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox mountainsCountTextBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox mapHeight;
        private System.Windows.Forms.TextBox mapWidth;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
    }
}

