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
        public static Int64 uptime = 0; 
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

            //Check if expected config file exists
            if (!File.Exists(xmlFile))
            {
                File.WriteAllTextAsync(xmlFile, FileInterface.StrB64Enc(FileInterface.defaultXml()));
                MessageBox.Show(xmlFile+" file not found\n Will load default template");
            }
            xmlFileEncoded = File.ReadAllText(xmlFile);
            if (FileInterface.IsBase64String(xmlFileEncoded))
            {
                xmlFileDecoded = FileInterface.StrB64Dec(xmlFileEncoded);
            } else
            {
                MessageBox.Show(xmlFile + " file might be corrupted\n Will load default template");
                //Call default file creation function
                File.Delete(xmlFile);
                File.WriteAllTextAsync(xmlFile, FileInterface.StrB64Enc(FileInterface.defaultXml()));
                xmlFileEncoded = File.ReadAllText(xmlFile);
                xmlFileDecoded = FileInterface.StrB64Dec(xmlFileEncoded);
                //Then read and decode file...
                //Or maybe generate xml and leave it there? To avoid extra Enc-Dec action
            }
            FileInterface.userAccount[] userAccount = new FileInterface.userAccount[configFile.readXml(xmlFileDecoded).Length];
            

            userAccount = configFile.readXml(xmlFileDecoded);

            //Fill GUI table
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

            //Read GUI to variables
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

            //writeXml populates Xml with user entries
            //What will happen if Read-Only???
            File.WriteAllTextAsync(xmlFile, FileInterface.StrB64Enc(configFile.writeXml(userAccount,xmlFileDecoded)));
            userGrid.ClearSelection();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            saveFunction();
        }

        private void userGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataLoaded) //Avoiding trouble on initial load
            {
                //null check here is useless... Checking if encoding box was changed
                if ((userGrid.CurrentCell.ColumnIndex == 4) && (userGrid.CurrentCell.Value != null))


                    //If we change encoded/not encoded then prevent from corrupting the encoded string
                    //Using Super Strong Encoding Base64 as per example
                    //Also check if pass cell is not null
                    if (Convert.ToBoolean(userGrid.CurrentCell.Value))
                    {
                        userGrid.CurrentCell = userGrid[3, userGrid.CurrentCell.RowIndex];
                        if (userGrid.CurrentCell.Value != null) //Check if Password cell has something to convert
                            userGrid.CurrentCell.Value = FileInterface.StrB64Enc(userGrid.CurrentCell.Value.ToString());
                        userGrid.CurrentCell.ReadOnly = true;
                    }
                    else
                    {
                        userGrid.CurrentCell = userGrid[3, userGrid.CurrentCell.RowIndex];
                        if (userGrid.CurrentCell.Value != null) //Check if Password cell has something to convert
                            userGrid.CurrentCell.Value = FileInterface.StrB64Dec(userGrid.CurrentCell.Value.ToString());
                        userGrid.CurrentCell.ReadOnly = false;
                    }
                userGrid.ClearSelection();

            }
        }

        private void generatePassBnt_Click(object sender, EventArgs e)
        {
            //Generate new passwords for selected rows
            bool wasEncoded = false;
            int selectedRowCount =
            userGrid.Rows.GetRowCount(DataGridViewElementStates.Selected);

            //Attempt to hide the file in plain sight ;)
            string passFilename = "System.Nothing.Important.Here.dll";
            
            
            //If no rows selected, then we do not get any file generated which results in StreamReades exception
            //"Fixed" by checking row count
            if (selectedRowCount > 0)
            {
                PowerShell ps = PowerShell.Create();
                //Current script generates numbers, upper and lower case chars; can be extended by adding additional ASCII codes
                ps.AddScript("for ($i = 1 ; $i -le " + selectedRowCount + " ; $i++)" +
                    "{-join ((48..57) + (65..90) + (97..122) | Get-Random -Count 12 |"+
                    "% {[char]$_}) | Out-File -Append -FilePath " + passFilename + " }");
                ps.Invoke();

                StreamReader singleLine = new StreamReader(passFilename);

                foreach (DataGridViewRow selectedRow in userGrid.SelectedRows)
                {
                    wasEncoded = false;
                    //If encoded - decode before changing
                    if (Convert.ToBoolean(selectedRow.Cells[4].Value))
                    {
                        wasEncoded = true;
                        selectedRow.Cells[4].Value = false;
                        selectedRow.Cells[3].Value = FileInterface.StrB64Dec(selectedRow.Cells[3].Value.ToString());
                        selectedRow.Cells[3].ReadOnly = false;
                    }

                    //Replace Password cell content with generated values from file
                    selectedRow.Cells[3].Value = singleLine.ReadLine();


                    //Return encoding state which was selected before updating pass
                    if (wasEncoded)
                    {
                        selectedRow.Cells[4].Value = true;
                        selectedRow.Cells[3].Value = FileInterface.StrB64Enc(selectedRow.Cells[3].Value.ToString());
                        selectedRow.Cells[3].ReadOnly = true;
                    }
                }
                singleLine.Close();
                userGrid.ClearSelection();
                //Remove the ps generated password file
                File.Delete(passFilename);

            }
            else
            {
                MessageBox.Show("No ROWS selected\n Entire ROW must be selected");
            }

            
        }

        private void userGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void userGrid_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (userGrid.IsCurrentCellDirty)
            {
                userGrid.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}