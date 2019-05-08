using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;

namespace Food.Models
{
  public class Cuisine
  {
    private string _name;
    private int _id;

    public Cuisine()
    {

    }

    public int GetId()
    {
      return _id;
    }

    public void SetId(int id)
    {
      _id = id;
    }

    public string GetName()
    {
      return _name;
    }

    public void SetName(string name)
    {
      _name = name;
    }

    public static string GetCuisine(int check)
    {
      string retString = "";
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisine where id = "+check+";";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      rdr.Read();
      if(rdr.IsDBNull(0) == false)
      {
        retString = rdr.GetString(0);
      }

      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return retString;
    }

    public static List<Cuisine> GetAll()
    {
      List<Cuisine> allItems = new List<Cuisine> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM cuisine;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while(rdr.Read())
      {
        Cuisine newItem = new Cuisine();
        newItem.SetName(rdr.GetString(0));
        newItem.SetId(rdr.GetInt32(1));
        allItems.Add(newItem);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allItems;
    }

    public static List<Res> GetSome(string cuisine)
    {
      
      int num = int.Parse(cuisine);
      List<Res> allItems = new List<Res> {};
      MySqlConnection conn = DB.Connection();
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = @"SELECT * FROM `restaurant` WHERE `primarycuisine` = "+num+" or `secondarycuisine` = "+num+";";
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
