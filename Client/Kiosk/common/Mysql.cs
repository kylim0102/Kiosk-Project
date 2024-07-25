using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace Kiosk.common
{
    #region MySql
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
    #endregion

    #region Temporary Table → Order Table
    internal class Order 
    {
        private static MySqlConnection mysql = Mysql.GetConnection();
        private MySqlDataReader reader = null;
        private string sql = null;

        string itemName = null;
        int price = 0;
        string content = null;
        string optionName = null;
        int optionPrice = 0;

        #region Insert OrderTable From TemporaryTable(결제 OrderTable에 담기)
        public void insertItem(string itemNumber, string itemName, int itemCount, int payment, int orderNumber)
        {
            sql = "insert into ordertable(itemNumber, itemName, itemCount, payment, orderNumber, regdate) values (@itemNumber, @itemName, @itemCount, @payment, @orderNumber, now())";
            using (MySqlCommand cmd = new MySqlCommand(sql, mysql))
            {
                cmd.Parameters.AddWithValue("@itemNumber", itemNumber);
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@itemCount", itemCount);
                cmd.Parameters.AddWithValue("@payment", payment);
                cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                cmd.ExecuteNonQuery();
            }

        }
        #endregion
        
        #region GetMaxOrderNumber(OrderTable에서 OrderNumber의 최댓값을 오늘 날짜의 cnt 수를 기준으로 출력)
        public int MaxOrderNumberFromDate()
        {
            int max = 0;
            int cnt = 0;

            try
            {
                sql = "select ifnull(max(orderNumber),0) as max, Count(orderNumber) as cnt from ordertable where regdate = curdate()";
                using (MySqlCommand cmd = new MySqlCommand(sql, mysql))
                {
                    using(reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        max = reader.GetInt32("max");
                        cnt = reader.GetInt32("cnt");
                    }
                }
            }
            catch(MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }

            if(cnt < 1)
            {
                max = 1;
                return max;
            }
            else
            {
                max = max + 1;
                return max;
            }
        }
        #endregion
    }
    #endregion

    #region Item List & Option List
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


        #region GetItemList(Kiosk 제품 선택 창에서 제품에 대한 정보를 Button으로 출력)
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

        #region GetOptionName(제품 View에서 옵션을 UI에 추가)
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
            catch (Exception ex)
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

        #region GetCategoryName(카테고리 이름을 TabControl의 Tab에 추가)
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
        #endregion
    }
    #endregion

    #region Temporary Table
    internal class TemporaryTable
    {
        // Temporary Table은 별도의 Con을 관리
        private static MySqlConnection DBconnection;
        private static MySqlDataReader reader = null;
        private static string sql = string.Empty;

        #region Temporary Table For DB Connection
        public static MySqlConnection DB_Connection()
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
            return DBconnection;
        }
        #endregion

        #region CreateTemporary(폼이 로드될 때 장바구니 DB를 Temporary Table로 생성)
        public static void CreateTemporary()
        {
            MySqlConnection con = DB_Connection();
            try
            {
                sql = "create temporary table if not exists temp_cart(idx int auto_increment primary key,itemNumber varchar(10) not null,itemName varchar(100) not null,itemCount int not null,payment int not null,orderNumber int not null,regdate date);";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    Console.WriteLine("Temporary Table을 생성합니다.");
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region CheckRows(Temporary Table내에 데이터가 있는지 여부 확인)
        public static int CheckTemporary()
        {
            MySqlConnection con = DB_Connection();
            int result = 0;

            try
            {
                sql = "select count(*) as cnt from temp_cart";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        result = reader.GetInt32("cnt");
                    }

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
            return result;
        }
        #endregion

        #region InsertDataToTemporaryTable(장바구니에 담은 제품을 TemporaryTable에 저장)
        public static void InsertTemporary(string itemNumber, string itemName, int itemCount, int payment, int orderNumber)
        {
            int result = 0;
            MySqlConnection con = DB_Connection();
            try
            {
                sql = "insert into temp_cart(itemNumber, itemName, itemCount, payment, orderNumber, regdate) values(@itemNumber, @itemName, @itemCount, @payment, @orderNumber, now())";

                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@itemNumber", itemNumber);
                    cmd.Parameters.AddWithValue("@itemName", itemName);
                    cmd.Parameters.AddWithValue("@itemCount", itemCount);
                    cmd.Parameters.AddWithValue("@payment", payment);
                    cmd.Parameters.AddWithValue("@orderNumber", orderNumber);
                    result = cmd.ExecuteNonQuery();
                }

                if (result < 1)
                {
                    MessageBox.Show("장바구니에 담는 과정에서 문제가 발생했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region GetMaxItemNumber(Temporary Table의 데이터들 중 옵션을 제외한 모든 제품에서 itemNumber의 최댓값을 출력)
        public static int GetMaxItemNumber()
        {
            MySqlConnection con = DB_Connection();
            int result = 0;
            try
            {
                sql = "select Max(itemNumber) as max from temp_cart where itemNumber = substring_index(itemNumber,'-',1)";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    result = reader.GetInt32("max");
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

            return result;
        }
        #endregion

        #region GetSchema(Temporary Table의 스키마를 DataTable에 복사)
        public static DataTable CreateTemporaryTableSchema()
        {
            DataTable table = new DataTable();
            MySqlConnection con = DB_Connection();

            try
            {
                sql = "select * from temp_cart LIMIT 0";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    using (reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        table = reader.GetSchemaTable();
                    }
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

            return table;
        }
        #endregion

        #region SettingColumn(DataTable에 컬럼을 세팅)
        public static DataTable CreateDataTable()
        {
            string[] iWantColumn = { "itemNumber", "itemName", "itemCount", "payment" }; //원하는 칼럼만
            DataTable dataTable = new DataTable();

            DataTable schemaTable = CreateTemporaryTableSchema(); // GetOrder() 메서드에서 스키마 정보 가져오기

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                Type dataType = Type.GetType(row["DataType"].ToString());

                // iWantColumn 배열에 columnName이 포함되어 있지 않으면 스킵
                if (!iWantColumn.Contains(columnName))
                {
                    continue;
                }

                DataColumn column = new DataColumn(columnName, dataType);
                dataTable.Columns.Add(column);
            }

            return dataTable;
        }
        #endregion

        // Guess 1
        #region CopyTemporaryTableToDataTable(Temporary Table에 있는 데이터를 DataTable로 복사)
        public static DataTable GetTemporaryDataTable()
        {
            DataTable dataTable = CreateDataTable();
            MySqlConnection con = DB_Connection();
            try
            {
                sql = "select itemNumber, itemName, itemCount, payment from temp_cart where itemNumber = substring_index(itemNumber,'-',1) and orderNumber = '0' order by itemNumber"; // 수정
                /*
                    Temporary Table에는 기본적으로 결제 이전이기 때문에 orderNumber는 0으로 정보가 들어감.
                    Temporary Table → MySql OrderTable로 이동할 때 orderNumber를 수정하는 개념이 아닌가 싶습니다.
                    결론은 Temporary Table을 조회할 때 orderNumber가 0인 데이터를 조회할 이유가 있나 싶어요
                */

                MySqlCommand cmd = new MySqlCommand(sql, con);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        #endregion

        #region CopyOrderTableToDataTable(OrderTable에 있는 데이터를 DataTable로 복사)
        public static DataTable all()
        {
            DataTable dataTable = CreateDataTable();
            MySqlConnection con = DB_Connection();
            try
            {
                sql = "select itemNumber, itemName, itemCount, payment from temp_cart where orderNumber = '0' order by itemNumber"; // 수정
                MySqlCommand cmd = new MySqlCommand(sql, con);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        #endregion

        #region DeleteCartItem(장바구니에서 선택한 제품을 장바구니에서 제거)
        public static void Delete (string itemNumber)
        {
            MySqlConnection con = DB_Connection();
            sql = "delete from temp_cart where itemNumber LIKE @itemNumber";
             MySqlCommand cmd = new MySqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@itemNumber", itemNumber + "%");
            cmd.ExecuteNonQuery();
        }
        #endregion

        #region GetTargetItemFromTemporaryTable(TemporaryTable에서 선택한 제품의 옵션 정보를 가져옴)
        public static DataTable GetAllTemporaryDataTable(string itemNumber)
        {
            DataTable dataTable = CreateDataTable();
            MySqlConnection con = DB_Connection();
            try
            {
                sql = "select itemNumber, itemName, itemCount, payment from temp_cart where  orderNumber = '0' AND itemNumber LIKE @itemNumber order by itemNumber";
                MySqlCommand cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("itemNumber", itemNumber + "-%");
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dataTable;
        }
        #endregion

        #region GetTargetItemOptionFromTemporaryTable(TemporaryTable에서 선택한 제품의 옵션 수를 가져옴)
        public static int GetItemOptionNumber(int itemNumber)
        {
            MySqlConnection con = DB_Connection();
            int result = 0;
            try
            {
                sql = "select count(*) as cnt from temp_cart where itemNumber like @itemNumber";
                using (MySqlCommand cmd = new MySqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@itemNumber", itemNumber + "-%");
                    reader = cmd.ExecuteReader();
                    reader.Read();

                    result = reader.GetInt32("cnt");
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

            return result;
        }
        #endregion
    }
    #endregion
}
