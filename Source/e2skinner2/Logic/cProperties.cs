using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using System.Data;


namespace OpenSkinDesigner.Logic
{
    static class cProperties
    {
        static private Hashtable pDefaultTable = new Hashtable();
        static private Hashtable pTable = new Hashtable();
        static public DataSet pDataSet;

        static private DataTable createTable(System.Type type) {
            DataTable dt = new DataTable(type.ToString());

            DataColumn dcName = new DataColumn();
            dcName.ColumnName = "Name";
            dcName.Caption = "Name";
            dcName.DataType = typeof(String);
            dcName.DefaultValue = "";

            dt.Columns.Add(dcName);

            DataColumn dcValue = new DataColumn();
            dcValue.ColumnName = "Value";
            dcValue.Caption = "Value";
            dcValue.DataType = type;

            dt.Columns.Add(dcValue);

            DataRow dr;

            foreach (DictionaryEntry key in pDefaultTable)
            {
                if (key.Value.GetType() == type)
                {
                    dr = dt.NewRow();
                    dr[0] = key.Key.ToString();
                    dr[1] = key.Value;
                    dt.Rows.Add(dr);
                }
            }
            return dt;
        }

        static public void init()
        {
            pDefaultTable.Add("fading", (bool)true);
            pDefaultTable.Add("label_test", (bool)true);
            pDefaultTable.Add("skinned", (bool)true);
            pDefaultTable.Add("skinned_screen", (bool)true);
            pDefaultTable.Add("skinned_label", (bool)true);
            pDefaultTable.Add("skinned_pixmap", (bool)true);
            pDefaultTable.Add("skinned_widget", (bool)true);

            pDefaultTable.Add("skinned_conditional_default", (bool)false);
            pDefaultTable.Add("skinned_conditional_all", (bool)true);
            pDefaultTable.Add("skinned_conditional_random", (bool)false);
            pDefaultTable.Add("skinned_conditional_none", (bool)false);


            
            pDefaultTable.Add("path_skin_xml", (string)"C:\\skin.xml");
            pDefaultTable.Add("path_skin", (string)"C:\\");
            pDefaultTable.Add("path", (string)"C:\\");
            pDefaultTable.Add("enable_alpha", (bool)true);
            pDefaultTable.Add("enable_backdrop", (bool)true);
            pDefaultTable.Add("path_fonts", (string)"E:\\Visual Studio 2008\\OpenSkinDesigner\\fonts");
            pDefaultTable.Add("path_skins", (string)"./skins/");

            pDataSet = new DataSet();
            pDataSet.Tables.Add(createTable(typeof(bool)));
            pDataSet.Tables.Add(createTable(typeof(string)));
            //pDataSet.Tables.Add(createTable(typeof(int)));

            
        }

        static public void saveFile()
        {
        }



        static public void setProperty(String name, String value)
        {
            if (pTable[name] == null)
                pTable.Add(name, value);
            else
                pTable[name] = value;
        }

        static public void setProperty(String name, bool value)
        {
            if (pTable[name] == null)
                pTable.Add(name, value.ToString());
            else
                pTable[name] = value.ToString();
        }


        static public String getProperty(String name)
        {
            String value = "";
            if (pTable[name] == null)
            {
                if (pDefaultTable[name] != null)
                {
                    value = pDefaultTable[name].ToString();
                }
                else
                    value = "0";
                setProperty(name, value);
            }
            else
            {
                value = pTable[name].ToString();
            }
            return value;
        }

        static public bool getPropertyBool(String name)
        {
            String value = "";
            if (pTable[name] == null)
            {
                if (pDefaultTable[name] != null)
                {
                    value = pDefaultTable[name].ToString();
                } else
                    value = true.ToString();
                setProperty(name, value);
            }
            else
            {
                value = pTable[name].ToString();
            }
            return Convert.ToBoolean(value);
        }

        static public Hashtable getProperties()
        {
            return pTable;
        }

        static public DataSet getPropertiesTable()
        {
            return pDataSet;
        }


    }
}
