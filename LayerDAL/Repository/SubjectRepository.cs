using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LayerDAL.Setting;
using LayerDAL.Entities;
using Microsoft.Extensions.Options;
using System.Data;
using System.Data.SqlClient;

namespace LayerDAL.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly ConnectionSetting _connection;

        public SubjectRepository(IOptions<ConnectionSetting> connection)
        {
            _connection = connection.Value;
        }

        public async Task<List<Subject>> GetSubjects()
        {
            List<Subject> ListSubject = new List<Subject>();

            using (var connect = new SqlConnection(_connection.SQLString))
            {
                connect.Open();
                SqlCommand cmd = new SqlCommand("Sp_GetSubject", connect);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        ListSubject.Add(new Subject()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            subject_code = reader["subject_code"].ToString(),
                            subject_name = reader["subject_name"].ToString(),
                            credit = Convert.ToInt32(reader["credit"])
                        });
                    }
                }

            }

            return ListSubject;
        }
    }
}
