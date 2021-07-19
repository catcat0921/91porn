﻿using System;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace M3U8_Downloader
{
    public partial class SetForm : Form
    {
        public string m_path;
        public string m_proxy;

        public SetForm()
        {
            InitializeComponent();
        }

        private void button_Ok_Click(object sender, EventArgs e)
        {
            m_path = textBoxPath.Text;
            m_proxy = textBoxProxy.Text;

            XmlDocument doc = new XmlDocument();
            doc.Load(System.Environment.CurrentDirectory + "\\settings\\M3u8_Downloader_Settings.xml");    //加载Xml文件  
            doc.SelectSingleNode("//DownPath").InnerText = m_path;
            doc.SelectSingleNode("//HttpProxy").InnerText = m_proxy;
            doc.Save(System.Environment.CurrentDirectory + "\\settings\\M3u8_Downloader_Settings.xml");


            this.DialogResult = DialogResult.OK;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetForm_Load(object sender, EventArgs e)
        {
            
            if (File.Exists(System.Environment.CurrentDirectory + "\\settings\\M3u8_Downloader_Settings.xml"))  //判断程序目录有无配置文件，并读取文件
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Environment.CurrentDirectory + "\\settings\\M3u8_Downloader_Settings.xml");    //加载Xml文件  
                m_path = doc.SelectSingleNode("//DownPath").InnerText;
                m_proxy = doc.SelectSingleNode("//HttpProxy").InnerText;
            }
            else  //若无配置文件，获取当前程序运行路径，即为默认下载路径
            {
                m_path = System.Environment.CurrentDirectory;
                m_proxy = "";
            }

            textBoxPath.Text = m_path;
            textBoxProxy.Text = m_proxy;
        }


        private void button_Choose_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }
    }
}
