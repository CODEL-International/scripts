using System.Data;
using System.Data.OleDb;
using System.Numerics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ReplaceTool
{
  public partial class Form1 : Form
  {
    public Form1()
    {
      InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {


      foreach (DataGridViewRow datarow in dgvData.Rows)
      {

        if (datarow.Cells[0].Value != null)
        {

          string outStr = txtTemplate.Text;

          foreach (DataGridViewRow keyrow in dgvKeys.Rows)
          {

            if (keyrow.Cells[0].Value != null)
            {
              if (keyrow.Cells[2].Value.ToString() == "1")
              {
                if (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "U16")
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "unsignedShort", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!CONVERSION!!", "", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "0", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "65535", RegexOptions.IgnoreCase);
                }
                else if (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "S16")
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "short", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!CONVERSION!!", "", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "-32768", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "32767", RegexOptions.IgnoreCase);
                }
                else if (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "Single")
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "float", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!CONVERSION!!", "swap4,swap2", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "-3.40282e+38", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "3.40282e+38", RegexOptions.IgnoreCase);
                }
              }
              else if (keyrow.Cells[2].Value.ToString() == "2")
              {
                outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), (400001 + int.Parse(datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString())).ToString(), RegexOptions.IgnoreCase);
              }

              outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString(), RegexOptions.IgnoreCase);


              //Type Code 3 is a multiplier other than 1.. so we set a float type. 
              if (keyrow.Cells[2].Value.ToString() == "3")
              {
                if (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "1")
                {
                  outStr = Regex.Replace(outStr, "!!CASTTYPE!!", "", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!ENABLESCALING!!", "false", RegexOptions.IgnoreCase);
                }
                else
                {
                  outStr = Regex.Replace(outStr, "!!CASTTYPE!!", "float", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!ENABLESCALING!!", "true", RegexOptions.IgnoreCase);
                }
              }
            }
            else
            {
              outStr = outStr + System.Environment.NewLine;
            }
          }

          txtOut.Text = txtOut.Text + outStr;
        }
      }
    }

    private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void dgvKeys_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {

    }

    private void button2_Click(object sender, EventArgs e)
    {
      try
      {
        OpenFileDialog dlg_im = new OpenFileDialog();
        dlg_im.Filter = "Excel File|*.xls;*.xlsx;*.xlsm";
        //dlg_im.Filter = "Excel File|*.xlsx";

        if (dlg_im.ShowDialog() == DialogResult.OK)
        {
          dgvData.Rows.Clear();

          string name = "Sheet1";
          string constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + dlg_im.FileName + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

          OleDbConnection Con = new OleDbConnection(constr);
          OleDbCommand OleConnection = new OleDbCommand("SELECT * FROM [Sheet1$]", Con);
          Con.Open();

          OleDbDataAdapter sda = new OleDbDataAdapter(OleConnection);
          System.Data.DataTable data = new DataTable();
          sda.Fill(data);
          dgvData.DataSource = data;

          //dgvData.ReadOnly = true;
          //dgvData.Columns[0].Width = 320;
          //dgvData.ClearSelection();
        }
      }
      catch (Exception ex)
      {
        MessageBox.Show(ex.ToString());
      }
    }

    private void label1_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {


      foreach (DataGridViewRow datarow in dgvData.Rows)
      {

        if (datarow.Cells[0].Value != null)
        {

          string outStr = txtTemplate.Text;

          foreach (DataGridViewRow keyrow in dgvKeys.Rows)
          {

            if (keyrow.Cells[0].Value != null)
            {
              if (keyrow.Cells[2].Value.ToString() == "1")
              {
                if ((datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "U16") || (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "u16"))
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "u16", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "0", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "65535", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMBYTES!!", "2", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMREGS!!", "1", RegexOptions.IgnoreCase);
                }
                else if ((datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "S16") || (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "s16"))
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "s16", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "-32768", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "32767", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMBYTES!!", "2", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMREGS!!", "1", RegexOptions.IgnoreCase);
                }
                else if ((datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "Single") || (datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString() == "float"))
                {
                  outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), "single", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MIN!!", "-3.40282e+38", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!MAX!!", "3.40282e+38", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMBYTES!!", "4", RegexOptions.IgnoreCase);
                  outStr = Regex.Replace(outStr, "!!NUMREGS!!", "2", RegexOptions.IgnoreCase);
                }
              }
              else if (keyrow.Cells[2].Value.ToString() == "4")
              {
                outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), (int.Parse(datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString(), System.Globalization.NumberStyles.HexNumber) - 0x2000).ToString("X2"), RegexOptions.IgnoreCase);
              }

              outStr = Regex.Replace(outStr, keyrow.Cells[0].Value.ToString(), datarow.Cells[int.Parse(keyrow.Cells[1].Value.ToString())].Value.ToString(), RegexOptions.IgnoreCase);


            }
            else
            {
              outStr = outStr + System.Environment.NewLine;
            }
          }

          txtOut.Text = txtOut.Text + outStr;
        }
      }
    }
  }
}
