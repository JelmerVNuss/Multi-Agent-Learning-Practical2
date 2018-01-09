// ===============================
// AUTHOR       : Maaike Burghoorn, Wouter van 't Hof
// CREATE DATE  : January 2018
// COURSE       : Multi-agent systems - Utrecht University 2017/2018
// PURPOSE      : Draws score table and plot on form
// SPECIAL NOTES: Also takes care of updates per tick and user input in windows form.
// ===============================
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;

namespace EVOMAL
{
    public partial class Evolution : Form
    {
        //Global vars
        int tickCount;
        //There is a total of 11 strategies
        double[] allproportions = new double[11];
        Strategy[] strategies = new Strategy[11];
        double[,] scoreTable;
        //Slider values
        int nrrounds;
        int nrrestarts;
        double noise;
        double birthrate;
        //Plot vars
        PlotModel populationState;
        LinearAxis x_axis;
        LinearAxis y_axis;
        Dictionary<int, LineSeries> lines;
        //String names of strategies
        List<string> names = new List<string> {
                "AllC", "AllD", "Random",
                "TFT", "TFT2", "Pavlov",
                "Unforg", "FP", "NR",
                "Major", "RL"
        };

        public Evolution()
        {
            InitializeComponent();
            Setup();
        }

        //Initializes proportions and resets plot
        public void Setup()
        {
            tickCount = 0;
            initProps();
            initPlot();

            //Init slider values
            nrrounds = this.nrroundsSlider.Value;
            nrrestarts = this.nrrestartsSlider.Value;
            noise = (double)this.noiseSlider.Value / 100;
            birthrate = (double)this.birthSlider.Value / 100;

            //Create object strategy list
            createStrategies();         
        }

        public void createTable()
        {
            //Clear the score table view
            dataGridView.Rows.Clear();

            //Create score table
            scoreTable = UpdateLogic.scoreTable(nrrounds, nrrestarts, strategies, noise);
            initDataGrid();

            //Also calls setup
            Setup();
        }

        //Event called every tick
        private void TickTimer_Tick(object sender, EventArgs e)
        {
            //Update proportions for next time step using replicator equation
            allproportions = UpdateLogic.replicator(allproportions, scoreTable, birthrate);

            tickCount++;
            this.tickLabel.Text = String.Format("Ticks = {0}", tickCount);
            //Update plot
            updatePlot();

            //Update proportions in textbox
            updateTextBox();
        }

        //Most beautiful method in the framework
        public void initProps()
        {
            //Read all slider proportions
            allproportions[0] = slider_AllC.Value;
            allproportions[1] = slider_AllD.Value;
            allproportions[2] = slider_Random.Value;
            allproportions[3] = slider_TFT.Value;
            allproportions[4] = slider_TFT2.Value;
            allproportions[5] = slider_Pavlov.Value;
            allproportions[6] = slider_Unforgiving.Value;
            allproportions[7] = slider_FP.Value;
            allproportions[8] = slider_NR.Value;
            allproportions[9] = slider_Majority.Value;
            allproportions[10] = slider_RL.Value;

            //Normalize proportions
            double sum = allproportions.Sum();

            if (sum == 0) sum = 1;

            for (int i = 0; i < allproportions.Length; i++)
            {
                allproportions[i] /= sum;
            }

            //Update label text
            this.allCLabel.Text = String.Format("All_C = {0}", allproportions[0].ToString("F"));
            this.allDLabel.Text = String.Format("All_D = {0}", allproportions[1].ToString("F"));
            this.randomLabel.Text = String.Format("Random = {0}", allproportions[2].ToString("F"));
            this.tftLabel.Text = String.Format("TFT = {0}", allproportions[3].ToString("F"));
            this.tft2Label.Text = String.Format("TFT2 = {0}", allproportions[4].ToString("F"));
            this.pavlovLabel.Text = String.Format("Pavlov = {0}", allproportions[5].ToString("F"));
            this.unforgivingLabel.Text = String.Format("Unforgiving = {0}", allproportions[6].ToString("F"));
            this.fpLabel.Text = String.Format("SmoothFP = {0}", allproportions[7].ToString("F"));
            this.nrLabel.Text = String.Format("PropNR = {0}", allproportions[8].ToString("F"));
            this.label_Majority.Text = String.Format("Majority = {0}", allproportions[9].ToString("F"));
            this.label_RL.Text = String.Format("RL = {0}", allproportions[10].ToString("F"));

            //Update sliders
            this.slider_AllC.Value = (int)(allproportions[0] * 100);
            this.slider_AllD.Value = (int)(allproportions[1] * 100);
            this.slider_Random.Value = (int)(allproportions[2] * 100);
            this.slider_TFT.Value = (int)(allproportions[3] * 100);
            this.slider_TFT2.Value = (int)(allproportions[4] * 100);
            this.slider_Pavlov.Value = (int)(allproportions[5] * 100);
            this.slider_Unforgiving.Value = (int)(allproportions[6] * 100);
            this.slider_FP.Value = (int)(allproportions[7] * 100);
            this.slider_NR.Value = (int)(allproportions[8] * 100);
            this.slider_Majority.Value = (int)(allproportions[9] * 100);
            this.slider_RL.Value = (int)(allproportions[10] * 100);
        }

