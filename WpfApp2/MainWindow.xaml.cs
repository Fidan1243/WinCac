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

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string ope = "";
        bool op = false;
        int num1 = 0;
        int num2 = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (sender is Button bt)
            {
                if (bt.Content.ToString() == "C")
                {
                    label1.Content = "0";
                    num1 = 0;
                    num2 = 0;
                    ope = "";
                }
                else if (bt.Content.ToString() == "+" || bt.Content.ToString() == "-" || bt.Content.ToString() == "*" || bt.Content.ToString() == "/")
                {
                    if (!op)
                    {
                        ope = bt.Content.ToString();
                        label2.Content = label1.Content;
                        label1.Content = "0";
                        label3.Content = ope;
                        op = true;
                    }
                    else
                    {
                        Op(bt.Content.ToString(), false);
                    }
                    
                }
                else if (bt.Content.ToString() == "=")
                {
                    label2.Content = "";
                    label3.Content = "";
                    Op("", true);
                }
                else if(bt.Content.ToString() == "X")
                {
                    this.Close();
                }
                else
                {
                    if (ope == "")
                    {
                        num1 = (num1 * 10) + Convert.ToInt32(bt.Content);
                        label1.Content = num1;
                    }
                    else
                    {
                        num2 = (num2 * 10) + Convert.ToInt32(bt.Content);
                        label1.Content = num2;
                    }
                }
            }
            
        }
        private void Op(string newop, bool isEq)
        {
            switch (ope)
            {
                case "+":
                    {
                        if (isEq)
                        {
                            label1.Content = num1 + num2;
                            num1 = Convert.ToInt32(label1.Content.ToString());
                            ope = "";
                            num2 = 0;
                        }
                        else
                        {
                            label2.Content = num1 + num2;
                            label1.Content = "0";
                            label3.Content = ope;
                            ope = newop;
                            num1 = Convert.ToInt32(label2.Content.ToString());
                            num2 = 0;
                        }
                        
                        break;
                    }
                case "-":
                    {
                        if (isEq)
                        {
                            label1.Content = num1 - num2;
                            num1 = Convert.ToInt32(label1.Content.ToString());
                            ope = "";
                            num2 = 0;
                        }
                        else
                        {
                            label2.Content = num1 - num2;
                            label1.Content = "0";
                            label3.Content = ope;
                            ope = newop;
                            num1 = Convert.ToInt32(label2.Content.ToString());
                            num2 = 0;
                        }
                        break;
                    }
                case "*":
                    {
                        if (isEq)
                        {
                            label1.Content = num1 * num2;
                            num1 = Convert.ToInt32(label1.Content.ToString());
                            ope = "";
                            num2 = 0;
                        }
                        else
                        {
                            label2.Content = num1 * num2;
                            label1.Content = "0";
                            label3.Content = ope;
                            ope = newop;
                            num1 = Convert.ToInt32(label2.Content.ToString());
                            num2 = 0;
                        }
                        break;
                    }
                case "/":
                    {
                        if (num2 == 0)
                        {
                            label1.Content = "Divided by zero is invalid";
                            ope = "";
                            num2 = 0;
                            num1 = 0;
                        }
                        else
                        {
                            if (isEq)
                            {
                                label1.Content = num1 / num2;
                                num1 = Convert.ToInt32(label1.Content.ToString());
                                ope = "";
                                num2 = 0;
                            }
                            else
                            {
                                label2.Content = num1 / num2;
                                label1.Content = "0";
                                label3.Content = ope;
                                ope = newop;
                                num1 = Convert.ToInt32(label2.Content.ToString());
                                num2 = 0;
                            }
                        }
                        break;
                    }
                default:
                    break;
            }
        }


    }

}
