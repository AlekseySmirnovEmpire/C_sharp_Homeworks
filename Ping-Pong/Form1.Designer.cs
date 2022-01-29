namespace Ping_Pong
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
            this.background = new System.Windows.Forms.Panel();
            this.gameBall = new System.Windows.Forms.PictureBox();
            this.gamePanel = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.result = new System.Windows.Forms.Label();
            this.looseLabel = new System.Windows.Forms.Label();
            this.restartLooseLabel = new System.Windows.Forms.Label();
            this.background.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamePanel)).BeginInit();
            this.SuspendLayout();
            // 
            // background
            // 
            this.background.Controls.Add(this.restartLooseLabel);
            this.background.Controls.Add(this.looseLabel);
            this.background.Controls.Add(this.result);
            this.background.Controls.Add(this.gameBall);
            this.background.Controls.Add(this.gamePanel);
            this.background.Dock = System.Windows.Forms.DockStyle.Fill;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(800, 450);
            this.background.TabIndex = 0;
            // 
            // gameBall
            // 
            this.gameBall.BackColor = System.Drawing.Color.Blue;
            this.gameBall.Location = new System.Drawing.Point(374, 179);
            this.gameBall.MaximumSize = new System.Drawing.Size(25, 25);
            this.gameBall.MinimumSize = new System.Drawing.Size(25, 25);
            this.gameBall.Name = "gameBall";
            this.gameBall.Size = new System.Drawing.Size(25, 25);
            this.gameBall.TabIndex = 1;
            this.gameBall.TabStop = false;
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.Red;
            this.gamePanel.Location = new System.Drawing.Point(308, 420);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(116, 18);
            this.gamePanel.TabIndex = 0;
            this.gamePanel.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // result
            // 
            this.result.AutoSize = true;
            this.result.Font = new System.Drawing.Font("Segoe UI Black", 17.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.result.Location = new System.Drawing.Point(12, 9);
            this.result.Name = "result";
            this.result.Size = new System.Drawing.Size(158, 31);
            this.result.TabIndex = 2;
            this.result.Text = "Результат: 0";
            // 
            // looseLabel
            // 
            this.looseLabel.AutoSize = true;
            this.looseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.looseLabel.Location = new System.Drawing.Point(221, 179);
            this.looseLabel.Name = "looseLabel";
            this.looseLabel.Size = new System.Drawing.Size(311, 47);
            this.looseLabel.TabIndex = 3;
            this.looseLabel.Text = "Вы проиграли!";
            // 
            // restartLooseLabel
            // 
            this.restartLooseLabel.AutoSize = true;
            this.restartLooseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30.45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.restartLooseLabel.Location = new System.Drawing.Point(346, 270);
            this.restartLooseLabel.Name = "restartLooseLabel";
            this.restartLooseLabel.Size = new System.Drawing.Size(536, 47);
            this.restartLooseLabel.TabIndex = 4;
            this.restartLooseLabel.Text = "Нажмите R для рестарта!";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.background);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.background.ResumeLayout(false);
            this.background.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameBall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamePanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel background;
        private System.Windows.Forms.PictureBox gameBall;
        private System.Windows.Forms.PictureBox gamePanel;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label result;
        private System.Windows.Forms.Label looseLabel;
        private System.Windows.Forms.Label restartLooseLabel;
    }
}