        public void createStrategies()
        {
            strategies[0] = new All_C();
            strategies[1] = new All_D();
            strategies[2] = new Randomly();
            strategies[3] = new TFT();
            strategies[4] = new TFT2();
            strategies[5] = new Pavlov();
            strategies[6] = new Unforgiving();
            strategies[7] = new SmoothFP();
            strategies[8] = new PropNR();
            strategies[9] = new Majority();
            strategies[10] = new RL();
        }

        #region Button Updates

        private void setupButton_Click(object sender, EventArgs e)
        {
            Setup();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (playButton.Text == "Play")
            {
                playButton.Text = "Pause";
                if (scoreTable == null)
                    createTable();

                TickTimer.Start();
            }

            else
            {
                playButton.Text = "Play";
                TickTimer.Stop();
            }
        }

        private void Recalculate_Click(object sender, EventArgs e)
        {
            createTable();
        }

        #endregion

        #region Slider Updates

        private void slider_AllC_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_AllC.Value / 100;
            this.allCLabel.Text = String.Format("All_C = {0}", newvalue.ToString("F"));
        }

        private void slider_AllD_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_AllD.Value / 100;
            this.allDLabel.Text = String.Format("All_D = {0}", newvalue.ToString("F"));
        }

        private void slider_Random_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_Random.Value / 100;
            this.randomLabel.Text = String.Format("Random = {0}", newvalue.ToString("F"));
        }

        private void slider_TFT_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_TFT.Value / 100;
            this.tftLabel.Text = String.Format("TFT = {0}", newvalue.ToString("F"));
        }

        private void slider_TFT2_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_TFT2.Value / 100;
            this.tft2Label.Text = String.Format("TFT2 = {0}", newvalue.ToString("F"));
        }

        private void slider_Pavlov_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_Pavlov.Value / 100;
            this.pavlovLabel.Text = String.Format("Pavlov = {0}", newvalue.ToString("F"));
        }

        private void slider_Unforgiving_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_Unforgiving.Value / 100;
            this.unforgivingLabel.Text = String.Format("Unforgiving = {0}", newvalue.ToString("F"));
        }

        private void slider_FP_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_FP.Value / 100;
            this.fpLabel.Text = String.Format("SmoothFP = {0}", newvalue.ToString("F"));
        }

        private void slider_NR_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double) slider_NR.Value / 100;
            this.nrLabel.Text = String.Format("ProprNR = {0}", newvalue.ToString("F"));
        }

        private void slider_Majority_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_Majority.Value / 100;
            this.label_Majority.Text = String.Format("Majority = {0}", newvalue.ToString("F"));
        }

        private void slider_RL_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)slider_RL.Value / 100;
            this.label_RL.Text = String.Format("RL = {0}", newvalue.ToString("F"));
        }

        private void nrroundsSlider_Scroll(object sender, EventArgs e)
        {
            int newvalue = nrroundsSlider.Value;
            nrrounds = newvalue;
            this.nrroundsLabel.Text = String.Format("nrrounds = {0}", newvalue);

        }

        private void nrrestartsSlider_Scroll(object sender, EventArgs e)
        {
            int newvalue = nrrestartsSlider.Value;
            nrrestarts = newvalue;
            this.nrrestartsLabel.Text = String.Format("nrrestarts = {0}", newvalue);

        }

        private void noiseSlider_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double) noiseSlider.Value / 100;
            noise = newvalue;
            this.noiseLabel.Text = String.Format("noise = {0}", newvalue);

        }

        private void birthSlider_Scroll(object sender, EventArgs e)
        {
            double newvalue = (double)birthSlider.Value / 100;
            birthrate = newvalue;
            this.birthLabel.Text = String.Format("birth rate = {0}", newvalue);
        }

        #endregion

        #region Plot
        public void initPlot()
        {
            //Create new plotmodel
            populationState = new PlotModel { Title = "Population State" };
            populationState.LegendTitle = "Strategies";
            populationState.LegendPosition = LegendPosition.RightTop;
            populationState.LegendPlacement = LegendPlacement.Outside;

            //Create x and y axis
            x_axis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 100,
                Title = "Ticks"
            };
            populationState.Axes.Add(x_axis);
            y_axis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = -0.1,
                Maximum = 1.1,
                Title = "Proportion"
            };
            populationState.Axes.Add(y_axis);

            //Create a line for each strategy
            lines = new Dictionary<int, LineSeries>();



            for (int i = 0; i < allproportions.Length; i++)
            {
                if (allproportions[i] != 0)
                {
                    LineSeries line1 = new LineSeries
                    {
                        Title = names[i],
                        StrokeThickness = 1
                    };

                    lines.Add(i, line1);
                }
            }

            //Add lines to plotmodel
            foreach (var line in lines)
            {
                populationState.Series.Add(line.Value);
            }

            //View plotmodel in plotview
            this.plotView.Model = populationState;
        }

        public void updatePlot()
        {
            //Add new datapoints to plot
            foreach (var line in lines)
            {
                line.Value.Points.Add(new DataPoint(tickCount, allproportions[line.Key]));
            }

            //If nr ticks exceeds x axis maximum, update x axis maximum
            if (tickCount >= x_axis.Maximum)
            {
                x_axis.Maximum = tickCount + 100;
            }
            this.populationState.InvalidatePlot(true);
            this.plotView.Invalidate();
        }
        #endregion

        #region Other form visualizations

        public void initDataGrid()
        {
            int height = scoreTable.GetLength(0);
            int width = scoreTable.GetLength(1);

            this.dataGridView.ColumnCount = width;

            for (int r = 0; r < height; r++)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(this.dataGridView);

                for (int c = 0; c < width; c++)
                {
                    //Numbers in table capped on 2 decimals
                    row.Cells[c].Value = Math.Round(scoreTable[r, c],2);
                }
                this.dataGridView.Rows.Add(row);
            }

            dataGridView.Columns[0].HeaderText = "AllC";
            dataGridView.Columns[1].HeaderText = "AllD";
            dataGridView.Columns[2].HeaderText = "Random";
            dataGridView.Columns[3].HeaderText = "TFT";
            dataGridView.Columns[4].HeaderText = "TFT2";
            dataGridView.Columns[5].HeaderText = "Pavlov";
            dataGridView.Columns[6].HeaderText = "Unf";
            dataGridView.Columns[7].HeaderText = "SmoothFP";
            dataGridView.Columns[8].HeaderText = "PropNR";
            dataGridView.Columns[9].HeaderText = "Major";
            dataGridView.Columns[10].HeaderText = "RL";

            dataGridView.Rows[0].HeaderCell.Value = "AllC";
            dataGridView.Rows[1].HeaderCell.Value = "AllD";
            dataGridView.Rows[2].HeaderCell.Value = "Random";
            dataGridView.Rows[3].HeaderCell.Value = "TFT";
            dataGridView.Rows[4].HeaderCell.Value = "TFT2";
            dataGridView.Rows[5].HeaderCell.Value = "Pavlov";
            dataGridView.Rows[6].HeaderCell.Value = "Unf";
            dataGridView.Rows[7].HeaderCell.Value = "SmoothFP";
            dataGridView.Rows[8].HeaderCell.Value = "PropNR";
            dataGridView.Rows[9].HeaderCell.Value = "Major";
            dataGridView.Rows[10].HeaderCell.Value = "RL";


            //Fit columns to content
            this.dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.RowHeadersWidth = 85;

            //Anti retard user :)
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToResizeRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView.ReadOnly = true;

            //Columns cant be sorted
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        public void updateTextBox()
        {
            this.currentProps.Text = "Proportions: \r\n";

            var sortedLines = lines.OrderByDescending(x => x.Value.Points.Last().Y);

            //Write proportions in textbox ordered by descending
            foreach (var l in sortedLines)
            {
                this.currentProps.Text += String.Format("{0} \t : \t {1} \r\n", names[l.Key], Math.Round(allproportions[l.Key], 5));
            }
        }

        #endregion
    }
}
