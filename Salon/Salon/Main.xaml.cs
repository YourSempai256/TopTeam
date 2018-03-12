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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        public Main()
        {
            InitializeComponent();

            DBCore.Init("LENOVO-PC");

            //var result = DBBill.GetBills();
        }

        private void Prototype_Click(object sender, RoutedEventArgs e)
        {
            MasterPage master = new MasterPage();
            master.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DBCore.Destroy();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form = new BillForm();
            form.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var form = new PaymentMethodForm();
            form.ShowDialog();
        }

        private void Client_Click(object sender, RoutedEventArgs e)
        {
            ClientForm client = new ClientForm();
            client.ShowDialog();
        }

        private void Visit_Click(object sender, RoutedEventArgs e)
        {
            VisitForm visit = new VisitForm();
            visit.ShowDialog();
        }

        private void ProvidingService_Click(object sender, RoutedEventArgs e)
        {
            ProvidingServiceForm services = new ProvidingServiceForm();
            services.ShowDialog();
        }
        private void Status_Click(object sender, RoutedEventArgs e)
        {
            StatusForm status = new StatusForm();
            status.ShowDialog();
        }

        private void Tariff_Click(object sender, RoutedEventArgs e)
        {
            TariffForm tariff = new TariffForm();
            tariff.ShowDialog();
        }

       

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            var form = new BankCardForm();
            form.ShowDialog();
        }

        private void SpisokUslug_Click(object sender, RoutedEventArgs e)
        {
            ServiceForm service = new ServiceForm();
            service.ShowDialog();
        }


       


        private void GroupService_Click(object sender, RoutedEventArgs e)
        {
            GroupServiceForm group_service = new GroupServiceForm();
            group_service.ShowDialog();
        }

        private void TypeService_Click(object sender, RoutedEventArgs e)
        {
            TypeServiceForm type_service = new TypeServiceForm();
            type_service.ShowDialog();
        }

        private void KindService_Click(object sender, RoutedEventArgs e)
        {
            KindService kind_service = new KindService();
            kind_service.ShowDialog();
        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            WorkerForm worker = new WorkerForm();
            worker.ShowDialog();
        }
    }
}
