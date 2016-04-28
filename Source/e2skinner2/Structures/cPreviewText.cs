using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace OpenSkinDesigner.Structures
{
    static public class cPreviewText
    {
        static Hashtable pTable = null;

        static public void init()
        {
            pTable = new Hashtable();
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load("xml/previewText.xml");
                XmlNodeList screenNodes = xDoc.GetElementsByTagName("screen");

                foreach (XmlNode nodeScreen in screenNodes)
                {
                    Hashtable pSourceTable = new Hashtable();
                    ArrayList sourceName = new ArrayList();

                    XmlNodeList previewNodes = nodeScreen.ChildNodes;
                    foreach (XmlNode nodePreview in previewNodes)
                    {
                        if (nodePreview.Name.Equals("name"))
                            sourceName.Add(nodePreview.InnerText);
                        else if (nodePreview.Name.Equals("entries"))
                        {
                            XmlNodeList entryNodes = nodePreview.ChildNodes;
                            foreach (XmlNode nodeEntry in entryNodes)
                            {
                                if (nodeEntry.NodeType == XmlNodeType.Comment)
                                    continue;
                                String valueName = nodeEntry.Attributes["name"].Value;
                                String valueString = nodeEntry.Attributes["value"].Value;
                                String typeString = nodeEntry.Attributes["type"].Value;
                                Object value = nodeEntry.Attributes["value"] == null ? "" : nodeEntry.Attributes["value"].Value;
                                switch (typeString)
                                {
                                    case "bool":
                                        value = Boolean.Parse(nodeEntry.Attributes["value"].Value);
                                        break;
                                    case "int":
                                        value = Int32.Parse(nodeEntry.Attributes["value"].Value);
                                        break;
                                    case "string":
                                    default:
                                        value = nodeEntry.Attributes["value"].Value;
                                        break;
                                }
                                if (valueName.Length > 0)
                                    pSourceTable.Add(valueName, value);
                            }
                        }
                    }

                    foreach (Object source in sourceName)
                        if (((String)source).Length > 0)
                            pTable.Add(((String)source), pSourceTable);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return;
        }

        static public String getText(String Screen, String Type)
        {
            String text = "";
            if (Screen.Length > 0 && Type.Length > 0)
            {
                if (pTable.ContainsKey(Screen))
                {
                    Hashtable screen = (Hashtable)pTable[Screen];
                    if (screen.ContainsKey(Type))
                    {
                        text = screen[Type].ToString();
                    }
                }
            }
            return text;
        }
    }
}
