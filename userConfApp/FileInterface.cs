using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace userConfApp
{
    class FileInterface
    {
        public struct userAccount
        {
            public string id;
            public bool enabled;
            public string name;
            public string password;
            public bool encPass;
        }

        public userAccount[] readXml(string xmlConfFile)
        {
            int accCount = 0;
            bool debugOut = false;
            


            XmlDocument xmlConf = new XmlDocument();
            
            //Load for filename
            //LoadXml will be needed for encoded file to load already decoded string
            xmlConf.LoadXml(xmlConfFile);
            XmlNodeList xmlVersionNodes = xmlConf.GetElementsByTagName("version");
            //Ooooh danger
            XmlNode xmlVersionNode = xmlVersionNodes[0];
            mainWindow.version = xmlVersionNode.InnerText;
            XmlNodeList xmlConfContent = xmlConf.GetElementsByTagName("acc");

            //acc count
            accCount = xmlConfContent.Count;

            userAccount[] usersList = new userAccount[accCount];

            int i = 0;

            foreach(XmlElement confAcc in xmlConfContent)
            {
                usersList[i].id = confAcc.GetAttribute("id");
                if (confAcc.GetAttribute("enabled") == "1")
                {
                    usersList[i].enabled = true;
                }else
                {
                    usersList[i].enabled = false;
                }
                usersList[i].name = confAcc.SelectSingleNode("user_name").InnerText;
                usersList[i].password = confAcc.SelectSingleNode("password").InnerText;

                if ((confAcc.SelectSingleNode("password") as XmlElement).GetAttribute("type") == "encoded")
                {
                    usersList[i].encPass = true;
                }
                else
                {
                    usersList[i].encPass = false;
                }

                
                i++;


            }
            
            return usersList;
        }

        public string writeXml(userAccount[] userAccounts, string xmlFileDecoded)
        {
            XmlDocument xmlConf = new XmlDocument();

           
            xmlConf.LoadXml(xmlFileDecoded);

            //XmlNode nodeSelect = xmlConf.SelectSingleNode("person");
            XmlNodeList xmlPersonNodes = xmlConf.GetElementsByTagName("person");
            XmlNode xmlPersonNode = xmlPersonNodes[0];
            xmlPersonNode.RemoveAll();

            for(int i = 0; i < userAccounts.Length; i++)
            {
                XmlNode newAccNode = xmlConf.CreateNode("element", "acc", "");

                XmlAttribute idAttr = xmlConf.CreateAttribute("id");
                idAttr.Value = userAccounts[i].id;

                XmlAttribute enabledAttr = xmlConf.CreateAttribute("enabled");
                if (userAccounts[i].enabled)
                {
                    enabledAttr.Value = "1";
                } else
                {
                    enabledAttr.Value = "0";
                }



                newAccNode.Attributes.Append(idAttr);
                newAccNode.Attributes.Append(enabledAttr);

                XmlNode newNameNode = xmlConf.CreateNode("element", "user_name", "");
                newNameNode.InnerText = userAccounts[i].name;

                XmlNode newPassNode = xmlConf.CreateNode("element", "password", "");
                newPassNode.InnerText = userAccounts[i].password;

                XmlAttribute encodedAttr = xmlConf.CreateAttribute("type");
                if (userAccounts[i].encPass)
                {
                    encodedAttr.Value = "encoded";
                }else
                {
                    encodedAttr.Value = "plaintext";
                }
                newPassNode.Attributes.Append(encodedAttr);
                newAccNode.AppendChild(newNameNode);
                newAccNode.AppendChild(newPassNode);

                xmlPersonNode.AppendChild(newAccNode);
            }

            //xmlConf.Save(xmlConfFile);
            return xmlConf.InnerXml;

        }

        
    }
}
