using BankAccountApp;
using System;
using System.Windows.Forms;

namespace DNTULoginForm
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // .NET 6 WinForms chuẩn
            

            using (var login = new LoginForm())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    // Nếu MainForm có ctor nhận context:
                    // var main = new MainForm(login.CurrentUser);

                    // Nếu không có, dùng ctor mặc định:
                    var main = new MainForm();
                    Application.Run(main);
                }
            }
        }
    }
}
