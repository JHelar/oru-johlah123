using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using System.IO;

namespace Pacman
{
    /// <summary>
    /// A filemanager class that helps reading and writing elements to/from a file to the program.
    /// Uses both normal text files and XML files
    /// </summary>
    public class FileManager
    {
        #region Variables
        enum LoadType { Attributes, Contents };

        LoadType type;

        List<string> tempAttributes, tempContents;

        bool identifierFound = false;
        #endregion
        #region Public methods
        /// <summary>
        /// Reads everything from a specified text file, the file has to be formatted for the specific function or it will not be read properly.
        /// Puts in the read data onto the two, two dimensional Lists.
        /// Attributes is the identifyer telling what type of data that is being loaded in.
        /// Contents is the actual data.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributes"></param>
        /// <param name="contents"></param>
        public void LoadContent(string filename, List<List<string>> attributes, List<List<string>> contents)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains("Load="))
                    {
                        tempAttributes = new List<string>();
                        line = line.Remove(0, line.IndexOf("=") + 1);
                        type = LoadType.Attributes;
                    }
                    else
                    {    
                        type = LoadType.Contents;
                    }

                    tempContents = new List<string>();

                    string[] lineArray = line.Split(']');
                    foreach (string li in lineArray)
                    {
                        string newLine = li.Trim('[', ' ', ']');
                        if (newLine != String.Empty)
                        {
                            if (type == LoadType.Contents)
                                tempContents.Add(newLine);
                            else
                                tempAttributes.Add(newLine);
                        }
                    }

                    if (type == LoadType.Contents && tempContents.Count > 0)
                    {
                        contents.Add(tempContents);
                        attributes.Add(tempAttributes);
                    }
                }
            }
        }
        /// <summary>
        /// An overloaded version of the LoadContent that starts to read when the identifier requirments are met and stops reading when told to.
        /// Other then that it does the same as the first LoadContent.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="attributes"></param>
        /// <param name="contents"></param>
        /// <param name="identifier"></param>
        public void LoadContent(string filename, List<List<string>> attributes, List<List<string>> contents, string identifier)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (line.Contains("EndLoad=") && line.Contains(identifier))
                    {
                        identifierFound = false;
                        break;
                    }
                    else if (line.Contains("Load=") && line.Contains(identifier))
                    {
                        identifierFound = true;
                        continue;
                    }

                    if (identifierFound)
                    {
                        if (line.Contains("Load="))
                        {
                            tempAttributes = new List<string>();
                            line = line.Remove(0, line.IndexOf("=") + 1);
                            type = LoadType.Attributes;
                        }
                        else
                        {
                            tempContents = new List<string>();
                            type = LoadType.Contents;
                        }

                        string[] lineArray = line.Split(']');
                        foreach (string li in lineArray)
                        {
                            string newLine = li.Trim('[', ' ', ']');
                            if (newLine != String.Empty)
                            {
                                if (type == LoadType.Contents)
                                    tempContents.Add(newLine);
                                else
                                    tempAttributes.Add(newLine);
                            }
                        }

                        if (type == LoadType.Contents && tempContents.Count > 0)
                        {
                            contents.Add(tempContents);
                            attributes.Add(tempAttributes);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Reads the score from a XML file, puts the name and score in their respective list.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="score"></param>
        /// <param name="playerName"></param>
        public void ReadScore(string fileName, List<int> score, List<string> playerName) 
        {
            XmlReader fileCheck = XmlReader.Create("PacScore.xml"); // gör en try catch om filen finns eller ej
            CreateXMLScore();
            fileName = "PacScore.xml";
            using (XmlReader reader = XmlReader.Create(fileName)) 
            {
                while (reader.Read()) 
                {
                    if (reader.IsStartElement()) 
                    {
                        switch (reader.Name) 
                        {
                            case "PacScore":
                                break;
                            case "Player":
                                if (reader.Read())
                                    playerName.Add(reader.Value.Trim());
                                break;
                            case "Score":
                                if (reader.Read())
                                    score.Add(Convert.ToInt32(reader.Value.Trim()));
                                break;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Appends the score and name to a XML file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="playerScore"></param>
        /// <param name="playerName"></param>
        public void WriteScore(string fileName,int playerScore, string playerName) 
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileName);
            XmlNode PacScore = doc.CreateElement("PacScore");
            XmlNode Player = doc.CreateElement("Player");
            XmlNode Score = doc.CreateElement("Score");
            Player.InnerText = playerName;
            Score.InnerText = playerScore.ToString();
            PacScore.AppendChild(Player);
            PacScore.AppendChild(Score);
            doc.DocumentElement.AppendChild(PacScore);
            doc.Save(fileName);
        }
        #endregion
        /// <summary>
        /// Skapar ett xml document med en dummy i sig.
        /// </summary>
        private void CreateXMLScore() 
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create("PacScore.xml", settings);
            writer.WriteStartElement("PacScore");
            writer.WriteStartElement("PacScore");
            writer.WriteStartElement("Player");
            writer.WriteString("Dummy");
            writer.WriteEndElement();
            writer.WriteStartElement("Score");
            writer.WriteString("0");
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.WriteEndElement();
            writer.Close();
        }
    }
}
