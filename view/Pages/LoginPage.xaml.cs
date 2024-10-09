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
using WpfApp25.Core;
using WpfApp25.Model;

namespace WpfApp25.view.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private ModelContext? _db=null;
        public LoginPage()
        {
            InitializeComponent();
            _db = new ModelContext();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            User? userModel = _db?.Users.FirstOrDefault(predicate: x=> x.Login== TbLogin.Text && x.Password==PbPassword.Password);
            if (userModel != null)
            {
                switch (userModel.Role.RoleID)
                {
                    case 1:
                        MessageBox.Show("Администратор",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
                        break;
                        case 2:
                        MessageBox.Show("Пользователь",
                           "Системное сообщение",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
                        break;
                        case 3:
                        MessageBox.Show("Гость",
                           "Системное сообщение",
                           MessageBoxButton.OK,
                           MessageBoxImage.Information);
                        break;

                }
            }
            else
            {
                MessageBox.Show("Ошибка ввода данных",
                            "Системное сообщение",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
            }
        }

        private void BtnRegistration_Click(object sender, RoutedEventArgs e)
        {
            Util.UtilFrame?.Navigate(new RegistrationPage());
        }
    }
}
