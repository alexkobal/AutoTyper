using AutoTyperGUI.Model;
using System;
using System.Windows.Forms;

namespace AutoTyperGUI.View
{
    /// <summary>
    /// Class for the Settings window view
    /// </summary>
    public partial class Settings : Form
    {
        /// <summary>
        /// Refference to the AutoTypeSettings objec that is being set
        /// Should be initialized in the constructor
        /// </summary>
        private AutoTypeSettings AutoTypeSettings { get; }

        /// <summary>
        /// Constructor to initilize the Settings window view
        /// </summary>
        /// <param name="autoTypeSettings">Refference to the AutoTypeSetting object which is being set</param>
        public Settings(AutoTypeSettings autoTypeSettings)
        {
            AutoTypeSettings = autoTypeSettings;
            InitializeComponent();
        }

        /// <summary>
        /// OnLoad event handler. Initializes the view elements based on the proveded AutoTypeSettins
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void Settings_Load(object sender, EventArgs e)
        {
            wpmTrackBar.Value = AutoTypeSettings.TypingSpeed.WordsPerMin;
            wpmSpeedLabel.Text = wpmTrackBar.Value.ToString();
            if (AutoTypeSettings.StdDeviation == 0)
                checkBox1.Checked = false;
            else
                checkBox1.Checked = true;
        }

        /// <summary>
        /// ScrollBar change event handler
        /// Sets the speed label value
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void wpmTrackBar_Scroll(object sender, EventArgs e)
        {
            wpmSpeedLabel.Text = wpmTrackBar.Value.ToString();
        }

        /// <summary>
        /// OK button click event handler
        /// Updates the AutoTypeSettins object and closes the settings window
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void OK_Click(object sender, EventArgs e)
        {
            AutoTypeSettings.TypingSpeed.WordsPerMin = wpmTrackBar.Value;
            if (checkBox1.Checked)
                AutoTypeSettings.StdDeviation = 30;
            else
                AutoTypeSettings.StdDeviation = 0;
            this.Close();
        }

        /// <summary>
        /// Cancel button click event handler
        /// Closes the settings window without updating the AutoTypeSettins object
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void wpmSpeedLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
