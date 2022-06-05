using System;
using System.Management.Automation;


namespace userConfApp
{
    public partial class mainWindow : Form
    {
        About aboutWindow;

        //Needed to bypass premature triggers to cell change
        bool dataLoaded;
        string xmlFileDecoded = "";
        string xmlFileEncoded = "";
        public static string version = "";
        public static int uptime = 0; 
        public mainWindow()
        {
            InitializeComponent();
            
            aboutWindow = new About();
        }


        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aboutWindow.Show();  
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFunction();
        }

        private void mainWindow_Load(object sender, EventArgs e)
        {
            string xmlFile = "config.xml";
            
            dataLoaded = false;
            FileInterface configFile = new FileInterface();

            //TODO: If there is no file
            xmlFileEncoded = File.ReadAllText(xmlFile);

            xmlFileDecoded = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(xmlFileEncoded));
            FileInterface.userAccount[] userAccount = new FileInterface.userAccount[configFile.readXml(xmlFileDecoded).Length];
            

            userAccount = configFile.readXml(xmlFileDecoded);
            for (int i = 0; i < userAccount.Length; i++)
            {
                userGrid.Rows.Add();
                userGrid.CurrentCell = userGrid[0, i];
                userGrid.CurrentCell.Value = userAccount[i].id;
                userGrid.CurrentCell = userGrid[1, i];
                userGrid.CurrentCell.Value = userAccount[i].enabled;
                userGrid.CurrentCell = userGrid[2, i];
                userGrid.CurrentCell.Value = userAccount[i].name;
                userGrid.CurrentCell = userGrid[3, i];
                userGrid.CurrentCell.Value = userAccount[i].password;
                userGrid.CurrentCell.ReadOnly = userAccount[i].encPass;
                userGrid.CurrentCell = userGrid[4, i];
                userGrid.CurrentCell.Value = userAccount[i].encPass;

            }
            userGrid.ClearSelection();
            
            dataLoaded = true;
        }

        private void saveFunction()
        {
            string xmlFile = "config.xml";
            FileInterface configFile = new FileInterface();
            FileInterface.userAccount[] userAccount = new FileInterface.userAccount[userGrid.RowCount - 1];
            for (int i = 0; i < userAccount.Length; i++)
            {
                userGrid.CurrentCell = userGrid[0, i];
                userAccount[i].id = userGrid.CurrentCell.Value.ToString();
                userGrid.CurrentCell = userGrid[1, i];
                userAccount[i].enabled = Convert.ToBoolean(userGrid.CurrentCell.Value);
                userGrid.CurrentCell = userGrid[2, i];
                userAccount[i].name = userGrid.CurrentCell.Value.ToString();
                userGrid.CurrentCell = userGrid[3, i];
                userAccount[i].password = userGrid.CurrentCell.Value.ToString();
                userGrid.CurrentCell = userGrid[4, i];
                userAccount[i].encPass = Convert.ToBoolean(userGrid.CurrentCell.Value);

            }
            File.WriteAllTextAsync(xmlFile, Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(configFile.writeXml(userAccount, xmlFileDecoded))) );
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveFunction();
        }

        private void userGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataLoaded)
            {
                
                if ((userGrid.CurrentCell.ColumnIndex == 4) && (userGrid.CurrentCell.Value != null))


                    //If we change encoded/not encoded then prevent from corrupting the encoded string
                    //Using Super Strong Encoding Base64 as per example
                    if (Convert.ToBoolean(userGrid.CurrentCell.Value))
                    {
                        userGrid.CurrentCell = userGrid[3, userGrid.CurrentCell.RowIndex];
                        userGrid.CurrentCell.Value = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(userGrid.CurrentCell.Value.ToString()));
                        userGrid.CurrentCell.ReadOnly = true;
                    }
                    else
                    {
                        userGrid.CurrentCell = userGrid[3, userGrid.CurrentCell.RowIndex];
                        userGrid.CurrentCell.Value = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(userGrid.CurrentCell.Value.ToString()));
                        userGrid.CurrentCell.ReadOnly = false;
                    }

            }
        }

        private void generatePassBnt_Click(object sender, EventArgs e)
        {
            //Generate new passwords for selected rows
            bool wasEncoded = false;
            int selectedRowCount =
            userGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);
            string passFilename = "System.Nothing.Important.Here.dll";
            string passFileLine;
            

          

            PowerShell ps = PowerShell.Create();

            ps.AddScript("for ($i = 1 ; $i -le "+selectedRowCount+" ; $i++)" +
                "{-join ((48..57) + (65..90) + (97..122) | Get-Random -Count 12 | % {[char]$_}) | Out-File -Append -FilePath "+passFilename+" }");
            ps.Invoke();

            StreamReader singleLine = new StreamReader(passFilename);


            //TODO: If there is no file
            foreach (DataGridViewRow selectedRow in userGrid.SelectedRows)
            {
                wasEncoded = false;
                //If encoded - decode before changing
                if (Convert.ToBoolean(selectedRow.Cells[4].Value))
                {
                    wasEncoded = true;
                    selectedRow.Cells[4].Value = false;
                    selectedRow.Cells[3].Value = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(selectedRow.Cells[3].Value.ToString()));
                    selectedRow.Cells[3].ReadOnly = false;
                }

                selectedRow.Cells[3].Value = singleLine.ReadLine();


                //Return encoding state
                if (wasEncoded)
                {
                    selectedRow.Cells[4].Value = true;
                    selectedRow.Cells[3].Value = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(selectedRow.Cells[3].Value.ToString()));
                    selectedRow.Cells[3].ReadOnly = true;
                }
            }
            singleLine.Close();  
            File.Delete(passFilename);
        }
    }
}