using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WFA_MailAyristirma
{
    public partial class Form1 : MetroForm
    {
        #region Fields
        private List<string> hotmailList = new List<string>();
        private List<string> hotmailTrList = new List<string>();
        private List<string> hotmailNetList = new List<string>();
        private List<string> gmailList = new List<string>();
        private List<string> gmailTrList = new List<string>();
        private List<string> gmailNetList = new List<string>();
        private List<string> trashList = new List<string>();
        #endregion

        #region Getters
        public int HotmailCount => hotmailList?.Count() ?? 0;
        public int HotmailTrCount => hotmailTrList?.Count() ?? 0;
        public int hotmailNetCount => hotmailNetList?.Count() ?? 0;
        public int GmailCount => hotmailNetList?.Count() ?? 0;
        public int GmailTrCount => hotmailNetList?.Count() ?? 0;
        public int GmailNetCount => hotmailNetList?.Count() ?? 0;
        #endregion

        #region Utilities
        private void Add()
        {
            if (String.IsNullOrWhiteSpace(mailAddress.Text.Trim()))
            {
                MessageBox.Show("Mail adresi boş olamaz!");
                return;
            }

            var _mailAddress = mailAddress.Text;
            var mails = _mailAddress.Split(new char[] { ';' });

            foreach (var mail in mails)
            {
                var endValue = mail.Split(new char[] { '@' });
                if (endValue.Length != 2)
                    break;

                switch (endValue[1].Trim())
                {
                    case "hotmail.com":
                        hotmailList.Add(mail);
                        break;
                    case "hotmail.com.tr":
                        hotmailTrList.Add(mail);
                        break;
                    case "hotmail.net":
                        hotmailNetList.Add(mail);
                        break;
                    case "gmail.com":
                        gmailList.Add(mail);
                        break;
                    case "gmail.com.tr":
                        gmailTrList.Add(mail);
                        break;
                    case "gmail.net":
                        gmailNetList.Add(mail);
                        break;

                    default: trashList.Add(mail); break;
                }
            }
        }

        private void ClearList()
        {
            hotmailList.Clear();
            hotmailTrList.Clear();
            hotmailNetList.Clear();
            gmailList.Clear();
            gmailTrList.Clear();
            gmailNetList.Clear();
            trashList.Clear();

            //Todo: Clear listbox items
        }

        private void FillListBoxes()
        {
            lstHotmailCom.Items.AddRange(hotmailList.ToArray());
            lstHotmailComTr.Items.AddRange(hotmailTrList.ToArray());
            lstHotmailNet.Items.AddRange(hotmailNetList.ToArray());
            lstGmailCom.Items.AddRange(gmailList.ToArray());
            lstGmailComTr.Items.AddRange(gmailTrList.ToArray());
            lstGmailNet.Items.AddRange(gmailNetList.ToArray());

            lstCopKutusu.Items.AddRange(trashList.ToArray());


        }


        private void Contery()
        {
            //Set count of the list
            metroLabel14.Text = HotmailCount.ToString();
            lblHotmailComTr.Text = HotmailTrCount.ToString();
            lblHotmailNet.Text = hotmailNetCount.ToString();
            lblGmailCom.Text = GmailCount.ToString();
            lblGmailComTr.Text = GmailTrCount.ToString();
            lblGmailNet.Text = GmailNetCount.ToString();
        }
        #endregion

        #region Ctor
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        private void metroButton2_Click(object sender, EventArgs e)
        {
            FillListBoxes();
            Contery();
        }



        private void metroButton1_Click(object sender, EventArgs e)
        {
            ClearList();
            Add();
        }
    }
}
