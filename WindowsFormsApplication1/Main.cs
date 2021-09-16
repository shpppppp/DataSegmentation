using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using NPOI;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel; //xlsx文件支持
using NPOI.HSSF.UserModel; //xls文件支持
using System.IO;
using System.Configuration;


namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public Main()  //构造器
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            Configuration config = System.Configuration.ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            #region  //创建输出目录
            txtFilePath.Text = config.AppSettings.Settings["OutPutPath"].Value;
            ReBuildPath();
            #endregion
            txtSevName.Text = config.AppSettings.Settings["ServerIP"].Value;
            txtUser.Text = config.AppSettings.Settings["DBUser"].Value;
            txtPwd.Text = config.AppSettings.Settings["DBKey"].Value;
            txtDB.Text = config.AppSettings.Settings["DBName"].Value;
            txtTabFilter.Text = config.AppSettings.Settings["TabFilter"].Value;
            txtTargetReference.Text = System.IO.Directory.GetCurrentDirectory() + "\\" + config.AppSettings.Settings["TargetReference"].Value;
            button1.Enabled = false;
            txtColFilter.Text = config.AppSettings.Settings["ColFilter"].Value;
        }

        private void ReBuildPath() //重建路径
        {
            try
            {
                CreateFolder(txtFilePath.Text);
            }
            catch
            {
                MessageBox.Show("输出目录创建失败");
            }
        }

        private void CreateFolder(string path)  //创建输出目录
        {
            if (System.IO.Directory.Exists(path) == false)
            {
                System.IO.Directory.CreateDirectory(path);
            }
        }

        private void btReBuildPath_Click(object sender, EventArgs e)  
        {
            ReBuildPath();
        }
        
        private string GetQueryTableStr()  //根据过滤条件构造查询语句，查询符合条件的表名
        {
            string str = "";
            if (txtTabFilter.Text != "")
            {
                str = "select a.name from " + txtDB.Text + ".sys.sysobjects a"
                       + " inner join " + txtDB.Text + ".sys.sysindexes b on a.id = b.id"
                       +" inner join (select distinct TABLE_NAME from " + txtDB.Text + ".INFORMATION_SCHEMA.COLUMNS"
                       +" where COLUMN_NAME = '" + txtColFilter.Text + "') c on a.name = c.TABLE_NAME"
                       + " where (a.type = 'u') and (b.indid in (0,1)) and b.rows > 0"
                       + " and a.name like '%" + txtTabFilter.Text + "%'";
            }
            else
            {
                str = "select a.name from " + txtDB.Text + ".sys.sysobjects a"
                       + " inner join " + txtDB.Text + ".sys.sysindexes b on a.id = b.id"
                       + " inner join (select distinct TABLE_NAME from " + txtDB.Text + ".INFORMATION_SCHEMA.COLUMNS"
                       + " where COLUMN_NAME = '" + txtColFilter.Text + "') c on a.name = c.TABLE_NAME"
                       + " where (a.type = 'u') and (b.indid in (0,1)) and b.rows > 0";
            }
            return str;
        }

        private string GetQueryResultStr(string tabName)  //根据表名构造查询
        {
            string str = "";
            str = "select * from [" + tabName+"]";
            return str;
        }

        private string GetQueryResultStr(string tabName,string originalName)  //重载_根据表名、源列名构造查询
        {
            string str = "";
            str = "select * from [" + tabName + "] where " + txtColFilter.Text + " ='"+originalName+"'";
            return str;
        }

        private string GetXlsFileName(string targetName, string tabName)  //按路径生成excel文件名（文件名格式：目标名称_表名.xls)
        { 
            string str="";
            str = txtFilePath.Text+"\\"+targetName+"_"+tabName+".xls";
            return str;
        }

        private string GetXlsFileName(string targetName)  //重载_按路径生成excel文件名（文件名格式：单位名称.xls)
        {
            string str = "";
            str = txtFilePath.Text + "\\" + targetName + ".xls";
            return str;
        }

        private string getConStr()  //获取连接字符串
        {
            return "server=" + txtSevName.Text + ";database=" + txtDB.Text + ";user=" + txtUser.Text + ";pwd=" + txtPwd.Text;
        }

        private string GetQueryOriginalStr(string table) //构造查询语句，查询指定表中无重复的指定字段
        {
            return "select [" + txtColFilter.Text + "] from [" + table + "] group by [" + txtColFilter.Text + "]";
        }

        private List<string> GetOriginalName(string tabName) //获取每个表中指定列的无重复数据，调用GetQueryOriginalStr方法
        {
            List<string> temp = new List<string>();
            SqlConnection con = new SqlConnection(getConStr());
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("数据库连接失败，重新启动程序并检查数据库连接配置");
                this.Close();
            }
            SqlCommand oriCmd = new SqlCommand();
            oriCmd.Connection = con;
            oriCmd.CommandType = CommandType.Text;
            oriCmd.CommandText = GetQueryOriginalStr(tabName); //查询结果只有一个字段，无重复指定列
            SqlDataReader oriDr = oriCmd.ExecuteReader();
            if (oriDr.HasRows)
            {
                while (oriDr.Read())
                {
                    originalName.Add(oriDr[0].ToString());
                }
            }
            oriDr.Close();
            con.Close();
            return temp;
        }

        private List<string> TableName = new List<string>(); //表名列表
        private List<string> TargetName = new List<string>(); //目标列表，如：标准预算单位名称
        private List<string> originalName = new List<string>(); //源于数据库的字段列表，将于目标列表匹配
        //private List<string> matchingFailure = new List<string>(); //匹配失败记录

        private void btConDB_Click(object sender, EventArgs e)
        {
            #region  打开数据库连接
            SqlConnection con = new SqlConnection();
            con.ConnectionString = getConStr();
            try
            {
                con.Open();
            }
            catch
            {
                MessageBox.Show("数据库连接失败，重新启动程序并检查数据库连接配置");
                this.Close();
            }
            #endregion
            
            #region 根据字段过滤条件获取表名
            if (txtColFilter.Text != "")
            {
                SqlCommand tbCmd = new SqlCommand();
                SqlDataReader dr = null;
                tbCmd.Connection = con;
                tbCmd.CommandType = CommandType.Text;
                tbCmd.CommandText = GetQueryTableStr(); //查询结果只有一个字段：表名
                dr = tbCmd.ExecuteReader();
                int count = 0;
                while (dr.Read())
                {
                    TableName.Add(dr[0].ToString()); 
                    count++;
                }
                lbTabCount.Text = "符合条件的表：" + count.ToString();
                dr.Close();
            }
            else
            {
                MessageBox.Show("主字段过滤必填");
            }
            #endregion

            #region  通过参考列表获取参考值
            try
            {
                StreamReader sr = new StreamReader(txtTargetReference.Text, Encoding.Default);
                string content;
                while ((content = sr.ReadLine()) != null)
                {
                    TargetName.Add(content);
                }
            }
            catch
            {
                MessageBox.Show("检查参考列表文件");
                this.Close();
            }
            #endregion

            #region 生成excel文件使用的SqlCommand
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            #endregion
            int tableCount = TableName.Count; //表个数
            int targetCount = TargetName.Count; //目标个数

            #region 获取所有表的指定列数据
            SqlConnection oriCon = new SqlConnection(getConStr());
            try
            {
                oriCon.Open();
            }
            catch
            {
                MessageBox.Show("数据库连接失败，重新启动程序并检查数据库连接配置");
                this.Close();
            }
            foreach (string t in TableName)
            {
                SqlCommand oriCmd = new SqlCommand();
                oriCmd.Connection = oriCon;
                oriCmd.CommandType = CommandType.Text;
                oriCmd.CommandText = GetQueryOriginalStr(t); //查询结果只有一个字段，无重复指定列
                SqlDataReader oriDr = oriCmd.ExecuteReader();
                if (oriDr.HasRows)
                {
                    while (oriDr.Read())
                    {
                        originalName.Add(oriDr[0].ToString());
                    }
                }
                oriDr.Close(); 
            }
            oriCon.Close();
            #endregion
            #region 去除指定列中重复数据
            HashSet<string> originalHash = new HashSet<string>(originalName);
            originalName = new List<string>(originalHash);
            #endregion
            #region 生成excel文件
            for (int orC = 0; orC < originalName.Count; orC++)
            {
                FileStream fs = File.Open(GetXlsFileName(originalName[orC]), FileMode.OpenOrCreate);
                HSSFWorkbook wk = new HSSFWorkbook();
                string tables = null; //疑点表名
                for (int tbC = 0; tbC < tableCount; tbC++)
                {
                    cmd.CommandText = GetQueryResultStr(TableName[tbC], originalName[orC]);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        ISheet st = wk.CreateSheet(TableName[tbC]);
                        int index = 0;
                        IRow row = st.CreateRow(index);
                        for (int r = 0; r < dr.FieldCount; r++)
                        {
                            row.CreateCell(r).SetCellValue(dr.GetName(r));
                        }
                        ++index;
                        while (dr.Read())
                        {
                            row = st.CreateRow(index);
                            index++;
                            for(int r=0;r<dr.FieldCount;r++)
                            {
                                row.CreateCell(r).SetCellValue(dr.GetSqlValue(r).ToString());
                            }
                        }
                        tables += TableName[tbC] + "  ";
                    }
                    dr.Close();
                }
                wk.Write(fs);
                wk.Close();
                fs.Close();
                txtShow.Text += originalName[orC] + "……处理完成，涉及的疑点："+ tables + "\r\n";
            }
            txtShow.Text += "全部完成……，共有单位:" + originalName.Count;
            #endregion

            con.Close(); //关闭数据库连接
        }

        private void button1_Click(object sender, EventArgs e) //测试NPOI读写excel
        {
            string str = "select * from [QFG2018]..[疑点_应缴财政财政款年末有余额]";
            SqlConnection con = new SqlConnection(getConStr());
            con.Open();
            SqlCommand cmd = new SqlCommand(str,con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            { 
                //创建HSSFWorkbook对象
                IWorkbook wk = new HSSFWorkbook();
                ISheet st = wk.CreateSheet("疑点_应缴财政财政款年末有余额");
                int index = 0;
                IRow row = st.CreateRow(index);
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row.CreateCell(i).SetCellValue(dr.GetName(i));
                }
                ++index;
                while(dr.Read())
                {
                    row = st.CreateRow(index);
                    index++;
                    for (int i = 0; i <dr.FieldCount; i++)
                    {
                        row.CreateCell(i).SetCellValue(dr.GetSqlValue(i).ToString());
                    }
                }
                FileStream fs = File.Open("F:\\xxxxxx6\\XXX.xls", FileMode.Create);
                wk.Write(fs);
                fs.Close();  //关闭文件流
                wk.Close();  //关闭工作簿
                dr.Close();  //关闭DataReader
                con.Close(); //关闭数据连接
            }
        }

    }

}
