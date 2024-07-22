using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Kiosk.common
{
    internal class Mysql
    {
        public static MySqlConnection DBconnection;
        // 데이터베이스 연결 하는 부분 수정 해야함 
        #region 전역 데이터베이스 연결
        public static void DB_Connection()
        {
            if (DBconnection == null)
            {
                MySqlConnectionStringBuilder connStringBuilder = new MySqlConnectionStringBuilder
                {
                    Server = "kiosk.mysql.database.azure.com",
                    Port = 3306,
                    Database = "kiosk",
                    UserID = "youngjin",
                    Password = "admin123456789;"
                };

                DBconnection = new MySqlConnection(connStringBuilder.ConnectionString);
                DBconnection.Open();
            }
        }
        #endregion

        #region MySqlHelper.GetConnection(); 을 쓰면 db 연결
        public static MySqlConnection GetConnection()
        {
            if (DBconnection == null)
            {
                DB_Connection();
            }

            return DBconnection;
        }
        #endregion
    }

    #region KioskPanel.cs
    internal class ItemInsert
    {
        private static MySqlConnection mysql = Mysql.GetConnection();
        private MySqlDataReader reader = null;
        private string sql = null;

        string itemName = null;
        int price = 0;
        string content = null;
        string optionName = null;
        int optionPrice = 0;
        

        #region 아이템 찾기 및 버튼 생성
        public List<Button> CheckItem(string category)
        {
            List<Button> itemlist = new List<Button>();
            try
            {
                sql = "select b.itemName, b.price, b.content from categorytable a join itemtable b on a.cg_code = b.category where b.`on/off` = 'y' and a.cg_name = @cg_name";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@cg_name", category);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    itemName = reader.GetString("itemName");
                    price = reader.GetInt32("price");
                    content = reader.GetString("content");

                    Button button = new Button();
                    button.Text = itemName;
                    button.Name = itemName;
                    button.Tag = new { itemName, price, content };

                    itemlist.Add(button);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            finally
            {
                reader.Close();
            } 
            return itemlist;
        }
        #endregion

        #region 아이템 DB 담기

        public void InsertItem(string itemName, int price, string content)
        {
            try
            {
                sql = "insert into kiosktest(itemName, payment, content, regdate) values (@itemName, @price, @content, now())";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@content", content);
                
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        #endregion

        #region 옵션 조회 에서 체크 박스 생성
        public List<CheckBox> checkBox()
        {
            List<CheckBox> checkbox = new List<CheckBox>();
            try
            {
                sql = "SELECT * FROM optiontable WHERE `on/off` = 'Y'";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    optionName = reader.GetString("optionname");
                    optionPrice = reader.GetInt32("option_value");
                    

                    CheckBox check = new CheckBox();
                    check.Text = optionName;
                    check.Name = optionName;
                    check.Tag = new { optionName, optionPrice };

                    checkbox.Add(check);
                }
            }
            catch(Exception ex) 
            {
                ex.ToString();
            }
            finally
            {
                reader.Close();
            }

            return checkbox;
        }
        #endregion

        public List<string> GetCategory()
        {
            List<string> category_names = new List<string>();
            try
            {
                sql = "select cg_name from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                if (mysql.State == ConnectionState.Closed)
                {
                    mysql.Open();
                }
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    category_names.Add(reader.GetString("cg_name"));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }

            return category_names;
        }
    }
    #endregion
}
