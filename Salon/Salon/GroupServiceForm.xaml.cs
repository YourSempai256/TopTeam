﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для GroupServiceForm.xaml
    /// </summary>
    public partial class GroupServiceForm : Window
    {
        public GroupServiceForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            GroupServiceActionForm grserv = new GroupServiceActionForm(FormState.Add);
            grserv.ShowDialog();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            GroupServiceActionForm grserv = new GroupServiceActionForm(FormState.Edit);
            grserv.ShowDialog();
        }
    }
}
