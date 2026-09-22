using System;
using System.Threading.Tasks;
using Npgsql;

namespace Repositories
{
    public static class DatabaseInitializer
    {
        public static async Task InitializeAsync(string connectionString)
        {
            try
            {
                using var conn = new NpgsqlConnection(connectionString);
                await conn.OpenAsync();

                var tUserSql = @"
                CREATE TABLE IF NOT EXISTS public.t_user
                (
                    c_userid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
                    c_username character varying(100) COLLATE pg_catalog.""default"" NOT NULL,
                    c_email character varying(100) COLLATE pg_catalog.""default"" NOT NULL,
                    c_password character varying(100) COLLATE pg_catalog.""default"" NOT NULL,
                    c_address character varying(500) COLLATE pg_catalog.""default"",
                    c_mobile character varying(50) COLLATE pg_catalog.""default"",
                    c_gender character varying(10) COLLATE pg_catalog.""default"",
                    c_image character varying(4000) COLLATE pg_catalog.""default"",
                    CONSTRAINT t_user_pkey PRIMARY KEY (c_userid)
                );";

                var tContactSql = @"
                CREATE TABLE IF NOT EXISTS public.t_contact
                (
                    c_contactid integer NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 2147483647 CACHE 1 ),
                    c_userid integer NOT NULL,
                    c_contactname character varying(100) NOT NULL,
                    c_email character varying(100) NOT NULL,
                    c_address character varying(500),
                    c_mobile character varying(50),
                    c_group character varying(50),
                    c_image character varying(4000),
                    c_status character varying(20),
                    CONSTRAINT t_contact_pkey PRIMARY KEY (c_contactid)
                );";

                using var cmdUser = new NpgsqlCommand(tUserSql, conn);
                await cmdUser.ExecuteNonQueryAsync();

                using var cmdContact = new NpgsqlCommand(tContactSql, conn);
                await cmdContact.ExecuteNonQueryAsync();
                
                await conn.CloseAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Database Initialization Error: " + ex.Message);
            }
        }
    }
}
