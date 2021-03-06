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
using System.Data;
using System.Data.SqlClient;
using Salon.Database;
using Salon.Extensions;
namespace Salon
{
    /// <summary>
    /// Логика взаимодействия для TariffActionForm.xaml
    /// </summary>
    public partial class TariffActionForm : Window
    {
        private readonly FormState _state;
        private readonly DataTable currentData;
        private readonly Action Back;
        public TariffActionForm(Action b, FormState state, string id=null, string serv_id=null)
        {
            InitializeComponent();
            Back = b;
            _state = state;
            switch (state)
            {
                case FormState.Edit:
                    HeaderLabel.Content = "Редактирование тарифа";
                    currentData = DBTariff.GetTariff(id);
                    PriceBox.Text = currentData.Rows[0]["Стоимость"].ToString();
                    StartDatePicker.SelectedDate = Convert.ToDateTime(currentData.Rows[0]["Дата начала"]);
                    ServiceCmbBox.ItemsSource = DBService.GetServices().DefaultView;
                    ServiceCmbBox.DisplayMemberPath = "Наименование";
                    ServiceCmbBox.SelectedValuePath = "id";
                    ServiceCmbBox.SelectedValue = currentData.Rows[0]["Услуга"].ToString();
                    break;
                case FormState.Add:
                    HeaderLabel.Content = "Добавление тарифа";
                    ServiceCmbBox.ItemsSource = DBService.GetServices().DefaultView;
                    ServiceCmbBox.DisplayMemberPath = "Наименование";
                    ServiceCmbBox.SelectedValuePath = "id";
                    break;
            }
        }

        private void ServiceForm_Click(object sender, RoutedEventArgs e)
        {
            ServiceForm service = new ServiceForm();
            service.ShowDialog();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (!PriceBox.Validate(true) || StartDatePicker.SelectedDate == null)
                {
                    return;
                }
                switch (_state)
                {
                    case FormState.Edit:
                        DBTariff.EditTariff(
                            currentData.Rows[0]["id"].ToString(),
                            ServiceCmbBox.SelectedValue.ToString(),
                            StartDatePicker.SelectedDate.ToString(),
                            Convert.ToDouble(PriceBox.Text)
                        );
                        break;
                    case FormState.Add:
                        DBTariff.AddTariff(
                            ServiceCmbBox.SelectedValue.ToString(),
                            StartDatePicker.SelectedDate.ToString(),
                            Convert.ToDouble(PriceBox.Text)
                        );
                        break;
                }

                Back();
                this.Close();
            }
            catch(System.FormatException)
            {
                MessageBox.Show("Введите правильную цену!");
            }
           
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ServiceFormButton_Click(object sender, RoutedEventArgs e)
        {
            ServiceForm type = new ServiceForm(() => { ServiceCmbBox.ItemsSource = DBService.GetServices().DefaultView; });
            type.ShowDialog();
        }
    }
}
