using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MacPWindowsSoundControl;

namespace MacPReminder
{
    public partial class frmReminder : Form
    {
        private bool _setSystemSoundVolume;

        SoundPlayer alarmSound = null;
        MacPVolumeControl macPVolumenControl = null;


        public frmReminder(string message, bool skipSystemSoundVolume)
        {
            string appPath = Application.StartupPath;

            InitializeComponent();

            _setSystemSoundVolume = !skipSystemSoundVolume;

            //Windows volume up
            if (_setSystemSoundVolume)
            {
                macPVolumenControl = new MacPVolumeControl(this.Handle);
                macPVolumenControl.TurnVolumeUp(15);
            }

            lblMessage.Text = message;
            alarmSound = new SoundPlayer(appPath + "\\Sounds\\Reminder.wav");
            alarmSound.Play();
        }

        private void frmReminder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                this.Left -= 10;
            }
            if (e.KeyCode == Keys.Right)
            {
                this.Left += 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.Top -= 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                this.Top += 10;
            }
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            //Windows volume down
            if (_setSystemSoundVolume)
            {
                macPVolumenControl.TurnVolumeDown(15);
            }

            Application.Exit();
        }
    }
}
