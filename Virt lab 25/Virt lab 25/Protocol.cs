using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security;
using System.Text;

namespace Virt_lab_25
{
    public partial class Protocol : Form
    {
        DateTime currentDate = DateTime.Now;
        
        string key = "b22ca5898a4e1133bbce2ea2022a1916";
        string[] encryptedString = new string[5];
        
        
        
        public string полноеИмя = "";
        public string группаИмя = "";
        public string workName = "Лабораторная работа 'Определение коэффициента самоиндукции катушки'";
        
        public string fullnameDecrypted = "";
        public string groupNameDecrypted = "";
        public string countErrorsDecrypted = "";
        public string workNameDecrypted = "";
        public string currentDateDecrypted = "";
        public string minimumLenghtDecrypted = "";
        public string maximumLenghtDecrypted = "";
        
        public int количествоОшибок = 0;

        public bool isWorkWasSuccess = true;
        
        public Protocol()
        {
            InitializeComponent();
            MaximizeBox = false;
            saveFileDialog1.Filter = "Prot files(*.prot)|*.prot";
            saveFileDialog1.AddExtension = true;
        }

        private void Protocol_Load(object sender, EventArgs e)
        {
            if (isWorkWasSuccess)
            {
                if (количествоОшибок == 0)
                {
                    label1.Text = "Время выполнения работы: " + currentDate + "\n" + workName + "\nФИО:  " + полноеИмя + "\nГруппа: " + группаИмя + "\nЛабораторная работа выполнена успешно." +  "\nКоличество ошибок: " + количествоОшибок.ToString();
                }
                else
                {
                    label1.Text = "Время выполнения работы: " + currentDate + "\n" + workName + "\nФИО:  " + полноеИмя + "\nГруппа: " + группаИмя + "\nЛабораторная работа выполнена с ошибками."  +  "\nКоличество ошибок: " + количествоОшибок.ToString();
                }
            }
            else
            {
                label1.Text = "Время выполнения работы: " + currentDate + "\n" + workName + "\nФИО:  " + полноеИмя + "\nГруппа: " + группаИмя + "\nЛабораторная работа выполнена не до конца/не выполнена." ;
                exportProtocol.Enabled = false;
            }
                

            
        }

        private void exportProtocol_Click(object sender, EventArgs e)
        {
            var str = label1.Text;
            var encryptedString = AesOperation.EncryptString(key, str);

            var nameEncrypted = AesOperation.EncryptString(key, полноеИмя);
            var groupNameEncrypted = AesOperation.EncryptString(key, группаИмя);
            var countErrorsEncrypted = AesOperation.EncryptString(key, количествоОшибок.ToString());
            var workNameEncrypted = AesOperation.EncryptString(key, workName);
            var currentDateEncrypted = AesOperation.EncryptString(key, currentDate.ToString());
          

            string[] encryptedStrings = new string[] { nameEncrypted, groupNameEncrypted, countErrorsEncrypted, workNameEncrypted, currentDateEncrypted };

            this.encryptedString = encryptedStrings;

            //System.IO.File.WriteAllText("protocol.prot", encryptedStrings);
           // File.WriteAllLines(fullName + "_Лаб25_ " + groupName  + ".prot", encryptedStrings);
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveFileDialog1.FileName, encryptedStrings);
            }
            MessageBox.Show("Протокол выгружен");
        }


    }

    public class AesOperation
    {
        public static string EncryptString(string key, string plainText)
        {
            byte[] iv = new byte[16];
            byte[] array;

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))
                        {
                            streamWriter.Write(plainText);
                        }

                        array = memoryStream.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(array);
        }

        public static string DecryptString(string key, string cipherText)
        {
            byte[] iv = new byte[16];
            byte[] buffer = Convert.FromBase64String(cipherText);

            using (Aes aes = Aes.Create())
            {
                aes.Key = Encoding.UTF8.GetBytes(key);
                aes.IV = iv;
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream(buffer))
                {
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))
                        {
                            return streamReader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}