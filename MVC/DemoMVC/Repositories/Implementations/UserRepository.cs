using Npgsql;

namespace Repositories;

public class UserRepository : IUserInterface
{
    private readonly NpgsqlConnection _connection;

    public UserRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

public async Task<int> Register(t_User user)
{
    try
    {
        await _connection.OpenAsync();

        // Check whether email already exists
        string checkQuery = @"
            SELECT COUNT(*)
            FROM t_user
            WHERE c_email = @c_email
        ";

        using (NpgsqlCommand checkCommand =
               new NpgsqlCommand(checkQuery, _connection))
        {
            checkCommand.Parameters.AddWithValue(
                "@c_email",
                user.c_email
            );

            int count = Convert.ToInt32(
                await checkCommand.ExecuteScalarAsync()
            );

            if (count > 0)
            {
                return 0;
            }
        }

        // Insert new user
        string insertQuery = @"
            INSERT INTO t_user
            (
                c_username,
                c_email,
                c_password,
                c_address,
                c_mobile,
                c_gender,
                c_image
            )
            VALUES
            (
                @c_username,
                @c_email,
                @c_password,
                @c_address,
                @c_mobile,
                @c_gender,
                @c_image
            )
        ";

        using (NpgsqlCommand command =
               new NpgsqlCommand(insertQuery, _connection))
        {
            command.Parameters.AddWithValue(
                "@c_username",
                user.c_username
            );

            command.Parameters.AddWithValue(
                "@c_email",
                user.c_email
            );

            command.Parameters.AddWithValue(
                "@c_password",
                user.c_password
            );

            command.Parameters.AddWithValue(
                "@c_address",
                (object?)user.c_address ?? DBNull.Value
            );

            command.Parameters.AddWithValue(
                "@c_mobile",
                (object?)user.c_mobile ?? DBNull.Value
            );

            command.Parameters.AddWithValue(
                "@c_gender",
                (object?)user.c_gender ?? DBNull.Value
            );

            command.Parameters.AddWithValue(
                "@c_image",
                (object?)user.c_image ?? DBNull.Value
            );

            await command.ExecuteNonQueryAsync();
        }

        return 1;
    }
    catch (Exception ex)
    {
        Console.WriteLine("REGISTER ERROR: " + ex.Message);
        return -1;
    }
    finally
    {
        await _connection.CloseAsync();
    }
}
    public async Task<t_User> Login(vm_Login user)
    {
        try
        {
            await _connection.OpenAsync();

            string query = @"
            SELECT c_userid,
                   c_username,
                   c_email,
                   c_password,
                   c_address,
                   c_mobile,
                   c_gender,
                   c_image
            FROM t_user
            WHERE c_email = @c_email
            AND c_password = @c_password
        ";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@c_email", user.c_email);
                command.Parameters.AddWithValue("@c_password", user.c_password);

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        t_User loggedInUser = new t_User
                        {
                            c_userid = reader.GetInt32(0),
                            c_username = reader.GetString(1),
                            c_email = reader.GetString(2),
                            c_password = reader.GetString(3),
                            c_address = reader.IsDBNull(4) ? null : reader.GetString(4),
                            c_mobile = reader.IsDBNull(5) ? null : reader.GetString(5),
                            c_gender = reader.IsDBNull(6) ? null : reader.GetString(6),
                            c_image = reader.IsDBNull(7) ? null : reader.GetString(7)
                        };

                        return loggedInUser;
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

    public async Task<t_User> GetUser(int userid)
    {
        try
        {
            await _connection.OpenAsync();

            string query = @"
            SELECT c_userid,
                   c_username,
                   c_email,
                   c_password,
                   c_address,
                   c_mobile,
                   c_gender,
                   c_image
            FROM t_user
            WHERE c_userid = @c_userid
        ";

            using (NpgsqlCommand command = new NpgsqlCommand(query, _connection))
            {
                command.Parameters.AddWithValue("@c_userid", userid);

                using (NpgsqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        t_User user = new t_User
                        {
                            c_userid = reader.GetInt32(0),
                            c_username = reader.GetString(1),
                            c_email = reader.GetString(2),
                            c_password = reader.GetString(3),
                            c_address = reader.IsDBNull(4) ? null : reader.GetString(4),
                            c_mobile = reader.IsDBNull(5) ? null : reader.GetString(5),
                            c_gender = reader.IsDBNull(6) ? null : reader.GetString(6),
                            c_image = reader.IsDBNull(7) ? null : reader.GetString(7)
                        };

                        return user;
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


}
