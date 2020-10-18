using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfExercise.Context;
using WpfExercise.Models;

namespace WpfExercise
{
    /// <summary>
    /// Interaction logic for SupplierMenu.xaml
    /// </summary>
    public partial class SupplierMenu : Page
    {
        MyContext myContext = new MyContext();
        public SupplierMenu()
        {
            InitializeComponent();
            SupplierTable.ItemsSource = myContext.Suppliers.ToList();

            textBoxId.IsEnabled = false;
        }

        private void SupplierTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                object supItem = SupplierTable.SelectedItem;
                
                string supId = (SupplierTable.SelectedCells[0].Column.GetCellContent(supItem) as TextBlock).Text;
                textBoxId.Text = supId;

                string supName = (SupplierTable.SelectedCells[1].Column.GetCellContent(supItem) as TextBlock).Text;
                textBoxName.Text = supName;
            }
            catch (Exception)
            {

            }
        }
        private void InputButton_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Anda belum memasukkan data");
            }
            else
            {
                var supplierInput = new Supplier(textBoxName.Text);
                myContext.Suppliers.Add(supplierInput);
                myContext.SaveChanges();

                MessageBox.Show($"Input {textBoxName.Text} berhasil");
                SupplierTable.ItemsSource = myContext.Suppliers.ToList();
                textBoxName.Clear();

            }
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxId.Text == string.Empty || textBoxName.Text == string.Empty)
            {
                MessageBox.Show("Pilih data yang ingin di update terlebih dahulu", "Peringatan");
            }
            else
            {
                int Id = (SupplierTable.SelectedItem as Supplier).Id;

                Supplier updateSupplier = myContext.Suppliers.Where(updateData => updateData.Id == Id).Single();
                updateSupplier.Name = textBoxName.Text;
                myContext.SaveChanges();

                MessageBox.Show($"{updateSupplier.Id} berhasil di update");
                SupplierTable.ItemsSource = myContext.Suppliers.ToList();
                textBoxId.Clear();
                textBoxName.Clear();
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if(textBoxName.Text == string.Empty || textBoxId.Text == string.Empty)
            {
                MessageBox.Show("Pilih terlebih dahulu data yang akan dihapus");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Anda Yakin Ingin Menghapus Data???", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if(result == MessageBoxResult.Yes)
                {
                    int supId = (SupplierTable.SelectedItem as Supplier).Id;

                    var deleteSupplier = myContext.Suppliers.Where(delete => delete.Id == supId).Single();
                    myContext.Suppliers.Remove(deleteSupplier);
                    myContext.SaveChanges();
                    SupplierTable.ItemsSource = myContext.Suppliers.ToList();

                    MessageBox.Show($"Data {textBoxId.Name} berhasil dihapus");
                    textBoxId.Clear();
                    textBoxName.Clear();
                }
                else
                {
                    SupplierTable.ItemsSource = myContext.Suppliers.ToList();
                }
            }
        }

        
    }
}
