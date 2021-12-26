using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Security;
using System.Text;

namespace Virt_lab_25
{
    public partial class ProtocolImport : Form
    {
        
        string key = "b22ca5898a4e1133bbce2ea2022a1916";
        private string fullnameDecrypted = "";
        private string groupNameDecrypted = "";
        private string countErrorsDecrypted = "";
        private string workNameDecrypted = "";
        private string currentDateDecrypted = " ";
      
        
        public ProtocolImport()
        {
            InitializeComponent();
            MaximizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var sr = new StreamReader(openFileDialog1.FileName);
                    if (Path.GetExtension(openFileDialog1.FileName) == ".prot")
                    {
                        var list = new List<string>();
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine();
                            list.Add(line);
                        }

                        var arrTheoria = list.ToArray();

                        this.fullnameDecrypted = AesOperation.DecryptString(key, arrTheoria[0]);
                        this.groupNameDecrypted = AesOperation.DecryptString(key, arrTheoria[1]);
                        this.countErrorsDecrypted = AesOperation.DecryptString(key, arrTheoria[2]);
                        this.workNameDecrypted = AesOperation.DecryptString(key, arrTheoria[3]);
                        this.currentDateDecrypted = AesOperation.DecryptString(key, arrTheoria[4]);
          

                        MessageBox.Show("Протокол загружен");
                    }
                    else
                    {
                        MessageBox.Show("Не поддерживаемый файл");
                        return;
                    }

                    sr.Close();

                    if (Convert.ToInt32(this.countErrorsDecrypted) == 0)
                    {
                        label1.Text = "Время выполнения работы: " + this.currentDateDecrypted + "\n" +
                                      this.workNameDecrypted + "\nФИО:  " + this.fullnameDecrypted + "\nГруппа: " +
                                      this.groupNameDecrypted + "\nЛабораторная работа выполнена успешно." + "\nКоличество ошибок: " + this.countErrorsDecrypted;
                    }
                    else
                    {
                        label1.Text = "Время выполнения работы: " + this.currentDateDecrypted + "\n" +
                                      this.workNameDecrypted + "\nФИО:  " + this.fullnameDecrypted + "\nГруппа: " +
                                      this.groupNameDecrypted + "\nЛабораторная работа выполнена с ошибками." +
                                      "\nКоличество ошибок: " + this.countErrorsDecrypted;
                    }
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show("Чет не то");
                }
            }
        }
    }
    
    
}
