using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Food.Models
{
  public class Res
  {
    private string _name;
    private int _id;
    private string _description;
    private int _primaryKey;
    private int _secondaryKey;

    public Res()
    {
      _secondaryKey = 0;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetDescription()
    {
      return _description;
    }

    public void SetDescription(string description)
    {
      _description = description;
    }

    public string GetPrimaryKey()
    {
      return Cuisine.GetCuisine(_primaryKey);
    }

    public void SetPrimaryKey(int primaryKey)
    {
      _primaryKey = primaryKey;
    }

    public string GetSecondaryKey()
    {
      if(_secondaryKey > 0)
      {
        return Cuisine.GetCuisine(_secondaryKey);
      }
      return "0";
    }

    public void SetSecondaryKey(int secondaryKey)
    {
      _secondaryKey = secondaryKey;
    }

    public void Save()
    {
      string checkNull = "NULL";
      if (_secondaryKey > 0)
      {
        checkNull = "'"+_secondaryKey+"'";
      }
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"INSERT INTO `restaurant` (`name`, `description`, `primarycuisine`, `secondarycuisine`) VALUES ('"+_name+"', '"+_description+"', '"+_primaryKey+"', "+checkNull+");";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    // public Cuisine GetCuisine(string check)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"SELECT * FROM cuisine where name = '"+check+"';";
    //   MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
    //   rdr.Read();
    //   Cuisine newItem = new Cuisine();
    //   newItem.SetName(rdr.GetString(0));
    //   newItem.SetId(rdr.GetId(1));
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    //   return newItem;
    // }

    public static List<Res> GetAll()
    {
      List<Res> allItems = new List<Res> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM restaurant;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Res newItem = new Res();
        newItem.SetName(rdr.GetString(1));
        newItem.SetId(rdr.GetInt32(0));
        newItem.SetDescription(rdr.GetString(2));
        newItem.SetPrimaryKey(rdr.GetInt32(3));
        if(rdr.IsDBNull(4) == false)
        {
          newItem.SetSecondaryKey(rdr.GetInt32(4));
        }
          allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    // public static void AddToDB(Cuisine toAdd)
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = @"INSERT INTO `animals` (`type`, `name`, `date_of_admittance`, `breed`, `sex`) VALUES ('"+toAdd.GetType()+"', '"+toAdd.GetName()+"', CURRENT_TIMESTAMP, '"+toAdd.GetBreed()+"', '"+toAdd.GetSex()+"');";
    //   cmd.ExecuteNonQuery();
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }
  }
}
