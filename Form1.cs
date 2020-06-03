using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TraficLights
{
    public partial class TraficLights : Form
    {
        private Timer timerSwitch;
        private Timer timerRedBlinking;
        private Timer timerGreenBlinking;

        int timerCounter = 0;

        Random rand = new Random();

        public TraficLights()
        {
            InitializeComponent();
            InitializeLights();

            InitializeTimerSwitch();

            InitializeTimerRedBlinking();
            InitializeTimerGreenBlinking();
        }
        public void InitializeLights()
        {
            RedLight.BackColor = Color.Gray;
            YellowLight.BackColor = Color.Gray;
            GreenLight.BackColor = Color.Gray;
        }
        private void InitializeTimerSwitch()
        {
            timerSwitch = new Timer();
            timerSwitch.Interval = 1000;
            timerSwitch.Tick += new EventHandler(TimerSwitch_Tick);
            timerSwitch.Start();
        }
        
        private void TimerSwitch_Tick(object sender, EventArgs e)
        {
            timerCounter += 1;
            if (timerCounter == 1)
            {
                timerGreenBlinking.Stop();
                RedLight.BackColor = Color.Red;
                YellowLight.BackColor = Color.Gray;
            }
            else if (timerCounter == 4)
            {
                timerRedBlinking.Start();
                YellowLight.BackColor = Color.Yellow;
            }
            else if(timerCounter == 6)
            {
                timerRedBlinking.Stop();
                GreenLight.BackColor = Color.LightGreen;
                YellowLight.BackColor = Color.Gray;
            }
            else if(timerCounter == 8)
            {
                timerGreenBlinking.Start();
                YellowLight.BackColor = Color.Yellow;
            }
            
            if(timerCounter > 12)
            {
                timerCounter = 0;
            }
        }

        private void InitializeTimerRedBlinking()
        {
            timerRedBlinking = new Timer();
            timerRedBlinking.Interval = 500;
            timerRedBlinking.Tick += new EventHandler(TimerRedBlinking_Tick);   
        }

        private void TimerRedBlinking_Tick(object sender, EventArgs e)
        {
            if(RedLight.BackColor == Color.Red)
            {
                RedLight.BackColor = Color.Gray;
            }
            else
            {
                RedLight.BackColor = Color.Red;
            }
        }

        private void InitializeTimerGreenBlinking()
        {
            timerGreenBlinking = new Timer();
            timerGreenBlinking.Interval = 500;
            timerGreenBlinking.Tick += new EventHandler(TimerGreenBlinking_Tick);
        }

        private void TimerGreenBlinking_Tick(object sender, EventArgs e)
        {
            if (GreenLight.BackColor == Color.LightGreen)
            {
                GreenLight.BackColor = Color.Gray;
            }
            else
            {
                GreenLight.BackColor = Color.LightGreen;
            }
        }


        
    }
}
