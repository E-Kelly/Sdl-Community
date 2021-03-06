﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sdl.Community.GroupShareKit.Models.Response.TranslationMemory;
using Sdl.Community.TMLifting.TranslationMemory;

namespace Sdl.Community.TMLifting
{
	public partial class LoginPage : Form
	{
		public AddServerBasedTMsDetails AddDetailsCallback;
		public LoginPage(string serverName)
		{
			InitializeComponent();
			serverNameTxtBox.Text = serverName;
		}

		private void serverNameTxtBox_TextChanged(object sender, EventArgs e)
		{

		}

		private async void btnOkServerBased_Click(object sender, EventArgs e)
		{
			var x  = await GetServerBasedTMs();
			AddDetailsCallback(userNameTxtBox.Text, passwordTxtBox.Text, serverNameTxtBox.Text);
			this.Close();
		}

		private async Task<ServerBasedTranslationMemory> GetServerBasedTMs()
		{
			try
			{
				return await ServerBasedTranslationMemory.CreateAsync(userNameTxtBox.Text, passwordTxtBox.Text, serverNameTxtBox.Text);
			}
			catch (Exception e)
			{
				MessageBox.Show(e.ToString());
				throw;
			}
		}

	}
}
