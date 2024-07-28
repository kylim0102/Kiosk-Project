﻿using Kiosk.pPanel.common;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Kiosk.pPanel.common
{
    #region To CategoryPanel.cs
    internal class CategoryTable
    {
        private static MySqlConnection mysql = oGlobal.GetConnection();
        private MySqlDataReader reader = null;
        private string sql = null;
        int result = 0;

        public int CategoryTableCount()
        {
            try
            {
                sql = "select count(*) as count from categorytable";
                MySqlCommand cmd = new MySqlCommand(sql, mysql);

                if (mysql.State == ConnectionState.Closed)
                {
                    mysql.Open();
                }
                using (reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    result = reader.GetInt32("count");
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

                list.Add(reader.GetInt32("idx") + "");
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
                cmd.Parameters.AddWithValue("@idx", category_idx);

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
                cmd.Parameters.AddWithValue("@idx", idx);

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
                cmd.Parameters.AddWithValue("@cg_name", cg_name);

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
        private static MySqlConnection mysql = oGlobal.GetConnection();
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
    private static MySqlConnection mysql = oGlobal.GetConnection();
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
        if (mysql.State == ConnectionState.Closed)
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
    private static MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int option_result = 0;

    #region 옵션 등록
    public void OptionRegister(string option_name, int option_value)
    {
        try
        {
            string optionday = DateTime.Now.ToString("yyyy-MM-dd");
            sql = "insert into optiontable(optionname, option_value, regdate) values(@optionname, @option_value, @regdate)";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            cmd.Parameters.AddWithValue("@optionname", option_name);
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
    }
    #endregion

    #region 옵션 이름 가져오기
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
    #endregion

    #region GridView에 옵션 담기
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
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
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
    #endregion

    #region 옵션 이름을 이용하여 데이터 가져오기
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
    #endregion

    #region 옵션 수정
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
    #endregion

    #region 옵션 삭제
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
    #endregion

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

#region TO OrderPanel.cs
internal class OrderTable
{
    private static MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int result = 0;

    #region Order Manage Select Menu(메뉴 버튼 선택 시 해당 메뉴의 정보를 DB에 저장)
    public void InsertOrder(string itemNumber, string itemName, int itemCount, int payment, int orderNumber)
    {
        try
        {
            sql = "insert into ordertable(itemNumber, itemName, itemCount, payment, orderNumber, regdate) values(@itemNumber, @itemName, @itemCount, @payment, @orderNumber, now())";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemNumber", itemNumber);
            cmd.Parameters.AddWithValue("@itemName", itemName);
            cmd.Parameters.AddWithValue("@itemCount", itemCount);
            cmd.Parameters.AddWithValue("@payment", payment);
            cmd.Parameters.AddWithValue("@orderNumber", orderNumber);

            result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품선택에서 문제가 발생했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    #region Order Manage Get Index Number(Count가 0이면, DB가 비어있으면 1로 시작 / 1이상이면 Max를 통해 최댓값 출력 후 +1)
    public int GetMaxItemNumber(string menu_name)
    {
        int cnt = 0;
        int max = 0;
        try
        {
            sql = "select count(itemNumber) as cnt from ordertable where orderNumber = 0";
            MySqlCommand cmd1 = new MySqlCommand(sql, mysql);
            reader = cmd1.ExecuteReader();

            reader.Read();
            cnt = reader.GetInt32("cnt");
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            reader.Close();
        }

        if (cnt == 0)
        {
            return 1;
        }
        else
        {
            try
            {
                sql = "select max(SUBSTRING_INDEX(itemNumber, '-', 1) ) as max from ordertable where orderNumber = 0";
                MySqlCommand cmd2 = new MySqlCommand(sql, mysql);
                reader = cmd2.ExecuteReader();
                reader.Read();
                max = reader.GetInt32("max") + 1;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                reader.Close();
            }
            return max;
        }

    }
    #endregion

    // 제품 명을 출력할 때 Order Number가 0인 제품만 출력해야 하지 않는가?(24.07.18 해야할 일) where orderNumber = '0'  추가
    #region Order Manage Get Item Names(선택한 제품명을 출력하여 중복 확인)
    public List<string> GetOrderNames()
    {
        List<string> items = new List<string>();

        if (mysql.State == ConnectionState.Closed)
        {
            mysql.Open();
        }
        try
        {
            sql = "select itemName from ordertable where orderNumber = '0'";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                items.Add(reader.GetString("itemName"));
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
        return items;
    }
    #endregion

    #region Order Manage Update Item Count(제품 중복 확인 후 중복 = True일 시 중복된 제품의 수량과 총 금액 변경)
    public void UpdateItemCount(string itemname, int price)
    {
        try
        {
            sql = "Update ordertable set itemCount = itemCount+1, payment = itemCount * @price where itemName = @itemname";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemname", itemname);
            cmd.Parameters.AddWithValue("@price", price);
            int result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품 추가 후 수정에 실패했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    // MAKE DATA TABLE AREA
    #region Order Manage Get Schema Table(DB의 스키마를 Data Table에 복사)
    public DataTable GetOrder()
    {
        DataTable dataTable = new DataTable();
        try
        {
            sql = "select * from ordertable LIMIT 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            using (reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                dataTable = reader.GetSchemaTable();
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
    #endregion
    #region Order Manage Set DataPropertyName(스키마 복사 후 사용 할 DataPropertyName을 세팅)
    public DataTable CreateDataTable()
    {
        string[] iWantColumn = { "itemNumber", "itemName", "itemCount", "payment" }; //원하는 칼럼만
        DataTable dataTable = new DataTable();

        DataTable schemaTable = GetOrder(); // GetOrder() 메서드에서 스키마 정보 가져오기

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
    #region Order Manage Set Order Table Values(생성, 세팅이 끝난 Data Table에 DB의 값을 저장) / feat.MySqlDataAdapter(adapter.Fill(datatable))
    public DataTable GetAllOrderTable()
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemNumber, itemName, itemCount, payment from ordertable where orderNumber = '0' order by itemNumber";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
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
    // MAKE DATA TABLE AREA
}
#endregion

#region option btn

#region 옵션 집어넣는거
internal class OrderTable_Option
{
    private MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int result = 0;

    //option 집어넣는거
    public void InsertOption(string itemNumber, string itemName, int itemCount, int payment, int orderNumber)
    {
        if (mysql.State == ConnectionState.Closed)
        {
            mysql.Open();
        }
        sql = "insert into ordertable(itemNumber, itemName, itemCount, payment, orderNumber, regdate) values(@itemNumber, @itemName, @itemCount, @payment, @orderNumber, now())";
        MySqlCommand cmd = new MySqlCommand(sql, mysql);
        cmd.Parameters.AddWithValue("@itemNumber", itemNumber);
        cmd.Parameters.AddWithValue("@itemName", itemName);
        cmd.Parameters.AddWithValue("@itemCount", itemCount);
        cmd.Parameters.AddWithValue("@payment", payment);
        cmd.Parameters.AddWithValue("@orderNumber", orderNumber);

        result = cmd.ExecuteNonQuery();
    }

    // 몇개있는지
    public int CountOption(string itemNumber)
    {
        Console.WriteLine(itemNumber);
        try
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            sql = "select count(*) as cnt from ordertable where itemNumber like @itemNumber and orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemNumber", itemNumber + "%");
            reader = cmd.ExecuteReader();

            reader.Read();

            result = reader.GetInt32("cnt");
            Console.WriteLine(result);
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

    //중복확인
    public int CheckOption(string itemNumber, string optionName)
    {
        try
        {
            sql = "select count(*) as cnt from ordertable where itemNumber like @itemNumber and itemName = @optionName and orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemNumber", itemNumber + "%");
            cmd.Parameters.AddWithValue("@optionName", optionName);
            reader = cmd.ExecuteReader();
            reader.Read();

            result = reader.GetInt32("cnt");
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




}
#endregion

internal class Pay
{
    private static MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int result = 0;

    //select max값 구하기
    public int OrderNumber()
    {
        try
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            sql = "select max(orderNumber) as max from ordertable ";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            reader = cmd.ExecuteReader();

            reader.Read();

            result = reader.GetInt32("max");
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            reader.Close();
        }
        return result + 1;
    }

    // 결제된 상품 orderNumber 값 올리기
    public void UpdateOrderNumber()
    {
        try
        {
            sql = "Update ordertable set orderNumber = @orderNumber where orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@orderNumber", OrderNumber());
            int result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품 추가 후 수정에 실패했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    //order 제품 삭제
    public void deleteOrder()
    {
        try
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            sql = "delete from ordertable where orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            int result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품 삭제에 실패했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }


    //order 선택한 제품 삭제
    public void delete_SelectedOption(string itemNumber)
    {
        try
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            sql = "delete from ordertable where itemNumber like @itemNumber and orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemNumber", itemNumber + "%");

            result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품 삭제에 실패했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    public void delete_SelectedItem(string itemNumber)
    {
        try
        {
            if (mysql.State == ConnectionState.Closed)
            {
                mysql.Open();
            }
            sql = "delete from ordertable where itemNumber = @itemNumber and orderNumber = 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@itemNumber", itemNumber);

            result = cmd.ExecuteNonQuery();

            if (result < 1)
            {
                MessageBox.Show("제품 삭제에 실패했습니다.\n관리자에게 문의하세요.", "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

}

#endregion


#region itemPanel 제품 수정 / 삭제
internal class ItemUpdate // internal 동일한 어셈블리 내에서만 접근 가능
{
    private static MySqlConnection mysql = oGlobal.GetConnection();
    int result = 0;
    #region datagridview 데이터 불러오기 class
    // datagridview 데이터 불러오기 class
    public DataTable SelectData(MySqlConnection mysql)
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
    public int ItemChange(String itemName, int price, String content, String category, int idx)
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
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MySql ERROR !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return result;
    }
    #endregion
}
#endregion


// 추가 
#region chartListPanel
internal class ChartList
{
    private static MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int result = 0;

    // 테이블 구조 들고오기  datagirdview 에서 칼럼명을 db에서 가져오기(데이터 타입도 들고올수 있음)
    #region 테이블 구조 들고오기
    private DataTable GetTableSchema(MySqlConnection mysql)
    {
        DataTable schemaTable = new DataTable();
        try
        {

            sql = "select * from ordertable LIMIT 0";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);

            using (reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
            {
                schemaTable = reader.GetSchemaTable();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return schemaTable;
    }
    #endregion

    // 테이블 구조 들고와서 빈 datatable 에 집어넣기
    #region 테이블 구조 들고와서 빈 datatable 에 집어넣기
    public DataTable CreateDataTable()
    {
        string[] iWantColumn = { "itemName", "itemCount", "payment" }; //원하는 칼럼만
        DataTable dataTable = new DataTable();

        DataTable schemaTable = GetTableSchema(mysql); // GetOrder() 메서드에서 스키마 정보 가져오기

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



    // DB 조건 검색 AREA
    #region Get After Payment All Data(DB에서 결제 후의 모든 데이터를 가져와 DataTable에 저장)
    public DataTable GetAllOrderTable()
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            //itemNumber, itemName, itemCount, payment
            sql = "select  itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND itemNumber = substring_index(itemNumber,'-',1) GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
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

    #region Get After Payment And Searching Keyword Data(DB에서 결제 후의 모든 데이터 중에서 키워드로 검색한 결과를 DataTable에 저장)
    public DataTable GetKeywordOrderTable(string keyword)
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND (itemName = @keyword OR itemName LIKE @like_keyword) GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@keyword",keyword);
            cmd.Parameters.AddWithValue("@like_keyword","%"+keyword+"%");


            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }

            
            if(dataTable.Rows.Count == 0)
            {
                MessageBox.Show("검색한 내용과 일치하거나 유사한 제품이 없습니다.\n다시 확인해주세요.","ITEM MANAGER",MessageBoxButtons.OK,MessageBoxIcon.Error);
                dataTable = GetAllOrderTable();
            }
        }
        catch(MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return dataTable;
    }
    #endregion

    #region Get After Payment And Searching Keyword And Target Date(DB에서 결제 후의 모든 데이터 중에서 특정 기간과 검색어가 일치하는 결과를 DataTable에 저장)
    public DataTable GetKeywordAndTargetDayOrderTable(string keyword, string target_day)
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND itemNumber = substring_index(itemNumber,'-',1) AND (itemName = @keyword OR itemName like @like_keyword) And regdate = @target_day GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@keyword", keyword);
            cmd.Parameters.AddWithValue("@like_keyword", "%" + keyword + "%");
            cmd.Parameters.AddWithValue("@target_day", target_day);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }


            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("검색한 내용과 일치하거나 유사한 제품이 없습니다.\n다시 확인해주세요.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = GetAllOrderTable();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dataTable;
    }
    #endregion

    #region Get After Payment And Searching Target Date(DB에서 결제 후의 모든 데이터 중에서 특정 기간으로 검색한 결과를 DataTable에 저장)
    public DataTable GetTargetDayOrderTable(string target_day)
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND itemNumber = substring_index(itemNumber,'-',1) AND regdate = @target_day GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@target_day", target_day);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }


            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("검색한 내용과 일치하거나 유사한 제품이 없습니다.\n다시 확인해주세요.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = GetAllOrderTable();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dataTable;
    }
    #endregion

    #region Get After Payment And Start Between End Date(DB에서 결제 후의 모든 데이터 중에서 특정 기간사이의 검색한 결과를 DataTable에 저장)
    public DataTable GetBetweenDayOrderTable(string start_day, string end_day)
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND itemNumber = substring_index(itemNumber,'-',1) AND regdate between @start_day And @end_day GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@start_day", start_day);
            cmd.Parameters.AddWithValue("@end_day", end_day);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }


            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("검색한 내용과 일치하거나 유사한 제품이 없습니다.\n다시 확인해주세요.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = GetAllOrderTable();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dataTable;
    }
    #endregion

    #region Get After payment And All Condition(DB에서 결제 후의 모든 데이터 중에서 모든 조건이 충족한 결과를 DataTable에 저장)
    public DataTable GetAllConditionOrderTable(string keyword, string start_day, string end_day)
    {
        DataTable dataTable = CreateDataTable();
        try
        {
            sql = "select itemName, sum(itemCount) as itemCount, sum(payment) as payment from ordertable where orderNumber != '0'  AND itemNumber = substring_index(itemNumber,'-',1) AND (itemName = @keyword OR itemName like @like_keyword) And regdate between @start_day AND @end_day GROUP BY itemName order by sum(itemCount) desc";
            MySqlCommand cmd = new MySqlCommand(sql, mysql);
            cmd.Parameters.AddWithValue("@keyword", keyword);
            cmd.Parameters.AddWithValue("@like_keyword", "%" + keyword + "%");
            cmd.Parameters.AddWithValue("@start_day", start_day);
            cmd.Parameters.AddWithValue("@end_day", end_day);

            using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
            {
                adapter.Fill(dataTable);
            }


            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("검색한 내용과 일치하거나 유사한 제품이 없습니다.\n다시 확인해주세요.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataTable = GetAllOrderTable();
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return dataTable;
    }
    #endregion
    // DB 조건 검색 AREA

    /*
        ↓ ↓ ↓
    */

    // DB 조건 검색 AREA에 있는 메서드를 실제로 사용하고 매게변수를 할당하는 부분
    #region Get Optional OrderTable(각 조건 별 DB 읽기, 만약 새로운 조건이 추가되면 이 메소드에서 else if 확장)
    public DataTable SelectData(MySqlConnection mysql, string keyword, string start_day, string end_day)
    {
        DataTable dataTable = new DataTable();
        string target_day = string.Empty;

        if (keyword.Equals("") && start_day.Equals("") && end_day.Equals("")) // 아무 검색 조건도 없음
        {
            dataTable = GetAllOrderTable();
        }
        else if (!keyword.Equals("") && start_day.Equals("") && end_day.Equals("")) // 키워드 O, 검색일 X
        {
            dataTable = GetKeywordOrderTable(keyword);
        }
        else if (keyword.Equals("") && !start_day.Equals("") && end_day.Equals("") || keyword.Equals("") && start_day.Equals("") && !end_day.Equals("")) // 키워드 X, 검색일(Start O, End X / Start X, End O)
        {
            dataTable = GetTargetDayOrderTable(!start_day.Equals("") ? target_day = start_day : target_day = end_day);
        }
        else if (keyword.Equals("") && !start_day.Equals("") && !end_day.Equals("")) // 키워드 X, 검색일(Start O, End O)
        {
            dataTable = GetBetweenDayOrderTable(start_day, end_day);
        }
        else if (!keyword.Equals("") && !start_day.Equals("") && end_day.Equals("") || !keyword.Equals("") && start_day.Equals("") && !end_day.Equals("")) // 키워드 O, 검색일(Start O, End X / Start X, End O)
        {
            dataTable = GetKeywordAndTargetDayOrderTable(keyword, !start_day.Equals("") ? target_day = start_day : target_day = end_day);
        }
        else if (!keyword.Equals("") && !start_day.Equals("") && !end_day.Equals("")) // 모든 검색 조건 입력
        {
            dataTable = GetAllConditionOrderTable(keyword, start_day, end_day);
        }
        else
        {
            MessageBox.Show("검색 조건을 다시 확인해주세요.", "ITEM MANAGER", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        return dataTable;
    }
    #endregion
}
#endregion

#region OrderListPanel
internal class OrderListSQL
{
    private static MySqlConnection mysql = oGlobal.GetConnection();
    private MySqlDataReader reader = null;
    private string sql = null;
    int result = 0;

    public ListBox GetAllOrderTable()
    {
        ListBox listbox = new ListBox();
        string prev_division = "---------- ";
        string next_division = " ----------";
        string division = "----------";
        string space = "     ";
        string item_info = string.Empty;

        string prev_itemNumber = string.Empty;
        string prev_itemName = string.Empty;
        string prev_itemCount = string.Empty;
        string prev_payment = string.Empty;

        string next_itemNumber = string.Empty;
        string next_itemName = string.Empty;
        string next_itemCount = string.Empty;
        string next_payment = string.Empty;

        try
        {
            sql = "select * from ordertable order by regdate, orderNumber, itemNumber";
            using (MySqlCommand cmd = new MySqlCommand(sql, mysql))
            {
                using (reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (!listbox.Items.Contains(division+prev_division + reader.GetDateTime("regdate").ToString("yyyy-MM-dd") + next_division+division+division))
                        {
                            listbox.Items.Add("");
                            listbox.Items.Add(division+prev_division + reader.GetDateTime("regdate").ToString("yyyy-MM-dd") + next_division+division+division);
                            listbox.Items.Add("");
                        }
                        prev_itemNumber = reader.GetString("itemNumber");
                        prev_itemName = reader.GetString("itemName");
                        prev_itemCount = reader.GetInt32("itemCOunt").ToString();
                        prev_payment = reader.GetInt32("payment").ToString("C");

                        if(prev_itemNumber.Contains("-")) // 출력하는 제품이 옵션이면
                        {
                            if(prev_itemName.Equals("샷 추가") || prev_itemName.Equals("연하게"))
                            {
                                item_info = string.Format("{0, -10} {1, 10} {2, 10:C}", "+" + prev_itemName.PadRight(10), prev_itemCount.PadLeft(15), prev_payment.PadLeft(20));
                            }
                            else if(prev_itemName.Equals("ICE") || prev_itemName.Equals("HOT"))
                            {
                                item_info = string.Format("{0, -10} {1, 10} {2, 10:C}", "+" + prev_itemName.PadRight(10), prev_itemCount.PadLeft(19), prev_payment.PadLeft(20));
                            }
                            listbox.Items.Add(item_info);

                            Console.WriteLine("prev_itemName: "+prev_itemName+" And next_itemName: "+next_itemName);

                            bool option1 = prev_itemName.Equals("샷 추가") && next_itemName.Equals("ICE");
                            bool option2 = prev_itemName.Equals("샷 추가") && next_itemName.Equals("HOT");
                            bool option3 = prev_itemName.Equals("연하게") && next_itemName.Equals("ICE");
                            bool option4 = prev_itemName.Equals("연하게") && next_itemName.Equals("HOT");

                            bool option5 = prev_itemName.Equals("ICE") && next_itemName.Equals("샷 추가");
                            bool option6 = prev_itemName.Equals("ICE") && next_itemName.Equals("연하게");
                            bool option7 = prev_itemName.Equals("HOT") && next_itemName.Equals("샷 추가");
                            bool option8 = prev_itemName.Equals("HOT") && next_itemName.Equals("연하게");


                            if (option1 || option2 || option3 || option4 || option5 || option6 || option7 || option8)
                            {
                                listbox.Items.Add("");
                                listbox.Items.Add(division + division + division + division);
                                listbox.Items.Add("");
                            }
                        }
                        else // 아니면
                        {
                            listbox.Items.Add("");
                            item_info = string.Format("{0, -10} {1, 10} {2, 10:C}",prev_itemName.PadRight(10), prev_itemCount.PadLeft(10), prev_payment.PadLeft(20));
                            listbox.Items.Add(item_info);
                        }

                        next_itemNumber = prev_itemNumber;
                        next_itemName = prev_itemName;
                        next_itemCount = prev_itemCount;
                        next_payment = prev_payment;

                    }
                }
            }
        }
        catch(MySqlException ex)
        {
            MessageBox.Show(ex.Message, "MYSQL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        return listbox;
    }
}
#endregion
