using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI;
using MySqlX.XDevAPI.Common;

namespace Kiosk.pPanel.common
{
    #region To CategoryPanel.cs
    internal class CategoryTable
    {
        private MySqlConnection mysql = oGlobal.GetConnection();
        private MySqlDataReader reader = null;
        private string sql = null;
        int result = 0;

        public int CategoryTableCount()
        {
            try
            {
                sql = "select count(*) as count from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetInt32("count");
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

            return result;
        }
        
        public int CategoryRegister(string category_code, string category_name)
        {
            try
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                sql = "insert into categorytable(cg_code, cg_name, regdate) values(@cg_code, @cg_name, @regdate)";
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

                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetInt32("max") + 10;
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

            return result;
        }

        public List<string> GetCategory()
        {
            List<string> category_names = new List<string>();
            try
            {
                sql = "select cg_name from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

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

        public DataTable AddGridView()
        {
            MySqlDataReader reader = null;
            DataTable dataTable = new DataTable();
            /*
            dataTable.Columns.Add("NO");
            dataTable.Columns.Add("CODE");
            dataTable.Columns.Add("NAME");
            dataTable.Columns.Add("DATE");
            */
            
            DataColumn data_idx = new DataColumn("NO", typeof(int));
            DataColumn data_code = new DataColumn("CODE", typeof(string));
            DataColumn data_name = new DataColumn("NAME", typeof(string));
            DataColumn data_regdate = new DataColumn("DATE", typeof(string));
            
            dataTable.Columns.Add(data_idx);
            dataTable.Columns.Add(data_code);
            dataTable.Columns.Add(data_name);
            dataTable.Columns.Add(data_regdate);
            
            try
            {
                sql = "select * from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                reader = cmd.ExecuteReader();

                int idx = 0;
                string cg_code = null;
                string cg_name = null;
                string regdate;

                while (reader.Read())
                {
                    idx = reader.GetInt32("idx");
                    cg_code = reader.GetString("cg_code");
                    cg_name = reader.GetString("cg_name");
                    regdate = reader.GetDateTime("regdate").ToString("yyyy-MM-dd");

                    dataTable.Rows.Add(idx, cg_code, cg_name, regdate);
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
            
            return dataTable;
        }

        public List<string> GetCategoryInfoForName(string cg_name)
        {
            List<string> list = new List<string>();
            try
            {
                sql = "select idx, cg_code, cg_name from categorytable where cg_name = @cg_name";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@cg_name", cg_name);

                reader = cmd.ExecuteReader();

                reader.Read();

                list.Add(reader.GetInt32("idx")+"");
                list.Add(reader.GetString("cg_code"));
                list.Add(reader.GetString("cg_name"));
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }
            return list;
        }

        public bool CategoryModify(string category_idx, string category_name)
        {
            try
            {
                sql = "update categorytable set cg_name = @cg_name where idx = @idx";
   
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@cg_name", category_name);
                cmd.Parameters.AddWithValue("@idx",category_idx);

                result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("카테고리 수정에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("성공적으로 카테고리를 수정했습니다!", "CATEGORY MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            if (result < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CategoryDelete(string idx)
        {
            try
            {
                sql = "delete from categorytable where idx = @idx";

                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@idx",idx);

                result = cmd.ExecuteNonQuery();
                if (result < 0)
                {
                    MessageBox.Show("카테고리 삭제에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("성공적으로 카테고리를 삭제했습니다!", "CATEGORY MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (result < 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    #endregion

    #region To ItemPanel.cs
    internal class ItemTable
    {
        private MySqlConnection mysql = oGlobal.GetConnection();
        private string sql = null;
        int result = 0;

        public int ItemRegister(string name, int price, string content, string category)
        {
            try
            {
                string now = DateTime.Now.ToString("yyyy-MM-dd");
                string sql = "insert into itemtable(itemName, price, content, regdate, category) values(@itemName, @price, @content, @regdate, @category)";

                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                cmd.Parameters.AddWithValue("@itemName", name);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@regdate", now);
                cmd.Parameters.AddWithValue("@category", category);

                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) 
            {
                MessageBox.Show(ex.Message, "MySql ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return result;
        }
    }
    #endregion

}


#region To ItemPanel.cs
internal class ItemTable
{
    private MySqlConnection mysql = oGlobal.GetConnection();
    private string sql = null;
    int result = 0;

    public int ItemRegister(string name, int price, string content, string category)
    {
        try
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string sql = "insert into itemtable(itemName, price, content, regdate, category) values(@itemName, @price, @content, @regdate, @category)";

            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            cmd.Parameters.AddWithValue("@itemName", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@regdate", now);
            cmd.Parameters.AddWithValue("@category", category);

            result = cmd.ExecuteNonQuery();
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MySql ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return result;
    }
}
#endregion


#region To OptionPanel.cs
internal class OptionTable
{
    private MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int option_result = 0;

    public int OptionRegister(string optionname, int option_value)
    {
        try
        {
            string optionday = DateTime.Now.ToString("yyyy-MM-dd");
            sql = "insert into optiontable(optionname, option_value, regdate) values(@optionname, @option_value, @regdate)";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            cmd.Parameters.AddWithValue("@optionname", optionname);
            cmd.Parameters.AddWithValue("@option_value", option_value);
            cmd.Parameters.AddWithValue("@regdate", optionday);

            option_result = cmd.ExecuteNonQuery();
            if (option_result < 0)
            {
                MessageBox.Show("옵션 등록에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("옵션 등록에 성공했습니다!", "OPTION REGISTER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return option_result;
    }

    public List<string> GetOption()
    {
        List<string> options = new List<string>();
        try
        {
            sql = "select optionname from optiontable";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                options.Add(reader.GetString("optionname"));
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

        return options;
    }

    public DataTable AddGridView()
    {
        MySqlDataReader reader = null;
        DataTable dataTable = new DataTable();


        DataColumn data_idx = new DataColumn("NO", typeof(int));
        DataColumn data_name = new DataColumn("NAME", typeof(string));
        DataColumn data_price = new DataColumn("PRICE", typeof(int));
        DataColumn data_regdate = new DataColumn("DATE", typeof(string));

        dataTable.Columns.Add(data_idx);
        dataTable.Columns.Add(data_name);
        dataTable.Columns.Add(data_price);
        dataTable.Columns.Add(data_regdate);

        try
        {
            sql = "select * from optiontable";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            reader = cmd.ExecuteReader();

            int idx = 0;
            string optionname = null;
            int option_value = 0;
            string regdate;

            while (reader.Read())
            {
                idx = reader.GetInt32("idx");
                optionname = reader.GetString("optionname");
                option_value = reader.GetInt32("option_value");
                regdate = reader.GetDateTime("regdate").ToString("yyyy-MM-dd");

                dataTable.Rows.Add(idx, optionname, option_value, regdate);
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

        return dataTable;
    }

    public List<string> GetOptionForName(string optionname)
    {
        List<string> list = new List<string>();
        try
        {
            sql = "select idx, option_value, optionname from optiontable where optionname = @optionname";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@optionname", optionname);

            reader = cmd.ExecuteReader();

            reader.Read();

            list.Add(reader.GetInt32("idx") + "");
            list.Add(reader.GetString("optionname"));
            list.Add(reader.GetInt32("option_value").ToString());
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            reader.Close();
        }
        return list;
    }

    public bool OptionModify(string idx, string optionname, string option_value)
    {
        try
        {
            String sql = "update optiontable set optionname = @optionname, option_value = @option_value where idx = @idx";

            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@optionname", optionname);
            cmd.Parameters.AddWithValue("@option_value", option_value);
            cmd.Parameters.AddWithValue("@idx", idx);

            option_result = cmd.ExecuteNonQuery();
            if (option_result < 0)
            {
                MessageBox.Show("옵션 수정에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("성공적으로 옵션을 수정했습니다!", "OPTION MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        if (option_result < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public bool OptionDelete(string idx)
    {
        try
        {
            sql = "delete from optiontable where idx = @idx";

            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@idx", idx);

            option_result = cmd.ExecuteNonQuery();
            if (option_result < 0)
            {
                MessageBox.Show("옵션 삭제에 실패했습니다! \n관리자에게 문의하세요.", "CODE : MS-ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("성공적으로 옵션을 삭제했습니다!", "OPTION MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (option_result < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}

#endregion




#region 제품 수정 / 삭제
internal class ItemUpdate // internal 동일한 어셈블리 내에서만 접근 가능
    {
        private MySqlConnection mysql = oGlobal.GetConnection();
        int result = 0;
        #region datagridview 데이터 불러오기 class
        // datagridview 데이터 불러오기 class
        public  DataTable SelectData(MySqlConnection mysql)
        {
            // 테이블 구조 들고와서 DataTable 생성
            DataTable schemaTable = GetTableSchema(mysql);

            // DataGirdView 에 들어갈 총 datatable 생성
            DataTable dataTable = CreateDataTable(schemaTable);
            DataTable dataFromDB = GetData(mysql);
            foreach (DataRow row in dataFromDB.Rows)
            {
                dataTable.ImportRow(row);
            }

            return dataTable;

        }
        // 테이블 구조 들고오기  datagirdview 에서 칼럼명을 db에서 가져오기(데이터 타입도 들고올수 있음)
        private static DataTable GetTableSchema(MySqlConnection mysql)
        {
            DataTable schemaTable = new DataTable();
            try
            {
                string query = "SELECT * FROM itemtable LIMIT 0"; // MySQL에서는 LIMIT 사용
                using (MySqlCommand command = new MySqlCommand(query, mysql))
                {
                    if (mysql.State == ConnectionState.Closed)
                    {
                        mysql.Open();
                    }
                    using (MySqlDataReader reader = command.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        schemaTable = reader.GetSchemaTable();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return schemaTable;
        }
        // 테이블 구조 들고와서 빈 datatable 에 집어넣기
        private static DataTable CreateDataTable(DataTable schemaTable)
        {
            DataTable dataTable = new DataTable();

            foreach (DataRow row in schemaTable.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                Type dataType = (Type)row["DataType"];
                DataColumn column = new DataColumn(columnName, dataType);
                dataTable.Columns.Add(column);
            }

            return dataTable;
        }
        private static DataTable GetData(MySqlConnection mysql)
        {
            DataTable dataTable = new DataTable();
            try
            {
                string query = "SELECT * FROM itemtable"; // 실제 데이터를 가져오는 쿼리
                using (MySqlCommand command = new MySqlCommand(query, mysql))
                {
                    if (mysql.State == ConnectionState.Closed)
                    {
                        mysql.Open();
                    }
                    // adapter.Fill 쓰면 테이블의 모든 데이터를 가져와서 넣어준다.
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return dataTable;
        }
        #endregion

        #region 데이터 수정
        public int ItemChange(String itemName, int price,String content,String category,int idx)
        {
            int result = 0;
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
               string query = "update itemtable set itemName = @itemName, price = @price, content = @content, regdate = @regdate, category = @category where idx = @idx";

                MySqlCommand cmd = new MySqlCommand(query, mysql);
                
                cmd.Parameters.AddWithValue("@itemName", itemName);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@content", content);
                cmd.Parameters.AddWithValue("@regdate", now);
                cmd.Parameters.AddWithValue("@category", category);
                cmd.Parameters.AddWithValue("@idx", idx);

                result = cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MySQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
        #region 데이터 삭제 
        public int ItemDelete(int idx)
        {
            try
            {
                //idx 값만 가져와서 삭제하기
                String query = "delete from itemtable where idx = @idx";
                MySqlCommand cmd = new MySqlCommand(query, mysql);
                cmd.Parameters.AddWithValue("@idx", idx);

                 result = cmd.ExecuteNonQuery();
            }catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MySql ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return result;
        }
        #endregion
    }
    #endregion



