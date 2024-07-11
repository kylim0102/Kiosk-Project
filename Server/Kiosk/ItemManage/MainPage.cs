﻿using Google.Protobuf.WellKnownTypes;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Kiosk.ItemManage.ItemPanel.OptionPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kiosk.ItemManage
{
    public partial class MainPage : Form
    {
        ItemPanel.ItemPanel item = new ItemPanel.ItemPanel();
        ItemPanel.CategoryPanel category = new ItemPanel.CategoryPanel();
        ItemPanel.OptionPanel option = new ItemPanel.OptionPanel();
        ItemPanel.Itemmanage itemmanage = new ItemPanel.Itemmanage();
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(category);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(option);

        }

        private void button4_Click(object sender, EventArgs e)
        {

            /*MySqlConnection conn = oGlobal.GetConnection();
            conn.Open();
            int idx = 98;
            string option = SharedData.Option;
            
            try
            {

                string query = "INSERT INTO test (idx, name) VALUES (@idx, @option)"; // 테이블 쿼리
                MySqlCommand cmd = new MySqlCommand(query, conn);

                // 파라미터 추가
                cmd.Parameters.AddWithValue("@idx", idx);
                cmd.Parameters.AddWithValue("@option", option);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("데이터가 성공적으로 삽입되었습니다.");
                }
                else
                {
                    MessageBox.Show("데이터 삽입에 실패했습니다.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
            finally
            {
                conn.Close();
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            // panel 하나 만들어서 생성
            panel1.Controls.Clear();
            panel1.Controls.Add(itemmanage);
        }
    }
}