namespace WindowsFormsApplication1
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btConDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSevName = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDB = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTabFilter = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColFilter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbTabCount = new System.Windows.Forms.Label();
            this.txtShow = new System.Windows.Forms.TextBox();
            this.btReBuildPath = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTargetReference = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btConDB
            // 
            this.btConDB.Location = new System.Drawing.Point(502, 436);
            this.btConDB.Name = "btConDB";
            this.btConDB.Size = new System.Drawing.Size(75, 23);
            this.btConDB.TabIndex = 0;
            this.btConDB.Text = "表拆分";
            this.btConDB.UseVisualStyleBackColor = true;
            this.btConDB.Click += new System.EventHandler(this.btConDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "服务器名称";
            // 
            // txtSevName
            // 
            this.txtSevName.Location = new System.Drawing.Point(93, 30);
            this.txtSevName.Name = "txtSevName";
            this.txtSevName.Size = new System.Drawing.Size(530, 21);
            this.txtSevName.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(93, 71);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(133, 21);
            this.txtUser.TabIndex = 3;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(288, 71);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Size = new System.Drawing.Size(133, 21);
            this.txtPwd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "账户";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "密码";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(443, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 7;
            this.label4.Text = "数据库";
            // 
            // txtDB
            // 
            this.txtDB.Location = new System.Drawing.Point(490, 71);
            this.txtDB.Name = "txtDB";
            this.txtDB.Size = new System.Drawing.Size(133, 21);
            this.txtDB.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.txtDB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSevName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtPwd);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(644, 109);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据库连接配置";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(16, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "文件保存路径";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(105, 139);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(449, 21);
            this.txtFilePath.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(42, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "表名过滤";
            // 
            // txtTabFilter
            // 
            this.txtTabFilter.Location = new System.Drawing.Point(105, 176);
            this.txtTabFilter.Name = "txtTabFilter";
            this.txtTabFilter.Size = new System.Drawing.Size(90, 21);
            this.txtTabFilter.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(201, 179);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(269, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "（对包含关键词的表拆分，不填表示所有表拆分）";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(29, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 12);
            this.label8.TabIndex = 15;
            this.label8.Text = "主字段过滤";
            // 
            // txtColFilter
            // 
            this.txtColFilter.Location = new System.Drawing.Point(105, 212);
            this.txtColFilter.Name = "txtColFilter";
            this.txtColFilter.Size = new System.Drawing.Size(90, 21);
            this.txtColFilter.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 215);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 12);
            this.label9.TabIndex = 17;
            this.label9.Text = "（以哪个字段对表拆分，必须填入）";
            // 
            // lbTabCount
            // 
            this.lbTabCount.AutoSize = true;
            this.lbTabCount.Location = new System.Drawing.Point(22, 282);
            this.lbTabCount.Name = "lbTabCount";
            this.lbTabCount.Size = new System.Drawing.Size(89, 12);
            this.lbTabCount.TabIndex = 18;
            this.lbTabCount.Text = "符合条件的表：";
            // 
            // txtShow
            // 
            this.txtShow.Location = new System.Drawing.Point(12, 297);
            this.txtShow.Multiline = true;
            this.txtShow.Name = "txtShow";
            this.txtShow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShow.Size = new System.Drawing.Size(644, 133);
            this.txtShow.TabIndex = 19;
            this.txtShow.WordWrap = false;
            // 
            // btReBuildPath
            // 
            this.btReBuildPath.Location = new System.Drawing.Point(560, 137);
            this.btReBuildPath.Name = "btReBuildPath";
            this.btReBuildPath.Size = new System.Drawing.Size(75, 23);
            this.btReBuildPath.TabIndex = 20;
            this.btReBuildPath.Text = "重建路径";
            this.btReBuildPath.UseVisualStyleBackColor = true;
            this.btReBuildPath.Click += new System.EventHandler(this.btReBuildPath_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(105, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "NPOItest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(16, 251);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "主字段参照表";
            // 
            // txtTargetReference
            // 
            this.txtTargetReference.Location = new System.Drawing.Point(105, 248);
            this.txtTargetReference.Name = "txtTargetReference";
            this.txtTargetReference.Size = new System.Drawing.Size(530, 21);
            this.txtTargetReference.TabIndex = 23;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 471);
            this.Controls.Add(this.txtTargetReference);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btReBuildPath);
            this.Controls.Add(this.txtShow);
            this.Controls.Add(this.lbTabCount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtColFilter);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTabFilter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btConDB);
            this.Name = "Main";
            this.Text = "东西湖区全覆盖审计数据切分工具 v2.0";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btConDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSevName;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDB;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTabFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtColFilter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbTabCount;
        private System.Windows.Forms.TextBox txtShow;
        private System.Windows.Forms.Button btReBuildPath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTargetReference;
    }
}

