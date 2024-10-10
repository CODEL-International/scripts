namespace ReplaceTool
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      txtTemplate = new TextBox();
      dgvKeys = new DataGridView();
      Key = new DataGridViewTextBoxColumn();
      ColumnNum = new DataGridViewTextBoxColumn();
      Type = new DataGridViewTextBoxColumn();
      button1 = new Button();
      txtOut = new TextBox();
      dgvData = new DataGridView();
      button2 = new Button();
      label1 = new Label();
      label2 = new Label();
      label3 = new Label();
      label4 = new Label();
      button3 = new Button();
      ((System.ComponentModel.ISupportInitialize)dgvKeys).BeginInit();
      ((System.ComponentModel.ISupportInitialize)dgvData).BeginInit();
      SuspendLayout();
      // 
      // txtTemplate
      // 
      txtTemplate.Location = new Point(684, 50);
      txtTemplate.Multiline = true;
      txtTemplate.Name = "txtTemplate";
      txtTemplate.Size = new Size(808, 639);
      txtTemplate.TabIndex = 0;
      // 
      // dgvKeys
      // 
      dgvKeys.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvKeys.Columns.AddRange(new DataGridViewColumn[] { Key, ColumnNum, Type });
      dgvKeys.Location = new Point(43, 50);
      dgvKeys.Name = "dgvKeys";
      dgvKeys.Size = new Size(586, 163);
      dgvKeys.TabIndex = 1;
      dgvKeys.CellContentClick += dgvKeys_CellContentClick;
      // 
      // Key
      // 
      Key.HeaderText = "Key";
      Key.Name = "Key";
      // 
      // ColumnNum
      // 
      ColumnNum.HeaderText = "ColumnNum";
      ColumnNum.Name = "ColumnNum";
      // 
      // Type
      // 
      Type.HeaderText = "Type";
      Type.Name = "Type";
      Type.Resizable = DataGridViewTriState.True;
      Type.SortMode = DataGridViewColumnSortMode.NotSortable;
      // 
      // button1
      // 
      button1.Location = new Point(554, 577);
      button1.Name = "button1";
      button1.Size = new Size(75, 38);
      button1.TabIndex = 2;
      button1.Text = "Convert to JMobile";
      button1.UseVisualStyleBackColor = true;
      button1.Click += button1_Click;
      // 
      // txtOut
      // 
      txtOut.Location = new Point(40, 577);
      txtOut.Multiline = true;
      txtOut.Name = "txtOut";
      txtOut.Size = new Size(481, 112);
      txtOut.TabIndex = 3;
      // 
      // dgvData
      // 
      dgvData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      dgvData.Location = new Point(40, 250);
      dgvData.Name = "dgvData";
      dgvData.Size = new Size(589, 282);
      dgvData.TabIndex = 4;
      // 
      // button2
      // 
      button2.Location = new Point(513, 538);
      button2.Name = "button2";
      button2.Size = new Size(116, 23);
      button2.TabIndex = 5;
      button2.Text = "Import Excel";
      button2.UseVisualStyleBackColor = true;
      button2.Click += button2_Click;
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Location = new Point(43, 32);
      label1.Name = "label1";
      label1.Size = new Size(464, 15);
      label1.TabIndex = 6;
      label1.Text = "Type 0 - Normal, 1 = DataType, 2 = + 400001(JM), 3= IsMultiplier (JM), 4=-2000 BASE(C)";
      label1.Click += label1_Click;
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Location = new Point(684, 32);
      label2.Name = "label2";
      label2.Size = new Size(55, 15);
      label2.TabIndex = 7;
      label2.Text = "Template";
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(43, 559);
      label3.Name = "label3";
      label3.Size = new Size(45, 15);
      label3.TabIndex = 8;
      label3.Text = "Output";
      // 
      // label4
      // 
      label4.AutoSize = true;
      label4.Location = new Point(40, 232);
      label4.Name = "label4";
      label4.Size = new Size(88, 15);
      label4.TabIndex = 9;
      label4.Text = "Data to Process";
      // 
      // button3
      // 
      button3.Location = new Point(554, 621);
      button3.Name = "button3";
      button3.Size = new Size(75, 38);
      button3.TabIndex = 10;
      button3.Text = "Convert to C#";
      button3.UseVisualStyleBackColor = true;
      button3.Click += button3_Click;
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1524, 715);
      Controls.Add(button3);
      Controls.Add(label4);
      Controls.Add(label3);
      Controls.Add(label2);
      Controls.Add(label1);
      Controls.Add(button2);
      Controls.Add(dgvData);
      Controls.Add(txtOut);
      Controls.Add(button1);
      Controls.Add(dgvKeys);
      Controls.Add(txtTemplate);
      Name = "Form1";
      Text = "ReplaceTool";
      ((System.ComponentModel.ISupportInitialize)dgvKeys).EndInit();
      ((System.ComponentModel.ISupportInitialize)dgvData).EndInit();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private TextBox txtTemplate;
    private DataGridView dgvKeys;
    private Button button1;
    private TextBox txtOut;
    private DataGridView dgvData;
    private Button button2;
    private DataGridViewTextBoxColumn Key;
    private DataGridViewTextBoxColumn ColumnNum;
    private DataGridViewTextBoxColumn Type;
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;
    private Button button3;
  }
}
