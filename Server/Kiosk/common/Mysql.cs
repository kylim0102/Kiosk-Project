using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
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

        public string GetCategoryCode(string cg_name)
        {
            string name = null;
            try
            {
                sql = "select cg_code from categorytable where cg_name = @cg_name";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);
                cmd.Parameters.AddWithValue("@cg_name",cg_name);

                reader = cmd.ExecuteReader();
                reader.Read();


                name = reader.GetString("cg_code");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }

            return name;
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
    private MySqlDataReader reader;
    private CategoryTable categoryTable = new CategoryTable();
    private string sql = null;
    int result = 0;

    public int ItemRegister(string name, int price, string content, string category)
    {
        try
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd");
            string cg_code = categoryTable.GetCategoryCode(category);
            sql = "insert into itemtable(itemName, price, content, regdate, category) values(@itemName, @price, @content, @regdate, @cg_code)";
            Console.WriteLine("1");
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            Console.WriteLine("2");
            cmd.Parameters.AddWithValue("@itemName", name);
            cmd.Parameters.AddWithValue("@price", price);
            cmd.Parameters.AddWithValue("@content", content);
            cmd.Parameters.AddWithValue("@regdate", now);
            cmd.Parameters.AddWithValue("@cg_code", cg_code);
            Console.WriteLine("3");
            result = cmd.ExecuteNonQuery();
            Console.WriteLine("4");
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MySql ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        

        return result;
    }

    public List<Button> MakeButtonForItems(string cg_name)
    {
        if(mysql.State == ConnectionState.Closed)
        {
            mysql.Open();
        }


        List<Button> items = new List<Button>();
        string sql = "select a.cg_code, a.cg_name, b.itemName, b.price, b.content, b.`on/off`, b.regdate from categorytable a join itemtable b on a.cg_code = b.category where b.`on/off` = 'y' and a.cg_name = @cg_name";

        MySqlCommand cmd = new MySqlCommand(sql, mysql);
        cmd.Parameters.AddWithValue("@cg_name", cg_name);

        int buttonTop = 10;
        int buttonSpacing = 30;

        using (reader = cmd.ExecuteReader())
        {
            int price = 0;
            string item_name = null, content = null, category = null, power = null;
            DateTime regdate;

            while (reader.Read())
            {
                item_name = reader.GetString("itemName");
                price = reader.GetInt32("price");
                content = reader.GetString("content");
                regdate = reader.GetDateTime("regdate");
                category = reader.GetString("cg_name");
                power = reader.GetString("on/off");

                Button button = new Button();
                button.Name = item_name+"_btn";
                button.Text = item_name;
                button.Tag = new {item_name, price, content, regdate, category, power};

                button.Top = buttonTop;
                button.Left = buttonSpacing;


                items.Add(button);

                buttonTop += buttonSpacing; // 다음 버튼의 y 좌표 설정
            }

        }

        return items;
    }

    /*
        Order Page에서 MySql Tab에 모든 Item 목륵을 버튼으로 추가하기 위해 만든 SQL문
        후에 코드 정리할 때 삭제하면 되는 부분
    */
    public List<Button> GetAllItems()
    {
        if (mysql.State == ConnectionState.Closed)
        {
            mysql.Open();
        }

        List<Button> items = new List<Button>();
        sql = "select * from itemtable";
        MySqlCommand cmd = new MySqlCommand(sql, mysql);

        int buttonTop = 10;
        int buttonSpacing = 30;

        using (reader = cmd.ExecuteReader())
        {
            int price = 0;
            string item_name = null, content = null, category = null, power = null;
            DateTime regdate;

            while (reader.Read())
            {
                item_name = reader.GetString("itemName");
                price = reader.GetInt32("price");
                content = reader.GetString("content");
                regdate = reader.GetDateTime("regdate");
                category = reader.GetString("category");
                power = reader.GetString("on/off");

                Button button = new Button();
                button.Name = item_name + "_btn";
                button.Text = item_name;
                button.Tag = new { item_name, price, content, regdate, category, power };

                button.Top = buttonTop;
                button.Left = buttonSpacing;


                items.Add(button);

                buttonTop += buttonSpacing; // 다음 버튼의 y 좌표 설정
            }

        }

        return items;
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

    #region on/off 가 n 인 것
    public List<string> GetOptionsWithN()
    {
        // 'on/off' 값이 'N'인 옵션들을 저장할 리스트
        List<string> options = new List<string>();

        try
        {
            // 'on/off' 값이 'N'인 행을 선택하는 SQL 쿼리
            string sql = "select * from optiontable where `on/off` = 'N'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            // SQL 쿼리 실행
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string itemn = $"{reader.GetInt32("idx")}, {reader.GetString("optionname")}, {reader.GetInt32("option_value")}";
                    options.Add(itemn);
                }
            }
        }
        catch (MySqlException ex)
        {
            // MySQL 예외 발생 시 메시지 박스에 오류 메시지 표시
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // 'on/off' 값이 'N'인 옵션들을 반환
        return options;
    }
    #endregion

    #region on/off 가 y 인 것
    public List<string> GetOptionsWithY()
    {
        // 'on/off' 값이 'Y'인 옵션들을 저장할 리스트
        List<string> options = new List<string>();

        try
        {
            // 'on/off' 값이 'Y'인 행을 선택하는 SQL 쿼리
            sql = "select * from optiontable where `on/off` = 'Y'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            // SQL 쿼리 실행
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                // 결과에서 optionname과 option_value를 리스트에 추가
                string itemy = $"{reader.GetInt32("idx")}, {reader.GetString("optionname")}, {reader.GetInt32("option_value")}";
                options.Add(itemy);
            }
        }
        catch (MySqlException ex)
        {
            // MySQL 예외 발생 시 메시지 박스에 오류 메시지 표시
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            // 리더가 null이 아닌 경우 닫기
            if (reader != null)
            {
                reader.Close();
            }
        }

        // 'on/off' 값이 'Y'인 옵션들을 반환
        return options;
    }
    #endregion

    #region 옵션 사용 Y로 바꾸기
    public void UpdateOption(int idx)
    {
        try
        {
            // 'on/off' 값을 'Y'로 변경하는 SQL UPDATE 쿼리
            sql = "UPDATE optiontable SET `on/off` = 'Y' WHERE idx = @idx";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@idx", idx);

            // SQL 쿼리 실행
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("옵션 삽입을 성공했습니다.", "옵션 삽입", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("옵션 삽입에 실패하였습니다!", "옵션 삽입", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            // MySQL 예외 발생 시 메시지 박스에 오류 메시지 표시
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    #endregion

    #region 옵션 사용 N으로 바꾸기
    public void RemoveOption(int idx)
    {
        try
        {
            // 'on/off' 값을 'Y'로 변경하는 SQL UPDATE 쿼리
            sql = "UPDATE optiontable SET `on/off` = 'N' WHERE idx = @idx";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@idx", idx);

            // SQL 쿼리 실행
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                MessageBox.Show("옵션 빼기를 성공했습니다.", "옵션 빼기", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("옵션 빼기를 실패하였습니다!", "옵션 빼기", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            // MySQL 예외 발생 시 메시지 박스에 오류 메시지 표시
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion
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



