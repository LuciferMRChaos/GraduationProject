using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
namespace DAL
{
    public class DataBaseAccess
    {
        static SqlCommand cmd = null;
        static SqlConnection conn = null;
        static SqlDataAdapter sda = null;
        static SqlDataReader sdr = null;

        static DataBaseAccess()
        {
            conn = new SqlConnection("Data Source=.;Database=CavalryJurisprudence;Integrated Security=sspi");
            cmd = new SqlCommand();
            cmd.Connection = conn;
            sda = new SqlDataAdapter();
        }
        public static object GetOneData(string sqlText)
        {///执行返回一个值的查询
            cmd.CommandText = sqlText;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            object i = cmd.ExecuteScalar();
            conn.Close();
            return i;
        }
        public static DataTable GetDataSet(string sqlText)
        {///执行一个命令查询一个数据集并返回该数据集(离线模式)
            cmd.CommandText = sqlText;
            cmd.CommandType = CommandType.Text;
            DataSet ds = new DataSet();
            sda.SelectCommand = cmd;
            sda.Fill(ds, "t");
            return ds.Tables["t"];
        }
        public static int ExecuteSql(string sqlText)
        {///执行一个命令对数据库进行增，删，改
            cmd.CommandText = sqlText;
            cmd.CommandType = CommandType.Text;
            conn.Open();
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }

    }
}
