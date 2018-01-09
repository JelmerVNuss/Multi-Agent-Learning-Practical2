namespace EVOMAL
{
    partial class Evolution
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TickTimer = new System.Windows.Forms.Timer(this.components);
            this.slider_AllC = new System.Windows.Forms.TrackBar();
            this.slider_AllD = new System.Windows.Forms.TrackBar();
            this.slider_Random = new System.Windows.Forms.TrackBar();
            this.slider_TFT = new System.Windows.Forms.TrackBar();
            this.slider_TFT2 = new System.Windows.Forms.TrackBar();
            this.slider_Pavlov = new System.Windows.Forms.TrackBar();
            this.slider_Unforgiving = new System.Windows.Forms.TrackBar();
            this.slider_FP = new System.Windows.Forms.TrackBar();
            this.slider_NR = new System.Windows.Forms.TrackBar();
            this.proportionLabel = new System.Windows.Forms.Label();
            this.allCLabel = new System.Windows.Forms.Label();
            this.allDLabel = new System.Windows.Forms.Label();
            this.randomLabel = new System.Windows.Forms.Label();
            this.tftLabel = new System.Windows.Forms.Label();
            this.tft2Label = new System.Windows.Forms.Label();
            this.pavlovLabel = new System.Windows.Forms.Label();
            this.unforgivingLabel = new System.Windows.Forms.Label();
            this.fpLabel = new System.Windows.Forms.Label();
            this.nrLabel = new System.Windows.Forms.Label();
            this.setupButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.plotView = new OxyPlot.WindowsForms.PlotView();
            this.tickLabel = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.currentProps = new System.Windows.Forms.TextBox();
            this.nrroundsSlider = new System.Windows.Forms.TrackBar();
            this.nrrestartsSlider = new System.Windows.Forms.TrackBar();
            this.nrroundsLabel = new System.Windows.Forms.Label();
            this.nrrestartsLabel = new System.Windows.Forms.Label();
            this.noiseSlider = new System.Windows.Forms.TrackBar();
            this.noiseLabel = new System.Windows.Forms.Label();
            this.Recalculate = new System.Windows.Forms.Button();
            this.birthSlider = new System.Windows.Forms.TrackBar();
            this.birthLabel = new System.Windows.Forms.Label();
            this.slider_Majority = new System.Windows.Forms.TrackBar();
            this.label_Majority = new System.Windows.Forms.Label();
            this.slider_RL = new System.Windows.Forms.TrackBar();
            this.label_RL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slider_AllC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_AllD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Random)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_TFT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_TFT2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Pavlov)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Unforgiving)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_FP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_NR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrroundsSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrrestartsSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Majority)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_RL)).BeginInit();
            this.SuspendLayout();
            // 
            // TickTimer
            // 
            this.TickTimer.Interval = 1;
            this.TickTimer.Tick += new System.EventHandler(this.TickTimer_Tick);
            // 
            // slider_AllC
            // 
            this.slider_AllC.LargeChange = 10;
            this.slider_AllC.Location = new System.Drawing.Point(738, 57);
            this.slider_AllC.Maximum = 100;
            this.slider_AllC.Name = "slider_AllC";
            this.slider_AllC.Size = new System.Drawing.Size(104, 45);
            this.slider_AllC.TabIndex = 0;
            this.slider_AllC.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_AllC.Value = 100;
            this.slider_AllC.Scroll += new System.EventHandler(this.slider_AllC_Scroll);
            // 
            // slider_AllD
            // 
            this.slider_AllD.LargeChange = 10;
            this.slider_AllD.Location = new System.Drawing.Point(869, 57);
            this.slider_AllD.Maximum = 100;
            this.slider_AllD.Name = "slider_AllD";
            this.slider_AllD.Size = new System.Drawing.Size(104, 45);
            this.slider_AllD.TabIndex = 1;
            this.slider_AllD.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_AllD.Scroll += new System.EventHandler(this.slider_AllD_Scroll);
            // 
            // slider_Random
            // 
            this.slider_Random.LargeChange = 10;
            this.slider_Random.Location = new System.Drawing.Point(991, 57);
            this.slider_Random.Maximum = 100;
            this.slider_Random.Name = "slider_Random";
            this.slider_Random.Size = new System.Drawing.Size(104, 45);
            this.slider_Random.TabIndex = 2;
            this.slider_Random.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_Random.Scroll += new System.EventHandler(this.slider_Random_Scroll);
            // 
            // slider_TFT
            // 
            this.slider_TFT.LargeChange = 10;
            this.slider_TFT.Location = new System.Drawing.Point(738, 108);
            this.slider_TFT.Maximum = 100;
            this.slider_TFT.Name = "slider_TFT";
            this.slider_TFT.Size = new System.Drawing.Size(104, 45);
            this.slider_TFT.TabIndex = 3;
            this.slider_TFT.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_TFT.Scroll += new System.EventHandler(this.slider_TFT_Scroll);
            // 
            // slider_TFT2
            // 
            this.slider_TFT2.LargeChange = 10;
            this.slider_TFT2.Location = new System.Drawing.Point(869, 108);
            this.slider_TFT2.Maximum = 100;
            this.slider_TFT2.Name = "slider_TFT2";
            this.slider_TFT2.Size = new System.Drawing.Size(104, 45);
            this.slider_TFT2.TabIndex = 4;
            this.slider_TFT2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_TFT2.Scroll += new System.EventHandler(this.slider_TFT2_Scroll);
            // 
            // slider_Pavlov
            // 
            this.slider_Pavlov.LargeChange = 10;
            this.slider_Pavlov.Location = new System.Drawing.Point(991, 108);
            this.slider_Pavlov.Maximum = 100;
            this.slider_Pavlov.Name = "slider_Pavlov";
            this.slider_Pavlov.Size = new System.Drawing.Size(104, 45);
            this.slider_Pavlov.TabIndex = 5;
            this.slider_Pavlov.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_Pavlov.Scroll += new System.EventHandler(this.slider_Pavlov_Scroll);
            // 
            // slider_Unforgiving
            // 
            this.slider_Unforgiving.LargeChange = 10;
            this.slider_Unforgiving.Location = new System.Drawing.Point(739, 159);
            this.slider_Unforgiving.Maximum = 100;
            this.slider_Unforgiving.Name = "slider_Unforgiving";
            this.slider_Unforgiving.Size = new System.Drawing.Size(104, 45);
            this.slider_Unforgiving.TabIndex = 6;
            this.slider_Unforgiving.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_Unforgiving.Scroll += new System.EventHandler(this.slider_Unforgiving_Scroll);
            // 
            // slider_FP
            // 
            this.slider_FP.LargeChange = 10;
            this.slider_FP.Location = new System.Drawing.Point(870, 159);
            this.slider_FP.Maximum = 100;
            this.slider_FP.Name = "slider_FP";
            this.slider_FP.Size = new System.Drawing.Size(104, 45);
            this.slider_FP.TabIndex = 7;
            this.slider_FP.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_FP.Scroll += new System.EventHandler(this.slider_FP_Scroll);
            // 
            // slider_NR
            // 
            this.slider_NR.LargeChange = 10;
            this.slider_NR.Location = new System.Drawing.Point(991, 159);
            this.slider_NR.Maximum = 100;
            this.slider_NR.Name = "slider_NR";
            this.slider_NR.Size = new System.Drawing.Size(104, 45);
            this.slider_NR.TabIndex = 8;
            this.slider_NR.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_NR.Scroll += new System.EventHandler(this.slider_NR_Scroll);
            // 
            // proportionLabel
            // 
            this.proportionLabel.AutoSize = true;
            this.proportionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.proportionLabel.Location = new System.Drawing.Point(734, 9);
            this.proportionLabel.Name = "proportionLabel";
            this.proportionLabel.Size = new System.Drawing.Size(171, 17);
            this.proportionLabel.TabIndex = 9;
            this.proportionLabel.Text = "Initial strategy proportions";
            // 
            // allCLabel
            // 
            this.allCLabel.AutoSize = true;
            this.allCLabel.Location = new System.Drawing.Point(744, 36);
            this.allCLabel.Name = "allCLabel";
            this.allCLabel.Size = new System.Drawing.Size(64, 13);
            this.allCLabel.TabIndex = 10;
            this.allCLabel.Text = "All_C = 1.00";
            // 
            // allDLabel
            // 
            this.allDLabel.AutoSize = true;
            this.allDLabel.Location = new System.Drawing.Point(866, 36);
            this.allDLabel.Name = "allDLabel";
            this.allDLabel.Size = new System.Drawing.Size(65, 13);
            this.allDLabel.TabIndex = 11;
            this.allDLabel.Text = "All_D = 0.00";
            // 
            // randomLabel
            // 
            this.randomLabel.AutoSize = true;
            this.randomLabel.Location = new System.Drawing.Point(993, 36);
            this.randomLabel.Name = "randomLabel";
            this.randomLabel.Size = new System.Drawing.Size(80, 13);
            this.randomLabel.TabIndex = 12;
            this.randomLabel.Text = "Random = 0.00";
            // 
            // tftLabel
            // 
            this.tftLabel.AutoSize = true;
            this.tftLabel.Location = new System.Drawing.Point(744, 85);
            this.tftLabel.Name = "tftLabel";
            this.tftLabel.Size = new System.Drawing.Size(60, 13);
            this.tftLabel.TabIndex = 13;
            this.tftLabel.Text = "TFT = 0.00";
            // 
            // tft2Label
            // 
            this.tft2Label.AutoSize = true;
            this.tft2Label.Location = new System.Drawing.Point(867, 85);
            this.tft2Label.Name = "tft2Label";
            this.tft2Label.Size = new System.Drawing.Size(66, 13);
            this.tft2Label.TabIndex = 14;
            this.tft2Label.Text = "TFT2 = 0.00";
            // 
            // pavlovLabel
            // 
            this.pavlovLabel.AutoSize = true;
            this.pavlovLabel.Location = new System.Drawing.Point(993, 85);
            this.pavlovLabel.Name = "pavlovLabel";
            this.pavlovLabel.Size = new System.Drawing.Size(73, 13);
            this.pavlovLabel.TabIndex = 15;
            this.pavlovLabel.Text = "Pavlov = 0.00";
            // 
            // unforgivingLabel
            // 
            this.unforgivingLabel.AutoSize = true;
            this.unforgivingLabel.Location = new System.Drawing.Point(745, 139);
            this.unforgivingLabel.Name = "unforgivingLabel";
            this.unforgivingLabel.Size = new System.Drawing.Size(94, 13);
            this.unforgivingLabel.TabIndex = 16;
            this.unforgivingLabel.Text = "Unforgiving = 0.00";
            // 
            // fpLabel
            // 
            this.fpLabel.AutoSize = true;
            this.fpLabel.Location = new System.Drawing.Point(867, 139);
            this.fpLabel.Name = "fpLabel";
            this.fpLabel.Size = new System.Drawing.Size(89, 13);
            this.fpLabel.TabIndex = 17;
            this.fpLabel.Text = "SmoothFP = 0.00";
            // 
            // nrLabel
            // 
            this.nrLabel.AutoSize = true;
            this.nrLabel.Location = new System.Drawing.Point(994, 139);
            this.nrLabel.Name = "nrLabel";
            this.nrLabel.Size = new System.Drawing.Size(78, 13);
            this.nrLabel.TabIndex = 18;
            this.nrLabel.Text = "PropNR = 0.00";
            // 
            // setupButton
            // 
            this.setupButton.Location = new System.Drawing.Point(15, 60);
            this.setupButton.Name = "setupButton";
            this.setupButton.Size = new System.Drawing.Size(75, 23);
            this.setupButton.TabIndex = 19;
            this.setupButton.Text = "Setup";
            this.setupButton.UseVisualStyleBackColor = true;
            this.setupButton.Click += new System.EventHandler(this.setupButton_Click);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(15, 89);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(75, 23);
            this.playButton.TabIndex = 20;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // plotView
            // 
            this.plotView.Location = new System.Drawing.Point(21, 322);
            this.plotView.Name = "plotView";
            this.plotView.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotView.Size = new System.Drawing.Size(843, 296);
            this.plotView.TabIndex = 21;
            this.plotView.Text = "plotView1";
            this.plotView.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotView.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotView.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // tickLabel
            // 
            this.tickLabel.AutoSize = true;
            this.tickLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tickLabel.Location = new System.Drawing.Point(12, 9);
            this.tickLabel.Name = "tickLabel";
            this.tickLabel.Size = new System.Drawing.Size(65, 17);
            this.tickLabel.TabIndex = 22;
            this.tickLabel.Text = "Ticks = 0";
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Location = new System.Drawing.Point(136, 12);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(592, 273);
            this.dataGridView.TabIndex = 23;
            // 
            // currentProps
            // 
            this.currentProps.Location = new System.Drawing.Point(908, 361);
            this.currentProps.Multiline = true;
            this.currentProps.Name = "currentProps";
            this.currentProps.ReadOnly = true;
            this.currentProps.Size = new System.Drawing.Size(165, 213);
            this.currentProps.TabIndex = 24;
            this.currentProps.Text = "Proportions:";
            // 
            // nrroundsSlider
            // 
            this.nrroundsSlider.LargeChange = 20;
            this.nrroundsSlider.Location = new System.Drawing.Point(15, 138);
            this.nrroundsSlider.Maximum = 1000;
            this.nrroundsSlider.Minimum = 10;
            this.nrroundsSlider.Name = "nrroundsSlider";
            this.nrroundsSlider.Size = new System.Drawing.Size(104, 45);
            this.nrroundsSlider.SmallChange = 5;
            this.nrroundsSlider.TabIndex = 25;
            this.nrroundsSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.nrroundsSlider.Value = 100;
            this.nrroundsSlider.Scroll += new System.EventHandler(this.nrroundsSlider_Scroll);
            // 
            // nrrestartsSlider
            // 
            this.nrrestartsSlider.Location = new System.Drawing.Point(15, 189);
            this.nrrestartsSlider.Maximum = 20;
            this.nrrestartsSlider.Minimum = 1;
            this.nrrestartsSlider.Name = "nrrestartsSlider";
            this.nrrestartsSlider.Size = new System.Drawing.Size(104, 45);
            this.nrrestartsSlider.TabIndex = 26;
            this.nrrestartsSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.nrrestartsSlider.Value = 10;
            this.nrrestartsSlider.Scroll += new System.EventHandler(this.nrrestartsSlider_Scroll);
            // 
            // nrroundsLabel
            // 
            this.nrroundsLabel.AutoSize = true;
            this.nrroundsLabel.Location = new System.Drawing.Point(18, 122);
            this.nrroundsLabel.Name = "nrroundsLabel";
            this.nrroundsLabel.Size = new System.Drawing.Size(78, 13);
            this.nrroundsLabel.TabIndex = 27;
            this.nrroundsLabel.Text = "nrrounds = 100";
            // 
            // nrrestartsLabel
            // 
            this.nrrestartsLabel.AutoSize = true;
            this.nrrestartsLabel.Location = new System.Drawing.Point(18, 173);
            this.nrrestartsLabel.Name = "nrrestartsLabel";
            this.nrrestartsLabel.Size = new System.Drawing.Size(74, 13);
            this.nrrestartsLabel.TabIndex = 28;
            this.nrrestartsLabel.Text = "nrrestarts = 10";
            // 
            // noiseSlider
            // 
            this.noiseSlider.Location = new System.Drawing.Point(15, 240);
            this.noiseSlider.Maximum = 100;
            this.noiseSlider.Name = "noiseSlider";
            this.noiseSlider.Size = new System.Drawing.Size(104, 45);
            this.noiseSlider.TabIndex = 29;
            this.noiseSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.noiseSlider.Scroll += new System.EventHandler(this.noiseSlider_Scroll);
            // 
            // noiseLabel
            // 
            this.noiseLabel.AutoSize = true;
            this.noiseLabel.Location = new System.Drawing.Point(18, 221);
            this.noiseLabel.Name = "noiseLabel";
            this.noiseLabel.Size = new System.Drawing.Size(59, 13);
            this.noiseLabel.TabIndex = 30;
            this.noiseLabel.Text = "noise = 0.0";
            // 
            // Recalculate
            // 
            this.Recalculate.Location = new System.Drawing.Point(15, 31);
            this.Recalculate.Name = "Recalculate";
            this.Recalculate.Size = new System.Drawing.Size(75, 23);
            this.Recalculate.TabIndex = 31;
            this.Recalculate.Text = "Calculate";
            this.Recalculate.UseVisualStyleBackColor = true;
            this.Recalculate.Click += new System.EventHandler(this.Recalculate_Click);
            // 
            // birthSlider
            // 
            this.birthSlider.Location = new System.Drawing.Point(15, 291);
            this.birthSlider.Maximum = 100;
            this.birthSlider.Name = "birthSlider";
            this.birthSlider.Size = new System.Drawing.Size(104, 45);
            this.birthSlider.TabIndex = 32;
            this.birthSlider.TickStyle = System.Windows.Forms.TickStyle.None;
            this.birthSlider.Value = 5;
            this.birthSlider.Scroll += new System.EventHandler(this.birthSlider_Scroll);
            // 
            // birthLabel
            // 
            this.birthLabel.AutoSize = true;
            this.birthLabel.Location = new System.Drawing.Point(18, 272);
            this.birthLabel.Name = "birthLabel";
            this.birthLabel.Size = new System.Drawing.Size(81, 13);
            this.birthLabel.TabIndex = 33;
            this.birthLabel.Text = "birth rate = 0.05";
            // 
            // slider_Majority
            // 
            this.slider_Majority.LargeChange = 10;
            this.slider_Majority.Location = new System.Drawing.Point(739, 210);
            this.slider_Majority.Maximum = 100;
            this.slider_Majority.Name = "slider_Majority";
            this.slider_Majority.Size = new System.Drawing.Size(104, 45);
            this.slider_Majority.TabIndex = 35;
            this.slider_Majority.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_Majority.Scroll += new System.EventHandler(this.slider_Majority_Scroll);
            // 
            // label_Majority
            // 
            this.label_Majority.AutoSize = true;
            this.label_Majority.Location = new System.Drawing.Point(744, 189);
            this.label_Majority.Name = "label_Majority";
            this.label_Majority.Size = new System.Drawing.Size(76, 13);
            this.label_Majority.TabIndex = 36;
            this.label_Majority.Text = "Majority = 0.00";
            // 
            // slider_RL
            // 
            this.slider_RL.LargeChange = 10;
            this.slider_RL.Location = new System.Drawing.Point(869, 210);
            this.slider_RL.Maximum = 100;
            this.slider_RL.Name = "slider_RL";
            this.slider_RL.Size = new System.Drawing.Size(104, 45);
            this.slider_RL.TabIndex = 37;
            this.slider_RL.TickStyle = System.Windows.Forms.TickStyle.None;
            this.slider_RL.Scroll += new System.EventHandler(this.slider_RL_Scroll);
            // 
            // label_RL
            // 
            this.label_RL.AutoSize = true;
            this.label_RL.Location = new System.Drawing.Point(866, 189);
            this.label_RL.Name = "label_RL";
            this.label_RL.Size = new System.Drawing.Size(54, 13);
            this.label_RL.TabIndex = 38;
            this.label_RL.Text = "RL = 0.00";
            // 
            // Evolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 640);
            this.Controls.Add(this.label_RL);
            this.Controls.Add(this.slider_RL);
            this.Controls.Add(this.label_Majority);
            this.Controls.Add(this.slider_Majority);
            this.Controls.Add(this.birthLabel);
            this.Controls.Add(this.birthSlider);
            this.Controls.Add(this.Recalculate);
            this.Controls.Add(this.noiseLabel);
            this.Controls.Add(this.noiseSlider);
            this.Controls.Add(this.nrrestartsLabel);
            this.Controls.Add(this.nrroundsLabel);
            this.Controls.Add(this.nrrestartsSlider);
            this.Controls.Add(this.nrroundsSlider);
            this.Controls.Add(this.currentProps);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.tickLabel);
            this.Controls.Add(this.plotView);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.setupButton);
            this.Controls.Add(this.nrLabel);
            this.Controls.Add(this.fpLabel);
            this.Controls.Add(this.unforgivingLabel);
            this.Controls.Add(this.pavlovLabel);
            this.Controls.Add(this.tft2Label);
            this.Controls.Add(this.tftLabel);
            this.Controls.Add(this.randomLabel);
            this.Controls.Add(this.allDLabel);
            this.Controls.Add(this.allCLabel);
            this.Controls.Add(this.proportionLabel);
            this.Controls.Add(this.slider_NR);
            this.Controls.Add(this.slider_FP);
            this.Controls.Add(this.slider_Unforgiving);
            this.Controls.Add(this.slider_Pavlov);
            this.Controls.Add(this.slider_TFT2);
            this.Controls.Add(this.slider_TFT);
            this.Controls.Add(this.slider_Random);
            this.Controls.Add(this.slider_AllD);
            this.Controls.Add(this.slider_AllC);
            this.Name = "Evolution";
            this.Text = "Replicator Dynamics";
            ((System.ComponentModel.ISupportInitialize)(this.slider_AllC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_AllD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Random)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_TFT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_TFT2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Pavlov)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Unforgiving)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_FP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_NR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrroundsSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nrrestartsSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.noiseSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.birthSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_Majority)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider_RL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer TickTimer;
        private System.Windows.Forms.TrackBar slider_AllC;
        private System.Windows.Forms.TrackBar slider_AllD;
        private System.Windows.Forms.TrackBar slider_Random;
        private System.Windows.Forms.TrackBar slider_TFT;
        private System.Windows.Forms.TrackBar slider_TFT2;
        private System.Windows.Forms.TrackBar slider_Pavlov;
        private System.Windows.Forms.TrackBar slider_Unforgiving;
        private System.Windows.Forms.TrackBar slider_FP;
        private System.Windows.Forms.TrackBar slider_NR;
        private System.Windows.Forms.Label proportionLabel;
        private System.Windows.Forms.Label allCLabel;
        private System.Windows.Forms.Label allDLabel;
        private System.Windows.Forms.Label randomLabel;
        private System.Windows.Forms.Label tftLabel;
        private System.Windows.Forms.Label tft2Label;
        private System.Windows.Forms.Label pavlovLabel;
        private System.Windows.Forms.Label unforgivingLabel;
        private System.Windows.Forms.Label fpLabel;
        private System.Windows.Forms.Label nrLabel;
        private System.Windows.Forms.Button setupButton;
        private System.Windows.Forms.Button playButton;
        private OxyPlot.WindowsForms.PlotView plotView;
        private System.Windows.Forms.Label tickLabel;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox currentProps;
        private System.Windows.Forms.TrackBar nrroundsSlider;
        private System.Windows.Forms.TrackBar nrrestartsSlider;
        private System.Windows.Forms.Label nrroundsLabel;
        private System.Windows.Forms.Label nrrestartsLabel;
        private System.Windows.Forms.TrackBar noiseSlider;
        private System.Windows.Forms.Label noiseLabel;
        private System.Windows.Forms.Button Recalculate;
        private System.Windows.Forms.TrackBar birthSlider;
        private System.Windows.Forms.Label birthLabel;
        private System.Windows.Forms.TrackBar slider_Majority;
        private System.Windows.Forms.Label label_Majority;
        private System.Windows.Forms.TrackBar slider_RL;
        private System.Windows.Forms.Label label_RL;
    }
}

