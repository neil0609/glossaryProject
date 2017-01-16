using GlossaryProject.Domain;
using GlossaryProject.Models.Requests.AddRequest;
using GlossaryProject.Models.Requests.UpdateRequest;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace GlossaryProject.Services
{
    public class GlossaryService : BaseService
    {

        // Inserts Item to the database
        public static int InsertGlossaryItem(AddGlossaryItem model)
        {

            var id = 0;

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Glossary_Insert"
                , inputParamMapper: delegate (SqlParameterCollection AddglossaryItem)
                {
                    AddglossaryItem.AddWithValue("@Term", model.Term);
                    AddglossaryItem.AddWithValue("@Definition", model.Definition);

                    SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    p.Direction = System.Data.ParameterDirection.Output;

                    AddglossaryItem.Add(p);

                }, returnParameters: delegate (SqlParameterCollection param)
                {
                    int.TryParse(param["@Id"].Value.ToString(), out id);
                });
            return id;
        }

        // Updates item in database by Id
        public static void UpdateglossaryItem(UpdateGlossaryItem model)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Glossary_Update"
                , inputParamMapper: delegate (SqlParameterCollection UpdateGlossaryItem)
                {
                    UpdateGlossaryItem.AddWithValue("@Id", model.Id);
                    UpdateGlossaryItem.AddWithValue("@Term", model.Term);
                    UpdateGlossaryItem.AddWithValue("@Definition", model.Definition);
                });
        }

        // Gets item from db by Id
        public static GlossaryItem GetGlossaryItem(int id)
        {
            GlossaryItem item = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Glossary_SelectById"
                , inputParamMapper: delegate (SqlParameterCollection commentsCollection)
                {
                    commentsCollection.AddWithValue("@Id", id);
                }, map: delegate (IDataReader reader, short set)
                {
                    item = MapGlossary(reader);
                });
            return item;
        }

        // Gets List of Items in db
        public static List<GlossaryItem> GetGlossaryItemList()
        {
            List<GlossaryItem> list = null;

            DataProvider.ExecuteCmd(GetConnection, "dbo.Glossary_SelectAll",
                inputParamMapper: null, map: delegate (IDataReader reader, short set)
                {

                    GlossaryItem item = MapGlossary(reader);

                    if (list == null)
                    {
                        list = new List<GlossaryItem>();
                    }
                    list.Add(item);
                }
            );
            return list;
        }

        // Deletes an Item in DB
        public static void DeleteGlossaryItem(int id)
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.Glossary_DeleteById"
                , inputParamMapper: delegate (SqlParameterCollection commentsCollection)
                {
                    commentsCollection.AddWithValue("@Id", id);
                });
        }

        // Mapping the item. Using DRY methodology.
        public static GlossaryItem MapGlossary(IDataReader reader)
        {
            GlossaryItem item = new GlossaryItem();
            int startingindex = 0;

            item.Id = reader.GetInt32(startingindex++);
            item.Term = reader.GetString(startingindex++);
            item.Definition = reader.GetString(startingindex++);

            return item;
        }

    }
}