using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace Kiosk.pPanel.common
{
    #region To CategoryPanel.cs
    internal class CategoryTable
    {
        private MySqlConnection mysql = oGlobal.GetConnection();
        private string sql = null;
        int result = 0;

        public int CategoryTableCount()
        {
            try
            {
                sql = "select count(*) as count from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetInt32("count");
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
        
        public int CategoryRegister(string category_code, string category_name)
        {
            try
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                sql = "insert into categorytable(cg_code, cg_name, regdate) values(@cg_code, @cg_name, regdate)";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                cmd.Parameters.AddWithValue("@cg_code", category_code);
                cmd.Parameters.AddWithValue("@cg_name", category_name);
                cmd.Parameters.AddWithValue("@regdate", now);

                result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("카테고리 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("카테고리 등록에 성공했습니다!", "CATEGORY REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }

        public int CategoryMaxCode()
        {
            try
            {
                sql = "select max(cg_code) as max from categorytable";

                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetInt32("max") + 10;
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
    }
    #endregion

    #region To ItemPanel.cs
    internal class ItemTable
    {

    }
    #endregion


    #region To OptionPanel.cs
    internal class OptionTable
    {

    }
    #endregion
}
