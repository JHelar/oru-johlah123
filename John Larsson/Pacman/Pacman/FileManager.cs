using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

using System.IO;

namespace Pacman
{
    public class FileManager
    {
        enum LoadType { Attributes, Contents, Name, Score };

        LoadType type;

        List<string> tempAttributes, tempContents;

        bool identifierFound = false;

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

        public void ReadScore(string fileName, List<int> score, List<string> playerName) 
        {
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
    }
}
