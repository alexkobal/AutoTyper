using AutoTyperGUI.View;
using System;
using System.Windows.Forms;

namespace AutoTyperGUI
{
    /// <summary>
    /// Class for application context
    /// </summary>
    internal class AutoTyperApplicationContext : ApplicationContext
    {
        /// <summary>
        /// Object to show an icon on the system tray
        /// </summary>
        private NotifyIcon notifyIcon;

        /// <summary>
        /// Instance of the configuration window view
        /// </summary>
        ConfigurationWindow configWindow = new ConfigurationWindow();

        /// <summary>
        /// Cosntructor
        /// Initializes the system tray icon
        /// Opens the configuration window by default
        /// </summary>
        public AutoTyperApplicationContext()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = Properties.Resources.AppIcon;
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[]
                { configMenuItem, exitMenuItem });
            notifyIcon.Visible = true;
            showConfigWindow();
        }

        /// <summary>
        /// Event handler for the Configuration option when right clicking on the system tray icon
        /// Opens the configuration window
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window, merely focus it.
            showConfigWindow();
        }

        /// <summary>
        /// Event handler for the Exit option when right clicking on the system tray icon
        /// Closes the application
        /// </summary>
        /// <param name="sender">Event sender object</param>
        /// <param name="e">Event arguments</param>
        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            Application.Exit();
        }

        /// <summary>
        /// Show the configuration window if it is not showing
        /// </summary>
        private void showConfigWindow()
        {
            if (configWindow.Visible)
            {
                configWindow.Activate();
            }
            else
            {
                configWindow.ShowDialog();
            }
        }
    }
}
