using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using System.Linq;

namespace Repositories;
public class ContactRepository : IContactInterface
{
    private readonly NpgsqlConnection _conn;
    public ContactRepository(NpgsqlConnection connection)
    {
        _conn = connection;
    }
    public async Task<int> Add(t_Contact data)
    {
        try {
            NpgsqlCommand cm = new NpgsqlCommand(@"INSERT INTO t_contact
(c_userid,c_contactname,c_email,c_mobile, c_address,c_image,c_status,c_group) VALUES 
(@c_userid,@c_contactname,@c_email,@c_mobile,@c_address,@c_image,@c_status,@c_group)", _conn);
            cm.Parameters.AddWithValue("@c_userid", data.c_UserId);
            cm.Parameters.AddWithValue("@c_contactname", data.c_ContactName);
            cm.Parameters.AddWithValue("@c_email", data.c_Email);
            cm.Parameters.AddWithValue("@c_mobile", data.c_Mobile ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_address", data.c_Address ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_image", string.IsNullOrEmpty(data.c_Image) ? DBNull.Value : data.c_Image);
            cm.Parameters.AddWithValue("@c_status", data.c_Status ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_group", data.c_Group ?? (object)DBNull.Value);
            
            await _conn.CloseAsync();
            await _conn.OpenAsync();
            await cm.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
    public async Task<int> Delete(string contactid)
    {
        try
        {
            NpgsqlCommand cm = new NpgsqlCommand(@"DELETE FROM t_contact WHERE c_contactid=@c_contactid", _conn);
            cm.Parameters.AddWithValue("@c_contactid", int.Parse(contactid));
            await _conn.CloseAsync();
            await _conn.OpenAsync();
            await cm.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
           
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
    public async Task<List<t_Contact>> GetAll()
    {
        DataTable dt = new DataTable();
        NpgsqlCommand cm = new NpgsqlCommand("select * from t_contact", _conn);
        await _conn.CloseAsync();
        await _conn.OpenAsync();
        NpgsqlDataReader datar = await cm.ExecuteReaderAsync();
        if (datar.HasRows)
        {
            dt.Load(datar);
        }
        List<t_Contact> contactList = new List<t_Contact>();
   
        contactList = (from DataRow dr in dt.Rows
                       select new t_Contact()
                       {
                           c_ContactId = Convert.ToInt32(dr["c_contactid"]),
                           c_UserId = int.Parse(dr["c_userid"].ToString()),
                           c_ContactName = dr["c_contactname"].ToString(),
                           c_Email = dr["c_email"].ToString(),
                           c_Mobile = dr["c_mobile"].ToString(),
                           c_Address = dr["c_address"].ToString(),
                           c_Image = dr["c_image"].ToString(), 
                           c_Group = dr["c_group"].ToString(),
                           c_Status = dr["c_status"].ToString()
                       }).ToList();
        await _conn.CloseAsync();
        return contactList;
    }
    
    public async Task<List<t_Contact>> GetAllByUser(string userid)
    {
        DataTable dt = new DataTable();
        NpgsqlCommand cm = new NpgsqlCommand("select * from t_contact", _conn);
        await _conn.CloseAsync();
        await _conn.OpenAsync();
        NpgsqlDataReader datar = await cm.ExecuteReaderAsync();
        if (datar.HasRows)
        {
            dt.Load(datar);
        }
        List<t_Contact> contactList = new List<t_Contact>();
        contactList = (from DataRow dr in dt.Rows
                       where dr["c_userid"].ToString() == userid
                       select new t_Contact()
                       {
                           c_ContactId = Convert.ToInt32(dr["c_contactid"]),
                           c_UserId = int.Parse(dr["c_userid"].ToString()),
                           c_ContactName = dr["c_contactname"].ToString(),
                           c_Email = dr["c_email"].ToString(),
                           c_Mobile = dr["c_mobile"].ToString(),
                           c_Address = dr["c_address"].ToString(),
                           c_Image = dr["c_image"].ToString(),
                           c_Group = dr["c_group"].ToString(),
                           c_Status = dr["c_status"].ToString()
                       }).ToList();
        await _conn.CloseAsync();
        return contactList;
    }
    public async Task<t_Contact> GetOne(string contactid)
    {
        DataTable dt = new DataTable();
        NpgsqlCommand cm = new NpgsqlCommand("select * from t_contact WHERE c_contactid=@c_contactid", _conn);
        cm.Parameters.AddWithValue("@c_contactid", int.Parse(contactid));
        await _conn.CloseAsync();
        await _conn.OpenAsync();
        NpgsqlDataReader datar = await cm.ExecuteReaderAsync();
        
        t_Contact contact = null;
        if (datar.Read())
        {
            contact = new t_Contact()
            {
                c_ContactId = Convert.ToInt32(datar["c_contactid"]),
                c_UserId = int.Parse(datar["c_userid"].ToString()),
                c_ContactName = datar["c_contactname"].ToString(),
                c_Email = datar["c_email"].ToString(),
                c_Mobile = datar["c_mobile"].ToString(),
                c_Address = datar["c_address"].ToString(),
                c_Image = datar["c_image"].ToString(),
                c_Group = datar["c_group"].ToString(),
                c_Status = datar["c_status"].ToString()
            };
        }
        await _conn.CloseAsync();
        return contact;
    }
   
    public async Task<int> Update(t_Contact data)
    {
        try
        {
            NpgsqlCommand cm = new NpgsqlCommand(@"UPDATE t_contact set
                                                   c_userid=@c_userid,
                                                   c_contactname=@c_contactname,
                                                   c_email=@c_email,
                                                   c_mobile=@c_mobile,
                                                   c_address=@c_address,
                                                   c_image=@c_image,
                                                   c_status=@c_status,
                                                   c_group=@c_group 
                                                   WHERE c_contactid=@c_contactid", _conn);
            cm.Parameters.AddWithValue("@c_userid", data.c_UserId);
            cm.Parameters.AddWithValue("@c_contactname", data.c_ContactName);
            cm.Parameters.AddWithValue("@c_email", data.c_Email);
            cm.Parameters.AddWithValue("@c_mobile", data.c_Mobile ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_address", data.c_Address ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_image", string.IsNullOrEmpty(data.c_Image) ? DBNull.Value : data.c_Image);
            cm.Parameters.AddWithValue("@c_status", data.c_Status ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_group", data.c_Group ?? (object)DBNull.Value);
            cm.Parameters.AddWithValue("@c_contactid", data.c_ContactId);
            
            await _conn.CloseAsync();
            await _conn.OpenAsync();
            await cm.ExecuteNonQueryAsync();
            await _conn.CloseAsync();
            return 1;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return 0;
        }
    }
}
