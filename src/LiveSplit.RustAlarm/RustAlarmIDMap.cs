using LiveSplit.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmIDMap
    {
        private readonly Dictionary<string, int> _map;
        private readonly string _mapFile;
        private int _maxId;

        internal RustAlarmIDMap(IRun run)
        {
            _map = [];
            _mapFile = MapFile(run);
            if (File.Exists(_mapFile))
            {
                XmlDocument document = new();
                document.Load(_mapFile);
                foreach (XmlNode mapping in document["Mappings"].ChildNodes)
                {
                    string name = mapping.Attributes["name"].Value;
                    int id = int.Parse(mapping.Attributes["id"].Value);
                    _map[name] = id;
                    _maxId = Math.Max(id, _maxId);
                }
            }
            else
            {
                foreach (ISegment segment in run)
                {
                    _map[segment.Name] = ++_maxId;
                }
                SaveToFile();
            }
        }

        internal int GetID(ISegment segment)
        {
            if (!_map.TryGetValue(segment.Name, out int id))
            {
                id = ++_maxId;
                _map[segment.Name] = id;
                SaveToFile();
            }
            return id;
        }

        internal void Remap(string oldName, string newName)
        {
            _map[newName] = _map[oldName];
            _map.Remove(oldName);
            SaveToFile();
        }

        private string MapFile(IRun run)
        {
            return Path.ChangeExtension(run.FilePath, ".ids");
        }
        
        private void SaveToFile()
        {
            XmlDocument document = new();
            XmlNode declaration = document.CreateXmlDeclaration("1.0", "UTF-8", null);
            document.AppendChild(declaration);

            XmlNode parent = document.CreateElement("Mappings");
            foreach (KeyValuePair<string, int> mapping in _map)
            {
                XmlNode node = document.CreateElement("Mapping");
                
                XmlAttribute name = document.CreateAttribute("name");
                name.Value = mapping.Key;
                node.Attributes.Append(name);

                XmlAttribute id = document.CreateAttribute("id");
                id.Value = mapping.Value.ToString();
                node.Attributes.Append(id);

                parent.AppendChild(node);
            }
            
            document.AppendChild(parent);
            document.Save(_mapFile);
        }
    }
}
