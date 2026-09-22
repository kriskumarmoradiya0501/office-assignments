using Npgsql;

namespace Repositories
{
    public class ContactRepository : IContactInterface
    {
        private readonly NpgsqlConnection _connection;

        public ContactRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<t_Contact>> GetAll()
        {
            List<t_Contact> contacts = new List<t_Contact>();

            try
            {
                await _connection.OpenAsync();

                string query = @"
            SELECT c_contactid,
                   c_userid,
                   c_name,
                   c_email,
                   c_group,
                   c_address,
                   c_mobile,
                   c_image,
                   c_status
            FROM t_contact
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            t_Contact contact = new t_Contact
                            {
                                c_contactid = reader.GetInt32(0),
                                c_userid = reader.GetInt32(1),
                                c_name = reader.GetString(2),
                                c_email = reader.GetString(3),
                                c_group = reader.IsDBNull(4) ? null : reader.GetString(4),
                                c_address = reader.IsDBNull(5) ? null : reader.GetString(5),
                                c_mobile = reader.IsDBNull(6) ? null : reader.GetString(6),
                                c_image = reader.IsDBNull(7) ? null : reader.GetString(7),
                                c_status = reader.GetBoolean(8)
                            };

                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Error handling
            }
            finally
            {
                await _connection.CloseAsync();
            }

            return contacts;
        }

        public async Task<List<t_Contact>> GetAllByUser(int userid)
        {
            List<t_Contact> contacts = new List<t_Contact>();

            try
            {
                await _connection.OpenAsync();

                string query = @"
            SELECT c_contactid,
                   c_userid,
                   c_name,
                   c_email,
                   c_group,
                   c_address,
                   c_mobile,
                   c_image,
                   c_status
            FROM t_contact
            WHERE c_userid = @c_userid
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@c_userid", userid);

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            t_Contact contact = new t_Contact
                            {
                                c_contactid = reader.GetInt32(0),
                                c_userid = reader.GetInt32(1),
                                c_name = reader.GetString(2),
                                c_email = reader.GetString(3),
                                c_group = reader.IsDBNull(4) ? null : reader.GetString(4),
                                c_address = reader.IsDBNull(5) ? null : reader.GetString(5),
                                c_mobile = reader.IsDBNull(6) ? null : reader.GetString(6),
                                c_image = reader.IsDBNull(7) ? null : reader.GetString(7),
                                c_status = reader.GetBoolean(8)
                            };

                            contacts.Add(contact);
                        }
                    }
                }
            }
            catch (Exception)
            {
                // Error handling
            }
            finally
            {
                await _connection.CloseAsync();
            }

            return contacts;
        }


        public async Task<t_Contact> GetOne(int contactid)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"
            SELECT c_contactid,
                   c_userid,
                   c_name,
                   c_email,
                   c_group,
                   c_address,
                   c_mobile,
                   c_image,
                   c_status
            FROM t_contact
            WHERE c_contactid = @c_contactid
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@c_contactid", contactid);

                    using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            t_Contact contact = new t_Contact
                            {
                                c_contactid = reader.GetInt32(0),
                                c_userid = reader.GetInt32(1),
                                c_name = reader.GetString(2),
                                c_email = reader.GetString(3),
                                c_group = reader.IsDBNull(4) ? null : reader.GetString(4),
                                c_address = reader.IsDBNull(5) ? null : reader.GetString(5),
                                c_mobile = reader.IsDBNull(6) ? null : reader.GetString(6),
                                c_image = reader.IsDBNull(7) ? null : reader.GetString(7),
                                c_status = reader.GetBoolean(8)
                            };

                            return contact;
                        }
                    }
                }

                return null;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> Add(t_Contact contact)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"
            INSERT INTO t_contact
            (
                c_userid,
                c_name,
                c_email,
                c_group,
                c_address,
                c_mobile,
                c_image,
                c_status
            )
            VALUES
            (
                @c_userid,
                @c_name,
                @c_email,
                @c_group,
                @c_address,
                @c_mobile,
                @c_image,
                @c_status
            )
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@c_userid", contact.c_userid);
                    command.Parameters.AddWithValue("@c_name", contact.c_name);
                    command.Parameters.AddWithValue("@c_email", contact.c_email);
                    command.Parameters.AddWithValue("@c_group", (object?)contact.c_group ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_address", (object?)contact.c_address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_mobile", (object?)contact.c_mobile ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_image", (object?)contact.c_image ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_status", contact.c_status);

                    await command.ExecuteNonQueryAsync();
                }

                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> Update(t_Contact contact)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"
            UPDATE t_contact
            SET
                c_name = @c_name,
                c_email = @c_email,
                c_group = @c_group,
                c_address = @c_address,
                c_mobile = @c_mobile,
                c_image = @c_image,
                c_status = @c_status
            WHERE c_contactid = @c_contactid
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@c_contactid", contact.c_contactid);
                    command.Parameters.AddWithValue("@c_name", contact.c_name);
                    command.Parameters.AddWithValue("@c_email", contact.c_email);
                    command.Parameters.AddWithValue("@c_group", (object?)contact.c_group ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_address", (object?)contact.c_address ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_mobile", (object?)contact.c_mobile ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_image", (object?)contact.c_image ?? DBNull.Value);
                    command.Parameters.AddWithValue("@c_status", contact.c_status);

                    await command.ExecuteNonQueryAsync();
                }

                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        public async Task<int> Delete(int contactid)
        {
            try
            {
                await _connection.OpenAsync();

                string query = @"
            DELETE FROM t_contact
            WHERE c_contactid = @c_contactid
        ";

                using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@c_contactid", contactid);

                    await command.ExecuteNonQueryAsync();
                }

                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
            finally
            {
                await _connection.CloseAsync();
            }
        }

        
        // Methods will come here
    }
}