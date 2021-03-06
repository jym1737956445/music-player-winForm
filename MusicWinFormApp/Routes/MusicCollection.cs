﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MusicWinFormApp.XmlRepositories;
using MusicWinFormApp.Models;

namespace MusicWinFormApp.Routes
{
    public partial class MusicCollection : UserControl
    {
        private MusicsRepository _music = new MusicsRepository();
        private Music music = new Music();
        public MusicCollection()
        {
            InitializeComponent();
        }

        private void MusicCollection_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = _music.FindMusicByType(2);
            listBox1.DisplayMember = "Name";
        }

        private void AddFavoriteBtn_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(music.Name))
            {
                music.MusicType = 1;
                _music.AddXMLElement(music);
                _music.LoadXMLFile();
            }
            else
            {

            }
        }

        private void ListBox1_MouseClick(object sender, MouseEventArgs e)
        {
            int index = listBox1.IndexFromPoint(e.X, e.Y);
            listBox1.SelectedIndex = index;
            if (listBox1.SelectedIndex != -1)
            {
                music = listBox1.SelectedItem as Music;
            }
        }

        private void RemoveFavorite_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(music.Name))
            {
                _music.DeleteXMLElement(music.Id);
                _music.LoadXMLFile();
            }
            else
            {

            }
        }
    }
}
